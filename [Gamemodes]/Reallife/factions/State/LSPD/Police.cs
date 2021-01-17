//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Chat;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.factions.State.LSPD;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Police : IScript
    {

        [Command("zeigen")]
        public static void ShowToPlayerLicense(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string Lizenzen = "";
                    if (player.Reallife.Autofuehrerschein == 1) { Lizenzen += Lizenzen + " Führerschein  [ ✔ ]"; }
                    else { Lizenzen += " Führerschein  [ ✘ ]"; }

                    if (player.Reallife.Motorradfuehrerschein == 1) { Lizenzen += Lizenzen + " Motorradschein  [ ✔ ]"; }
                    else { Lizenzen += " Motorradschein  [ ✘ ]"; }

                    if (player.Reallife.LKWfuehrerschein == 1) { Lizenzen += Lizenzen + " LKW-Führerschein  [ ✔ ]"; }
                    else { Lizenzen += " LKW-Führerschein  [ ✘ ]"; }

                    if (player.Reallife.Waffenschein == 1) { Lizenzen += Lizenzen + " Waffenschein  [ ✔ ]"; }
                    else { Lizenzen += " Waffenschein  [ ✘ ]"; }

                    if (player.Reallife.Motorbootschein == 1) { Lizenzen += Lizenzen + " Bootsführerschein  [ ✔ ]"; }
                    else { Lizenzen += " Bootsführerschein  [ ✘ ]"; }

                    if (player.Reallife.FlugscheinKlasseA == 1) { Lizenzen += Lizenzen + " Flugschein A  [ ✔ ]"; }
                    else { Lizenzen += " Flugschein A  [ ✘ ]"; }

                    if (player.Reallife.FlugscheinKlasseB == 1) { Lizenzen += Lizenzen + " Flugschein B  [ ✔ ]"; }
                    else { Lizenzen += Lizenzen + " Flugschein B  [ ✘ ]"; }

                    if (player.Reallife.Helikopterfuehrerschein == 1) { Lizenzen = Lizenzen + " Helikopterschein  [ ✔ ]"; }
                    else { Lizenzen += " Helikopterschein  [ ✘ ]"; }

                    if (player.Reallife.Angelschein == 1) { Lizenzen += " Angelschein  [ ✔ ]"; }
                    else { Lizenzen += Lizenzen + " Angelschein  [ ✘ ]"; }

                    player.SendReallifeMessage("Du hast " + target.Username + " deine Lizenzen gezeigt!");
                    target.SendReallifeMessage(RageAPI.GetHexColorcode(200, 0, 200) + "Vorhandene Lizenzen von " + player.Username + " : " + RageAPI.GetHexColorcode(200, 200, 0) + " Lizenzen");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zu weit von " + target.Username + " entfernt!");
                }
            }
            catch { }
        }


        [Command("frisk")]
        public static void FriskPlayer(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.Username + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                    ItemModel KOKS = Main.GetPlayerItemModelFromHash(target, Constants.ITEM_HASH_KOKS);
                    ItemModel WEED = Main.GetPlayerItemModelFromHash(target, Constants.ITEM_HASH_WEED);
                    ItemModel MATS = Main.GetPlayerItemModelFromHash(target, Constants.ITEM_HASH_MATS);
                    int kokain = 0;
                    int mats = 0;
                    int weed = 0;
                    if (KOKS != null)
                    {
                        kokain = KOKS.Amount;
                    }
                    if (WEED != null)
                    {
                        weed = WEED.Amount;
                    }
                    if (MATS != null)
                    {
                        mats = MATS.Amount;
                    }

                    player.SendTranslatedChatMessage(inventory + "Materials: " + mats + " Stk, Kokain: " + kokain + "g , Drogen: " + weed + "g");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " hat dich durchsucht!");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zu weit von " + target.Username + " entfernt!");
                }
            }
            catch
            {
            }
        }

        [Command("takeillegal")]
        public static void Takeillegal(VnXPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                    {
                        if (player.Position.Distance(target.Position) < 5)
                        {
                            string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.Username + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                            ItemModel KOKS = Main.GetPlayerItemModelFromHash(target, Constants.ITEM_HASH_KOKS);
                            ItemModel WEED = Main.GetPlayerItemModelFromHash(target, Constants.ITEM_HASH_WEED);
                            ItemModel MATS = Main.GetPlayerItemModelFromHash(target, Constants.ITEM_HASH_MATS);
                            if (KOKS != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(KOKS.Id);
                                _Globals_.Inventory.Inventory.DatabaseItems.Remove(KOKS);
                            }
                            if (WEED != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(WEED.Id);
                                _Globals_.Inventory.Inventory.DatabaseItems.Remove(WEED);
                            }
                            if (MATS != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(MATS.Id);
                                _Globals_.Inventory.Inventory.DatabaseItems.Remove(MATS);
                            }

                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " hat dir deine Illegalen Gegenstaende abgenommen!");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Du hast " + target.Username + " seine Illegalen Gegenstaende abgenommen!");
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zu weit von " + target.Username + " entfernt!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht im Dienst!!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Staatsfraktionist!");
                }
            }
            catch
            {
            }
        }


        [Command("ausknasten")]
        public void RemovePlayerFromKnast(VnXPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) return;
                if (player.Reallife.FactionRank >= 3)
                {
                    if (target.Reallife.Knastzeit > 0)
                    {
                        //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                        target.Reallife.Knastzeit = 0;
                        target.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                        target.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        target.Freeze = false;
                        RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 105, 145) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat " + target.Username + " ausgeknastet.");
                    }
                }
                else
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab Rank 3 verfügbar!");
            }
            catch { }
        }


        private static List<WantedModel> WantedList = new List<WantedModel>
        {
            // 1 Stars
            new WantedModel("körperverletzung",                     1,  new string[]{ "kpv" },      "Körperverletzung"),
            new WantedModel("beamtenbehinderung",                   1,  new string[]{ "behind" },   "Beamtenbehinderung"),
            new WantedModel("beamtenbelästigung",                   1,  new string[]{ "beläst" },   "Beamtenbelästigung"),
            new WantedModel("beleidigung",                          1,  new string[]{ "belei" },    "Beleidigung"),
            new WantedModel("flucht vor kontrolle",                 1,  new string[]{ "vkk" },      "Flucht vor/aus Kontrolle"),
            new WantedModel("diebstahl",                            1,  new string[]{ "dieb" },     "Diebstahl"),
            new WantedModel("versuchter diebstahl",                 1,  new string[]{ "vdieb" },    "Versuchter Diebstahl"),
            new WantedModel("sachbeschädigung",                     1,  new string[]{ "sb" },       "Sachbeschädigung"),
            new WantedModel("illegale werbung",                     1,  new string[]{ "werb" },     "Illegale Werbung"),
            new WantedModel("illegales straßenrennen",              1,  new string[]{ "rennen" },   "Illegales straßenrennen"),
            new WantedModel("vortäuschen falscher tatsachen",       1,  new string[]{ "tat" },      "Vortäuschen falscher Tatsachen"),
            new WantedModel("fahren ohne fahrerlaubnis",            1,  new string[]{ "fof" },      "Fahren ohne Fahrerlaubnis"),
            new WantedModel("drogenbesitz1",                        1,  new string[]{ "drug1" },    "Drogenbesitz (10 - 49g)"),
            new WantedModel("kokainbesitz1",                        1,  new string[]{ "koks1" },    "Koksinbesitz (10 - 49g)"),
            new WantedModel("matsbesitz1",                          1,  new string[]{ "mats1" },    "Matsbesitz (10 - 49Stk.)"),

            // 2 Stars
            new WantedModel("verweigerung der durchsuchung",        2,  new string[]{ "verweig" },  "Verweigerung der Durchsuchung"),
            new WantedModel("schusswaffengebrauch",                 2,  new string[]{ "waffe" },    "Schusswaffengebrauch"),
            new WantedModel("körperverletzung durch schusswaffen",  2,  new string[]{ "kpvs" },     "Körperverletzung durch Schusswaffen"),
            new WantedModel("herstellung illegaler gegenstände",    2,  new string[]{ "btm" },      "Herstellung illegaler gegenstände"),
            new WantedModel("drogenkonsum",                         2,  new string[]{ "konsum" },   "Drogenkonsum"),
            new WantedModel("raubüberfall",                         2,  new string[]{ "raub" },     "Raubüberfall"),
            new WantedModel("bestechungsversuch",                   2,  new string[]{ "stech" },    "Bestechungsversuch"),
            new WantedModel("waffenverkauf",                        2,  new string[]{ "verkauf" },  "Waffenverkauf"),
            new WantedModel("carrob",                               2,  new string[]{ "cr" },       "Carrob"),
            new WantedModel("drogenbesitz2",                        2,  new string[]{ "drug2" },    "Drogenbesitz (50 - 149g)"),
            new WantedModel("kokainbesitz2",                        2,  new string[]{ "koks2" },    "Koksinbesitz (50 - 149g)"),
            new WantedModel("matsbesitz2",                          2,  new string[]{ "mats2" },    "Matsbesitz (50 - 149Stk.)"),

            // 3 Stars 
            new WantedModel("mord",                                 3,  new string[]{},             "Mord"),
            new WantedModel("betreten von sperrzonen",              3,  new string[]{ "sperr" },    "Betreten von Sperrzonen"),
            new WantedModel("beihilfe zur freiheitsberaubung",      3,  new string[]{ "beraub" },   "Beihilfe zur Freiheitsberaubung"),
            new WantedModel("drogentruck",                          3,  new string[]{ "dt" },       "Drogentruck (und Beihilfe)"),
            new WantedModel("kokaintruck",                          3,  new string[]{ "kt" },       "Kokaintruck (und Beihilfe)"),
            new WantedModel("matstruck",                            3,  new string[]{ "mt" },       "Matstruck (und Beihilfe)"),
            new WantedModel("waffentruck",                          3,  new string[]{ "wt" },       "Waffentruck (und Beihilfe)"),
            new WantedModel("drogenbesitz3",                        3,  new string[]{ "drug3" },    "Drogenbesitz (150g und mehr)"),
            new WantedModel("kokainbesitz3",                        3,  new string[]{ "koks3" },    "Koksinbesitz (150g und mehr)"),
            new WantedModel("matsbesitz3",                          3,  new string[]{ "mats3" },    "Matsbesitz (150 Stk. und mehr)"),

            // 4 Stars
            new WantedModel("bankraub",                             4,  new string[]{ "br" },       "Bankraub (und Beihilfe)"),
            new WantedModel("geiselnahme",                          4,  new string[]{ "geisel" },   "Geiselnahme (und Beihilfe)"),

            // 6 Stars
            new WantedModel("einbruch beim fib",                    4,  new string[]{ "fib" },      "Einbruch beim FIB"),
            new WantedModel("einbruch beim lspd",                   4,  new string[]{ "pd" },       "Einbruch beim LSPD"),
        };
        private static Dictionary<string, WantedModel> _wantedModelByCommand = new Dictionary<string, WantedModel>();
        public static void AddToWantedDictionary()
        {
            foreach (WantedModel wanted in WantedList)
            {
                _wantedModelByCommand[wanted.Reason] = wanted;
                foreach (var str in wanted.ShortReasons)
                    _wantedModelByCommand[str] = wanted;
            }
        }

        [Command("su", aliases: new string[] { "suspect" })]
        public static void GivePlayerStars(VnXPlayer player, string targetName, params string[] actionArr)
        {
            try
            {
                //Debug.OutputDebugString("Called WantedFunktion with : " + targetName + " | " + action);
                if (Allround.isStateFaction(player) == false) { player.SendTranslatedChatMessage("Du bist kein Staatsfraktionist!"); return; }
                VnXPlayer target = RageAPI.GetPlayerFromName(targetName);
                if (target is null) { target.SendReallifeMessage(RageAPI.GetHexColorcode(175, 0, 0) + targetName + " ist nicht Online/Wurde nicht gefunden."); return; }
                if (target.Playing && target.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    string action = string.Join(" ", actionArr);
                    action = action.ToLower();
                    if (!_wantedModelByCommand.TryGetValue(action, out WantedModel wantedClass))
                    {
                        player.SendReallifeMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Grund wurde nicht gefunden! Dein Grund war : " + action);
                        return;
                    }
                    target.Reallife.Wanteds = Math.Min(6, target.Reallife.Wanteds + wantedClass.Wanteds);
                    target.SendReallifeMessage(Core.RageAPI.GetHexColorcode(255, 255, 0) + "Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedClass.Description); ;
                    foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers())
                    {
                        if (Allround.isStateFaction(targetsingame))
                        {
                            targetsingame.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat das Fahndungslevel von " + target.Username + " erhöht auf " + target.Reallife.Wanteds + "! Grund: " + wantedClass.Description);
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist nicht in Reallife online.");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [Command("clear", true)]
        public void Clearuserwanteds(VnXPlayer player, string targetName)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                VnXPlayer target = RageAPI.GetPlayerFromName(targetName);
                if (target is null) { target.SendReallifeMessage(RageAPI.GetHexColorcode(175, 0, 0) + targetName + " ist nicht Online/Wurde nicht gefunden."); return; }
                if (target.Playing && target.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    if (target.Reallife.Wanteds == 0) player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");
                    else
                    {
                        target.Reallife.Wanteds = 0;
                        target.SendTranslatedChatMessage("{007d00}Officer " + player.Username + " hat deine Akte Gelöscht!");

                        foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers())
                        {
                            if (Allround.isStateFaction(targetsingame))
                            {
                                targetsingame.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat die Akte von " + target.Username + " Gelöscht!");
                            }
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist nicht in Reallife online.");
                }
            }
            catch { }
        }
    }
}