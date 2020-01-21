using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV.Reallife.anzeigen.Usefull;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using VenoXV.Reallife.vnx_stored_files;

namespace VenoXV.Reallife.Environment
{
    public class Death : IScript
    {

        public static void CreateKrankenhausTimer(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1 && player.Dimension == 0)
                {
                    dxLibary.VnX.CreateCTimer(player, "Krankenhaus", 2 * 60000);
                    player.Emit("showKrankenhausTimer");
                }
            }
            catch { }
        }


        public static void OnPlayerDeath(IPlayer player, IPlayer killer, uint weapon)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 0)
                {
                    anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 3000);
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_KILLED, 1);
                    Emergency.CreateEmergencyDeathNotify(player, 120);
                    CreateKrankenhausTimer(player);
                    if (killer != null)
                    {
                        killer.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
                        if (player.Name == killer.Name)
                        {
                            player.SendChatMessage("Du hast Selbstmord begangen!");
                            logfile.WriteLogs("kill",player.Name + " hat sich selbst umgebracht! ");
                            return;
                        }
                        if (Allround.isStateFaction(killer))
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 0)
                            {
                                Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_POLICE);
                                if (killer.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                                {
                                    Database.SetFactionStats(Constants.FACTION_POLICE, fkasse.money + player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                    player.SetData(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 6);
                                    killer.SendChatMessage("!{#007d00}Du hast " +player.Name + " verhaftet für " + player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) + " Minuten! " + player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 75 + " $ werden dir auf dein Bankkonto überwiesen.");
                                    player.SendChatMessage("!{#000096}Officer " + killer.Name + " hat dich eingesperrt für " + player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) + " Minuten!.");
                                    Core.VnX.vnxSetSharedData(killer, Core.VnX.PLAYER_BANKMONEY, killer.vnxGetElementData<int>(EntityData.PLAYER_BANK) + player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 75);
                                    logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " hat " +player.Name + " getötet!");
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_WANTEDS, 0);
                                    //RemoveAllWeapons(player);
                                    anzeigen.Usefull.VnX.onWantedChange(player);
                                }
                            }
                            else
                            {
                                killer.SendChatMessage("Du hast einen Zivilisten getötet! (" +player.Name + ")");
                                player.SendChatMessage(killer.Name + " hat dich getötet.");
                                logfile.WriteLogs("kill", "Officer " + killer.Name + " hat " +player.Name + " Ohne Wanteds getötet!");
                            }
                            return;
                        }
                        else if (killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 6)
                        {
                            killer.SendChatMessage("!{#ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + " ! Grund : Mord ");
                        }
                        else if (killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 3)
                        {
                            Core.VnX.vnxSetSharedData(killer, EntityData.PLAYER_WANTEDS, 6);
                            killer.SendChatMessage("!{#ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + " ! Grund : Mord ");
                        }
                        else
                        {
                            Core.VnX.vnxSetSharedData(killer, EntityData.PLAYER_WANTEDS, killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 3);
                            killer.SendChatMessage("!{#ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + " ! Grund : Mord ");
                        }

                        killer.SendChatMessage("Du hast " +player.Name + " getötet!");
                        player.SendChatMessage(killer.Name + " hat dich getötet.");
                        logfile.WriteLogs("kill", killer.Name + " hat " +player.Name + " getötet!");
                        anzeigen.Usefull.VnX.onWantedChange(killer);
                    }
                    player.SendChatMessage(Constants.Rgba_ERROR + "Du bist gestorben! Warte 120 Sekunden oder auf einen Medic.");
                }
            }
            catch
            {
            }
        }


        //[AltV.Net.ClientEvent("OnDeath_DMG")]
        public static void OnDeath_DMG(IPlayer killer, IPlayer player)
        {
            try {
                OnPlayerDeath(player, killer, 0);
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("log_damage_veh")]
        public static void Log_Damage_veh(IPlayer player, IPlayer target, string weapon, string dmg)
        {
            try
            {
                logfile.WriteLogs("damage",player.Name +  " hat das Fahrzeug von " + target.Name + "["+ target.Vehicle.Model.ToString() +"] mit der Waffe " + weapon + " Gehittet! Damage : " + dmg); 
            }
            catch
            {

            }
        }

        //[AltV.Net.ClientEvent("log_damage_ped")]
        public static void Log_Damage_ped(IPlayer player, IPlayer target, string weapon, string dmg)
        {
            try
            {
                logfile.WriteLogs("damage",player.Name + " hat den Spieler " + target.Name + " mit der Waffe " + weapon + " Gehittet! Damage : " + dmg);
            }
            catch
            {

            }
        }

    }
}
