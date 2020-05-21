using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.gangwar.v2;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.gangwar
{
    public class Allround : IScript
    {
        public static int GetFactionFactionBlipRgba(int factionId)
        {
            switch (factionId)
            {
                case Constants.FACTION_COSANOSTRA: return 55;
                case Constants.FACTION_YAKUZA: return 59;
                case Constants.FACTION_MS13: return 31;
                case Constants.FACTION_SAMCRO: return 76;
                case Constants.FACTION_BALLAS: return 7;
                case Constants.FACTION_GROVE: return 52;
                default: return 44; // ORANGE = FEHLER !!
            }
        }

        public static GangwarManager _gangwarManager { get; set; }
        public static void OnResourceStart()
        {
            // Initialize Core
            _gangwarManager = new GangwarManager();
        }

        public static void ProcessDamage(Client source, Client target, float damage)
        {
            // _gangwarManager.ProcessDamage(source, target.vnxGetElementData<int>( damage);
        }

        public static void ProcessKill(Client source, Client target)
        {
            _gangwarManager.ProcessKill(source, target);
        }

        [Command("attack")]
        public static void AtackGangwarArea(Client player)
        {
            try
            {
                // Is a current gangwar assigned?
                if (_gangwarManager.currentArea == null)
                {
                    if (!factions.Allround.isBadFaction(player))
                        return;

                    if (_gangwarManager.attacksCount < GangwarManager.MAX_ATTACKS_DAY)
                    {
                        foreach (GangwarArea area in _gangwarManager.GangwarAreas)
                        {
                            // Is the player close to the TK
                            if (area.TK.Distance(player.Position) < GangwarManager.TKRange)
                            {
                                // Is the player's faction isnt the area's owner id?
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) != area.IDOwner)
                                {
                                    // Is the player's rank above the minimum rank?
                                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_RANK) >= GangwarManager.MIN_RANK_ATTACK)
                                    {
                                        // Has the Defeneder Faction enough ppl online?
                                        if (_gangwarManager.GetFactionCount(area.IDOwner) >= GangwarManager.MIN_COUNT_PLAYER)
                                        {
                                            // Is the area's cooldwon expired?
                                            if (area.isAttackable())
                                            {
                                                // Assign the new running gangwar area
                                                _gangwarManager.currentArea = area;
                                                _gangwarManager.currentArea.setCooldown(GangwarManager.GW_ATTACK_CD);
                                                _gangwarManager.currentArea.Attack(player);
                                                ++_gangwarManager.attacksCount;

                                                // Notify all player about this event
                                                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Ein Gangwar wird vorbereitet!");
                                                factions.Faction.CreateCustomFactionInformation(_gangwarManager.currentArea.GetCurrentRound().AttackerId, RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " hat einen Gangwar gegen " + factions.Faction.GetPlayerFactionName(_gangwarManager.currentArea.GetCurrentRound().DefenderId) + " gestartet!");
                                                return;
                                            }
                                            else { RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(175, 0, 0) + "Das Gebiet " + area.Name + " hat noch einen Cooldown bis zum : " + area.GetLeftTime().ToString()); }
                                        }
                                        else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Die Verteidiger Fraktion haben haben nicht genug Spieler online!"); }
                                    }
                                    else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht befugt dieses Gebiet anzugreifen!"); }
                                }
                                else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst nicht deine eigene Fraktion angreifen!"); }
                            }
                        }
                    }
                }
                else
                {
                    // Add player to the running Gangwar Round 
                    if (factions.Allround.isBadFaction(player) && player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _gangwarManager.currentArea.GetCurrentRound().AttackerId)
                    {
                        if (_gangwarManager.currentArea.GetCurrentRound().CurrentState == GangwarRound.RoundStates.PREPARING)
                        {
                            var attCount = _gangwarManager.currentArea.GetCurrentRound().AliveFactionCount(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            if ((GangwarManager.AttackerCountMore && attCount <= _gangwarManager.GetFactionCount(_gangwarManager.currentArea.IDOwner))
                                || (!GangwarManager.AttackerCountMore && attCount < _gangwarManager.GetFactionCount(_gangwarManager.currentArea.IDOwner)))
                            {
                                _gangwarManager.currentArea.AddPlayer(player);
                                factions.Faction.CreateCustomFactionInformation(_gangwarManager.currentArea.GetCurrentRound().AttackerId, RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " nimmt nun am Gangwar teil.");
                                return;

                            }
                            else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Ihr seid schon genug Angreifer!"); }
                        }
                    }
                    else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Angreifer oder in einer Bösen Fraktion!"); }
                }
            }
            catch { }
        }

        [Command("defend")]
        public static void DefendGangwarArea(Client player)
        {
            try
            {
                // Ist ein Gangwar schon am laufen?
                if (_gangwarManager.currentArea != null)
                {
                    if (factions.Allround.isBadFaction(player) && player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _gangwarManager.currentArea.GetCurrentRound().DefenderId)
                    {
                        if (_gangwarManager.currentArea.GetCurrentRound().CurrentState == GangwarRound.RoundStates.RUNNING)
                        {
                            if (_gangwarManager.currentArea.Position.Distance(player.Position) > GangwarManager.MIN_DIST)
                            {
                                // Calculation
                                var allowedDefCount = _gangwarManager.currentArea.GetCurrentRound().AliveFactionCount(_gangwarManager.currentArea.GetCurrentRound().AttackerId);
                                var defCount = _gangwarManager.currentArea.GetCurrentRound().AliveFactionCount(_gangwarManager.currentArea.GetCurrentRound().DefenderId);
                                if (GangwarManager.DefenderCountMore)
                                {
                                    ++allowedDefCount;
                                }

                                // Add if defender count is lower than attacker count + 1
                                if (defCount < allowedDefCount)
                                {
                                    if (DateTime.Now <= _gangwarManager.currentArea.GetCurrentRound().DefenderMaxTime)
                                    {
                                        _gangwarManager.currentArea.AddPlayer(player);
                                        factions.Faction.CreateCustomFactionInformation(_gangwarManager.currentArea.GetCurrentRound().DefenderId, RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " nimmt nun am Gangwar teil.");
                                        factions.Faction.CreateCustomFactionInformation(_gangwarManager.currentArea.GetCurrentRound().AttackerId, RageAPI.GetHexColorcode(150, 0, 0) + player.Username + " nimmt nun am Gangwar teil.");

                                    }
                                    else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist leider zu spaet zum GW!"); }
                                }
                                else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Ihr seid schon zu viele"); }
                            }
                            else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du musst weiter weg vom Gebiet sein!"); }
                        }
                    }
                    else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Verteidiger oder in einer Bösen Fraktion!"); }
                }
            }
            catch { }
        }

        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                foreach (GangwarArea area in _gangwarManager.GangwarAreas)
                {
                    // You entered a GW Area
                    if (area.AreaIColShape == shape)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du hast ein Ganggebiet betreten!");
                        return;
                    }

                    // You entered the TK of an area
                    if (area.TKIColShape == shape)
                    {
                        area.Inform(player);
                        return;
                    }
                }
            }
            catch { }
        }

        public static void OnUpdate()
        {
            try
            {
                if (_gangwarManager != null)
                    _gangwarManager.Update();
            }
            catch { }
        }

        public static void OnPlayerDisconnected(Client player, string type, string reason)
        {
            try
            {
                if (_gangwarManager.currentArea != null)
                {
                    var quiter = _gangwarManager.currentArea.GetCurrentRound().GetPlayerEntry(player);
                    if (quiter != null)
                    {
                        _gangwarManager.currentArea.GetCurrentRound().PlayerQuit(quiter);
                    }
                }
            }
            catch { }
        }

        //[ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Client player, Client killer, uint reason)
        {
            try
            {
                if (_gangwarManager.currentArea != null)
                {
                    var playerEntry = _gangwarManager.currentArea.GetCurrentRound().GetPlayerEntry(player);
                    var killerEntry = _gangwarManager.currentArea.GetCurrentRound().GetPlayerEntry(killer);
                    if (playerEntry != null)
                    {
                        if (killerEntry != null)
                        {
                            // If source and target has different factions
                            if (playerEntry.GetFaction() != killerEntry.GetFaction())
                            {
                                killerEntry._totalKills += 1;
                            }
                        }

                        _gangwarManager.currentArea.GetCurrentRound().KillPlayer(playerEntry);

                        // Respawn target
                        playerEntry._isRespawned = true;
                        factions.Spawn.spawnplayer_on_spawnpoint(player);
                    }
                }
            }
            catch { }
        }
    }
}