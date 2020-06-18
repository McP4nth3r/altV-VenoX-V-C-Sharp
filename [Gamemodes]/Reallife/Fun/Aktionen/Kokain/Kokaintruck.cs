using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Numerics;
using System.Timers;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Anti_Cheat;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun
{
    public class Kokaintruck : IScript
    {
        public static ColShapeModel Kokaintruck_Col = RageAPI.CreateColShapeSphere(new Position(-1265.874f, -3432.416f, 1.5f), 1.5f);
        static Timer KTTimer = new Timer();

        public static void OnResourceStart()
        {
            Core.RageAPI.CreateBlip("Kokaintruck [Illegal]", new Vector3(-1265.874f, -3432.416f, 13.5f), 318, 27, true);
            Core.RageAPI.CreateBlip("Waffentruck [Illegal]", new Vector3(2854.921f, 1501.922f, 24.77632f), 318, 1, true);
        }


        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == Kokaintruck_Col.Entity)
                {
                    if (Factions.Allround.isBadFaction(player))
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 200) + "[Kokaintruck] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Jo... Willst du dir paar gramm Kokain dazu verdienen?");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 200) + "[Kokaintruck] : " + RageAPI.GetHexColorcode(255, 255, 255) + "nutze /kokaintruck [Zahl] um einen Kokaintruck zu starten! Maximal 1000 G");
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 200) + "[Kokaintruck] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Bist du in einer Gang? Nein? Dann verzieh dich.");
                    }
                }
                else if (shape.vnxGetElementData<bool>("AKTION_COL") == true)
                {
                    if (Factions.Allround.isBadFaction(player))
                    {
                        if (player.IsInVehicle)
                        {
                            if (player.Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                            {
                                int koksimfahrzeug = player.Vehicle.vnxGetElementData<int>(EntityData.PLAYER_KOKS);
                                ItemModel KOKS = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                                if (KOKS == null) // WEED
                                {
                                    KOKS = new ItemModel();
                                    KOKS.amount = koksimfahrzeug;
                                    KOKS.dimension = 0;
                                    KOKS.position = new Position(0.0f, 0.0f, 0.0f);
                                    KOKS.hash = Constants.ITEM_HASH_KOKS;
                                    KOKS.ownerIdentifier = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                                    KOKS.ITEM_ART = "Drogen";
                                    KOKS.objectHandle = null;

                                    // Add the item into the database
                                    KOKS.id = Database.AddNewItem(KOKS);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(KOKS);
                                }
                                else
                                {
                                    KOKS.amount += koksimfahrzeug;
                                    // Update the amount into the database
                                    Database.UpdateItem(KOKS);
                                }
                                Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                                Allround.ChangeAktionsState(false);
                                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 200, 200) + "[Illegal]: Der Kokaintruck wurde abgegeben!");
                                player.WarpOutOfVehicle<bool>();
                                player.Vehicle.Remove();
                                Alt.RemoveColShape(shape);
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                                {
                                    if (Factions.Allround.isBadFaction(target) || Factions.Allround.isStateFaction(target))
                                    {
                                        dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    }
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage("Du bist nicht im Kokaintruck!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage("Du bist nicht im Kokaintruck!");
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static IVehicle Kokaintruckveh { get; set; }

        [Command("kokaintruck")]
        public void StartKokaintruck(Client player, int koks)
        {
            try
            {
                if (koks <= 1)
                {
                    return;
                }
                if (Factions.Allround.isBadFaction(player))
                {
                    int cops = 0;
                    foreach (Client Spieler in VenoXV.Globals.Main.ReallifePlayers)
                    {
                        if (Factions.Allround.isStateFaction(Spieler))
                        {
                            cops += 1;
                        }
                    }

                    if (cops < 3)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Nicht genug Cops Online!");
                        return;
                    }
                    if (Allround.AktionAmLaufen(player))
                    {
                        return;
                    }
                    else if (Allround.isAktionPossible(player) == false)
                    {
                        return;
                    }
                    else if (koks > 1000)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "Maximal nur 1000 G möglich!");
                        return;
                    }
                    else
                    {
                        int playermoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                        int kokskosten = koks * 15;
                        if (player.Position.Distance(new Position(-1265.874f, -3432.416f, 14)) > 2.5f)
                        {
                            player.SendTranslatedChatMessage("[Kokaintruck] : Du bist hier Falsch...");
                            return;
                        }
                        if (playermoney < kokskosten)
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Du hast nicht genug geld! für " + koks + " G Kokain brauchst du " + kokskosten + " $");
                            return;
                        }
                        AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                        Allround.ChangeAktionsState(true);
                        ColShapeModel Kokaintruck_Col_Abgabe = RageAPI.CreateColShapeSphere(new Position(2536.999f, 2578.391f, 0), 3f);
                        Kokaintruck_Col_Abgabe.vnxSetElementData("AKTION_COL", true);
                        RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(175, 0, 0) + "[Illegal] : Ein Kokaintruck wurde beladen!");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast einen Kokaintruck mit " + RageAPI.GetHexColorcode(0, 200, 255) + " " + koks + "g " + RageAPI.GetHexColorcode(255, 255, 255) + "Kokain für " + RageAPI.GetHexColorcode(0, 200, 255) + " " + kokskosten + " " + RageAPI.GetHexColorcode(255, 255, 255) + "$ gestartet.");
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - kokskosten);

                        VehicleModel Kokaintruckveh = (VehicleModel)AltV.Net.Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Pounder, new Position(-1249.692f, -3437.256f, 13.94016f), new Rotation(0, 0, 0));
                        //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Kokaintruckveh, -1);

                        Kokaintruckveh.SetSyncedMetaData("AKTIONS_FAHRZEUG", true);

                        Kokaintruckveh.EngineOn = true;
                        Kokaintruckveh.Kms = 0;
                        Kokaintruckveh.Gas = 100;
                        Kokaintruckveh.SetSyncedMetaData(EntityData.PLAYER_KOKS, koks);
                        Kokaintruckveh.Save = false;
                        foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                        {
                            if (Factions.Allround.isBadFaction(target) || Factions.Allround.isStateFaction(target))
                            {
                                dxLibary.VnX.DrawZielBlip(target, "Kokaintruck - Abgabe", new Position(2536.999f, 2578.391f, 38), 315, 59, 0);
                            }
                        }
                        dxLibary.VnX.DrawWaypoint(player, 2536.999f, 2578.391f);

                        KTTimer.Elapsed += new ElapsedEventHandler(ChangeActionStateKT);
                        KTTimer.Interval = 20 * 60000;
                        KTTimer.Enabled = true;
                    }
                }
                else
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "[Kokaintruck] : Du bist kein Mitglied einer Bösen Fraktion!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION StartKokaintruck] " + ex.Message);
                Console.WriteLine("[EXCEPTION StartKokaintruck] " + ex.StackTrace);
            }
        }


        public static void ChangeActionStateKT(object unused, ElapsedEventArgs e)
        {
            KTTimer.Stop();
            foreach (VehicleModel Vehicle in Alt.GetAllVehicles())
            {
                if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 200, 0) + "Der Kokaintruck wurde wegen Zeitüberschreitung zerstört!");
                    Kokaintruckveh.Remove();
                }
            }
        }
    }
}
