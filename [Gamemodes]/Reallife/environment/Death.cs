using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Language_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("Reallife:Revive")]
        public static void RevivePlayer(VnXPlayer player)
        {
            try
            {
                Emergency.DeleteCurrentMedicBlip(player);
                Spawn.SpawnPlayerOnSpawnpoint(player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static async void OnPlayerDeath(VnXPlayer player, VnXPlayer killer, uint weapon)
        {
            try
            {
                if (player.IsDead) return;
                VnX.RemoveAllWeapons(player);
                Emergency.OnPlayerDeath(player);
                CreateKrankenhausTimer(player);
                if (killer != null)
                {
                    VenoX.TriggerClientEvent(killer, "start_screen_fx", "ExplosionJosh3", 0, false);
                    if (player == killer)
                    {
                        player.SendTranslatedChatMessage("Du hast Selbstmord begangen!");
                        Logfile.WriteLogs("kill", player.Username + " hat sich selbst umgebracht! ");
                        return;
                    }
                    if (Allround.IsStateFaction(killer))
                    {
                        if (player.Reallife.WantedStars > 0)
                        {
                            FraktionsKassen fkasse = Database.Database.GetFactionStats(Constants.FactionLspd);
                            if (killer.VnxGetElementData<int>(EntityData.PlayerOnDuty) == 1)
                            {
                                Database.Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + player.Reallife.WantedStars * 400, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                                player.Reallife.JailTime = player.Reallife.WantedStars * 6;
                                string translatedText = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "Du hast");
                                string translatedText1 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "verhaftet für");
                                string translatedText2 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "Minuten!");
                                string translatedText3 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "$ werden dir auf dein Bankkonto überwiesen.");
                                killer.SendChatMessage("{007d00}" + translatedText + " " + player.Username + " " + translatedText1 + " " + player.Reallife.JailTime + " " + translatedText2 + player.Reallife.WantedStars * 75 + translatedText3);

                                string translatedText4 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, " hat dich eingesperrt für ");
                                player.SendTranslatedChatMessage("{000096}Officer " + killer.Username + " hat dich eingesperrt für " + player.Reallife.JailTime + " " + translatedText2);
                                killer.Reallife.Bank += (player.Reallife.WantedStars * 75);
                                Logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " hat " + player.Username + " getötet!");
                                player.Reallife.WantedStars = 0;
                                VnX.RemoveAllWeapons(player);
                            }
                        }
                        else
                        {
                            killer.SendTranslatedChatMessage("Du hast einen Zivilisten getötet!");
                            string translatedText = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, " hat dich getötet.");
                            player.SendTranslatedChatMessage(killer.Username + " " + translatedText);
                            Logfile.WriteLogs("kill", "Officer " + killer.Username + " killed " + player.Username + " without Wanteds getötet!");
                        }
                        return;
                    }

                    switch (killer.Reallife.WantedStars)
                    {
                        case 6:
                            killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.Reallife.WantedStars + " ! Grund : Mord ");
                            break;
                        case > 3:
                            killer.Reallife.WantedStars = 6;
                            killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.Reallife.WantedStars + " ! Grund : Mord ");
                            break;
                        default:
                            killer.Reallife.WantedStars += 3;
                            killer.SendTranslatedChatMessage("{ffff00}Dein FahndungsLevel wurde erhöht auf " + killer.Reallife.WantedStars + " ! Grund : Mord ");
                            break;
                    }
                    killer.SendChatMessage("Du hast " + player.Username + " getötet!");
                    player.SendChatMessage(killer.Username + " hat dich getötet.");
                    Logfile.WriteLogs("kill", killer.Username + " killed " + player.Username + "!");
                }
                player.SendTranslatedChatMessage(Constants.RgbaError + "Du bist gestorben! Warte 120 Sekunden oder auf einen Medic.");

            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }
    }
}
