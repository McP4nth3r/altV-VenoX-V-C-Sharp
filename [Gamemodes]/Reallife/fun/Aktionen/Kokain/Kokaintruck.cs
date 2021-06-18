using System;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Chat;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.chat;
using VenoXV.Reallife.Fun.Aktionen;
using Main = VenoXV._Globals_.Main;

namespace VenoXV._Gamemodes_.Reallife.Fun
{
    public class Kokaintruck : IScript
    {
        public static ColShapeModel KokaintruckCol = RageApi.CreateColShapeSphere(new Position(-1265.874f, -3432.416f, 1.5f), 1.5f);
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("Kokaintruck [Illegal]", new Vector3(-1265.874f, -3432.416f, 13.5f), 318, 27, true);
            RageApi.CreateBlip("Waffentruck [Illegal]", new Vector3(2854.921f, 1501.922f, 24.77632f), 318, 1, true);
        }


        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == KokaintruckCol)
                {
                    if (VenoXV.Reallife.factions.Allround.IsBadFaction(player))
                    {
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 200) + "[Kokaintruck] : " + RageApi.GetHexColorcode(255, 255, 255) + "Jo... Willst du dir paar gramm Kokain dazu verdienen?");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 200) + "[Kokaintruck] : " + RageApi.GetHexColorcode(255, 255, 255) + "nutze /kokaintruck [Zahl] um einen Kokaintruck zu starten! Maximal 1000 G");
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 200) + "[Kokaintruck] : " + RageApi.GetHexColorcode(255, 255, 255) + "Bist du in einer Gang? Nein? Dann verzieh dich.");
                    }
                }
                else if (shape.AktionCol == Allround.ActionKokaintruck)
                {
                    if (VenoXV.Reallife.factions.Allround.IsBadFaction(player))
                    {
                        if (player.IsInVehicle)
                        {
                            VehicleModel vehClass = (VehicleModel)player.Vehicle;

                            if (vehClass.Reallife.ActionVehicle)
                            {
                                int koksimfahrzeug = vehClass.Reallife.Koks;
                                player.Inventory.GiveItem(Constants.ItemHashKoks, ItemType.Drugs, vehClass.Reallife.Koks, true);
                                // Add the item into the database
                                foreach (VnXPlayer otherplayers in Main.ReallifePlayers.ToList()) otherplayers.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 200, 200) + "[Illegal]: Der Kokaintruck wurde abgegeben!");

                                player.WarpOutOfVehicle();
                                Allround.DestroyTargetMarker();
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

        [Command("kokaintruck")]
        public void StartKokaintruck(VnXPlayer player, int koks)
        {
            try
            {
                if (VenoXV.Reallife.factions.Allround.IsBadFaction(player))
                {
                    if (player.Position.Distance(new Position(-1265.874f, -3432.416f, 14)) > 2.5f) { player.SendTranslatedChatMessage("[Kokaintruck] : Du bist hier Falsch..."); return; }
                    if (koks > 1000) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(125, 0, 0) + "Maximal nur 1000 G möglich!"); return; }
                    int kokskosten = koks * 15;
                    if (player.Reallife.Money < kokskosten) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Du hast nicht genug geld! für " + koks + " G Kokain brauchst du " + kokskosten + " $"); return; }
                    if (!Allround.StartAction(player) || koks <= 0) return;
                    ReallifeChat.SendReallifeMessageToAll(RageApi.GetHexColorcode(175, 0, 0) + "[Illegal] : Ein Kokaintruck wurde beladen!");
                    player.SendReallifeMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast einen Kokaintruck mit " + RageApi.GetHexColorcode(0, 200, 255) + " " + koks + "g " + RageApi.GetHexColorcode(255, 255, 255) + "Kokain für " + RageApi.GetHexColorcode(0, 200, 255) + " " + kokskosten + " " + RageApi.GetHexColorcode(255, 255, 255) + "$ gestartet.");
                    player.Reallife.Money -= kokskosten;
                    VehicleModel kt = Allround.CreateActionVehicle(player, AltV.Net.Enums.VehicleModel.Pounder, new Position(-1249.692f, -3437.256f, 13.94016f), new Rotation(0, 0, 0), true);
                    kt.Reallife.Koks = koks;
                    Allround.CreateTargetMarker("Kokaintruck - Abgabe", new Position(2536.999f, 2578.391f, 38), 315, 59, false, Allround.ActionKokaintruck);
                    player.DrawWaypoint(2536.999f, 2578.391f);
                }
                else
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(125, 0, 0) + "[Kokaintruck] : Du bist kein Mitglied einer Bösen Fraktion!");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
