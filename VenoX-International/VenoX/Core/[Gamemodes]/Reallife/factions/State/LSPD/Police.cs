//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using System;
using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.chat;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Globals_;
using VenoX.Core._Preload_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using EntityData = VenoX.Core._Gamemodes_.Reallife.globals.EntityData;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;

namespace VenoX.Core._Gamemodes_.Reallife.factions.State.LSPD
{
    public class Police : IScript
    {

        [Command("zeigen")]
        public static void ShowToPlayerLicense(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string lizenzen = "";
                    if (player.Reallife.DrivingLicense == 1) { lizenzen += lizenzen + " Führerschein  [ ✔ ]"; }
                    else { lizenzen += " Führerschein  [ ✘ ]"; }

                    if (player.Reallife.BikeDrivingLicense == 1) { lizenzen += lizenzen + " Motorradschein  [ ✔ ]"; }
                    else { lizenzen += " Motorradschein  [ ✘ ]"; }

                    if (player.Reallife.TruckDrivingLicense == 1) { lizenzen += lizenzen + " LKW-Führerschein  [ ✔ ]"; }
                    else { lizenzen += " LKW-Führerschein  [ ✘ ]"; }

                    if (player.Reallife.WeaponLicense == 1) { lizenzen += lizenzen + " Waffenschein  [ ✔ ]"; }
                    else { lizenzen += " Waffenschein  [ ✘ ]"; }

                    if (player.Reallife.MotorBoatDrivingLicense == 1) { lizenzen += lizenzen + " Bootsführerschein  [ ✔ ]"; }
                    else { lizenzen += " Bootsführerschein  [ ✘ ]"; }

                    if (player.Reallife.FlyLicenseA == 1) { lizenzen += lizenzen + " Flugschein A  [ ✔ ]"; }
                    else { lizenzen += " Flugschein A  [ ✘ ]"; }

                    if (player.Reallife.FlyLicenseB == 1) { lizenzen += lizenzen + " Flugschein B  [ ✔ ]"; }
                    else { lizenzen += lizenzen + " Flugschein B  [ ✘ ]"; }

                    if (player.Reallife.HelicopterDrivingLicense == 1) { lizenzen = lizenzen + " Helikopterschein  [ ✔ ]"; }
                    else { lizenzen += " Helikopterschein  [ ✘ ]"; }

                    if (player.Reallife.FishingLicense == 1) { lizenzen += " Angelschein  [ ✔ ]"; }
                    else { lizenzen += lizenzen + " Angelschein  [ ✘ ]"; }

                    player.SendReallifeMessage("Du hast " + target.CharacterUsername + " deine Lizenzen gezeigt!");
                    target.SendReallifeMessage(RageApi.GetHexColorcode(200, 0, 200) + "Vorhandene Lizenzen von " + player.CharacterUsername + " : " + RageApi.GetHexColorcode(200, 200, 0) + " Lizenzen");
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist zu weit von " + target.CharacterUsername + " entfernt!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        [Command("frisk")]
        public static void FriskPlayer(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string inventory = RageApi.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.CharacterUsername + " : " + RageApi.GetHexColorcode(255, 255, 255) + "";

                    ItemModel cocaineItem = Main.GetPlayerItemModelFromHash(target, Constants.ItemHashKoks);
                    ItemModel weedItem = Main.GetPlayerItemModelFromHash(target, Constants.ItemHashWeed);
                    ItemModel matsItem = Main.GetPlayerItemModelFromHash(target, Constants.ItemHashMats);
                    int cocaine = 0;
                    int mats = 0;
                    int weed = 0;
                    if (cocaineItem != null)
                    {
                        cocaine = cocaineItem.Amount;
                    }
                    if (weedItem != null)
                    {
                        weed = weedItem.Amount;
                    }
                    if (matsItem != null)
                    {
                        mats = matsItem.Amount;
                    }

                    player.SendTranslatedChatMessage(inventory + "Materials: " + mats + " Stk, Kokain: " + cocaine + "g , Drogen: " + weed + "g");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " hat dich durchsucht!");
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist zu weit von " + target.CharacterUsername + " entfernt!");
                }
            }
            catch
            {
            }
        }

        [Command("takeillegal")]
        public static void Takeillegal(VnXPlayer player, string targetName)
        {
            try
            {
                if (factions.Allround.IsStateFaction(player))
                {
                    VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                    if (target == null) { return; }
                    if (player.VnxGetElementData<int>(EntityData.PlayerOnDuty) == 1)
                    {
                        if (player.Position.Distance(target.Position) < 5)
                        {
                            string inventory = RageApi.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.CharacterUsername + " : " + RageApi.GetHexColorcode(255, 255, 255) + "";

                            ItemModel koks = Main.GetPlayerItemModelFromHash(target, Constants.ItemHashKoks);
                            ItemModel weed = Main.GetPlayerItemModelFromHash(target, Constants.ItemHashWeed);
                            ItemModel mats = Main.GetPlayerItemModelFromHash(target, Constants.ItemHashMats);
                            if (koks != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(koks.Id);
                                Inventory.DatabaseItems.Remove(koks);
                            }
                            if (weed != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(weed.Id);
                                Inventory.DatabaseItems.Remove(weed);
                            }
                            if (mats != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(mats.Id);
                                Inventory.DatabaseItems.Remove(mats);
                            }

                            target.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " hat dir deine Illegalen Gegenstaende abgenommen!");
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Du hast " + target.CharacterUsername + " seine Illegalen Gegenstaende abgenommen!");
                        }
                        else
                        {
                            Notification.DrawNotification(player, Notification.Types.Error, "Du bist zu weit von " + target.CharacterUsername + " entfernt!");
                        }
                    }
                    else
                    {
                        Notification.DrawNotification(player, Notification.Types.Error, "Du bist nicht im Dienst!!");
                    }
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist kein Staatsfraktionist!");
                }
            }
            catch
            {
            }
        }


        [Command("ausknasten")]
        public void RemovePlayerFromKnast(VnXPlayer player, string targetName)
        {
            try
            {
                if (factions.Allround.IsStateFaction(player) == false)
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) return;
                if (player.Reallife.FactionRank >= 3)
                {
                    if (target.Reallife.PrisonTime > 0)
                    {
                        //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                        target.Reallife.PrisonTime = 0;
                        target.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                        target.Dimension = Initialize.ReallifeDimension + target.Language;
                        target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        target.Freeze = false;
                        RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 105, 145) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat " + target.CharacterUsername + " ausgeknastet.");
                    }
                }
                else
                    Notification.DrawNotification(player, Notification.Types.Error, "Erst ab Rank 3 verfügbar!");
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        private static readonly List<WantedModel> _wantedList = new List<WantedModel>
        {
            // 1 Stars
            new WantedModel("körperverletzung",                     1,  new[]{ "kpv" },      "Körperverletzung"),
            new WantedModel("beamtenbehinderung",                   1,  new[]{ "behind" },   "Beamtenbehinderung"),
            new WantedModel("beamtenbelästigung",                   1,  new[]{ "beläst" },   "Beamtenbelästigung"),
            new WantedModel("beleidigung",                          1,  new[]{ "belei" },    "Beleidigung"),
            new WantedModel("flucht vor kontrolle",                 1,  new[]{ "vkk" },      "Flucht vor/aus Kontrolle"),
            new WantedModel("diebstahl",                            1,  new[]{ "dieb" },     "Diebstahl"),
            new WantedModel("versuchter diebstahl",                 1,  new[]{ "vdieb" },    "Versuchter Diebstahl"),
            new WantedModel("sachbeschädigung",                     1,  new[]{ "sb" },       "Sachbeschädigung"),
            new WantedModel("illegale werbung",                     1,  new[]{ "werb" },     "Illegale Werbung"),
            new WantedModel("illegales straßenrennen",              1,  new[]{ "rennen" },   "Illegales straßenrennen"),
            new WantedModel("vortäuschen falscher tatsachen",       1,  new[]{ "tat" },      "Vortäuschen falscher Tatsachen"),
            new WantedModel("fahren ohne fahrerlaubnis",            1,  new[]{ "fof" },      "Fahren ohne Fahrerlaubnis"),
            new WantedModel("drogenbesitz1",                        1,  new[]{ "drug1" },    "Drogenbesitz (10 - 49g)"),
            new WantedModel("kokainbesitz1",                        1,  new[]{ "koks1" },    "Koksinbesitz (10 - 49g)"),
            new WantedModel("matsbesitz1",                          1,  new[]{ "mats1" },    "Matsbesitz (10 - 49Stk.)"),

            // 2 Stars
            new WantedModel("verweigerung der durchsuchung",        2,  new[]{ "verweig" },  "Verweigerung der Durchsuchung"),
            new WantedModel("schusswaffengebrauch",                 2,  new[]{ "waffe" },    "Schusswaffengebrauch"),
            new WantedModel("körperverletzung durch schusswaffen",  2,  new[]{ "kpvs" },     "Körperverletzung durch Schusswaffen"),
            new WantedModel("herstellung illegaler gegenstände",    2,  new[]{ "btm" },      "Herstellung illegaler gegenstände"),
            new WantedModel("drogenkonsum",                         2,  new[]{ "konsum" },   "Drogenkonsum"),
            new WantedModel("raubüberfall",                         2,  new[]{ "raub" },     "Raubüberfall"),
            new WantedModel("bestechungsversuch",                   2,  new[]{ "stech" },    "Bestechungsversuch"),
            new WantedModel("waffenverkauf",                        2,  new[]{ "verkauf" },  "Waffenverkauf"),
            new WantedModel("carrob",                               2,  new[]{ "cr" },       "Carrob"),
            new WantedModel("drogenbesitz2",                        2,  new[]{ "drug2" },    "Drogenbesitz (50 - 149g)"),
            new WantedModel("kokainbesitz2",                        2,  new[]{ "koks2" },    "Koksinbesitz (50 - 149g)"),
            new WantedModel("matsbesitz2",                          2,  new[]{ "mats2" },    "Matsbesitz (50 - 149Stk.)"),

            // 3 Stars 
            new WantedModel("mord",                                 3,  new string[]{},             "Mord"),
            new WantedModel("betreten von sperrzonen",              3,  new[]{ "sperr" },    "Betreten von Sperrzonen"),
            new WantedModel("beihilfe zur freiheitsberaubung",      3,  new[]{ "beraub" },   "Beihilfe zur Freiheitsberaubung"),
            new WantedModel("drogentruck",                          3,  new[]{ "dt" },       "Drogentruck (und Beihilfe)"),
            new WantedModel("kokaintruck",                          3,  new[]{ "kt" },       "Kokaintruck (und Beihilfe)"),
            new WantedModel("matstruck",                            3,  new[]{ "mt" },       "Matstruck (und Beihilfe)"),
            new WantedModel("waffentruck",                          3,  new[]{ "wt" },       "Waffentruck (und Beihilfe)"),
            new WantedModel("drogenbesitz3",                        3,  new[]{ "drug3" },    "Drogenbesitz (150g und mehr)"),
            new WantedModel("kokainbesitz3",                        3,  new[]{ "koks3" },    "Koksinbesitz (150g und mehr)"),
            new WantedModel("matsbesitz3",                          3,  new[]{ "mats3" },    "Matsbesitz (150 Stk. und mehr)"),

            // 4 Stars
            new WantedModel("bankraub",                             4,  new[]{ "br" },       "Bankraub (und Beihilfe)"),
            new WantedModel("geiselnahme",                          4,  new[]{ "geisel" },   "Geiselnahme (und Beihilfe)"),

            // 6 Stars
            new WantedModel("einbruch beim fib",                    4,  new[]{ "fib" },      "Einbruch beim FIB"),
            new WantedModel("einbruch beim lspd",                   4,  new[]{ "pd" },       "Einbruch beim LSPD"),
        };
        private static readonly Dictionary<string, WantedModel> _wantedModelByCommand = new Dictionary<string, WantedModel>();
        public static void AddToWantedDictionary()
        {
            foreach (WantedModel wanted in _wantedList)
            {
                _wantedModelByCommand[wanted.Reason] = wanted;
                foreach (var str in wanted.ShortReasons)
                    _wantedModelByCommand[str] = wanted;
            }
        }

        [Command("su", aliases: new[] { "suspect" })]
        public static void GivePlayerStars(VnXPlayer player, string targetName, params string[] actionArr)
        {
            try
            {
                //Debug.OutputDebugString("Called WantedFunktion with : " + targetName + " | " + action);
                if (factions.Allround.IsStateFaction(player) == false) { player.SendTranslatedChatMessage("Du bist kein Staatsfraktionist!"); return; }
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target is null) { target.SendReallifeMessage(RageApi.GetHexColorcode(175, 0, 0) + targetName + " ist nicht Online/Wurde nicht gefunden."); return; }
                if (target.Playing && target.Gamemode == (int)Preload.Gamemodes.Reallife)
                {
                    string action = string.Join(" ", actionArr);
                    action = action.ToLower();
                    if (!_wantedModelByCommand.TryGetValue(action, out WantedModel wantedClass))
                    {
                        player.SendReallifeMessage(RageApi.GetHexColorcode(175, 0, 0) + "Grund wurde nicht gefunden! Dein Grund war : " + action);
                        return;
                    }
                    target.Reallife.WantedStars = Math.Min(6, target.Reallife.WantedStars + wantedClass.Wanteds);
                    target.SendReallifeMessage(RageApi.GetHexColorcode(255, 255, 0) + "Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.WantedStars + "! Grund : " + wantedClass.Description); ;
                    foreach (VnXPlayer targetsingame in _RootCore_.VenoX.GetAllPlayers())
                    {
                        if (factions.Allround.IsStateFaction(targetsingame))
                        {
                            targetsingame.SendChatMessage(RageApi.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat das Fahndungslevel von " + target.CharacterUsername + " erhöht auf " + target.Reallife.WantedStars + "! Grund: " + wantedClass.Description);
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist nicht in Reallife online.");
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [Command("clear", true)]
        public void Clearuserwanteds(VnXPlayer player, string targetName)
        {
            try
            {
                if (factions.Allround.IsStateFaction(player) == false)
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target is null) { target.SendReallifeMessage(RageApi.GetHexColorcode(175, 0, 0) + targetName + " ist nicht Online/Wurde nicht gefunden."); return; }
                if (target.Playing && target.Gamemode == (int)Preload.Gamemodes.Reallife)
                {
                    if (target.Reallife.WantedStars == 0) player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");
                    else
                    {
                        target.Reallife.WantedStars = 0;
                        target.SendTranslatedChatMessage("{007d00}Officer " + player.CharacterUsername + " hat deine Akte Gelöscht!");

                        foreach (VnXPlayer targetsingame in _RootCore_.VenoX.GetAllPlayers())
                        {
                            if (factions.Allround.IsStateFaction(targetsingame))
                            {
                                targetsingame.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat die Akte von " + target.CharacterUsername + " Gelöscht!");
                            }
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist nicht in Reallife online.");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}