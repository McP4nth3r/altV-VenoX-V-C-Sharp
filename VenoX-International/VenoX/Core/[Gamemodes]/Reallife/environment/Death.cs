using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.factions;
using VenoX.Core._Gamemodes_.Reallife.factions.Medic;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;
using Main = VenoX.Core._Language_.Main;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Gamemodes_.Reallife.environment
{
    public class Death : IScript
    {
        const int DeathScreenTime = 120000;

        private static void CreateHospitalTimer(VnXPlayer player)
        {
            try
            {
                _RootCore_.VenoX.TriggerClientEvent(player, "DeathScreen:Show", DeathScreenTime);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("Reallife:Revive")]
        public static void RevivePlayer(VnXPlayer player)
        {
            try
            {
                Emergency.DeleteCurrentMedicBlip(player);
                Spawn.SpawnPlayerOnSpawnpoint(player);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
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
                    _RootCore_.VenoX.TriggerClientEvent(killer, "start_screen_fx", "ExplosionJosh3", 0, false);
                    if (player == killer)
                    {
                        player.SendTranslatedChatMessage("You committed suicide!");
                        Logfile.WriteLogs("kill", player.CharacterUsername + " committed suicide!");
                        return;
                    }
                    if (Allround.IsStateFaction(killer))
                    {
                        if (player.Reallife.WantedStars > 0)
                        {
                            FraktionsKassen fkasse = Database.GetFactionStats(Constants.FactionLspd);
                            if (killer.VnxGetElementData<int>(EntityData.PlayerOnDuty) != 1) return;
                            Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + player.Reallife.WantedStars * 400, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                            player.Reallife.PrisonTime = player.Reallife.WantedStars * 6;
                            string translatedText = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, "You have");
                            string translatedText1 = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, "arrested for");
                            string translatedText2 = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, "Minute away!");
                            string translatedText3 = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, "$ will be transferred to your bank account.");
                            killer.SendChatMessage("{007d00}" + translatedText + " " + player.CharacterUsername + " " + translatedText1 + " " + player.Reallife.PrisonTime + " " + translatedText2 + player.Reallife.WantedStars * 75 + translatedText3);

                            string translatedText4 = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, " hat dich eingesperrt für ");
                            player.SendTranslatedChatMessage("{000096}Officer " + killer.CharacterUsername + translatedText4 + player.Reallife.PrisonTime + " " + translatedText2);
                            killer.Reallife.Bank += (player.Reallife.WantedStars * 75);
                            Logfile.WriteLogs("kill", "[WANTED] Officer " + killer.Name + " killed " + player.CharacterUsername + "!");
                            player.Reallife.WantedStars = 0;
                            VnX.RemoveAllWeapons(player);
                        }
                        else
                        {
                            killer.SendTranslatedChatMessage("You killed a civilian!");
                            string translatedText = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, " hat dich getötet.");
                            player.SendTranslatedChatMessage(killer.CharacterUsername + " " + translatedText);
                            Logfile.WriteLogs("kill", "Officer " + killer.CharacterUsername + " killed " + player.CharacterUsername + " without Wanteds!");
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
                    string killedMsg = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, "You killed");
                    string killedInfoMsg = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)killer.Language, "Killed you.");

                    killer.SendChatMessage(killedMsg + player.CharacterUsername + "!");
                    player.SendChatMessage(killer.CharacterUsername + killedInfoMsg);
                    Logfile.WriteLogs("kill", killer.CharacterUsername + " killed " + player.CharacterUsername + "!");
                }
                player.SendTranslatedChatMessage(Constants.RgbaError + "You died! Wait 120 seconds or for a medic.");

            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchExceptions(ex);
            }
        }
    }
}
