using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
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
                    Alt.Server.TriggerClientEvent(player, "showRathausWindow", "Stadthalle", PERSO_BTN, CAR_BTN, LKW_BTN, BIKE_BTN, PLANE_A_BTN, PLANE_B_BTN, HELICOPTER_BTN, BOAT_BTN, FISHER_BTN, WEAPON_BTN, perso, fuehrer, lkw, bike, fa, fb, heli, boot, angel, waffen);
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_STADTHALLE);
                }
            }
            catch { }
        }

        [ClientEvent("On_Clicked_Button_Rathaus")]
        public static void OnClickedButton_Rathaus(Client player, string button)
        {
            try
            {
                switch (button)
                {
                    case "Perso":
                        anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_PERSO);
                        if (player.Reallife.Personalausweis == 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Personalausweis!");
                            return;
                        }
                        if (player.Reallife.Money < 450)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.Reallife.Money -= 450;
                        player.Reallife.Personalausweis = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Personalausweis erhalten!");
                        break;
                    case "Auto":
                        if (player.Reallife.Money < 10500)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        Führerschein.Führerschein.Start_Führerschein(player);
                        break;
                    case "Bike":
                        if (player.Reallife.Money < 8750)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        Führerschein.Motorrad_Führerschein.Start_Motorrad_Führerschein(player);
                        break;
                    case "LKW":
                        if (player.Reallife.Money < 16750)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        Führerschein.LKW_Führerschein.Start_LKW_Führerschein(player);
                        break;
                    case "Plane_A":

                        if (player.Reallife.FlugscheinKlasseA == 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Flugschein A!");
                            return;
                        }
                        if (player.Reallife.Money < 28250)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.Reallife.Money -= 28250;
                        player.Reallife.FlugscheinKlasseA = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Flugschein A erhalten!");
                        break;
                    case "Plane_B":

                        if (player.Reallife.FlugscheinKlasseB != 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst zuerst einen Flugschein A!");
                            return;
                        }
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN) == 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Flugschein B!");
                            return;
                        }
                        if (player.Reallife.Money < 37625)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.Reallife.Money -= 37625;
                        player.Reallife.FlugscheinKlasseB = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Flugschein B erhalten!");
                        break;
                    case "Heli":
                        if (player.Reallife.Helikopterfuehrerschein == 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Helikopterschein!");
                            return;
                        }
                        if (player.Reallife.Money < 25438)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.Reallife.Money -= 25438;
                        player.Reallife.Helikopterfuehrerschein = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Helikopterschein erhalten!");
                        break;
                    case "Boat":
                        if (player.Reallife.Motorbootschein == 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Bootsschein!");
                            return;
                        }
                        if (player.Reallife.Money < 5220)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.Reallife.Money -= 5220;
                        player.Reallife.Motorbootschein = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Bootsschein erhalten!");
                        break;
                    case "Fisher":

                        if (player.Reallife.Angelschein == 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Angelschein!");
                            return;
                        }
                        if (player.Reallife.Money < 1150)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.Reallife.Money -= 1150;
                        player.Reallife.Angelschein = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Angelschein erhalten!");
                        break;
                    case "Weapon":
                        if (player.Reallife.Waffenschein == 1)
                        {
                            anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Waffenschein!");
                            return;
                        }
                        if (player.Reallife.Money < 21250)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        if (player.Played < 3 * 60)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab 3 Spielstunden möglich.");
                            return;
                        }
                        player.Reallife.Money -= 21250;
                        player.Reallife.Waffenschein = 1;
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "------------WAFFENSCHEIN INFORMATION------------");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + " Du hast soeben deinen Waffenschein erhalten, der dich zum Besitz einer Waffe berechtigt.");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + " Trägst du deine Waffen offen, so wird die Polizei sie dir abnehmen.");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Falls du zu oft negativ auffällst ( z.b. durch Schiesserein) können sie dir ihn auch wieder abnehmen");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "------------WAFFENSCHEIN INFORMATION------------");
                        anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                        break;
                    default:
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast nichts ausgewählt!");
                        break;
                }
            }
            catch { }
        }

        private static List<MarkerModel> DrivingSchoolMarkers = new List<MarkerModel>();
        private static List<ColShapeModel> DrivingSchoolColShapeClasses = new List<ColShapeModel>();
        private static List<IColShape> DrivingSchoolCols = new List<IColShape>();

        /* Usefull Functions & Calling - Events/Functions */

        public static List<IColShape> CurrentDrivingSchoolColShapes = new List<IColShape>();
        public static List<BlipModel> CurrentDrivingSchoolBlips = new List<BlipModel>();
        public static List<MarkerModel> CurrentDrivingSchoolMarker = new List<MarkerModel>();
        public static List<VehicleModel> CurrentDrivingSchoolVehicles = new List<VehicleModel>();
        public static string DRIVINGSCHOOL_COLCLASS_ENTITY = "DRIVINGSCHOOL_COLCLASS_ENTITY";
        public static string DRIVINGSCHOOL_COL_ENTITY = "DRIVINGSCHOOL_COL_ENTITY";
        public static string DRIVINGSCHOOL_MARKER_ENTITY = "DRIVINGSCHOOL_MARKER_ENTITY";
        public static string DRIVINGSCHOOL_BLIP_ENTITY = "DRIVINGSCHOOL_BLIP_ENTITY";

        public static void CreateDrivingSchoolMarker(Client player, int BlipID, Vector3 Position, int Scale, int[] Color)
        {
            try
            {
                MarkerModel markerClass = RageAPI.CreateMarker(30, Position, new Vector3(Scale), Color, player, player.Dimension);
                BlipModel blipClass = RageAPI.CreateBlip("Abgabe [Schein]", Position, BlipID, 75, false, player);
                ColShapeModel colClass = RageAPI.CreateColShapeSphere(Position, Scale, player.Dimension);
                Alt.Server.TriggerClientEvent(player, "Player:SetWaypoint", Position.X, Position.Y);
                player.vnxSetElementData(DRIVINGSCHOOL_MARKER_ENTITY, markerClass);
                player.vnxSetElementData(DRIVINGSCHOOL_BLIP_ENTITY, blipClass);
                player.vnxSetElementData(DRIVINGSCHOOL_COL_ENTITY, colClass.Entity);
                player.vnxSetElementData(DRIVINGSCHOOL_COLCLASS_ENTITY, colClass);
                CurrentDrivingSchoolMarker.Add(markerClass);
                CurrentDrivingSchoolBlips.Add(blipClass);
                CurrentDrivingSchoolColShapes.Add(colClass.Entity);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateJobMarker", ex); }
        }
        public static void DestroyDrivingSchoolMarker(Client player)
        {
            try
            {
                //Remove ColShapes
                if (CurrentDrivingSchoolColShapes.Contains(player.vnxGetElementData<IColShape>(DRIVINGSCHOOL_COL_ENTITY)))
                {
                    RageAPI.RemoveColShape(player.vnxGetElementData<ColShapeModel>(DRIVINGSCHOOL_COLCLASS_ENTITY));
                    CurrentDrivingSchoolColShapes.Remove(player.vnxGetElementData<IColShape>(DRIVINGSCHOOL_COL_ENTITY));
                }
                //Remove Marker
                if (CurrentDrivingSchoolMarker.Contains(player.vnxGetElementData<MarkerModel>(DRIVINGSCHOOL_MARKER_ENTITY)))
                {
                    RageAPI.RemoveMarker(player.vnxGetElementData<MarkerModel>(DRIVINGSCHOOL_MARKER_ENTITY));
                    CurrentDrivingSchoolMarker.Remove(player.vnxGetElementData<MarkerModel>(DRIVINGSCHOOL_MARKER_ENTITY));
                }
                //Remove Blips
                if (CurrentDrivingSchoolBlips.Contains(player.vnxGetElementData<BlipModel>(DRIVINGSCHOOL_BLIP_ENTITY)))
                {
                    RageAPI.RemoveBlip(player.vnxGetElementData<BlipModel>(DRIVINGSCHOOL_BLIP_ENTITY));
                    CurrentDrivingSchoolBlips.Remove(player.vnxGetElementData<BlipModel>(DRIVINGSCHOOL_BLIP_ENTITY));
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("DestroyDrivingSchoolMarker", ex); }
        }

        public static void OnColShapeHit(IColShape shape, Client player)
        {
            try
            {

            }
            catch { }
        }

        public static VehicleModel CreateDrivingSchoolVehicle(Client player, AltV.Net.Enums.VehicleModel veh, Vector3 Position, Vector3 Rotation, int Dimension = 0, bool WarpIntoVehicle = true)
        {
            try
            {
                VehicleModel DrivingSchoolVehicle = (VehicleModel)Alt.CreateVehicle(veh, Position, Rotation);
                player.Dimension = Dimension;
                DrivingSchoolVehicle.Dimension = Dimension;
                DrivingSchoolVehicle.EngineOn = true;
                DrivingSchoolVehicle.Owner = player.Username;
                DrivingSchoolVehicle.Kms = 0;
                DrivingSchoolVehicle.Gas = 100;
                DrivingSchoolVehicle.Job = Constants.JOB_NONE;
                DrivingSchoolVehicle.Reallife.DrivingSchoolVehicle = true;
                DrivingSchoolVehicle.NotSave = true;
                if (WarpIntoVehicle) { player.WarpIntoVehicle(DrivingSchoolVehicle, -1); }
                CurrentDrivingSchoolVehicles.Add(DrivingSchoolVehicle);
                return DrivingSchoolVehicle;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateDrivingSchoolVehicle", ex); return null; }
        }

        [ClientEvent("CancelDrivingSchool")]
        public static void CancelDrivingSchhol(Client player, int speed)
        {
            try
            {


                if (player.IsInVehicle)
                {
                    VehicleModel playerVeh = (VehicleModel)player.Vehicle;
                    if (CurrentDrivingSchoolVehicles.Contains(playerVeh)) { CurrentDrivingSchoolVehicles.Remove(playerVeh); }
                    playerVeh.Remove();
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Du bist zu schnell gefahren! Km/h : " + speed);
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    DestroyDrivingSchoolMarker(player);
                }
            }
            catch { }
        }
    }
}
