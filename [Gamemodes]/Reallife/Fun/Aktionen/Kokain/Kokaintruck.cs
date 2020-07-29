using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Chat;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun
{
    public class Kokaintruck : IScript
    {
        public static ColShapeModel Kokaintruck_Col = RageAPI.CreateColShapeSphere(new Position(-1265.874f, -3432.416f, 1.5f), 1.5f);
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
                else
                {
                    if (Factions.Allround.isBadFaction(player))
                    {
                        if (player.IsInVehicle)
                        {
                            VehicleModel vehClass = (VehicleModel)player.Vehicle;

                            if (vehClass.Reallife.ActionVehicle)
                            {
                                int koksimfahrzeug = vehClass.Reallife.Koks;
                                ItemModel KOKS = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_KOKS);
                                if (KOKS == null) // WEED
                                {
                                    KOKS = new ItemModel
                                    {
                                        amount = koksimfahrzeug,
                                        dimension = 0,
                                        position = new Position(0.0f, 0.0f, 0.0f),
                                        hash = Constants.ITEM_HASH_KOKS,
                                        ownerIdentifier = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID),
                                        ITEM_ART = "Drogen",
                                        objectHandle = null
                                    };

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

                                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 200, 200) + "[Illegal]: Der Kokaintruck wurde abgegeben!");
                                player.WarpOutOfVehicle();
                                player.Vehicle.Remove();
                                Alt.RemoveColShape(shape);
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers.ToList())
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
                if (Factions.Allround.isBadFaction(player))
                {
                    if (!Fun.Allround.StartAction(player, 3)) { return; }
                    if (koks <= 1) { return; }
                    if (player.Position.Distance(new Position(-1265.874f, -3432.416f, 14)) > 2.5f) { player.SendTranslatedChatMessage("[Kokaintruck] : Du bist hier Falsch..."); return; }
                    if (koks > 1000) { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "Maximal nur 1000 G möglich!"); return; }
                    int kokskosten = koks * 15;
                    if (player.Reallife.Money < kokskosten) { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Du hast nicht genug geld! für " + koks + " G Kokain brauchst du " + kokskosten + " $"); return; }

                    ReallifeChat.SendReallifeMessageToAll(RageAPI.GetHexColorcode(175, 0, 0) + "[Illegal] : Ein Kokaintruck wurde beladen!");
                    player.SendReallifeMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast einen Kokaintruck mit " + RageAPI.GetHexColorcode(0, 200, 255) + " " + koks + "g " + RageAPI.GetHexColorcode(255, 255, 255) + "Kokain für " + RageAPI.GetHexColorcode(0, 200, 255) + " " + kokskosten + " " + RageAPI.GetHexColorcode(255, 255, 255) + "$ gestartet.");
                    player.Reallife.Money -= kokskosten;
                    Allround.CreateActionVehicle(player, AltV.Net.Enums.VehicleModel.Pounder, new Position(-1249.692f, -3437.256f, 13.94016f), new Rotation(0, 0, 0), true);
                    Allround.CreateTargetMarker("Kokaintruck - Abgabe", new Position(2536.999f, 2578.391f, 38), 315, 59, false, Allround.ACTION_KOKAINTRUCK);
                    player.DrawWaypoint(2536.999f, 2578.391f);
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
    }
}
