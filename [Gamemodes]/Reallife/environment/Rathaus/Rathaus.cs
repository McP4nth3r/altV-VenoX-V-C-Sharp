﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.Rathaus
{
    public class Rathaus : IScript
    {

        public static ColShapeModel RathausColShapeModel = RageAPI.CreateColShapeSphere(new Position(-548.8972f, -202.5477f, 38.30002f), 1.2f);
        //public static Marker RathausMarkerImInterior = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-546.1301, -202.6208, 38.30002), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        //public static Marker RathausMarkerEingang = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-545.3177f, -203.7145f, 38.2151f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        public static MarkerModel RathausMarkerImInterior = RageAPI.CreateMarker(0, new Vector3(-546.1301f, -202.6208f, 38.30002f), new Vector3(1, 1, 1), new int[] { 0, 150, 200, 255 });
        public static MarkerModel RathausMarkerEingang = RageAPI.CreateMarker(0, new Vector3(-545.3177f, -203.7145f, 38.2151f), new Vector3(1, 1, 1), new int[] { 0, 150, 200, 255 });

        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == RathausColShapeModel.Entity)
                {
                    string PERSO_BTN = "Personalausweis";
                    string CAR_BTN = "Führerschein";
                    string LKW_BTN = "LKW-Führerschein";
                    string BIKE_BTN = "Motorradschein";
                    string PLANE_A_BTN = "Flugschein A";
                    string PLANE_B_BTN = "Flugschein B";
                    string HELICOPTER_BTN = "Helikopterschein";
                    string BOAT_BTN = "Bootsschein";
                    string FISHER_BTN = "Angelschein";
                    string WEAPON_BTN = "Waffenschein";
                    string perso = "Der Personalausweis ist das<br> wichtigste was du bei dir<br>haben kannst, mit diesem<br> Identifizierst du dich<br>bei den Behörden. <br><br>Preis: 450$";
                    string fuehrer = "Der Führerschein wird<br>benötigt um ein Auto fahren<br>zu duerfen, solltest du<br>ohne einen Führerschein<br>erwischt wirst, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 10.500$";
                    string lkw = "Der LKW-Führerschein wird<br>benötigt um ein LKW fahren<br>zu duerfen, solltest du<br>ohne einen LKW-Führerschein<br>erwischt wirst, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 16.750$";
                    string bike = "Der Motorradschein wird<br>benötigt um ein Motorrad fahren<br>zu duerfen, solltest du<br>ohne ein Motorradschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 8.750$";
                    string fa = "Der Flugschein (A) wird<br>benötigt um kleine Flugzeuge<br>fliegen zu duerfen, solltest du<br>ohne einen Flugschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 28.250$";
                    string fb = "Der Flugschein (B) wird<br>benötigt um groessere Flugzeuge<br>fliegen zu duerfen, solltest<br>du ohne einen Flugschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 37.625$";
                    string heli = "Der Helikopterschein wird<br>benötigt um Helikopter<br>fliegen zu duerfen, solltest<br>du ohne einen Helikopterschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 25.438$";
                    string boot = "Der Bootschein wird<br>benötigt um ein Boot<br>fahren zu duerfen, solltest<br>du ohne einen Bootschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 5.220$";
                    string angel = "Der Angelschein wird<br>benötigt um Angeln<br>zu duerfen, solltest du<br>ohne einen Angelschein<br>beim Angeln erwischt<br>werden, drohen dir<br>Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 1.150$";
                    string waffen = "Der Waffenschein wird<br>benötigt um eine Waffe<br>zu besitzen, solltest du<br>ohne einen Waffenschein<br>mit einer Waffe erwischt<br>werden, drohen dir<br>Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 21.250$";
                    Alt.Server.TriggerClientEvent(player,"showRathausWindow", "Stadthalle", PERSO_BTN, CAR_BTN, LKW_BTN, BIKE_BTN, PLANE_A_BTN, PLANE_B_BTN, HELICOPTER_BTN, BOAT_BTN, FISHER_BTN, WEAPON_BTN, perso, fuehrer, lkw, bike, fa, fb, heli, boot, angel, waffen);
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_STADTHALLE);
                }
            }
            catch
            {

            }
        }

        //[AltV.Net.ClientEvent("On_Clicked_Button_Rathaus")]
        public static void OnClickedButton_Rathaus(Client player, string button)
        {
            try
            {
                if (button == "Perso")
                {
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_PERSO);
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_PERSONALAUSWEIS) == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Personalausweis!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 450)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 450);
                    player.vnxSetElementData(EntityData.PLAYER_PERSONALAUSWEIS, 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Personalausweis erhalten!");
                }
                else if (button == "Auto")
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 10500)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    Führerschein.Führerschein.Start_Führerschein(player);
                }
                else if (button == "Bike")
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 8750)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    Führerschein.Motorrad_Führerschein.Start_Motorrad_Führerschein(player);
                }
                else if (button == "LKW")
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 16750)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    Führerschein.LKW_Führerschein.Start_LKW_Führerschein(player);

                }
                else if (button == "Plane_A")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN) == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Flugschein A!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 28250)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 28250);
                    player.vnxSetElementData(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Flugschein A erhalten!");
                }
                else if (button == "Plane_B")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN) != 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst zuerst einen Flugschein A!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN) == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Flugschein B!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 37625)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 37625);
                    player.vnxSetElementData(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Flugschein B erhalten!");
                }
                else if (button == "Heli")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN) == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Helikopterschein!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 25438)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 25438);
                    player.vnxSetElementData(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Helikopterschein erhalten!");
                }
                else if (button == "Boat")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN) == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Bootsschein!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 5220)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 5220);
                    player.vnxSetElementData(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Bootsschein erhalten!");
                }
                else if (button == "Fisher")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN) == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Angelschein!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 1150)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 1150);
                    player.vnxSetElementData(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Angelschein erhalten!");
                }
                else if (button == "Weapon")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN) == 1)
                    {
                        anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Waffenschein!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 21250)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) < 3 * 60)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab 3 Spielstunden möglich.");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 21250);
                    player.vnxSetElementData(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, 1);
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "------------WAFFENSCHEIN INFORMATION------------");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + " Du hast soeben deinen Waffenschein erhalten, der dich zum Besitz einer Waffe berechtigt.");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + " Trägst du deine Waffen offen, so wird die Polizei sie dir abnehmen.");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Falls du zu oft negativ auffällst ( z.b. durch Schiesserein) können sie dir ihn auch wieder abnehmen");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "------------WAFFENSCHEIN INFORMATION------------");
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                }
                else
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast nichts ausgewählt!");
                }
            }
            catch
            {
            }
        }



        //[AltV.Net.ClientEvent("CancelDrivingSchool")]
        public static void CancelDrivingSchhol(Client player, int speed)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle != null && vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") == player.Username && player.vnxGetSharedData<bool>("PLAYER_DRIVINGSCHOOL") == true)
                    {
                        player.vnxSetElementData("Marker_Pruefung", 0);
                        dxLibary.VnX.DestroyRadarElement(player, "Blip");
                        dxLibary.VnX.DrawWaypoint(player, player.Position.X, player.Position.Y);
                        Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                        player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                        player.Dimension = 0;
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Du bist zu schnell gefahren! Km/h : " + speed);
                        player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                        Alt.Server.TriggerClientEvent(player,"Destroy_Rathaus_License_Ped");
                        if (player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "AUTO")
                        {
                            player.vnxSetElementData("PRUEFUNGS_NAME", false);
                        }
                        else if (player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "BIKE")
                        {
                            player.vnxSetElementData("PRUEFUNGS_NAME", false);
                        }

                        vehicle.Remove();
                        ColShapeModel FührerscheinCol = Führerschein.Führerschein.Führerschein_Abgabe_Marker;
                        ColShapeModel FührerscheinMotorradCol = Führerschein.Motorrad_Führerschein.Motorrad_Führerschein_Abgabe_Marker;
                        if (FührerscheinMotorradCol != null && FührerscheinMotorradCol.vnxGetElementData<string>("Name") == player.Username)
                        {
                            RageAPI.RemoveColShape(Führerschein.Motorrad_Führerschein.Motorrad_Führerschein_Abgabe_Marker);
                            return;
                        }
                        else if (FührerscheinCol != null && FührerscheinCol.vnxGetElementData<string>("Name") == player.Username)
                        {
                            RageAPI.RemoveColShape(FührerscheinCol);
                            return;
                        }
                        return;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
