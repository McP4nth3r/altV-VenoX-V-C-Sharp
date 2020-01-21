using AltV.Net.Elements.Entities;
using System;
using System.Text;
using System.Threading.Tasks;
using VenoXV.Reallife.business;
using VenoXV.Reallife.database;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using System.Collections.Generic;
using VenoXV.Anti_Cheat;
using System.Timers;
using AltV.Net.Resources.Chat.Api;
using AltV.Net;
using AltV.Net.Data;
using VenoXV.Reallife.Core;

namespace VenoXV.Reallife.Fun
{
    public class Kokaintruck : IScript
    {
        public static IColShape Kokaintruck_Col = Alt.CreateColShapeSphere(new Position(-1265.874f, -3432.416f, 1.5f), 1.5f);
        static Timer KTTimer = new Timer();

        public static void OnResourceStart()
        {
           /* Blip KokaintruckBlip = NAPI.Blip.CreateBlip(new Position(-1265.874, -3432.416, 13.5));
            KokaintruckBlip.Name = "Kokaintruck [Illegal]";
            KokaintruckBlip.ShortRange = true;
            KokaintruckBlip.Sprite = 318;
            KokaintruckBlip.Rgba = 27;

            Blip WWTBlip = NAPI.Blip.CreateBlip(new Position(2854.921, 1501.922, 24.77632));
            WWTBlip.Name = "Waffentruck [Illegal]";
            WWTBlip.ShortRange = true;
            WWTBlip.Sprite = 318;
            WWTBlip.Rgba = 1;*/
        }


        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == Kokaintruck_Col)
                {
                    if (factions.Allround.isBadFaction(player))
                    {
                        player.SendChatMessage( "!{150,0,200}[Kokaintruck] : !{255,255,255}Jo... Willst du dir paar gramm Kokain dazu verdienen?");
                        player.SendChatMessage( "!{150,0,200}[Kokaintruck] : !{255,255,255}nutze /kokaintruck [Zahl] um einen Kokaintruck zu starten! Maximal 1000 G");
                    }
                    else
                    {
                        player.SendChatMessage( "!{150,0,200}[Kokaintruck] : !{255,255,255}Bist du in einer Gang? Nein? Dann verzieh dich.");
                    }
                }
                else if (shape.vnxGetElementData<bool>("AKTION_COL") == true)
                {
                    if (factions.Allround.isBadFaction(player))
                    {
                        if (player.IsInVehicle)
                        {
                            if (player.Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                            {
                                int koksimfahrzeug = player.Vehicle.vnxGetElementData<int>(EntityData.PLAYER_KOKS);
                                ItemModel KOKS = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                                if (KOKS == null) // WEED
                                {
                                    KOKS = new ItemModel();
                                    KOKS.amount = koksimfahrzeug;
                                    KOKS.dimension = 0;
                                    KOKS.position = new Position(0.0f, 0.0f, 0.0f);
                                    KOKS.hash = Constants.ITEM_HASH_KOKS;
                                    KOKS.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                                    KOKS.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                                    KOKS.ITEM_ART = "Drogen";
                                    KOKS.objectHandle = null;

                                    // Add the item into the database
                                    KOKS.id = Database.AddNewItem(KOKS);
                                        Main.itemList.Add(KOKS);
                                }
                                else
                                {
                                    KOKS.amount += koksimfahrzeug;
                                    // Update the amount into the database
                                    Database.UpdateItem(KOKS);
                                }
                                Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                                Allround.ChangeAktionsState(false);
                                Reallife.Core.RageAPI.SendChatMessageToAll("!{200,200,200}[Illegal]: Der Kokaintruck wurde abgegeben!");
                                //ToDo :  Fix player.WarpOutOfIVehicle();
                                player.Vehicle.Remove();
                                AltV.Net.Alt.RemoveColShape(shape);
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                foreach (IPlayer target in Alt.GetAllPlayers())
                                {
                                    if (factions.Allround.isBadFaction(target) || factions.Allround.isStateFaction(target))
                                    {
                                        dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    }
                                }
                            }
                            else
                            {
                                player.SendChatMessage("Du bist nicht im Kokaintruck!");
                            }
                        }
                        else
                        {
                            player.SendChatMessage("Du bist nicht im Kokaintruck!");
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
        public void StartKokaintruck(IPlayer player, int koks)
        {
            try {
                if(koks <= 1)
                {
                    return;
                }
                if (factions.Allround.isBadFaction(player))
                {
                    int cops = 0;
                    foreach (IPlayer Spieler in Alt.GetAllPlayers())
                    {
                        if(factions.Allround.isStateFaction(Spieler))
                        {
                            cops += 1;
                        }
                    }

                    if (cops < 3)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Nicht genug Cops Online!");
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
                        player.SendChatMessage( "!{125,0,0}Maximal nur 1000 G möglich!");
                        return;
                    }
                    else
                    {
                        int playermoney = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);
                        int kokskosten = koks * 15;
                        if (player.Position.Distance(new Position(-1265.874f, -3432.416f, 14)) > 2.5f)
                        {
                            player.SendChatMessage( "[Kokaintruck] : Du bist hier Falsch...");
                            return;
                        }
                        if (playermoney < kokskosten)
                        {
                            player.SendChatMessage( "!{175,0,0}Du hast nicht genug geld! für " + koks + " G Kokain brauchst du " + kokskosten + " $");
                            return;
                        }
                        AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                        Allround.ChangeAktionsState(true);
                        IColShape Kokaintruck_Col_Abgabe = Alt.CreateColShapeSphere(new Position(2536.999f, 2578.391f, 0), 3f);
                        Kokaintruck_Col_Abgabe.SetData("AKTION_COL", true);
                        Reallife.Core.RageAPI.SendChatMessageToAll("!{175,0,0}[Illegal] : Ein Kokaintruck wurde beladen!");
                        player.SendChatMessage( "!{255,255,255}Du hast einen Kokaintruck mit !{0,200,255}" + koks + "g !{255,255,255}Kokain für !{0,200,255}" + kokskosten + " !{255,255,255}$ gestartet.");
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, playermoney - kokskosten);

                        IVehicle Kokaintruckveh = AltV.Net.Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Pounder, new Position(-1249.692f, -3437.256f, 13.94016f), new Rotation(0,0,0));
                        //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Kokaintruckveh, -1);

                        Kokaintruckveh.SetSyncedMetaData("AKTIONS_FAHRZEUG", true);

                        Kokaintruckveh.EngineOn = true;
                        Kokaintruckveh.SetSyncedMetaData(EntityData.VEHICLE_MODEL, "Kokaintruck");
                        Kokaintruckveh.SetSyncedMetaData(EntityData.VEHICLE_PLATE, "KOKAINTRUCK"); ;
                        Core.VnX.IVehiclevnxSetSharedData(Kokaintruckveh, "kms", 0);
                        Core.VnX.IVehiclevnxSetSharedData(Kokaintruckveh, "gas", 100);
                        Kokaintruckveh.SetSyncedMetaData(EntityData.PLAYER_KOKS, koks);
                        Kokaintruckveh.SetSyncedMetaData(EntityData.VEHICLE_NOT_SAVED, true);
                        foreach (IPlayer target in Alt.GetAllPlayers())
                        {
                            if (factions.Allround.isBadFaction(target) || factions.Allround.isStateFaction(target))
                            {
                               dxLibary.VnX.DrawZielBlip(target, "Kokaintruck - Abgabe", new Position(2536.999f, 2578.391f, 38), 315, 59, 0);
                            }
                        }
                        dxLibary.VnX.DrawWaypoint(player, 2536.999f, 2578.391f);

                        KTTimer.Elapsed += new ElapsedEventHandler(ChangeActionStateKT);
                        KTTimer.Interval = 20*60000;
                        KTTimer.Enabled = true;
                    }
                }
                else
                {
                    player.SendChatMessage( "!{125,0,0}[Kokaintruck] : Du bist kein Mitglied einer Bösen Fraktion!");
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION StartKokaintruck] " + ex.Message);
                Alt.Log("[EXCEPTION StartKokaintruck] " + ex.StackTrace);
            }
        }


        public static void ChangeActionStateKT(object unused, ElapsedEventArgs e)
        {
            KTTimer.Stop();
            foreach (IVehicle Vehicle in Alt.GetAllVehicles())
            {
                if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    Reallife.Core.RageAPI.SendChatMessageToAll("!{0,200,0}Der Kokaintruck wurde wegen Zeitüberschreitung zerstört!");
                    Kokaintruckveh.Remove();
                }
            }
        }
    }
}
