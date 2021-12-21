using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.gangwar.v2;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV.Models;
using VenoXV.Reallife.chat;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.gangwar.v2;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV.Reallife.gangwar
{
    public class Allround : IScript
    {
        public static int GetFactionFactionBlipRgba(int factionId)
        {
            return factionId switch
            {
                Constants.FactionLcn => 55,
                Constants.FactionYakuza => 59,
                Constants.FactionNarcos => 31,
                Constants.FactionSamcro => 76,
                Constants.FactionBallas => 7,
                Constants.FactionCompton => 52,
                _ => 44,// ORANGE = FEHLER !!
            };
        }

        public static GangwarManager GangwarManager { get; set; }
        public static void OnResourceStart()
        {
            // Initialize Core
            GangwarManager = new GangwarManager();
        }

        public static void ProcessDamage(VnXPlayer source, VnXPlayer target, float damage)
        {
            GangwarManager.ProcessDamage(source, target, damage);
        }

        public static void ProcessKill(VnXPlayer source, VnXPlayer target)
        {
            GangwarManager.ProcessKill(source, target);
        }

        [Command("attack")]
        public static void AtackGangwarArea(VnXPlayer player)
        {
            try
            {
                // Is a current gangwar assigned?
                if (GangwarManager.CurrentArea == null)
                {
                    if (!factions.Allround.IsBadFaction(player)) return;

                    if (GangwarManager.AttacksCount >= GangwarManager.MaxAttacksDay) return;
                    foreach (var area in GangwarManager.GangwarAreas.Where(area => area.Tk.Distance(player.Position) < GangwarManager.TkRange))
                    {
                        // Is the player's faction isnt the area's owner id?
                        if (player.Reallife.Faction != area.IdOwner)
                        {
                            // Is the player's rank above the minimum rank?
                            if (player.Reallife.FactionRank >= GangwarManager.MinRankAttack)
                            {
                                // Has the Defeneder Faction enough ppl online?
                                if (GangwarManager.GetFactionCount(area.IdOwner) >= GangwarManager.MinCountPlayer)
                                {
                                    // Is the area's cooldwon expired?
                                    if (area.IsAttackable())
                                    {
                                        // Assign the new running gangwar area
                                        GangwarManager.CurrentArea = area;
                                        GangwarManager.CurrentArea.SetCooldown(GangwarManager.GwAttackCd);
                                        GangwarManager.CurrentArea.Attack(player);
                                        ++GangwarManager.AttacksCount;

                                        // Notify all player about this event
                                        ReallifeChat.SendReallifeMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + "Ein Gangwar wird vorbereitet!");
                                        Faction.CreateCustomFactionInformation(GangwarManager.CurrentArea.GetCurrentRound().AttackerId, RageApi.GetHexColorcode(0, 200, 0) + player.Username + " hat einen Gangwar gegen " + Faction.GetFactionNameById(GangwarManager.CurrentArea.GetCurrentRound().DefenderId) + " gestartet!");
                                        return;
                                    }

                                    ReallifeChat.SendReallifeMessageToAll(RageApi.GetHexColorcode(175, 0, 0) + "Das Gebiet " + area.Name + " hat noch einen Cooldown bis zum : " + area.GetLeftTime());
                                }
                                else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Die Verteidiger Fraktion haben haben nicht genug Spieler online!"); }
                            }
                            else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Du bist nicht befugt dieses Gebiet anzugreifen!"); }
                        }
                        else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Du kannst nicht deine eigene Fraktion angreifen!"); }
                    }
                }
                else
                {
                    // Add player to the running Gangwar Round 
                    if (factions.Allround.IsBadFaction(player) && player.Reallife.Faction == GangwarManager.CurrentArea.GetCurrentRound().AttackerId)
                    {
                        if (GangwarManager.CurrentArea.GetCurrentRound().CurrentState != GangwarRound.RoundStates.Preparing) return;
                        var attCount = GangwarManager.CurrentArea.GetCurrentRound().AliveFactionCount(player.Reallife.Faction);
                        if ((GangwarManager.AttackerCountMore && attCount <= GangwarManager.GetFactionCount(GangwarManager.CurrentArea.IdOwner)) || (!GangwarManager.AttackerCountMore && attCount < GangwarManager.GetFactionCount(GangwarManager.CurrentArea.IdOwner)))
                        {
                            GangwarManager.CurrentArea.AddPlayer(player);
                            Faction.CreateCustomFactionInformation(GangwarManager.CurrentArea.GetCurrentRound().AttackerId, RageApi.GetHexColorcode(0, 200, 0) + player.Username + " nimmt nun am Gangwar teil.");
                        }
                        else { Main.DrawNotification(player, Main.Types.Error, "Ihr seid schon genug Angreifer!"); }
                    }
                    else { Main.DrawNotification(player, Main.Types.Error, "Du bist kein Angreifer oder in einer Bösen Fraktion!"); }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("defend")]
        public static void DefendGangwarArea(VnXPlayer player)
        {
            try
            {
                // Ist ein Gangwar schon am laufen?
                if (GangwarManager.CurrentArea == null) return;
                if (factions.Allround.IsBadFaction(player) && player.Reallife.Faction == GangwarManager.CurrentArea.GetCurrentRound().DefenderId)
                {
                    if (GangwarManager.CurrentArea.GetCurrentRound().CurrentState != GangwarRound.RoundStates.Running) return;
                    if (GangwarManager.CurrentArea.Position.Distance(player.Position) > GangwarManager.MinDist)
                    {
                        // Calculation
                        var allowedDefCount = GangwarManager.CurrentArea.GetCurrentRound().AliveFactionCount(GangwarManager.CurrentArea.GetCurrentRound().AttackerId);
                        var defCount = GangwarManager.CurrentArea.GetCurrentRound().AliveFactionCount(GangwarManager.CurrentArea.GetCurrentRound().DefenderId);
                        if (GangwarManager.DefenderCountMore)
                        {
                            ++allowedDefCount;
                        }

                        // Add if defender count is lower than attacker count + 1
                        if (defCount < allowedDefCount)
                        {
                            if (DateTime.Now <= GangwarManager.CurrentArea.GetCurrentRound().DefenderMaxTime)
                            {
                                GangwarManager.CurrentArea.AddPlayer(player);
                                Faction.CreateCustomFactionInformation(GangwarManager.CurrentArea.GetCurrentRound().DefenderId, RageApi.GetHexColorcode(0, 200, 0) + player.Username + " nimmt nun am Gangwar teil.");
                                Faction.CreateCustomFactionInformation(GangwarManager.CurrentArea.GetCurrentRound().AttackerId, RageApi.GetHexColorcode(150, 0, 0) + player.Username + " nimmt nun am Gangwar teil.");
                            }
                            else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Du bist leider zu spaet zum GW!"); }
                        }
                        else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Ihr seid schon zu viele"); }
                    }
                    else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Du musst weiter weg vom Gebiet sein!"); }
                }
                else { Main.DrawTranslatedNotification(player, Main.Types.Error, "Du bist kein Verteidiger oder in einer Bösen Fraktion!"); }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                foreach (GangwarArea area in GangwarManager.GangwarAreas)
                {
                    // You entered a GW Area
                    if (area.AreaColShapeModel == shape)
                    {
                        Main.DrawTranslatedNotification(player, Main.Types.Warning, "Du hast ein Ganggebiet betreten!");
                        return true;
                    }

                    // You entered the TK of an area
                    if (area.TkColShapeModel != shape) continue;
                    area.Inform(player);
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public static void OnUpdate()
        {
            try
            {
                if (GangwarManager != null)
                    GangwarManager.Update();
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnPlayerDisconnected(VnXPlayer player, string type, string reason)
        {
            try
            {
                if (GangwarManager.CurrentArea == null) return;
                var quiter = GangwarManager.CurrentArea.GetCurrentRound().GetPlayerEntry(player);
                if (quiter != null)
                {
                    GangwarManager.CurrentArea.GetCurrentRound().PlayerQuit(quiter);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[ServerEvent(Event.PlayerDeath)]
        public static void OnPlayerDeath(VnXPlayer player, VnXPlayer killer, uint reason)
        {
            try
            {
                if (GangwarManager.CurrentArea == null) return;
                var playerEntry = GangwarManager.CurrentArea.GetCurrentRound().GetPlayerEntry(player);
                var killerEntry = GangwarManager.CurrentArea.GetCurrentRound().GetPlayerEntry(killer);
                if (playerEntry == null) return;
                if (killerEntry != null)
                {
                    // If source and target has different factions
                    if (playerEntry.GetFaction() != killerEntry.GetFaction())
                    {
                        killerEntry.TotalKills += 1;
                    }
                    ProcessKill(player, killer);
                }

                GangwarManager.CurrentArea.GetCurrentRound().KillPlayer(playerEntry);

                // Respawn target
                playerEntry.IsRespawned = true;
                Spawn.SpawnPlayerOnSpawnpoint(player);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}