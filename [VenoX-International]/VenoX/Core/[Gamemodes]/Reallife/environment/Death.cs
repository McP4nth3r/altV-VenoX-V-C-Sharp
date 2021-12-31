using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.factions;
using Main = VenoXV._Language_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoXV._Gamemodes_.Reallife.Environment
{
    public class Death : IScript
    {
        const int DeathScreenTime = 120000;

        private static void CreateHospitalTimer(VnXPlayer player)
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
                CreateHospitalTimer(player);
                if (killer != null)
                {
                    VenoX.TriggerClientEvent(killer, "start_screen_fx", "ExplosionJosh3", 0, false);
                    if (player == killer)
                    {
                        player.SendTranslatedChatMessage("You committed suicide!");
                        Logfile.WriteLogs("kill", player.Username + " committed suicide!");
                        return;
                    }
                    if (Allround.IsStateFaction(killer))
                    {
                        if (player.Reallife.WantedStars > 0)
                        {
                            FraktionsKassen fkasse = Database.Database.GetFactionStats(Constants.FactionLspd);
                            if (killer.VnxGetElementData<int>(EntityData.PlayerOnDuty) != 1) return;
                            Database.Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + player.Reallife.WantedStars * 400, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                            player.Reallife.JailTime = player.Reallife.WantedStars * 6;
                            string translatedText = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "You have");
                            string translatedText1 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "arrested for");
                            string translatedText2 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "Minute away!");
                            string translatedText3 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "$ will be transferred to your bank account.");
                            killer.SendChatMessage("{007d00}" + translatedText + " " + player.Username + " " + translatedText1 + " " + player.Reallife.JailTime + " " + translatedText2 + player.Reallife.WantedStars * 75 + translatedText3);

                            string translatedText4 = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, " hat dich eingesperrt für ");
                            player.SendTranslatedChatMessage("{000096}Officer " + killer.Username + translatedText4 + player.Reallife.JailTime + " " + translatedText2);
                            killer.Reallife.Bank += (player.Reallife.WantedStars * 75);
                            Logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " killed " + player.Username + "!");
                            player.Reallife.WantedStars = 0;
                            VnX.RemoveAllWeapons(player);
                        }
                        else
                        {
                            killer.SendTranslatedChatMessage("You killed a civilian!");
                            string translatedText = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, " hat dich getötet.");
                            player.SendTranslatedChatMessage(killer.Username + " " + translatedText);
                            Logfile.WriteLogs("kill", "Officer " + killer.Username + " killed " + player.Username + " without Wanteds!");
                        }
                        return;
                    }

                    switch (killer.Reallife.WantedStars)
                    {
                        case 6:
                            killer.SendTranslatedChatMessage("{ffff00}Your search level has been increased to " + killer.Reallife.WantedStars + " ! Grund : Murder ");
                            break;
                        case > 3:
                            killer.Reallife.WantedStars = 6;
                            killer.SendTranslatedChatMessage("{ffff00}Your search level has been increased to " + killer.Reallife.WantedStars + " ! Grund : Murder ");
                            break;
                        default:
                            killer.Reallife.WantedStars += 3;
                            killer.SendTranslatedChatMessage("{ffff00}Your search level has been increased to " + killer.Reallife.WantedStars + " ! Grund : Murder ");
                            break;
                    }
                    string killedMsg = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "You killed");
                    string killedInfoMsg = await Main.GetTranslatedTextAsync((Main.Languages)killer.Language, "Killed you.");

                    killer.SendChatMessage(killedMsg + player.Username + "!");
                    player.SendChatMessage(killer.Username + killedInfoMsg);
                    Logfile.WriteLogs("kill", killer.Username + " killed " + player.Username + "!");
                }
                player.SendTranslatedChatMessage(Constants.RgbaError + "You died! Wait 120 seconds or for a medic.");

            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }
    }
}
