using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Database;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment
{
    public class Death : IScript
    {

        public static void CreateKrankenhausTimer(Client player)
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


        public static void OnPlayerDeath(Client player, Client killer, uint weapon)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 0)
                {
                    anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 3000);
                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_KILLED, 1);
                    Emergency.CreateEmergencyDeathNotify(player, 120);
                    CreateKrankenhausTimer(player);
                    if (killer != null)
                    {
                        killer.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
                        if (player.Username == killer.Name)
                        {
                            player.SendTranslatedChatMessage("Du hast Selbstmord begangen!");
                            logfile.WriteLogs("kill", player.Username + " hat sich selbst umgebracht! ");
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
                                    player.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 6);
                                    killer.SendTranslatedChatMessage("{007d00}Du hast " + player.Username + " verhaftet für " + player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) + " Minuten! " + player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 75 + " $ werden dir auf dein Bankkonto überwiesen.");
                                    player.SendTranslatedChatMessage("{000096}Officer " + killer.Name + " hat dich eingesperrt für " + player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) + " Minuten!.");
                                    killer.vnxSetStreamSharedElementData(Core.VnX.PLAYER_BANKMONEY, killer.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) + player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 75);
                                    logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " hat " + player.Username + " getötet!");
                                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                                    //RemoveAllWeapons(player);
                                    anzeigen.Usefull.VnX.onWantedChange(player);
                                }
                            }
                            else
                            {
                                killer.SendTranslatedChatMessage("Du hast einen Zivilisten getötet! (" + player.Username + ")");
                                player.SendTranslatedChatMessage(killer.Name + " hat dich getötet.");
                                logfile.WriteLogs("kill", "Officer " + killer.Name + " hat " + player.Username + " Ohne Wanteds getötet!");
                            }
                            return;
                        }
                        else if (killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 6)
                        {
                            killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + " ! Grund : Mord ");
                        }
                        else if (killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 3)
                        {
                            killer.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 6);
                            killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + " ! Grund : Mord ");
                        }
                        else
                        {
                            killer.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 3);
                            killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + " ! Grund : Mord ");
                        }

                        killer.SendTranslatedChatMessage("Du hast " + player.Username + " getötet!");
                        player.SendTranslatedChatMessage(killer.Name + " hat dich getötet.");
                        logfile.WriteLogs("kill", killer.Name + " hat " + player.Username + " getötet!");
                        anzeigen.Usefull.VnX.onWantedChange(killer);
                    }
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du bist gestorben! Warte 120 Sekunden oder auf einen Medic.");
                }
            }
            catch
            {
            }
        }


        //[AltV.Net.ClientEvent("OnDeath_DMG")]
        public static void OnDeath_DMG(Client killer, Client player)
        {
            try
            {
                OnPlayerDeath(player, killer, 0);
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("log_damage_veh")]
        public static void Log_Damage_veh(Client player, string target_name, string weapon, string dmg)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                logfile.WriteLogs("damage", player.Username + " hat das Fahrzeug von " + target.Username + "[" + target.Vehicle.Model.ToString() + "] mit der Waffe " + weapon + " Gehittet! Damage : " + dmg);
            }
            catch
            {

            }
        }

        //[AltV.Net.ClientEvent("log_damage_ped")]
        public static void Log_Damage_ped(Client player, string target_name, string weapon, string dmg)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                logfile.WriteLogs("damage", player.Username + " hat den Spieler " + target.Username + " mit der Waffe " + weapon + " Gehittet! Damage : " + dmg);
            }
            catch
            {

            }
        }

    }
}
