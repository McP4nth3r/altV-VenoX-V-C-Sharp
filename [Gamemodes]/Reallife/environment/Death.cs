using AltV.Net;
using System;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment
{
    public class Death : IScript
    {
        const int DeathScreenTime = 120000;
        public static void CreateKrankenhausTimer(VnXPlayer player)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "DeathScreen:Show", DeathScreenTime);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ClientEvent("Reallife:Revive")]
        public static void RevivePlayer(VnXPlayer player)
        {
            try
            {
                Spawn.SpawnPlayerOnSpawnpoint(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerDeath(VnXPlayer player, VnXPlayer killer, uint weapon)
        {
            try
            {
                if (player.IsDead) { return; }
                anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                Emergency.CreateEmergencyDeathNotify(player, 120);
                CreateKrankenhausTimer(player);
                if (killer != null)
                {
                    killer.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
                    if (player == killer)
                    {
                        player.SendTranslatedChatMessage("Du hast Selbstmord begangen!");
                        logfile.WriteLogs("kill", player.Username + " hat sich selbst umgebracht! ");
                        return;
                    }
                    if (Allround.isStateFaction(killer))
                    {
                        if (player.Reallife.Wanteds > 0)
                        {
                            Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_LSPD);
                            if (killer.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                            {
                                Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + player.Reallife.Wanteds * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                player.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, player.Reallife.Wanteds * 6);
                                killer.SendTranslatedChatMessage("{007d00}Du hast " + player.Username + " verhaftet für " + player.Reallife.Knastzeit + " Minuten! " + player.Reallife.Wanteds * 75 + " $ werden dir auf dein Bankkonto überwiesen.");
                                player.SendTranslatedChatMessage("{000096}Officer " + killer.Username + " hat dich eingesperrt für " + player.Reallife.Knastzeit + " Minuten!.");
                                //killer.vnxSetStreamSharedElementData(VnX.PLAYER_BANKMONEY, killer.Reallife.Bank + player.Reallife.Wanteds * 75);
                                killer.Reallife.Bank += (player.Reallife.Wanteds * 75);
                                logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " hat " + player.Username + " getötet!");
                                player.Reallife.Wanteds = 0;
                                //RemoveAllWeapons(player);
                            }
                        }
                        else
                        {
                            killer.SendTranslatedChatMessage("Du hast einen Zivilisten getötet! (" + player.Username + ")");
                            player.SendTranslatedChatMessage(killer.Username + " hat dich getötet.");
                            logfile.WriteLogs("kill", "Officer " + killer.Username + " hat " + player.Username + " Ohne Wanteds getötet!");
                        }
                        return;
                    }
                    else if (killer.Reallife.Wanteds == 6)
                    {
                        killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.Reallife.Wanteds + " ! Grund : Mord ");
                    }
                    else if (killer.Reallife.Wanteds > 3)
                    {
                        killer.Reallife.Wanteds = 6;
                        killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.Reallife.Wanteds + " ! Grund : Mord ");
                    }
                    else
                    {
                        killer.Reallife.Wanteds += 3;
                        killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.Reallife.Wanteds + " ! Grund : Mord ");
                    }
                    killer.SendTranslatedChatMessage("Du hast " + player.Username + " getötet!");
                    player.SendTranslatedChatMessage(killer.Username + " hat dich getötet.");
                    logfile.WriteLogs("kill", killer.Username + " hat " + player.Username + " getötet!");
                }
                player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du bist gestorben! Warte 120 Sekunden oder auf einen Medic.");

            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }
    }
}
