using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_;
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
                VenoX.TriggerClientEvent(player, "DeathScreen:Show", DeathScreenTime);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ClientEvent("Reallife:Revive")]
        public static void RevivePlayer(VnXPlayer player)
        {
            try
            {
                Emergency.DeleteCurrentMedicBlip(player);
                Spawn.SpawnPlayerOnSpawnpoint(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static async void OnPlayerDeath(VnXPlayer player, VnXPlayer killer, uint weapon)
        {
            try
            {
                if (player.IsDead) return;
                player.Reallife.IsDead = true;
                anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                Emergency.OnPlayerDeath(player);
                CreateKrankenhausTimer(player);
                if (killer != null)
                {
                    VenoX.TriggerClientEvent(killer, "start_screen_fx", "ExplosionJosh3", 0, false);
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
                                player.Reallife.Knastzeit = player.Reallife.Wanteds * 6;
                                string TranslatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)killer.Language, "Du hast");
                                string TranslatedText1 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)killer.Language, "verhaftet für");
                                string TranslatedText2 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)killer.Language, "Minuten!");
                                string TranslatedText3 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)killer.Language, "$ werden dir auf dein Bankkonto überwiesen.");
                                killer.SendChatMessage("{007d00}" + TranslatedText + " " + player.Username + " " + TranslatedText1 + " " + player.Reallife.Knastzeit + " " + TranslatedText2 + player.Reallife.Wanteds * 75 + TranslatedText3);

                                string TranslatedText4 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)killer.Language, " hat dich eingesperrt für ");
                                player.SendTranslatedChatMessage("{000096}Officer " + killer.Username + " hat dich eingesperrt für " + player.Reallife.Knastzeit + " " + TranslatedText2);
                                killer.Reallife.Bank += (player.Reallife.Wanteds * 75);
                                logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " hat " + player.Username + " getötet!");
                                player.Reallife.Wanteds = 0;
                                anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                            }
                        }
                        else
                        {
                            killer.SendTranslatedChatMessage("Du hast einen Zivilisten getötet!");
                            string TranslatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, " hat dich getötet.");
                            player.SendTranslatedChatMessage(killer.Username + " " + TranslatedText);
                            logfile.WriteLogs("kill", "Officer " + killer.Username + " killed " + player.Username + " without Wanteds getötet!");
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
                    killer.SendChatMessage("Du hast " + player.Username + " getötet!");
                    player.SendChatMessage(killer.Username + " hat dich getötet.");
                    logfile.WriteLogs("kill", killer.Username + " killed " + player.Username + "!");
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
