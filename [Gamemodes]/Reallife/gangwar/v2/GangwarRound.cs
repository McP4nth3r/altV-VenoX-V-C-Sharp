using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Models;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoXV._Gamemodes_.Reallife.gangwar.v2
{
    public class GangwarRound
    {
        public enum RoundStates { Preparing, Running, Decided, Stopped }

        public class PlayerEntry
        {
            public VnXPlayer Player;
            public float TotalDamage;
            public int TotalKills;
            public bool IsInTk;
            public bool IsRespawned;
            public bool IsKilled;
            public bool IsLeft;

            public PlayerEntry(VnXPlayer player)
            {
                Player = player;
                TotalDamage = 0.0f;
                TotalKills = 0;
                IsRespawned = false;
                IsKilled = false;
                IsLeft = false;
            }

            public int GetFaction() => Player.Reallife.Faction;
        }

        public int DefenderId;
        public int AttackerId;
        private GangwarArea _gangwarArea;
        public RoundStates CurrentState;
        public List<PlayerEntry> PlayerList;
        private DateTime _startTime;
        private DateTime _stopTime;
        private DateTime _preparingCd;
        private DateTime _maxTime;
        private DateTime _tkCooldown;
        public int TkCounter;
        public DateTime DefenderMaxTime;
        public GangwarRound(GangwarArea gangwar, int defenderId, int attackerId)
        {
            _gangwarArea = gangwar;
            DefenderId = defenderId;
            AttackerId = attackerId;
            CurrentState = RoundStates.Preparing;
            PlayerList = new List<PlayerEntry>();
            _startTime = DateTime.Now;
            _stopTime = _startTime;
            _preparingCd = _startTime.AddMinutes(GangwarManager.GwPrepareTime);
            _maxTime = _preparingCd.AddMinutes(GangwarManager.GwRunningTime);
            DefenderMaxTime = _preparingCd.AddMinutes(GangwarManager.GwPrepareTime);
            _tkCooldown = _preparingCd;
            TkCounter = 0;
            InformAttacker();
        }

        public void PlayerUpdateTkTime(DateTime time)
        {
            _tkCooldown = time;
        }

        public void Inform(VnXPlayer player)
        {
            //player.SendTranslatedChatMessage("[GW-ROUND] " + StartTime + " started; " + StopTime + " stopped; State: " + CurrentState + "; Count: " + PlayerList.Count);
        }

        public void Stop()
        {
            try
            {
                if (CurrentState == RoundStates.Preparing || CurrentState == RoundStates.Running)
                {
                    _stopTime = DateTime.Now;
                    CurrentState = RoundStates.Stopped;
                    ResetPlayer();
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void Decided(int winnerId, int loserId, string state)
        {
            try
            {
                _stopTime = DateTime.Now;
                CurrentState = RoundStates.Decided;

                _gangwarArea.IsRunning = false;
                _gangwarArea.SetOwner(winnerId);
                _gangwarArea.RemoveElements();

                Allround.GangwarManager.CurrentArea = null;

                ResetPlayer();
                VenoX.TriggerEventForAll("StopCurrentGangwar", _gangwarArea.Name);

                if (state == "verteidigt!")
                {
                    RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(100, 150, 0) + "Die " + Faction.GetFactionNameById(winnerId) + " haben erfolgreich ihr Gebiet " + _gangwarArea.Name + " gegen die " + Faction.GetFactionNameById(loserId) + " " + state);
                }
                else
                {
                    RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(100, 150, 0) + "Die " + Faction.GetFactionNameById(winnerId) + " haben erfolgreich das Gebiet der " + Faction.GetFactionNameById(loserId) + " " + state);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public string GetFactionInfo(int facId)
        {
            try
            {
                int max = 0;
                int alive = 0;
                foreach (var entry in PlayerList.ToList())
                {
                    if (!entry.IsLeft)
                    {
                        if (entry.GetFaction() == facId)
                        {
                            ++max;
                            if (entry.IsKilled == false)
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

        public void ProcessDamage(VnXPlayer source, VnXPlayer player, float damage)
        {
            try
            {
                var sourceEntry = GetPlayerEntry(source);
                var playerEntry = GetPlayerEntry(player);
                if (sourceEntry != null && playerEntry != null)
                {
                    // If source and target has different factions
                    if (playerEntry.GetFaction() != sourceEntry.GetFaction())
                        sourceEntry.TotalDamage += damage;

                    SyncStats(source, sourceEntry);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void ProcessKill(VnXPlayer source, VnXPlayer player)
        {
            try
            {
                var sourceEntry = GetPlayerEntry(source);
                var playerEntry = GetPlayerEntry(player);
                if (sourceEntry != null && playerEntry != null)
                {
                    if (!playerEntry.IsLeft || !playerEntry.IsKilled)
                    {
                        // If source and target has different factions
                        if (playerEntry.GetFaction() != sourceEntry.GetFaction())
                        {
                            sourceEntry.TotalKills += 1;
                        }
                        KillPlayer(playerEntry);

                        // Respawn target
                        playerEntry.IsRespawned = true;
                        Spawn.SpawnPlayerOnSpawnpoint(player);
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void UpdateTime()
        {
            try
            {
                // PPEPARING TIME
                if (CurrentState == RoundStates.Preparing)
                {
                    if (DateTime.Now >= _preparingCd)
                    {
                        // Prepare Time is over
                        //RageAPI.SendTranslatedChatMessageToAll("UPDATE");
                        CurrentState = RoundStates.Running;
                        _gangwarArea.FreezeElements(GangwarManager.FreezeIVehicles);
                        InformDefender();
                        SyncTime();
                        foreach (VnXPlayer c in Main.ReallifePlayers.ToList())
                        {
                            VenoX.TriggerClientEvent(c, "gw:aa", _gangwarArea.Position.X, _gangwarArea.Position.Y, _gangwarArea.Position.Z, _gangwarArea.Radius, _gangwarArea.Rotation, GangwarManager.AttBlipRgba);
                        }
                    }
                }

                // RUNNING TIME
                if (CurrentState == RoundStates.Running)
                {
                    // If the first 5sec expires
                    if (DateTime.Now >= _tkCooldown)
                    {
                        // Check if player's position is close to the TK pos
                        bool inTk = false;
                        foreach (var entry in PlayerList)
                        {
                            if (entry.GetFaction() == AttackerId)
                            {
                                if (_gangwarArea.Tk.Distance(entry.Player.Position) <= GangwarManager.TkRange)
                                {
                                    inTk = true;
                                    if (TkCounter > 0)
                                    {
                                        TkCounter = 0;
                                        Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(0, 255, 0) + entry.Player.Username + " hat den TK beesetzt!", AttackerId);
                                    }
                                    break;
                                }
                            }
                        }
                        if (!inTk)
                        {
                            ++TkCounter;
                            switch (TkCounter)
                            {
                                case 1:
                                    Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(175, 0, 0) + "Besetzt sofort den TK, ansonsten verliert ihr nach 15 Sekunden!", AttackerId);
                                    PlayerUpdateTkTime(DateTime.Now.AddSeconds(5));
                                    break;
                                case 2:
                                    Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(175, 0, 0) + "Ihr habt noch 10 Sekunden!", AttackerId);
                                    PlayerUpdateTkTime(DateTime.Now.AddSeconds(5));
                                    break;
                                case 3:
                                    Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(175, 0, 0) + "Ihr habt noch 5 Sekunden!", AttackerId);
                                    PlayerUpdateTkTime(DateTime.Now.AddSeconds(5));
                                    break;
                                case 4:
                                    Decided(DefenderId, AttackerId, "verteidigt!");
                                    return;
                            }
                        }
                    }

                    if (DateTime.Now >= _maxTime)
                    {
                        // Prepare Time is over
                        Decided(AttackerId, DefenderId, "erobert!");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void InformDefender()
        {
            Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(0, 180, 0) + "Eurer Ganggebiet " + _gangwarArea.Name + " wird von " + Faction.GetFactionNameById(AttackerId) + " angegriffen !", DefenderId);
            Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(0, 180, 0) + "Benutzt /defend um am Gangwar teilzunehmen!", DefenderId);
        }

        public void InformAttacker()
        {
            Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(0, 225, 0) + "Eure Gang greift das Ganggebiet " + _gangwarArea.Name + " an!", AttackerId);
            Faction.CreateCustomBadFactionMessage(RageApi.GetHexColorcode(0, 225, 0) + "Benutzt /attack um am Gangwar teilzunehmen!", AttackerId);
        }

        public void AddPlayer(VnXPlayer player)
        {
            try
            {
                VnX.RemoveAllBadGwWeapons(player);
                // Add player to the round
                PlayerEntry playerEntry = new PlayerEntry(player);
                player.Dimension = GangwarManager.GwDim;
                PlayerList.Add(playerEntry);

                // Display Player DX for joined Player 
                Rgba attackRgb = _gangwarArea.GangwarIVehicleRgbas(AttackerId);
                Rgba defenderRgb = _gangwarArea.GangwarIVehicleRgbas(DefenderId);
                VenoX.TriggerClientEvent(player, "gw:showUp", true, Faction.GetFactionNameById(AttackerId), Faction.GetFactionNameById(DefenderId), attackRgb.R, attackRgb.G, attackRgb.B, defenderRgb.R, defenderRgb.G, defenderRgb.B);
                SyncStats(player, playerEntry);
                InformAllThatPlayerJoined();

                SyncTime(player);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void InformAllThatPlayerJoined()
        {
            try
            {
                foreach (VnXPlayer c in Main.ReallifePlayers.ToList())
                {
                    VenoX.TriggerClientEvent(c, "gw:joinedPlayer", GetFactionInfo(AttackerId), GetFactionInfo(DefenderId));
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public void SyncTime()
        {
            try
            {
                foreach (var entry in PlayerList)
                {
                    SyncTime(entry.Player);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void SyncTime(VnXPlayer player)
        {
            try
            {
                switch (CurrentState)
                {
                    case RoundStates.Preparing:
                    {
                        double leftTime = (DateTime.Now - _preparingCd).TotalSeconds * -1;
                        VenoX.TriggerClientEvent(player, "gw:updateTime", (int)leftTime);
                        break;
                    }
                    case RoundStates.Running:
                    {
                        double leftTime = (DateTime.Now - _maxTime).TotalSeconds * -1;
                        VenoX.TriggerClientEvent(player, "gw:updateTime", (int)leftTime);
                        break;
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void SyncStats(VnXPlayer player, PlayerEntry playerEntry)
        {
            try
            {
                if (!playerEntry.IsLeft)
                {
                    VenoX.TriggerClientEvent(player, "gw:updateStats", playerEntry.TotalDamage, playerEntry.TotalKills, GetFactionInfo(AttackerId), GetFactionInfo(DefenderId));
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public PlayerEntry GetPlayerEntry(VnXPlayer player)
        {
            try
            {
                foreach (var entry in PlayerList)
                {
                    if (entry.Player == player)
                        return entry;
                }
                return null;
            }
            catch { return null; }
        }

        public bool IsPlayerJoined(VnXPlayer player)
        {
            try
            {
                foreach (var entry in PlayerList)
                {
                    if (entry.Player == player)
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
                foreach (var entry in PlayerList)
                {
                    ResetPlayer(entry);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void ResetPlayer(PlayerEntry playerEntry)
        {
            try
            {
                playerEntry.IsKilled = false;

                if (!playerEntry.IsLeft)
                {
                    VenoX.TriggerClientEvent(playerEntry.Player, "gw:showUp", false, "FAC 1", "FAC 2", 255, 255, 255, 255, 255, 255);
                    int playerMoney = playerEntry.Player.Reallife.Money;
                    int earnings = ((GangwarManager.EarnKill * Convert.ToInt32(playerEntry.TotalKills)) + (GangwarManager.EarnDmg * Convert.ToInt32(playerEntry.TotalDamage)));
                    playerEntry.Player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 0, 0) + "Du erhältst für " + playerEntry.TotalKills + " Kills und " + playerEntry.TotalDamage + " DMG " + earnings + "$");

                    playerEntry.Player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playerMoney + earnings);

                    if (!playerEntry.IsRespawned)
                    {
                        Spawn.SpawnPlayerOnSpawnpoint(playerEntry.Player);
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public int AliveFactionCount(int facId)
        {
            try
            {
                int result = 0;
                foreach (var entry in PlayerList)
                {
                    if (!entry.IsLeft)
                    {
                        if (entry.GetFaction() == facId)
                        {
                            if (entry.IsKilled == false)
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
                entry.IsKilled = true;

                // Sync info with each player in the GW
                foreach (var pentrys in PlayerList)
                {
                    SyncStats(pentrys.Player, GetPlayerEntry(pentrys.Player));
                }

                if (CurrentState == RoundStates.Running) // Bug Fix for preparing Time !
                {
                    if (AliveFactionCount(DefenderId) == 0) // Check if defender are dead
                    {
                        Decided(AttackerId, DefenderId, "erobert!");
                    }
                    else if (AliveFactionCount(AttackerId) == 0) // Check if attacker are dead
                    {
                        Decided(DefenderId, AttackerId, "verteidigt!");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public void PlayerQuit(PlayerEntry entry)
        {
            try
            {
                entry.IsLeft = true;
                KillPlayer(entry);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
