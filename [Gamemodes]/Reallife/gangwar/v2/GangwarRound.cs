using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.gangwar.v2
{
    public class GangwarRound
    {
        public enum RoundStates { PREPARING, RUNNING, DECIDED, STOPPED }

        public class PlayerEntry
        {
            public VnXPlayer _player;
            public float _totalDamage;
            public int _totalKills;
            public bool _isInTK;
            public bool _isRespawned;
            public bool _isKilled;
            public bool _isLeft;

            public PlayerEntry(VnXPlayer player)
            {
                _player = player;
                _totalDamage = 0.0f;
                _totalKills = 0;
                _isRespawned = false;
                _isKilled = false;
                _isLeft = false;
            }

            public int GetFaction() => _player.Reallife.Faction;
        }

        public int DefenderId;
        public int AttackerId;
        private GangwarArea GangwarArea;
        public RoundStates CurrentState;
        public List<PlayerEntry> PlayerList;
        private DateTime StartTime;
        private DateTime StopTime;
        private DateTime PreparingCD;
        private DateTime MaxTime;
        private DateTime TKCooldown;
        public int TKCounter;
        public DateTime DefenderMaxTime;
        public GangwarRound(GangwarArea gangwar, int defenderId, int attackerId)
        {
            GangwarArea = gangwar;
            DefenderId = defenderId;
            AttackerId = attackerId;
            CurrentState = RoundStates.PREPARING;
            PlayerList = new List<PlayerEntry>();
            StartTime = DateTime.Now;
            StopTime = StartTime;
            PreparingCD = StartTime.AddMinutes(GangwarManager.GW_PREPARE_TIME);
            MaxTime = PreparingCD.AddMinutes(GangwarManager.GW_RUNNING_TIME);
            DefenderMaxTime = PreparingCD.AddMinutes(GangwarManager.GW_PREPARE_TIME);
            TKCooldown = PreparingCD;
            TKCounter = 0;
            informAttacker();
        }

        public void PlayerUpdateTKTime(DateTime time)
        {
            this.TKCooldown = time;
        }

        public void Inform(VnXPlayer player)
        {
            //player.SendTranslatedChatMessage("[GW-ROUND] " + StartTime + " started; " + StopTime + " stopped; State: " + CurrentState + "; Count: " + PlayerList.Count);
        }

        public void Stop()
        {
            try
            {
                if (this.CurrentState == RoundStates.PREPARING || this.CurrentState == RoundStates.RUNNING)
                {
                    StopTime = DateTime.Now;
                    CurrentState = RoundStates.STOPPED;
                    ResetPlayer();
                }
            }
            catch { }
        }

        public void Decided(int winnerId, int loserId, string state)
        {
            try
            {
                StopTime = DateTime.Now;
                CurrentState = RoundStates.DECIDED;

                GangwarArea.isRunning = false;
                GangwarArea.SetOwner(winnerId);
                GangwarArea.RemoveElements();

                Allround._gangwarManager.currentArea = null;

                ResetPlayer();
                Alt.EmitAllClients("StopCurrentGangwar", this.GangwarArea.Name);

                if (state == "verteidigt!")
                {
                    Chat.ReallifeChat.SendReallifeMessageToAll(RageAPI.GetHexColorcode(100, 150, 0) + "Die " + Faction.GetFactionNameById(winnerId) + " haben erfolgreich ihr Gebiet " + GangwarArea.Name + " gegen die " + Faction.GetFactionNameById(loserId) + " " + state);
                }
                else
                {
                    Chat.ReallifeChat.SendReallifeMessageToAll(RageAPI.GetHexColorcode(100, 150, 0) + "Die " + Faction.GetFactionNameById(winnerId) + " haben erfolgreich das Gebiet der " + Faction.GetFactionNameById(loserId) + " " + state);
                }
            }
            catch { }
        }

        public string GetFactionInfo(int facId)
        {
            try
            {
                int max = 0;
                int alive = 0;
                foreach (var entry in this.PlayerList)
                {
                    if (!entry._isLeft)
                    {
                        if (entry.GetFaction() == facId)
                        {
                            ++max;
                            if (entry._isKilled == false)
                            {
                                ++alive;
                            }

                        }
                    }
                }
                return alive + " / " + max;
            }
            catch { return "999 / 999"; }
        }

        public void ProcessDamage(VnXPlayer source, VnXPlayer Player, float damage)
        {
            try
            {
                var sourceEntry = this.GetPlayerEntry(source);
                var IPlayerEntry = this.GetPlayerEntry(Player);
                if (sourceEntry != null && IPlayerEntry != null)
                {
                    // If source and target has different factions
                    if (IPlayerEntry.GetFaction() != sourceEntry.GetFaction())
                    {
                        sourceEntry._totalDamage += damage;
                    }

                    SyncStats(source, sourceEntry);
                }
            }
            catch { }
        }

        public void ProcessKill(VnXPlayer source, VnXPlayer Player)
        {
            try
            {
                var sourceEntry = this.GetPlayerEntry(source);
                var IPlayerEntry = this.GetPlayerEntry(Player);
                if (sourceEntry != null && IPlayerEntry != null)
                {
                    if (!IPlayerEntry._isLeft || !IPlayerEntry._isKilled)
                    {
                        // If source and target has different factions
                        if (IPlayerEntry.GetFaction() != sourceEntry.GetFaction())
                        {
                            sourceEntry._totalKills += 1;
                        }
                        KillPlayer(IPlayerEntry);

                        // Respawn target
                        IPlayerEntry._isRespawned = true;
                        Factions.Spawn.SpawnPlayerOnSpawnpoint(Player);
                    }
                }
            }
            catch { }
        }

        public void UpdateTime()
        {
            try
            {
                // PPEPARING TIME
                if (this.CurrentState == RoundStates.PREPARING)
                {
                    if (DateTime.Now >= this.PreparingCD)
                    {
                        // Prepare Time is over
                        //RageAPI.SendTranslatedChatMessageToAll("UPDATE");
                        CurrentState = RoundStates.RUNNING;
                        this.GangwarArea.FreezeElements(GangwarManager.FreezeIVehicles);
                        informDefender();
                        SyncTime();
                        foreach (VnXPlayer _c in VenoXV.Globals.Main.ReallifePlayers.ToList())
                        {
                            Alt.Server.TriggerClientEvent(_c, "gw:aa", this.GangwarArea.Position.X, this.GangwarArea.Position.Y, this.GangwarArea.Position.Z, this.GangwarArea.Radius, this.GangwarArea.Rotation, GangwarManager.ATT_BLIP_Rgba);
                        }
                    }
                }

                // RUNNING TIME
                if (this.CurrentState == RoundStates.RUNNING)
                {
                    // If the first 5sec expires
                    if (DateTime.Now >= this.TKCooldown)
                    {
                        // Check if player's position is close to the TK pos
                        bool inTK = false;
                        foreach (var entry in PlayerList)
                        {
                            if (entry.GetFaction() == AttackerId)
                            {
                                if (GangwarArea.TK.Distance(entry._player.Position) <= GangwarManager.TKRange)
                                {
                                    inTK = true;
                                    if (TKCounter > 0)
                                    {
                                        TKCounter = 0;
                                        Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 255, 0) + entry._player.Username + " hat den TK beesetzt!", AttackerId);
                                    }
                                    break;
                                }
                            }
                        }
                        if (!inTK)
                        {
                            ++TKCounter;
                            if (TKCounter == 1)
                            {
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Besetzt sofort den TK, ansonsten verliert ihr nach 15 Sekunden!", AttackerId);
                                PlayerUpdateTKTime(DateTime.Now.AddSeconds(5));
                            }
                            if (TKCounter == 2)
                            {
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Ihr habt noch 10 Sekunden!", AttackerId);
                                PlayerUpdateTKTime(DateTime.Now.AddSeconds(5));
                            }
                            if (TKCounter == 3)
                            {
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Ihr habt noch 5 Sekunden!", AttackerId);
                                PlayerUpdateTKTime(DateTime.Now.AddSeconds(5));
                            }
                            if (TKCounter == 4)
                            {
                                Decided(this.DefenderId, this.AttackerId, "verteidigt!");
                                return;
                            }
                        }
                    }

                    if (DateTime.Now >= this.MaxTime)
                    {
                        // Prepare Time is over
                        Decided(this.AttackerId, this.DefenderId, "erobert!");
                        return;
                    }
                }
            }
            catch { }
        }

        public void informDefender()
        {
            Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 180, 0) + "Eurer Ganggebiet " + this.GangwarArea.Name + " wird von " + Faction.GetFactionNameById(this.AttackerId) + " angegriffen !", this.DefenderId);
            Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 180, 0) + "Benutzt /defend um am Gangwar teilzunehmen!", this.DefenderId);
        }

        public void informAttacker()
        {
            Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 225, 0) + "Eure Gang greift das Ganggebiet " + this.GangwarArea.Name + " an!", this.AttackerId);
            Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 225, 0) + "Benutzt /attack um am Gangwar teilzunehmen!", this.AttackerId);
        }

        public void AddPlayer(VnXPlayer player)
        {
            try
            {
                anzeigen.Usefull.VnX.RemoveAllBadGWWeapons(player);
                // Add player to the round
                PlayerEntry playerEntry = new PlayerEntry(player);
                player.Dimension = GangwarManager.GW_DIM;
                this.PlayerList.Add(playerEntry);

                // Display Player DX for joined Player 
                Rgba AttackRGB = GangwarArea.GangwarIVehicleRgbas(this.AttackerId);
                Rgba DefenderRGB = GangwarArea.GangwarIVehicleRgbas(this.DefenderId);
                Alt.Server.TriggerClientEvent(player, "gw:showUp", true, Faction.GetFactionNameById(this.AttackerId), Faction.GetFactionNameById(this.DefenderId), AttackRGB.R, AttackRGB.G, AttackRGB.B, DefenderRGB.R, DefenderRGB.G, DefenderRGB.B);
                SyncStats(player, playerEntry);
                InformAllThatPlayerJoined();

                SyncTime(player);
            }
            catch { }
        }

        public void InformAllThatPlayerJoined()
        {
            try
            {
                foreach (VnXPlayer _c in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    Alt.Server.TriggerClientEvent(_c, "gw:joinedPlayer", GetFactionInfo(this.AttackerId), GetFactionInfo(this.DefenderId));
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("InformAllThatPlayerJoined", ex); }
        }

        public void SyncTime()
        {
            try
            {
                foreach (var entry in this.PlayerList)
                {
                    SyncTime(entry._player);
                }
            }
            catch { }
        }

        public void SyncTime(VnXPlayer player)
        {
            try
            {
                if (this.CurrentState == RoundStates.PREPARING)
                {
                    double leftTime = (DateTime.Now - this.PreparingCD).TotalSeconds * -1;
                    Alt.Server.TriggerClientEvent(player, "gw:updateTime", (int)leftTime);
                }
                if (this.CurrentState == RoundStates.RUNNING)
                {
                    double leftTime = (DateTime.Now - this.MaxTime).TotalSeconds * -1;
                    Alt.Server.TriggerClientEvent(player, "gw:updateTime", (int)leftTime);
                }
            }
            catch { }
        }

        public void SyncStats(VnXPlayer player, PlayerEntry playerEntry)
        {
            try
            {
                if (!playerEntry._isLeft)
                {
                    Alt.Server.TriggerClientEvent(player, "gw:updateStats", playerEntry._totalDamage, playerEntry._totalKills, GetFactionInfo(this.AttackerId), GetFactionInfo(this.DefenderId));
                }
            }
            catch { }
        }

        public PlayerEntry GetPlayerEntry(VnXPlayer player)
        {
            try
            {
                foreach (var entry in this.PlayerList)
                {
                    if (entry._player == player)
                        return entry;
                }
                return null;
            }
            catch { return null; }
        }

        public bool isPlayerJoined(VnXPlayer player)
        {
            try
            {
                foreach (var entry in this.PlayerList)
                {
                    if (entry._player == player)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch { return false; }
        }

        public void ResetPlayer()
        {
            try
            {
                foreach (var entry in this.PlayerList)
                {
                    ResetPlayer(entry);
                }
            }
            catch { }
        }

        public void ResetPlayer(PlayerEntry playerEntry)
        {
            try
            {
                playerEntry._isKilled = false;

                if (!playerEntry._isLeft)
                {
                    Alt.Server.TriggerClientEvent(playerEntry._player, "gw:showUp", false, "FAC 1", "FAC 2", 255, 255, 255, 255, 255, 255);
                    int playerMoney = playerEntry._player.Reallife.Money;
                    int earnings = ((GangwarManager.EARN_KILL * Convert.ToInt32(playerEntry._totalKills)) + (GangwarManager.EARN_DMG * Convert.ToInt32(playerEntry._totalDamage)));
                    playerEntry._player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Du erhältst für " + playerEntry._totalKills + " Kills und " + playerEntry._totalDamage + " DMG " + earnings + "$");

                    playerEntry._player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney + earnings);

                    if (!playerEntry._isRespawned)
                    {
                        Factions.Spawn.SpawnPlayerOnSpawnpoint(playerEntry._player);
                    }
                }
            }
            catch { }
        }

        public int AliveFactionCount(int facId)
        {
            try
            {
                int result = 0;
                foreach (var entry in this.PlayerList)
                {
                    if (!entry._isLeft)
                    {
                        if (entry.GetFaction() == facId)
                        {
                            if (entry._isKilled == false)
                            {
                                result++;
                            }
                        }
                    }
                }
                return result;
            }
            catch { return 0; }
        }

        public void KillPlayer(PlayerEntry entry)
        {
            try
            {
                // Set player death
                entry._isKilled = true;

                // Sync info with each player in the GW
                foreach (var pentrys in this.PlayerList)
                {
                    SyncStats(pentrys._player, this.GetPlayerEntry(pentrys._player));
                }

                if (this.CurrentState == RoundStates.RUNNING) // Bug Fix for preparing Time !
                {
                    if (AliveFactionCount(DefenderId) == 0) // Check if defender are dead
                    {
                        Decided(AttackerId, DefenderId, "erobert!");
                        return;
                    }
                    else if (AliveFactionCount(AttackerId) == 0) // Check if attacker are dead
                    {
                        Decided(DefenderId, AttackerId, "verteidigt!");
                        return;
                    }
                }
            }
            catch { }
        }

        public void PlayerQuit(PlayerEntry entry)
        {
            try
            {
                entry._isLeft = true;
                KillPlayer(entry);
            }
            catch { }
        }
    }
}
