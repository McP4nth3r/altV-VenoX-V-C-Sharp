using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.quests;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.Rathaus
{
    public class Rathaus : IScript
    {

        public static ColShapeModel RathausColShapeModel = RageAPI.CreateColShapeSphere(new Position(-548.8972f, -202.5477f, 38.30002f), 1.2f);
        public static NPCModel npc = RageAPI.CreateNPC("ig_abigail", new Vector3(-550.5427f, -204.1586f, 38.29998f), new Vector3(0, 0, 290), 0, null);
        //public static Marker RathausMarkerImInterior = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-546.1301, -202.6208, 38.30002), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

        //public static Marker RathausMarkerEingang = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-545.3177f, -203.7145f, 38.2151f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        public static MarkerModel RathausMarkerImInterior = RageAPI.CreateMarker(0, new Vector3(-546.1301f, -202.6208f, 38.30002f), new Vector3(1, 1, 1), new int[] { 0, 150, 200, 255 });
        public static MarkerModel RathausMarkerEingang = RageAPI.CreateMarker(0, new Vector3(-1285.1868f, -566.53186f, 31.706177f), new Vector3(1, 1, 1), new int[] { 0, 150, 200, 255 });

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != RathausColShapeModel) return false;
                Task.Run(async () =>
                {
                    string price = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Preis:");
                    string PERSO_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Personalausweis");
                    string CAR_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Führerschein");
                    string LKW_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "LKW-Führerschein");
                    string BIKE_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Motorradschein");
                    string PLANE_A_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Flugschein A");
                    string PLANE_B_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Flugschein B");
                    string HELICOPTER_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Helikopterschein");
                    string BOAT_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Bootsschein");
                    string FISHER_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Angelschein");
                    string WEAPON_BTN = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Waffenschein");

                    string perso_asset = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Der Personalausweis ist das");
                    string perso_asset1 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "wichtigste was du bei dir");
                    string perso_asset2 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "haben kannst, mit diesem");
                    string perso_asset3 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Identifizierst du dich");
                    string perso_asset4 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "bei den Behörden.");

                    string perso = perso_asset + "<br> " + perso_asset1 + "<br>" + perso_asset2 + "<br>" + perso_asset3 + "<br>" + perso_asset4 + " <br><br>" + price + " 450$";



                    string fuehrer = "Der Führerschein wird<br>benötigt um ein Auto fahren<br>zu duerfen, solltest du<br>ohne einen Führerschein<br>erwischt wirst, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 10.500$";
                    string lkw = "Der LKW-Führerschein wird<br>benötigt um ein LKW fahren<br>zu duerfen, solltest du<br>ohne einen LKW-Führerschein<br>erwischt wirst, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 16.750$";
                    string bike = "Der Motorradschein wird<br>benötigt um ein Motorrad fahren<br>zu duerfen, solltest du<br>ohne ein Motorradschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 8.750$";
                    string fa = "Der Flugschein (A) wird<br>benötigt um kleine Flugzeuge<br>fliegen zu duerfen, solltest du<br>ohne einen Flugschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 28.250$";
                    string fb = "Der Flugschein (B) wird<br>benötigt um groessere Flugzeuge<br>fliegen zu duerfen, solltest<br>du ohne einen Flugschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 37.625$";
                    string heli = "Der Helikopterschein wird<br>benötigt um Helikopter<br>fliegen zu duerfen, solltest<br>du ohne einen Helikopterschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 25.438$";
                    string boot = "Der Bootschein wird<br>benötigt um ein Boot<br>fahren zu duerfen, solltest<br>du ohne einen Bootschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 5.220$";
                    string angel = "Der Angelschein wird<br>benötigt um Angeln<br>zu duerfen, solltest du<br>ohne einen Angelschein<br>beim Angeln erwischt<br>werden, drohen dir<br>Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 1.150$";
                    string waffen = "Der Waffenschein wird<br>benötigt um eine Waffe<br>zu besitzen, solltest du<br>ohne einen Waffenschein<br>mit einer Waffe erwischt<br>werden, drohen dir<br>Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 21.250$";
                    VenoX.TriggerClientEvent(player, "showRathausWindow", "Stadthalle", PERSO_BTN, CAR_BTN, LKW_BTN, BIKE_BTN, PLANE_A_BTN, PLANE_B_BTN, HELICOPTER_BTN, BOAT_BTN, FISHER_BTN, WEAPON_BTN, perso, fuehrer, lkw, bike, fa, fb, heli, boot, angel, waffen);
                    //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_STADTHALLE);
                    if (quests.Quests.QuestDict.ContainsKey(Quests.QUEST_STADTHALLE))
                        Quests.OnQuestDone(player, quests.Quests.QuestDict[Quests.QUEST_STADTHALLE]);
                });
                return true;
            }
            catch { return false; }
        }

        [VenoXRemoteEvent("On_Clicked_Button_Rathaus")]
        public static void OnClickedButton_Rathaus(VnXPlayer player, string button)
        {
            try
            {
                switch (button)
                {
                    case "Perso":
                        //anzeigen.Usefull.VnX.QUEST_PERSO(player, anzeigen.Usefull.VnX.QUEST_PERSO);
                        if (quests.Quests.QuestDict.ContainsKey(Quests.QUEST_PERSO))
                            Quests.OnQuestDone(player, quests.Quests.QuestDict[Quests.QUEST_PERSO]);
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
                        if (player.Reallife.FlugscheinKlasseB == 1)
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
                            //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                            if (Quests.QuestDict.ContainsKey(Quests.QUEST_GETWEAPONLICENSE))
                                Quests.OnQuestDone(player, Quests.QuestDict[Quests.QUEST_GETWEAPONLICENSE]);
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
                        //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                        if (Quests.QuestDict.ContainsKey(Quests.QUEST_GETWEAPONLICENSE))
                            Quests.OnQuestDone(player, Quests.QuestDict[Quests.QUEST_GETWEAPONLICENSE]);
                        break;
                    default:
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast nichts ausgewählt! : " + button);
                        break;
                }
            }
            catch { }
        }

        /* Usefull Functions & Calling - Events/Functions */

        public static List<IColShape> CurrentDrivingSchoolColShapes = new List<IColShape>();
        public static List<BlipModel> CurrentDrivingSchoolBlips = new List<BlipModel>();
        public static List<MarkerModel> CurrentDrivingSchoolMarker = new List<MarkerModel>();
        public static List<VehicleModel> CurrentDrivingSchoolVehicles = new List<VehicleModel>();
        public static string DRIVINGSCHOOL_COLCLASS_ENTITY = "DRIVINGSCHOOL_COLCLASS_ENTITY";
        public static string DRIVINGSCHOOL_COL_ENTITY = "DRIVINGSCHOOL_COL_ENTITY";
        public static string DRIVINGSCHOOL_MARKER_ENTITY = "DRIVINGSCHOOL_MARKER_ENTITY";
        public static string DRIVINGSCHOOL_BLIP_ENTITY = "DRIVINGSCHOOL_BLIP_ENTITY";

        public static void CreateDrivingSchoolMarker(VnXPlayer player, int BlipID, Vector3 Position, int Scale, int[] Color)
        {
            try
            {
                player.DrawWaypoint(Position.X, Position.Y);
                MarkerModel markerClass = RageAPI.CreateMarker(30, Position, new Vector3(Scale), Color, player, player.Dimension);
                BlipModel blipClass = RageAPI.CreateBlip("Abgabe [Schein]", Position, BlipID, 75, false, player);
                ColShapeModel colClass = RageAPI.CreateColShapeSphere(Position, Scale, player.Dimension);
                player.vnxSetElementData(DRIVINGSCHOOL_MARKER_ENTITY, markerClass);
                player.vnxSetElementData(DRIVINGSCHOOL_BLIP_ENTITY, blipClass);
                player.vnxSetElementData(DRIVINGSCHOOL_COL_ENTITY, colClass);
                player.vnxSetElementData(DRIVINGSCHOOL_COLCLASS_ENTITY, colClass);
                CurrentDrivingSchoolMarker.Add(markerClass);
                CurrentDrivingSchoolBlips.Add(blipClass);
                CurrentDrivingSchoolColShapes.Add(colClass);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void DestroyDrivingSchoolMarker(VnXPlayer player)
        {
            try
            {
                //Remove ColShapes
                IColShape col = player.vnxGetElementData<IColShape>(DRIVINGSCHOOL_COL_ENTITY);
                if (col != null)
                {
                    if (CurrentDrivingSchoolColShapes.Contains(col))
                    {
                        ColShapeModel ColModel = player.vnxGetElementData<ColShapeModel>(DRIVINGSCHOOL_COLCLASS_ENTITY);
                        if (ColModel != null) { RageAPI.RemoveColShape(ColModel); }
                        else { Alt.RemoveColShape(col); }
                        CurrentDrivingSchoolColShapes.Remove(col);
                    }
                }

                //Remove Marker
                MarkerModel MarkerModel = player.vnxGetElementData<MarkerModel>(DRIVINGSCHOOL_MARKER_ENTITY);
                if (MarkerModel != null)
                {
                    if (CurrentDrivingSchoolMarker.Contains(MarkerModel))
                    {
                        RageAPI.RemoveMarker(MarkerModel);
                        CurrentDrivingSchoolMarker.Remove(MarkerModel);
                    }
                }

                //Remove Blips
                BlipModel BlipModel = player.vnxGetElementData<BlipModel>(DRIVINGSCHOOL_BLIP_ENTITY);
                if (BlipModel != null)
                {
                    if (CurrentDrivingSchoolBlips.Contains(BlipModel))
                    {
                        RageAPI.RemoveBlip(BlipModel, player);
                        CurrentDrivingSchoolBlips.Remove(BlipModel);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        public const string DRIVINGSCHOOL_LICENSE_CAR = "DRIVINGSCHOOL_LICENSE_CAR";
        public const string DRIVINGSCHOOL_LICENSE_BIKE = "DRIVINGSCHOOL_LICENSE_BIKE";
        public const string DRIVINGSCHOOL_LICENSE_LKW = "DRIVINGSCHOOL_LICENSE_LKW";
        public static bool OnColShapeHit(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehClass = (VehicleModel)player.Vehicle;
                    IColShape playerShape = player.vnxGetElementData<IColShape>(DRIVINGSCHOOL_COL_ENTITY);
                    if (playerShape != null && CurrentDrivingSchoolColShapes.Contains(playerShape) && shape == playerShape)
                    {
                        if (vehClass.Reallife.DrivingSchoolVehicle)
                        {
                            switch (vehClass.Reallife.DrivingSchoolLicense)
                            {
                                case DRIVINGSCHOOL_LICENSE_CAR:
                                    Führerschein.Führerschein.OnPlayerEnterColShapeModel(shape, player);
                                    Debug.OutputDebugString("Called Car Hit Marker");
                                    break;
                                case DRIVINGSCHOOL_LICENSE_BIKE:
                                    Führerschein.Motorrad_Führerschein.OnPlayerEnterColShapeModel(shape, player);
                                    Debug.OutputDebugString("Called Bike Hit Marker");
                                    break;
                                case DRIVINGSCHOOL_LICENSE_LKW:
                                    Führerschein.LKW_Führerschein.OnPlayerEnterColShapeModel(shape, player);
                                    Debug.OutputDebugString("Called LKW Hit Marker");
                                    break;
                                default:
                                    Debug.OutputDebugString("Called " + vehClass.Reallife.DrivingSchoolLicense);
                                    break;
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }

        public static VehicleModel CreateDrivingSchoolVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel veh, Vector3 Position, Vector3 Rotation, int Dimension = (VenoXV._Globals_.Main.REALLIFE_DIMENSION), bool WarpIntoVehicle = true)
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
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }

        [VenoXRemoteEvent("CancelDrivingSchool")]
        public static void CancelDrivingSchhol(VnXPlayer player, int speed)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel playerVeh = (VehicleModel)player.Vehicle;
                    if (CurrentDrivingSchoolVehicles.Contains(playerVeh)) { CurrentDrivingSchoolVehicles.Remove(playerVeh); }
                    RageAPI.DeleteVehicleThreadSafe((VehicleModel)playerVeh);
                    //playerVeh.Remove();
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION + player.Language;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Du bist zu schnell gefahren! Km/h : " + speed);
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    DestroyDrivingSchoolMarker(player);
                }
            }
            catch { }
        }
    }
}
