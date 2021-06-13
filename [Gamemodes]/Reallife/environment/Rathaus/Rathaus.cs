using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.Environment.Rathaus.Führerschein;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.quests;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;

namespace VenoXV._Gamemodes_.Reallife.Environment.Rathaus
{
    public class Rathaus : IScript
    {

        public static ColShapeModel RathausColShapeModel = RageApi.CreateColShapeSphere(new Position(-548.8972f, -202.5477f, 38.30002f), 1.2f);
        public static NpcModel Npc = RageApi.CreateNpc("ig_abigail", new Vector3(-550.5427f, -204.1586f, 38.29998f), new Vector3(0, 0, 290), 0);
        //public static Marker RathausMarkerImInterior = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-546.1301, -202.6208, 38.30002), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

        //public static Marker RathausMarkerEingang = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-545.3177f, -203.7145f, 38.2151f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        public static MarkerModel RathausMarkerImInterior = RageApi.CreateMarker(0, new Vector3(-546.1301f, -202.6208f, 38.30002f), new Vector3(1, 1, 1), new[] { 0, 150, 200, 255 });
        public static MarkerModel RathausMarkerEingang = RageApi.CreateMarker(0, new Vector3(-1285.1868f, -566.53186f, 31.706177f), new Vector3(1, 1, 1), new[] { 0, 150, 200, 255 });

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != RathausColShapeModel) return false;
                Task.Run(async () =>
                {
                    string price = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Preis:");
                    string persoBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Personalausweis");
                    string carBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Führerschein");
                    string lkwBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "LKW-Führerschein");
                    string bikeBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Motorradschein");
                    string planeABtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Flugschein A");
                    string planeBBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Flugschein B");
                    string helicopterBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Helikopterschein");
                    string boatBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Bootsschein");
                    string fisherBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Angelschein");
                    string weaponBtn = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Waffenschein");

                    string persoAsset = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Der Personalausweis ist das");
                    string persoAsset1 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "wichtigste was du bei dir");
                    string persoAsset2 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "haben kannst, mit diesem");
                    string persoAsset3 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Identifizierst du dich");
                    string persoAsset4 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "bei den Behörden.");

                    string perso = persoAsset + "<br> " + persoAsset1 + "<br>" + persoAsset2 + "<br>" + persoAsset3 + "<br>" + persoAsset4 + " <br><br>" + price + " 450$";



                    string fuehrer = "Der Führerschein wird<br>benötigt um ein Auto fahren<br>zu duerfen, solltest du<br>ohne einen Führerschein<br>erwischt wirst, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 10.500$";
                    string lkw = "Der LKW-Führerschein wird<br>benötigt um ein LKW fahren<br>zu duerfen, solltest du<br>ohne einen LKW-Führerschein<br>erwischt wirst, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 16.750$";
                    string bike = "Der Motorradschein wird<br>benötigt um ein Motorrad fahren<br>zu duerfen, solltest du<br>ohne ein Motorradschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 8.750$";
                    string fa = "Der Flugschein (A) wird<br>benötigt um kleine Flugzeuge<br>fliegen zu duerfen, solltest du<br>ohne einen Flugschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 28.250$";
                    string fb = "Der Flugschein (B) wird<br>benötigt um groessere Flugzeuge<br>fliegen zu duerfen, solltest<br>du ohne einen Flugschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 37.625$";
                    string heli = "Der Helikopterschein wird<br>benötigt um Helikopter<br>fliegen zu duerfen, solltest<br>du ohne einen Helikopterschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 25.438$";
                    string boot = "Der Bootschein wird<br>benötigt um ein Boot<br>fahren zu duerfen, solltest<br>du ohne einen Bootschein<br>erwischt werden, drohen<br>dir Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 5.220$";
                    string angel = "Der Angelschein wird<br>benötigt um Angeln<br>zu duerfen, solltest du<br>ohne einen Angelschein<br>beim Angeln erwischt<br>werden, drohen dir<br>Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 1.150$";
                    string waffen = "Der Waffenschein wird<br>benötigt um eine Waffe<br>zu besitzen, solltest du<br>ohne einen Waffenschein<br>mit einer Waffe erwischt<br>werden, drohen dir<br>Fahndungslevel von den<br>Behörden und Strafgelder.<br><br>Preis: 21.250$";
                    VenoX.TriggerClientEvent(player, "showRathausWindow", "Stadthalle", persoBtn, carBtn, lkwBtn, bikeBtn, planeABtn, planeBBtn, helicopterBtn, boatBtn, fisherBtn, weaponBtn, perso, fuehrer, lkw, bike, fa, fb, heli, boot, angel, waffen);
                    //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_STADTHALLE);
                    if (Quests.QuestDict.ContainsKey(Quests.QuestStadthalle))
                        Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestStadthalle]);
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
                        if (Quests.QuestDict.ContainsKey(Quests.QuestPerso))
                            Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestPerso]);
                        if (player.Reallife.IDCard == 1)
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
                        player.Reallife.IDCard = 1;
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
                        MotorradFührerschein.Start_Motorrad_Führerschein(player);
                        break;
                    case "LKW":
                        if (player.Reallife.Money < 16750)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        LkwFührerschein.Start_LKW_Führerschein(player);
                        break;
                    case "Plane_A":

                        if (player.Reallife.FlyLicenseA == 1)
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
                        player.Reallife.FlyLicenseA = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Flugschein A erhalten!");
                        break;
                    case "Plane_B":

                        if (player.Reallife.FlyLicenseB != 1)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst zuerst einen Flugschein A!");
                            return;
                        }
                        if (player.Reallife.FlyLicenseB == 1)
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
                        player.Reallife.FlyLicenseB = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Flugschein B erhalten!");
                        break;
                    case "Heli":
                        if (player.Reallife.HelicopterDrivingLicense == 1)
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
                        player.Reallife.HelicopterDrivingLicense = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Helikopterschein erhalten!");
                        break;
                    case "Boat":
                        if (player.Reallife.MotorBoatDrivingLicense == 1)
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
                        player.Reallife.MotorBoatDrivingLicense = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Bootsschein erhalten!");
                        break;
                    case "Fisher":

                        if (player.Reallife.FishingLicense == 1)
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
                        player.Reallife.FishingLicense = 1;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "[Rathaus] : Angelschein erhalten!");
                        break;
                    case "Weapon":
                        if (player.Reallife.WeaponLicense == 1)
                        {
                            //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                            if (Quests.QuestDict.ContainsKey(Quests.QuestGetweaponlicense))
                                Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestGetweaponlicense]);
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
                        player.Reallife.WeaponLicense = 1;
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "------------WAFFENSCHEIN INFORMATION------------");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + " Du hast soeben deinen Waffenschein erhalten, der dich zum Besitz einer Waffe berechtigt.");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + " Trägst du deine Waffen offen, so wird die Polizei sie dir abnehmen.");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Falls du zu oft negativ auffällst ( z.b. durch Schiesserein) können sie dir ihn auch wieder abnehmen");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "------------WAFFENSCHEIN INFORMATION------------");
                        //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETWEAPONLICENSE);
                        if (Quests.QuestDict.ContainsKey(Quests.QuestGetweaponlicense))
                            Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestGetweaponlicense]);
                        break;
                    default:
                        player.SendTranslatedChatMessage(Constants.RgbaError + "Du hast nichts ausgewählt! : " + button);
                        break;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        /* Usefull Functions & Calling - Events/Functions */

        public static List<IColShape> CurrentDrivingSchoolColShapes = new List<IColShape>();
        public static List<BlipModel> CurrentDrivingSchoolBlips = new List<BlipModel>();
        public static List<MarkerModel> CurrentDrivingSchoolMarker = new List<MarkerModel>();
        public static List<VehicleModel> CurrentDrivingSchoolVehicles = new List<VehicleModel>();
        public static string DrivingschoolColclassEntity = "DRIVINGSCHOOL_COLCLASS_ENTITY";
        public static string DrivingschoolColEntity = "DRIVINGSCHOOL_COL_ENTITY";
        public static string DrivingschoolMarkerEntity = "DRIVINGSCHOOL_MARKER_ENTITY";
        public static string DrivingschoolBlipEntity = "DRIVINGSCHOOL_BLIP_ENTITY";

        public static void CreateDrivingSchoolMarker(VnXPlayer player, int blipId, Vector3 position, int scale, int[] color)
        {
            try
            {
                player.DrawWaypoint(position.X, position.Y);
                MarkerModel markerClass = RageApi.CreateMarker(30, position, new Vector3(scale), color, player, player.Dimension);
                BlipModel blipClass = RageApi.CreateBlip("Abgabe [Schein]", position, blipId, 75, false, player);
                ColShapeModel colClass = RageApi.CreateColShapeSphere(position, scale, player.Dimension);
                player.VnxSetElementData(DrivingschoolMarkerEntity, markerClass);
                player.VnxSetElementData(DrivingschoolBlipEntity, blipClass);
                player.VnxSetElementData(DrivingschoolColEntity, colClass);
                player.VnxSetElementData(DrivingschoolColclassEntity, colClass);
                CurrentDrivingSchoolMarker.Add(markerClass);
                CurrentDrivingSchoolBlips.Add(blipClass);
                CurrentDrivingSchoolColShapes.Add(colClass);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void DestroyDrivingSchoolMarker(VnXPlayer player)
        {
            try
            {
                //Remove ColShapes
                IColShape col = player.VnxGetElementData<IColShape>(DrivingschoolColEntity);
                if (col != null)
                {
                    if (CurrentDrivingSchoolColShapes.Contains(col))
                    {
                        ColShapeModel colModel = player.VnxGetElementData<ColShapeModel>(DrivingschoolColclassEntity);
                        if (colModel != null) { RageApi.RemoveColShape(colModel); }
                        else { Alt.RemoveColShape(col); }
                        CurrentDrivingSchoolColShapes.Remove(col);
                    }
                }

                //Remove Marker
                MarkerModel markerModel = player.VnxGetElementData<MarkerModel>(DrivingschoolMarkerEntity);
                if (markerModel != null)
                {
                    if (CurrentDrivingSchoolMarker.Contains(markerModel))
                    {
                        RageApi.RemoveMarker(markerModel);
                        CurrentDrivingSchoolMarker.Remove(markerModel);
                    }
                }

                //Remove Blips
                BlipModel blipModel = player.VnxGetElementData<BlipModel>(DrivingschoolBlipEntity);
                if (blipModel != null)
                {
                    if (CurrentDrivingSchoolBlips.Contains(blipModel))
                    {
                        RageApi.RemoveBlip(blipModel, player);
                        CurrentDrivingSchoolBlips.Remove(blipModel);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public const string DrivingschoolLicenseCar = "DRIVINGSCHOOL_LICENSE_CAR";
        public const string DrivingschoolLicenseBike = "DRIVINGSCHOOL_LICENSE_BIKE";
        public const string DrivingschoolLicenseLkw = "DRIVINGSCHOOL_LICENSE_LKW";
        public static bool OnColShapeHit(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehClass = (VehicleModel)player.Vehicle;
                    IColShape playerShape = player.VnxGetElementData<IColShape>(DrivingschoolColEntity);
                    if (playerShape != null && CurrentDrivingSchoolColShapes.Contains(playerShape) && shape == playerShape)
                    {
                        if (vehClass.Reallife.DrivingSchoolVehicle)
                        {
                            switch (vehClass.Reallife.DrivingSchoolLicense)
                            {
                                case DrivingschoolLicenseCar:
                                    Führerschein.Führerschein.OnPlayerEnterColShapeModel(shape, player);
                                    Debug.OutputDebugString("Called Car Hit Marker");
                                    break;
                                case DrivingschoolLicenseBike:
                                    MotorradFührerschein.OnPlayerEnterColShapeModel(shape, player);
                                    Debug.OutputDebugString("Called Bike Hit Marker");
                                    break;
                                case DrivingschoolLicenseLkw:
                                    LkwFührerschein.OnPlayerEnterColShapeModel(shape, player);
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
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }

        public static VehicleModel CreateDrivingSchoolVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel veh, Vector3 position, Vector3 rotation, int dimension = (Main.ReallifeDimension), bool warpIntoVehicle = true)
        {
            try
            {
                VehicleModel drivingSchoolVehicle = (VehicleModel)Alt.CreateVehicle(veh, position, rotation);
                player.Dimension = dimension;
                drivingSchoolVehicle.Dimension = dimension;
                drivingSchoolVehicle.EngineOn = true;
                drivingSchoolVehicle.Owner = player.Username;
                drivingSchoolVehicle.Kms = 0;
                drivingSchoolVehicle.Gas = 100;
                drivingSchoolVehicle.Job = Constants.JobNone;
                drivingSchoolVehicle.Reallife.DrivingSchoolVehicle = true;
                drivingSchoolVehicle.NotSave = true;
                if (warpIntoVehicle) { player.WarpIntoVehicle(drivingSchoolVehicle, -1); }
                CurrentDrivingSchoolVehicles.Add(drivingSchoolVehicle);
                return drivingSchoolVehicle;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
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
                    RageApi.DeleteVehicleThreadSafe(playerVeh);
                    //playerVeh.Remove();
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = Main.ReallifeDimension + player.Language;
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 0, 0) + "Du bist zu schnell gefahren! Km/h : " + speed);
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    DestroyDrivingSchoolMarker(player);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
