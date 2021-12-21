using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Enums;
using VenoXV._Gamemodes_.Reallife.Environment.Rathaus;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.Globals
{
    public class Constants
    {
        // Gamemode version
        public const string GmVersion = "v1.1.3";


        // Sex
        public const int SexNone = -1;
        public const int SexMale = 0;
        public const int SexFemale = 1;

        // Chat
        public const int ChatLength = 85;
        public const int ChatRanges = 5;

        // Administrative ranks

        public const int AdminlvlNone = 0;
        public const int AdminlvlNulld = 1;
        public const int AdminlvlTsupporter = 2;
        public const int AdminlvlSupporter = 3;
        public const int AdminlvlModerator = 4;
        public const int AdminlvlAdministrator = 5;
        public const int AdminlvlStellvp = 6;
        public const int AdminlvlProjektleiter = 7;

        public const int ClothesMask = 1;
        public const int ClothesTorso = 3;
        public const int ClothesLegs = 4;
        public const int ClothesBags = 5;
        public const int ClothesFeet = 6;
        public const int ClothesAccessories = 7;
        public const int ClothesUndershirt = 8;
        public const int ClothesTops = 11;

        // Tattoo zones
        public const int TattooZoneTorso = 0;
        public const int TattooZoneHead = 1;
        public const int TattooZoneLeftArm = 2;
        public const int TattooZoneRightArm = 3;
        public const int TattooZoneLeftLeg = 4;
        public const int TattooZoneRightLeg = 5;

        // Accessory types
        public const int AccessoryHats = 0;
        public const int AccessoryGlasses = 1;
        public const int AccessoryEars = 2;

        // IVehicle components
        public const int VehicleModSpoiler = 0;
        public const int VehicleModFrontBumper = 1;
        public const int VehicleModRearBumper = 2;
        public const int VehicleModSideSkirt = 3;
        public const int VehicleModExhaust = 4;
        public const int VehicleModFrame = 5;
        public const int VehicleModGrille = 6;
        public const int VehicleModHood = 7;
        public const int VehicleModFender = 8;
        public const int VehicleModRightFender = 9;
        public const int VehicleModRoof = 10;
        public const int VehicleModEngine = 11;
        public const int VehicleModBrakes = 12;
        public const int VehicleModTransmission = 13;
        public const int VehicleModHorn = 14;
        public const int VehicleModSuspension = 15;
        public const int VehicleModArmor = 16;
        public const int VehicleModXenon = 22;
        public const int VehicleModFrontWheels = 23;
        public const int VehicleModBackWheels = 24;
        public const int VehicleModPlateHolders = 25;
        public const int VehicleModTrimDesign = 27;
        public const int VehicleModOrnamients = 28;
        public const int VehicleModDialDesign = 30;
        public const int VehicleModSteeringWheel = 33;
        public const int VehicleModShifterLeavers = 34;
        public const int VehicleModPlaques = 35;
        public const int VehicleModHydraulics = 38;
        public const int VehicleModLivery = 48;



        public const int VehicleOfflineDim = 95;
        public const int VehicleJobOfflineDim = 180;



        //
        public const int BusinessTypeNone = -1;
        public const int BusinessType247 = 1;
        public const int BusinessTypeElectronics = 2;
        public const int BusinessTypeHardware = 3;
        public const int BusinessTypeClothes = 4;
        public const int BusinessTypeBar = 5;
        public const int BusinessTypeDisco = 6;
        public const int BusinessTypeAmmunation = 7;
        public const int BusinessTypeWarehouse = 8;
        public const int BusinessTypeJewelry = 9;
        public const int BusinessTypePrivateOffice = 10;
        public const int BusinessTypeClubhouse = 11;
        public const int BusinessTypeGasStation = 12;
        public const int BusinessTypeSlaughterhouse = 13;
        public const int BusinessTypeBarberShop = 14;
        public const int BusinessTypeFactory = 15;
        public const int BusinessTypeTortureRoom = 16;
        public const int BusinessTypeGarageLowEnd = 17;
        public const int BusinessTypeWarehouseMedium = 18;
        public const int BusinessTypeSocialClub = 19;
        public const int BusinessTypeMechanic = 20;
        public const int BusinessTypeTattooShop = 21;
        public const int BusinessTypeBennysWhorkshop = 22;
        public const int BusinessTypeVanilla = 23;
        public const int BusinessTypeFishing = 24;

        // Item types
        public const int ItemTypeConsumable = 0;
        public const int ItemTypeEquipable = 1;
        public const int ItemTypeOpenable = 2;
        public const int ItemTypeWeapon = 3;
        public const int ItemTypeAmmunition = 4;
        public const int ItemTypeMisc = 5;

        // Amount of items when container opened
        public const int ItemOpenBeerAmount = 6;



        // ALLGEMEINE ITEMS : 

        public const string ItemHashWeed = "1233311452";
        public const string ItemHashKoks = "1243355452";
        public const string ItemHashBenzinkannister = "1243844452";
        public const string ItemHashTankstellensnack = "1243344492";
        public const string ItemHashLebkuchenmaennchen = "1243444492";
        public const string ItemHashMilch = "1243544492";
        public const string ItemHashCookies = "1243644492";
        public const string ItemHashGluehwein = "1243744492";
        public const string ItemHashSparerips = "1243844492";
        public const string ItemHashSchokolade = "1243944492";
        public const string ItemHashHeisseschokolade = "1244044492";
        public const string ItemHashMats = "1246355452";

        // Waffen items 

        public const string ItemHashFallschirm = "Parachute";

        public const string ItemHashSwitchblade = "SwitchBlade";

        public const string ItemHashBrokenbottle = "Broken Bottle";

        public const string ItemHashHammer = "Hammer";

        public const string ItemHashSnowball = "Snowball";

        public const string ItemHashNightstick = "NightStick";

        public const string ItemHashBaseball = "Bat";

        public const string ItemHashTazer = "STUNGUN";

        public const string ItemHashVintagepistol = "Vintage Pistol";

        public const string ItemHashMinismg = "Mini SMG";

        public const string ItemHashPistole = "Pistol";

        public const string ItemHashPistole50 = "Pistol50";

        public const string ItemHashRevolver = "Revolver";

        public const string ItemHashPistolAmmo = "PistolAmmo";



        public const string ItemHashShotgun = "PumpShotgun";

        public const string ItemHashPdw = "CombatPDW";

        public const string ItemHashMp5 = "SMG";

        public const string ItemHashKarabiner = "CarbineRifle";

        public const string ItemHashAk47 = "AssaultRifle";

        public const string ItemHashAdvancedrifle = "AdvancedRifle";

        public const string ItemHashRifle = "Musket";

        public const string ItemHashRpg = "RPG";

        public const string ItemHashSniperrifle = "SniperRifle";



        // Waffen Namen 
        public const string ItemNamePistolammo = "Pistolen Magazin";



        //Waffenlager Dinge

        public const int BaseballLager = 65;
        public const int BaseballMaxLager = 100;

        public const int NightstickLager = 65;
        public const int NightstickMaxLager = 100;

        public const int StungunLager = 115;
        public const int StungunMaxLager = 100;


        public const int PistolLager = 135;
        public const int PistolAmmoLager = 45;

        public const int PistolMaxLager = 60;
        public const int PistolAmmoMaxLager = 120;


        public const int Pistol50Lager = 245;
        public const int Pistol50AmmoLager = 85;
        public const int Pistol50MaxLager = 45;
        public const int Pistol50AmmoMaxLager = 90;


        public const int RevolverLager = 275;
        public const int RevolverAmmoLager = 110;
        public const int RevolverMaxLager = 35;
        public const int RevolverAmmoMaxLager = 75;


        public const int ShotgunLager = 290;
        public const int ShotgunAmmoLager = 85;
        public const int ShotgunMaxLager = 100;
        public const int ShotgunAmmoMaxLager = 175;



        public const int Mp5Lager = 550;
        public const int Mp5AmmoLager = 210;
        public const int Mp5MaxLager = 45;
        public const int Mp5AmmoMaxLager = 90;


        public const int CombatpdwLager = 550;
        public const int CombatpdwAmmoLager = 210;
        public const int CombatpdwMaxLager = 45;
        public const int CombatpdwAmmoMaxLager = 90;



        public const int Ak47Lager = 650;
        public const int Ak47MaxLager = 40;
        public const int Ak47AmmoLager = 210;
        public const int Ak47AmmoMaxLager = 80;


        public const int KarabinerLager = 650;
        public const int KarabinerMaxLager = 40;
        public const int KarabinerAmmoLager = 210;
        public const int KarabinerAmmoMaxLager = 80;



        public const int RifleLager = 750;
        public const int RifleAmmoLager = 310;
        public const int RifleMaxLager = 35;
        public const int RifleAmmoMaxLager = 70;

        public const int AdvancedrifleLager = 750;
        public const int AdvancedrifleAmmoLager = 310;
        public const int AdvancedrifleMaxLager = 35;
        public const int AdvancedrifleAmmoMaxLager = 70;



        public const int SniperLager = 1200;
        public const int SniperAmmoLager = 420;
        public const int SniperMaxLager = 10;
        public const int SniperAmmoMaxLager = 30;


        public const int RpgLager = 5000;
        public const int RpgAmmoLager = 500;
        public const int RpgMaxLager = 10;
        public const int RpgAmmoMaxLager = 30;


        public const int TraenengasLager = 100;
        public const int TraenengasMaxLager = 40;

        public const int MolotovLager = 250;
        public const int MolotovMaxLager = 40;





        // IVehicle Rgba types
        public const int VehicleRgbaTypePredefined = 0;
        public const int VehicleRgbaTypeCustom = 1;

        // IVehicle types
        public const string VehicleClassCompacts = "compact";
        public const string VehicleClassSedans = "sedan";
        public const string VehicleClassSuvs = "suv";
        public const string VehicleClassCoupes = "coupe";
        public const string VehicleClassMuscle = "muscle";
        public const string VehicleClassSports = "sport";
        public const string VehicleClassClassics = "sportsclassic";
        public const string VehicleClassSuper = "super";
        public const int VehicleClassMotorcycles = 8;
        public const string VehicleClassOffroad = "offroads";
        public const int VehicleClassIndustrial = 10;
        public const int VehicleClassUtility = 11;
        public const string VehicleClassVans = "van";
        public const int VehicleClassCycles = 13;
        public const int VehicleClassBoats = 14;
        public const int VehicleClassHelicopters = 15;
        public const int VehicleClassPlanes = 16;
        public const int VehicleClassService = 17;
        public const int VehicleClassEmergency = 18;
        public const int VehicleClassMilitary = 19;
        public const int VehicleClassCommercial = 20;
        public const int VehicleClassTrains = 21;

        // Tax percentage
        public const float TaxesIVehicle = 0.0025f;
        public const float TaxesHouse = 0.0030f;

        public const float VipBoniBronze = 0.025f;
        public const float VipBoniSilber = 0.050f;
        public const float VipBoniGold = 0.1f;
        public const float VipBoniRed = 0.15f;
        public const float VipBoniPlatin = 0.20f;
        public const float VipBoniTop = 0.25f;

        public const float VipBoniAutosteuerSilver = 0.1f;
        public const float VipBoniAutosteuerGold = 0.2f;
        public const float VipBoniAutosteuerUltimatered = 0.3f;
        public const float VipBoniAutosteuerPlatin = 0.4f;
        public const float VipBoniAutosteuerTopdonator = 0.5f;

        // Factions
        public const int FactionNone = 0;
        public const int FactionLspd = 1;
        public const int FactionLcn = 2;
        public const int FactionYakuza = 3;
        public const int FactionTerrorclosed = 4;
        public const int FactionNews = 5;
        public const int FactionFbi = 6;
        public const int FactionNarcos = 7;
        public const int FactionUsarmy = 8;
        public const int FactionSamcro = 9;
        public const int FactionEmergency = 10;
        public const int FactionMechanik = 11;
        public const int FactionBallas = 12;
        public const int FactionCompton = 13;

        public const string FactionNoneName = "Zivilist";
        public const string FactionPoliceName = "Los Santos Police Department";
        public const string FactionCosanostraName = "La Cosa Nostra";
        public const string FactionYakuzaName = "Yakuza";
        public const string FactionTerrorclosedName = "CLOSED";
        public const string FactionNewsName = "SAN NEWS";
        public const string FactionFbiName = "Federal Investigation Bureau";
        public const string FactionMs13Name = "Narcos";
        public const string FactionUsarmyName = "U.S Army";
        public const string FactionSamcroName = "Samcro Redwoods";
        public const string FactionEmergencyName = "Medic";
        public const string FactionMechanikName = "Mechaniker";
        public const string FactionBallasName = "Rollin Height Ballas";
        public const string FactionGroveName = "Compton Family´s";


        // Jobs
        public const string JobNone = "Arbeitslos";
        public const string JobCityTransport = "VENOX_CITY_TRANSPORT";
        public const string JobAirport = "VENOX_AIRPORT";
        public const string JobBus = "VENOX_BUSCENTER";






        // House status
        public const int HouseStateNone = 0;
        public const int HouseStateRentable = 1;
        public const int HouseStateBuyable = 2;

        // Chat message types
        public const int MessageTalk = 0;
        public const int MessageYell = 1;
        public const int MessageWhisper = 2;
        public const int MessageMe = 3;
        public const int MessageDo = 4;
        public const int MessageSuTrue = 6;
        public const int MessageSuFalse = 7;
        public const int MessageNews = 8;
        public const int MessagePhone = 9;
        public const int MessageDisconnect = 10;
        public const int MessageMegaphone = 11;
        public const int MessageRadio = 12;

        // Chat Rgbas
        public const string RgbaChatClose = "{FFFFFF}";
        public const string RgbaChatNear = "{C8C8C8}";
        public const string RgbaChatMedium = "{AAAAAA}";
        public const string RgbaChatFar = "{8C8C8C}";
        public const string RgbaChatLimit = "{6E6E6E}";
        public const string RgbaChatMe = "{C2A2DA}";
        public const string RgbaChatDo = "{0F9622}";
        public const string RgbaChatFaction = "{27F7C8}";
        public const string RgbaChatPhone = "{27F7C8}";
        public const string RgbaAdminInfo = "{00FCFF}";
        public const string RgbaAdminClantag = "{00C8FF}[VnX]{FFFFFF}";
        public const string RgbaAdminNews = "{F93131}";
        public const string RgbaAdminMp = "{F93131}";
        public const string RgbaSuccess = "{33B517}";
        public const string RgbaError = "{E10000}";
        public const string RgbaInfo = "{FDFE8B}";
        public const string RgbaHelp = "{FFFFFF}";
        public const string RgbaSuPositive = "{E3E47D}";
        public const string RgbaNews = "{805CC9}";


        // Generic interiors
        public static List<InteriorModel> InteriorList = new List<InteriorModel>
        {
            new InteriorModel("Krankenhaus", new Position(355.45f, -596.153f, 28.77341f), new Position(275.446f, -1361.11f, 24.5378f), "Coroner_Int_On", 153, "Krankenhaus", 255,255,255, 1),
            new InteriorModel("Weazel News", new Position(-598.51f, -929.95f, 23.87f), new Position(-1082.433f, -258.7667f, 37.76331f), "facelobby", 459, "Weazel News",  255,255,255,0),
            new InteriorModel("Los Santos Police Department", new Position(434.4719f,-982.0015f,30.71084f), new Position(434.4719f,-982.0015f,30.71084f), string.Empty, 60, "Los Santos Police Department",255,255,255, 0),
            new InteriorModel("Rathaus", Rathaus.RathausMarkerEingang.Position, Rathaus.RathausMarkerImInterior.Position, string.Empty, 1, "Rathaus", 255,255,255, 64),
        };


        // House interiors from the game
        public static List<HouseIplModel> HouseIplList = new List<HouseIplModel>
        {
            // Apartments with IPL
            new HouseIplModel("apa_v_mp_h_01_a", new Position(-786.8663f, 315.7642f, 217.6385f)),
            new HouseIplModel("apa_v_mp_h_01_c", new Position(-786.9563f, 315.6229f, 187.9136f)),
            new HouseIplModel("apa_v_mp_h_01_b", new Position(-774.0126f, 342.0428f, 196.6864f)),
            new HouseIplModel("apa_v_mp_h_02_a", new Position(-787.0749f, 315.8198f, 217.6386f)),
            new HouseIplModel("apa_v_mp_h_02_c", new Position(-786.8195f, 315.5634f, 187.9137f)),
            new HouseIplModel("apa_v_mp_h_02_b", new Position(-774.1382f, 342.0316f, 196.6864f)),
            new HouseIplModel("apa_v_mp_h_03_a", new Position(-786.6245f, 315.6175f, 217.6385f)),
            new HouseIplModel("apa_v_mp_h_03_c", new Position(-786.9584f, 315.7974f, 187.9135f)),
            new HouseIplModel("apa_v_mp_h_03_b", new Position(-774.0223f, 342.1718f, 196.6863f)),
            new HouseIplModel("apa_v_mp_h_04_a", new Position(-787.0902f, 315.7039f, 217.6384f)),
            new HouseIplModel("apa_v_mp_h_04_c", new Position(-787.0155f, 315.7071f, 187.9135f)),
            new HouseIplModel("apa_v_mp_h_04_b", new Position(-773.8976f, 342.1525f, 196.6863f)),
            new HouseIplModel("apa_v_mp_h_05_a", new Position(-786.9887f, 315.7393f, 217.6386f)),
            new HouseIplModel("apa_v_mp_h_05_c", new Position(-786.8809f, 315.6634f, 187.9136f)),
            new HouseIplModel("apa_v_mp_h_05_b", new Position(-774.0675f, 342.0773f, 196.6864f)),
            new HouseIplModel("apa_v_mp_h_06_a", new Position(-787.1423f, 315.6943f, 217.6384f)),
            new HouseIplModel("apa_v_mp_h_06_c", new Position(-787.0961f, 315.815f, 187.9135f)),
            new HouseIplModel("apa_v_mp_h_06_b", new Position(-773.9552f, 341.9892f, 196.6862f)),
            new HouseIplModel("apa_v_mp_h_07_a", new Position(-787.029f, 315.7113f, 217.6385f)),
            new HouseIplModel("apa_v_mp_h_07_c", new Position(-787.0574f, 315.6567f, 187.9135f)),
            new HouseIplModel("apa_v_mp_h_07_b", new Position(-774.0109f, 342.0965f, 196.6863f)),
            new HouseIplModel("apa_v_mp_h_08_a", new Position(-786.9469f, 315.5655f, 217.6383f)),
            new HouseIplModel("apa_v_mp_h_08_c", new Position(-786.9756f, 315.723f, 187.9134f)),
            new HouseIplModel("apa_v_mp_h_08_b", new Position(-774.0349f, 342.0296f, 196.6862f)),

            // Apartments without IPL
            new HouseIplModel("house_no_ipl_a", new Position(265.9776f, -1006.97f, -100.8839f)),
            new HouseIplModel("house_no_ipl_b", new Position(-30.58078f, -595.3096f, 80.03086f)),
            new HouseIplModel("house_no_ipl_c", new Position(-30.58078f, -595.3096f, 80.03086f)),
            new HouseIplModel("house_no_ipl_d", new Position(-17.72512f, -588.8995f, 90.1148f)),
            new HouseIplModel("house_no_ipl_e", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_f", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_g", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_h", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_i", new Position(-174.2659f, 497.3836f, 137.667f)),
            new HouseIplModel("house_no_ipl_j", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_k", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_l", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_m", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_n", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_o", new Position(-1451.652f, -523.7687f, 56.92904f)),
            new HouseIplModel("house_no_ipl_p", new Position(-1451.652f, -523.7687f, 56.92904f)),

            // Trevor's trailer
            new HouseIplModel("TrevorsMP", new Position(1972.965f, 3816.529f, 33.42873f)),
            new HouseIplModel("TrevorsTrailerTidy", new Position(1972.965f, 3816.529f, 33.42873f)),

            // Floyd's house
            new HouseIplModel("vb_30_crimetape", new Position(-1149.709f, -1521.088f, 10.78267f)),

            // Lester's house
            new HouseIplModel("lester_house", new Position(1273.9f, -1719.305f, 54.77141f)),

            // Janitor's office
            new HouseIplModel("v_janitor", new Position(-107.6496f, -8.308348f, 70.51957f)),

            // Mansion
            new HouseIplModel("mansion_no_ipl", new Position(1396.415f, 1141.854f, 114.3336f)),

            // Flat with rooms
            new HouseIplModel("flat_no_ipl", new Position(346.3212f, -1012.968f, -99.19625f)),

            // Franklin's aunt's house
            new HouseIplModel("franklin_hoo_house", new Position(-14.31764f, -1439.986f, 31.10155f)),

            // Franklin's mansion
            new HouseIplModel("franklin_mansion_no_ipl", new Position(7.69007f, 538.0661f, 176.028f)),

            // O'Neill's farm
            new HouseIplModel("farmint", new Position(2436.875f, 4974.916f, 46.8106f)),

            // Motel room
            new HouseIplModel("motel_room_no_ipl", new Position(151.1905f, -1007.731f, -98.99999f))
        };

        // Faction ranks
        public static List<FactionModel> FactionRankList = new List<FactionModel>
        {
            new FactionModel(Messages.FacNoneM, Messages.FacNoneF, FactionNone, 0, 500),
            new FactionModel(Messages.FacNoneM, Messages.FacNoneF, FactionNone, 1, 500),
            new FactionModel(Messages.FacNoneM, Messages.FacNoneF, FactionNone, 2, 500),
            new FactionModel(Messages.FacNoneM, Messages.FacNoneF, FactionNone, 3, 500),
            new FactionModel(Messages.FacNoneM, Messages.FacNoneF, FactionNone, 4, 500),
            new FactionModel(Messages.FacNoneM, Messages.FacNoneF, FactionNone, 5, 500),

            // Police department
            new FactionModel(Messages.FacLspd0M, Messages.FacLspd0F, FactionLspd, 0, 625),
            new FactionModel(Messages.FacLspd1M, Messages.FacLspd1F, FactionLspd, 1, 750),
            new FactionModel(Messages.FacLspd2M, Messages.FacLspd2F, FactionLspd, 2, 1000),
            new FactionModel(Messages.FacLspd3M, Messages.FacLspd3F, FactionLspd, 3, 1350),
            new FactionModel(Messages.FacLspd4M, Messages.FacLspd4F, FactionLspd, 4, 1500),
            new FactionModel(Messages.FacLspd5M, Messages.FacLspd5F, FactionLspd, 5, 1750),

            // Mafia 
            new FactionModel(Messages.FacMafia0M, Messages.FacMafia0F, FactionLcn, 0, 480),
            new FactionModel(Messages.FacMafia1M, Messages.FacMafia1F, FactionLcn, 1, 600),
            new FactionModel(Messages.FacMafia2M, Messages.FacMafia2F, FactionLcn, 2, 700),
            new FactionModel(Messages.FacMafia3M, Messages.FacMafia3F, FactionLcn, 3, 900),
            new FactionModel(Messages.FacMafia4M, Messages.FacMafia4F, FactionLcn, 4, 1200),
            new FactionModel(Messages.FacMafia5M, Messages.FacMafia5F, FactionLcn, 5, 1400),

            // YAKUZA 
            new FactionModel(Messages.FacYakuza0M, Messages.FacYakuza0F, FactionYakuza, 0, 480),
            new FactionModel(Messages.FacYakuza1M, Messages.FacYakuza1F, FactionYakuza, 1, 600),
            new FactionModel(Messages.FacYakuza2M, Messages.FacYakuza2F, FactionYakuza, 2, 700),
            new FactionModel(Messages.FacYakuza3M, Messages.FacYakuza3F, FactionYakuza, 3, 900),
            new FactionModel(Messages.FacYakuza4M, Messages.FacYakuza4F, FactionYakuza, 4, 1200),
            new FactionModel(Messages.FacYakuza5M, Messages.FacYakuza5F, FactionYakuza, 5, 1400),


            // NEWS 
            new FactionModel(Messages.FacNews0M, Messages.FacNews0F, FactionNews, 0, 1000),
            new FactionModel(Messages.FacNews1M, Messages.FacNews1F, FactionNews, 1, 1250),
            new FactionModel(Messages.FacNews2M, Messages.FacNews2F, FactionNews, 2, 1500),
            new FactionModel(Messages.FacNews3M, Messages.FacNews3F, FactionNews, 3, 1600),
            new FactionModel(Messages.FacNews4M, Messages.FacNews4F, FactionNews, 4, 1850),
            new FactionModel(Messages.FacNews5M, Messages.FacNews5F, FactionNews, 5, 1900),

            // FBI 
            new FactionModel(Messages.FacFbi0M, Messages.FacFbi0F, FactionFbi, 0, 825),
            new FactionModel(Messages.FacFbi1M, Messages.FacFbi1F, FactionFbi, 1, 950),
            new FactionModel(Messages.FacFbi2M, Messages.FacFbi2F, FactionFbi, 2, 1200),
            new FactionModel(Messages.FacFbi3M, Messages.FacFbi3F, FactionFbi, 3, 1550),
            new FactionModel(Messages.FacFbi4M, Messages.FacFbi4F, FactionFbi, 4, 1750),
            new FactionModel(Messages.FacFbi5M, Messages.FacFbi5F, FactionFbi, 5, 1950),

            // MS13 
            new FactionModel(Messages.FacMs130M, Messages.FacMs130F, FactionNarcos, 0, 480),
            new FactionModel(Messages.FacMs131M, Messages.FacMs131F, FactionNarcos, 1, 600),
            new FactionModel(Messages.FacMs132M, Messages.FacMs132F, FactionNarcos, 2, 700),
            new FactionModel(Messages.FacMs133M, Messages.FacMs133F, FactionNarcos, 3, 900),
            new FactionModel(Messages.FacMs134M, Messages.FacMs134F, FactionNarcos, 4, 1200),
            new FactionModel(Messages.FacMs135M, Messages.FacMs135F, FactionNarcos, 5, 1400),

            // USARMY 
            new FactionModel(Messages.FacUsarmy0M, Messages.FacUsarmy0F, FactionUsarmy, 0, 0),
            new FactionModel(Messages.FacUsarmy1M, Messages.FacUsarmy1F, FactionUsarmy, 1, 1250),
            new FactionModel(Messages.FacUsarmy2M, Messages.FacUsarmy2F, FactionUsarmy, 2, 1388),
            new FactionModel(Messages.FacUsarmy3M, Messages.FacUsarmy3F, FactionUsarmy, 3, 1685),
            new FactionModel(Messages.FacUsarmy4M, Messages.FacUsarmy4F, FactionUsarmy, 4, 2056),
            new FactionModel(Messages.FacUsarmy5M, Messages.FacUsarmy5F, FactionUsarmy, 5, 2420),

            // AOD 
            new FactionModel(Messages.FacSamcro0M, Messages.FacSamcro0F, FactionSamcro, 0, 480),
            new FactionModel(Messages.FacSamcro1M, Messages.FacSamcro1F, FactionSamcro, 1, 600),
            new FactionModel(Messages.FacSamcro2M, Messages.FacSamcro2F, FactionSamcro, 2, 700),
            new FactionModel(Messages.FacSamcro3M, Messages.FacSamcro3F, FactionSamcro, 3, 900),
            new FactionModel(Messages.FacSamcro4M, Messages.FacSamcro4F, FactionSamcro, 4, 1200),
            new FactionModel(Messages.FacSamcro5M, Messages.FacSamcro5F, FactionSamcro, 5, 1400),

            // MEDIC 
            new FactionModel(Messages.FacMedic0M, Messages.FacMedic0F, FactionEmergency, 0, 1200),
            new FactionModel(Messages.FacMedic1M, Messages.FacMedic1F, FactionEmergency, 1, 1300),
            new FactionModel(Messages.FacMedic2M, Messages.FacMedic2F, FactionEmergency, 2, 1500),
            new FactionModel(Messages.FacMedic3M, Messages.FacMedic3F, FactionEmergency, 3, 1650),
            new FactionModel(Messages.FacMedic4M, Messages.FacMedic4F, FactionEmergency, 4, 1850),
            new FactionModel(Messages.FacMedic5M, Messages.FacMedic5F, FactionEmergency, 5, 2000),

            // MECHANIKER 
            new FactionModel(Messages.FacMechaniker0M, Messages.FacMechaniker0F, FactionMechanik, 0, 200),
            new FactionModel(Messages.FacMechaniker1M, Messages.FacMechaniker1F, FactionMechanik, 1, 600),
            new FactionModel(Messages.FacMechaniker2M, Messages.FacMechaniker2F, FactionMechanik, 2, 750),
            new FactionModel(Messages.FacMechaniker3M, Messages.FacMechaniker3F, FactionMechanik, 3, 950),
            new FactionModel(Messages.FacMechaniker4M, Messages.FacMechaniker4F, FactionMechanik, 4, 1350),
            new FactionModel(Messages.FacMechaniker5M, Messages.FacMechaniker5F, FactionMechanik, 5, 1500),

            // BALLAS 
            new FactionModel(Messages.FacBallas0M, Messages.FacBallas0F, FactionBallas, 0, 480),
            new FactionModel(Messages.FacBallas1M, Messages.FacBallas1F, FactionBallas, 1, 600),
            new FactionModel(Messages.FacBallas2M, Messages.FacBallas2F, FactionBallas, 2, 700),
            new FactionModel(Messages.FacBallas3M, Messages.FacBallas3F, FactionBallas, 3, 900),
            new FactionModel(Messages.FacBallas4M, Messages.FacBallas4F, FactionBallas, 4, 1200),
            new FactionModel(Messages.FacBallas5M, Messages.FacBallas5F, FactionBallas, 5, 1400),

            // Compton 
            new FactionModel(Messages.FacCompton0M, Messages.FacCompton0F, FactionCompton, 0, 480),
            new FactionModel(Messages.FacCompton1M, Messages.FacCompton1F, FactionCompton, 1, 600),
            new FactionModel(Messages.FacCompton2M, Messages.FacCompton2F, FactionCompton, 2, 700),
            new FactionModel(Messages.FacCompton3M, Messages.FacCompton3F, FactionCompton, 3, 900),
            new FactionModel(Messages.FacCompton4M, Messages.FacCompton4F, FactionCompton, 4, 1200),
            new FactionModel(Messages.FacCompton5M, Messages.FacCompton5F, FactionCompton, 5, 1400),
        };


        // Uniform list
        public static List<UniformModel> UniformList = new List<UniformModel>
        {  
            // Male police uniform
            new UniformModel(0, FactionLspd, SexMale, 0, 0, 0),
            new UniformModel(0, FactionLspd, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_LSPD, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionLspd, SexMale, 3, 0, 0),
            new UniformModel(0, FactionLspd, SexMale, 4, 35, 0),
            new UniformModel(0, FactionLspd, SexMale, 5, 0, 0),
            new UniformModel(0, FactionLspd, SexMale, 6, 25, 0),
            new UniformModel(0, FactionLspd, SexMale, 7, 0, 0),
            new UniformModel(0, FactionLspd, SexMale, 8, 58, 0),
            new UniformModel(0, FactionLspd, SexMale, 9, 0, 0),
            new UniformModel(0, FactionLspd, SexMale, 10, 0, 0),
            new UniformModel(0, FactionLspd, SexMale, 11, 55, 0),

            // Female police uniform
            new UniformModel(0, FactionLspd, SexFemale, 0, 0, 0),
            new UniformModel(0, FactionLspd, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_LSPD, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionLspd, SexFemale, 3, 14, 0),
            new UniformModel(0, FactionLspd, SexFemale, 4, 34, 0),
            new UniformModel(0, FactionLspd, SexFemale, 5, 0, 0),
            new UniformModel(0, FactionLspd, SexFemale, 6, 25, 0),
            new UniformModel(0, FactionLspd, SexFemale, 7, 0, 0),
            new UniformModel(0, FactionLspd, SexFemale, 8, 35, 0),
            new UniformModel(0, FactionLspd, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionLspd, SexFemale, 10, 0, 0),
            new UniformModel(0, FactionLspd, SexFemale, 11, 48, 0),


            //////////////////////////////////////////////


            // Male Mafia uniform
            new UniformModel(0, FactionLcn, SexMale, 0, 0, 0),
            new UniformModel(0, FactionLcn, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_LCN, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionLcn, SexMale, 3, 4, 0),
            new UniformModel(0, FactionLcn, SexMale, 4, 28, 0),
            new UniformModel(0, FactionLcn, SexMale, 5, 0, 0),
            new UniformModel(0, FactionLcn, SexMale, 6, 21, 0),
            new UniformModel(0, FactionLcn, SexMale, 7, 0, 0),
            new UniformModel(0, FactionLcn, SexMale, 8, 33, 0),
            new UniformModel(0, FactionLcn, SexMale, 9, 0, 0),
            new UniformModel(0, FactionLcn, SexMale, 10, 0, 0),
            new UniformModel(0, FactionLcn, SexMale, 11, 29, 0),

            // Female Mafia uniform
            new UniformModel(0, FactionLcn, SexFemale, 0, 0, 0),
            new UniformModel(0, FactionLcn, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_LCN, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionLcn, SexFemale, 3, 3, 0),
            new UniformModel(0, FactionLcn, SexFemale, 4, 37, 0),
            new UniformModel(0, FactionLcn, SexFemale, 5, 0, 0),
            new UniformModel(0, FactionLcn, SexFemale, 6, 29, 0),
            new UniformModel(0, FactionLcn, SexFemale, 7, 0, 0),
            new UniformModel(0, FactionLcn, SexFemale, 8, 147, 0),
            new UniformModel(0, FactionLcn, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionLcn, SexFemale, 10, 0, 0),
            new UniformModel(0, FactionLcn, SexFemale, 11, 7, 0),
            //////////////////////////////////////////////


            // Male YAKUZA uniform


            //new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 2, -1, -1),


            new UniformModel(0, FactionYakuza, SexMale, 5, 0, 0),

            new UniformModel(0, FactionYakuza, SexMale, 7, 0, 0),
            new UniformModel(0, FactionYakuza, SexMale, 8, 15, 0),
            new UniformModel(0, FactionYakuza, SexMale, 9, 0, 0),
            new UniformModel(0, FactionYakuza, SexMale, 10, 0, 0),

            // Move
            new UniformModel(0, FactionYakuza, SexMale, 0, 0, 0),
            new UniformModel(0, FactionYakuza, SexMale, 1, -1, 0),
            new UniformModel(0, FactionYakuza, SexMale, 11, 107, 2),
            new UniformModel(0, FactionYakuza, SexMale, 3, 33, 0),
            new UniformModel(0, FactionYakuza, SexMale, 4, 33, 0),
            new UniformModel(0, FactionYakuza, SexMale, 6, 81, 0),


            // Female YAKUZA uniform
            new UniformModel(0, FactionYakuza, SexFemale, 0, 0, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionYakuza, SexFemale, 3, 3, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 4, 23, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 5, 0, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 6, 0, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 7, 0, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 8, 15, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 10, 0, 0),
            new UniformModel(0, FactionYakuza, SexFemale, 11, 98, 0),

            // Male NEWS uniform
            new UniformModel(0, FactionNews, SexMale, 0, 0, 0),
            new UniformModel(0, FactionNews, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_NEWS, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionNews, SexMale, 3, 0, 0),
            new UniformModel(0, FactionNews, SexMale, 4, 1, 0),
            new UniformModel(0, FactionNews, SexMale, 5, 0, 0),
            new UniformModel(0, FactionNews, SexMale, 6, 9, 1),
            new UniformModel(0, FactionNews, SexMale, 7, 0, 0),
            new UniformModel(0, FactionNews, SexMale, 8, 15, 0),
            new UniformModel(0, FactionNews, SexMale, 9, 0, 0),
            new UniformModel(0, FactionNews, SexMale, 10, 0, 0),
            new UniformModel(0, FactionNews, SexMale, 11, 9, 15),

            // Female NEWS uniform
            new UniformModel(0, FactionNews, SexFemale, 0, 0, 0),
            new UniformModel(0, FactionNews, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionNews, SexFemale, 3, 3, 0),
            new UniformModel(0, FactionNews, SexFemale, 4, 23, 0),
            new UniformModel(0, FactionNews, SexFemale, 5, 0, 0),
            new UniformModel(0, FactionNews, SexFemale, 6, 0, 0),
            new UniformModel(0, FactionNews, SexFemale, 7, 0, 0),
            new UniformModel(0, FactionNews, SexFemale, 8, 15, 0),
            new UniformModel(0, FactionNews, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionNews, SexFemale, 10, 0, 0),
            new UniformModel(0, FactionNews, SexFemale, 11, 98, 0),




            // Male FBI uniform
            new UniformModel(0, FactionFbi, SexMale, 0, -1, -1),
            new UniformModel(0, FactionFbi, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_FBI, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionFbi, SexMale, 3, 11, 0),
            new UniformModel(0, FactionFbi, SexMale, 4, 10, 0),
            new UniformModel(0, FactionFbi, SexMale, 5, -1, -1),
            new UniformModel(0, FactionFbi, SexMale, 6, 10, 0),
            new UniformModel(0, FactionFbi, SexMale, 7, 12, 2),
            new UniformModel(0, FactionFbi, SexMale, 8, 15, 0),
            new UniformModel(0, FactionFbi, SexMale, 9, 0, 0),
            new UniformModel(0, FactionFbi, SexMale, 10, -1, 0),
            new UniformModel(0, FactionFbi, SexMale, 11,13, 0),

            // Female FBI uniform
            new UniformModel(0, FactionFbi, SexFemale, 0, -1, -1),
            new UniformModel(0, FactionFbi, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_FBI, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionFbi, SexFemale, 3, 85, 0),
            new UniformModel(0, FactionFbi, SexFemale, 4, 96, 0),
            new UniformModel(0, FactionFbi, SexFemale, 5, -1, -1),
            new UniformModel(0, FactionFbi, SexFemale, 6, 51, 0),
            new UniformModel(0, FactionFbi, SexFemale, 7, 127, 0),
            new UniformModel(0, FactionFbi, SexFemale, 8, 129, 0),
            new UniformModel(0, FactionFbi, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionFbi, SexFemale, 10, 58, 0),
            new UniformModel(0, FactionFbi, SexFemale, 11, 250, 0),



            
            // Male AZTECAS uniform
            new UniformModel(0, FactionNarcos, SexMale, 0, 8, -1),
            new UniformModel(0, FactionNarcos, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_NARCOS, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionNarcos, SexMale, 3, 11, 0),
            new UniformModel(0, FactionNarcos, SexMale, 4, 22, 0),
            new UniformModel(0, FactionNarcos, SexMale, 5, 0, -1),
            new UniformModel(0, FactionNarcos, SexMale, 6, 21, 5),
            new UniformModel(0, FactionNarcos, SexMale, 7, 0, 0),
            new UniformModel(0, FactionNarcos, SexMale, 8, 15, 0),
            new UniformModel(0, FactionNarcos, SexMale, 9, 0, 0),
            new UniformModel(0, FactionNarcos, SexMale, 10, 0, 0),
            new UniformModel(0, FactionNarcos, SexMale, 11,13, 1),

            // Female AZTECAS uniform
            new UniformModel(0, FactionNarcos, SexFemale, 0, -1, -1),
            new UniformModel(0, FactionNarcos, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_NARCOS, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionNarcos, SexFemale, 3, 85, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 4, 96, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 5, -1, -1),
            new UniformModel(0, FactionNarcos, SexFemale, 6, 51, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 7, 0, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 8, 129, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 10, 58, 0),
            new UniformModel(0, FactionNarcos, SexFemale, 11, 250, 0),

            // Male Army uniform
            new UniformModel(0, FactionUsarmy, SexMale, 0, 107, 8),
            new UniformModel(0, FactionUsarmy, SexMale, 2, 2,4),
            new UniformModel(0, FactionUsarmy, SexMale, 4, 86, 8),
            new UniformModel(0, FactionUsarmy, SexMale, 6, 24, 0),
            new UniformModel(0, FactionUsarmy, SexMale, 8, 130, 0),
            new UniformModel(0, FactionUsarmy, SexMale, 11,220, 8),
                        
            // Male ROCKER uniform
            new UniformModel(0, FactionSamcro, SexMale, 0, -1, -1),
            new UniformModel(0, FactionSamcro, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionSamcro, SexMale, 3, 2, 0),
            new UniformModel(0, FactionSamcro, SexMale, 4, 76, 1),
            new UniformModel(0, FactionSamcro, SexMale, 5, -1, -1),
            new UniformModel(0, FactionSamcro, SexMale, 6, 25, 0),
            new UniformModel(0, FactionSamcro, SexMale, 7, 0, 0),
            new UniformModel(0, FactionSamcro, SexMale, 8, 14, 0),
            new UniformModel(0, FactionSamcro, SexMale, 9, 0, 0),
            new UniformModel(0, FactionSamcro, SexMale, 10, -1, 0),
            new UniformModel(0, FactionSamcro, SexMale, 11,175,3),

            // Female ROCKER uniform
            new UniformModel(0, FactionSamcro, SexFemale, 0, -1, -1),
            new UniformModel(0, FactionSamcro, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionSamcro, SexFemale, 3, 85, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 4, 96, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 5, -1, -1),
            new UniformModel(0, FactionSamcro, SexFemale, 6, 51, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 7, 127, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 8, 129, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 10, 58, 0),
            new UniformModel(0, FactionSamcro, SexFemale, 11, 250, 0),




            // Male paramedic uniform
            new UniformModel(0, FactionEmergency, SexMale, 0, -1, -1),
            new UniformModel(0, FactionEmergency, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionEmergency, SexMale, 3, 90, 0),
            new UniformModel(0, FactionEmergency, SexMale, 4, 96, 0),
            new UniformModel(0, FactionEmergency, SexMale, 5, -1, -1),
            new UniformModel(0, FactionEmergency, SexMale, 6, 51, 0),
            new UniformModel(0, FactionEmergency, SexMale, 7, 126, 0),
            new UniformModel(0, FactionEmergency, SexMale, 8, 15, 0),
            new UniformModel(0, FactionEmergency, SexMale, 9, 0, 0),
            new UniformModel(0, FactionEmergency, SexMale, 10, 57, 0),
            new UniformModel(0, FactionEmergency, SexMale, 11,249, 0),

            // Female paramedic uniform
            new UniformModel(0, FactionEmergency, SexFemale, 0, -1, -1),
            new UniformModel(0, FactionEmergency, SexFemale, 1, 0, 0),
            //new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionEmergency, SexFemale, 3, 85, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 4, 96, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 5, -1, -1),
            new UniformModel(0, FactionEmergency, SexFemale, 6, 51, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 7, 127, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 8, 129, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 10, 58, 0),
            new UniformModel(0, FactionEmergency, SexFemale, 11, 250, 0),


            // Male paramedic uniform
            new UniformModel(0, FactionMechanik, SexMale, 0, -1, -1),
            new UniformModel(0, FactionMechanik, SexMale, 1, 0, 0),
            //new UniformModel(0, FACTION_MECHANIK, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionMechanik, SexMale, 3, 0, 0),
            new UniformModel(0, FactionMechanik, SexMale, 4, 36, 0),
            new UniformModel(0, FactionMechanik, SexMale, 5, -1, -1),
            new UniformModel(0, FactionMechanik, SexMale, 6, 27, 0),
            new UniformModel(0, FactionMechanik, SexMale, 7, -1, -1),
            new UniformModel(0, FactionMechanik, SexMale, 8, 59, 0),
            new UniformModel(0, FactionMechanik, SexMale, 9, -1, -1),
            new UniformModel(0, FactionMechanik, SexMale, 10, -1, -1),
            new UniformModel(0, FactionMechanik, SexMale, 11, 273, 0),

            // Male BALLAS uniform
            new UniformModel(0, FactionBallas, SexMale, 0, -1, -1),
            new UniformModel(0, FactionBallas, SexMale, 1, -1, -1),
            //new UniformModel(0, FACTION_BALLAS, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionBallas, SexMale, 3, 5, 0),
            new UniformModel(0, FactionBallas, SexMale, 4, 5, 9),
            new UniformModel(0, FactionBallas, SexMale, 5, -1, -1),
            new UniformModel(0, FactionBallas, SexMale, 6, 9, 1),
            new UniformModel(0, FactionBallas, SexMale, 7, -1, -1),
            new UniformModel(0, FactionBallas, SexMale, 8, 15, 0),
            new UniformModel(0, FactionBallas, SexMale, 9, 0, 0),
            new UniformModel(0, FactionBallas, SexMale, 10, -1, 0),
            new UniformModel(0, FactionBallas, SexMale, 11,237,11),

            // Female BALLAS uniform
            new UniformModel(0, FactionBallas, SexFemale, 0, -1, -1),
            new UniformModel(0, FactionBallas, SexFemale, 1, -1, -1),
            //new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionBallas, SexFemale, 3, 85, 0),
            new UniformModel(0, FactionBallas, SexFemale, 4, 96, 0),
            new UniformModel(0, FactionBallas, SexFemale, 5, -1, -1),
            new UniformModel(0, FactionBallas, SexFemale, 6, 51, 0),
            new UniformModel(0, FactionBallas, SexFemale, 7, -1, -1),
            new UniformModel(0, FactionBallas, SexFemale, 8, 129, 0),
            new UniformModel(0, FactionBallas, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionBallas, SexFemale, 10, 58, 0),
            new UniformModel(0, FactionBallas, SexFemale, 11, 250, 0),
            
            // Male GROVE uniform
            new UniformModel(0, FactionCompton, SexMale, 0, -1, -1),
            new UniformModel(0, FactionCompton, SexMale, 1, -1, -1),
            //new UniformModel(0, FACTION_COMPTON, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FactionCompton, SexMale, 3, 5, 0),
            new UniformModel(0, FactionCompton, SexMale, 4, 27, 10),
            new UniformModel(0, FactionCompton, SexMale, 5, -1, -1),
            new UniformModel(0, FactionCompton, SexMale, 6, 9, 1),
            new UniformModel(0, FactionCompton, SexMale, 7, -1, -1),
            new UniformModel(0, FactionCompton, SexMale, 8, 15, 0),
            new UniformModel(0, FactionCompton, SexMale, 9, 0, 0),
            new UniformModel(0, FactionCompton, SexMale, 10, -1, 0),
            new UniformModel(0, FactionCompton, SexMale, 11,237,14),

            // Female GROVE uniform
            new UniformModel(0, FactionCompton, SexFemale, 0, -1, -1),
            new UniformModel(0, FactionCompton, SexFemale, 1, -1, 0),
            //new UniformModel(0, FACTION_COMPTON, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FactionCompton, SexFemale, 3, 85, 0),
            new UniformModel(0, FactionCompton, SexFemale, 4, 96, 0),
            new UniformModel(0, FactionCompton, SexFemale, 5, -1, -1),
            new UniformModel(0, FactionCompton, SexFemale, 6, 51, 0),
            new UniformModel(0, FactionCompton, SexFemale, 7, -1, -1),
            new UniformModel(0, FactionCompton, SexFemale, 8, 129, 0),
            new UniformModel(0, FactionCompton, SexFemale, 9, 0, 0),
            new UniformModel(0, FactionCompton, SexFemale, 10, 58, 0),
            new UniformModel(0, FactionCompton, SexFemale, 11, 250, 0),
        };



        // Jail positions
        public static List<Position> JailSpawns = new List<Position>
        {
            // Cells
            new Position(460.0685f, -993.9847f, 24.91487f),
            new Position(459.6115f, -998.0204f, 24.91487f),
            new Position(459.8612f, -1001.641f, 24.91487f),

            // IC jail's exit
            new Position(463.6655f, -990.8979f, 24.91487f),

            // OOC jail's exit
            new Position(-1285.544f, -567.0439f, 31.71239f)
        };

        // Inventory targets
        public const int InventoryTargetSelf = 0;
        public const int InventoryTargetPlayer = 1;
        public const int InventoryTargetHouse = 2;
        public const int InventoryTargetVehicleTrunk = 3;
        public const int InventoryTargetVehiclePlayer = 4;


        // Business sellable items
        public static List<BusinessItemModel> BusinessItemList = new List<BusinessItemModel>
        {
            // 24-7
            new BusinessItemModel("Benzinkannister", ItemHashBenzinkannister, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Tankstellen Snack", ItemHashTankstellensnack, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Lebkuchenmännchen", ItemHashLebkuchenmaennchen, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Cookies", ItemHashCookies, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Schokolade", ItemHashSchokolade, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Spareribs", ItemHashSparerips, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Lebkuchenmännchen", ItemHashTankstellensnack, ItemTypeConsumable, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Glühwein", ItemHashGluehwein, ItemTypeConsumable, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Milch", ItemHashMilch, ItemTypeConsumable, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Heiße Schokolade", ItemHashHeisseschokolade, ItemTypeConsumable, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Schokolade", ItemHashSchokolade, ItemTypeConsumable, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Kokain", ItemHashKoks, ItemTypeConsumable, 8, 0.1f, -2, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(270.0f, 0.0f, 0.0f), BusinessType247, 0.0f),
            new BusinessItemModel("Gras", ItemHashWeed, ItemTypeConsumable, 5, 0.1f, 5, 1, new Position(0.05f, -0.03f, 0.0f), new Rotation(270.0f, 20.0f, -20.0f), BusinessType247, 0.0f),
        };

        // Clothes list
        public static List<BusinessClothesModel> BusinessClothesList = new List<BusinessClothesModel>
        {
            // Masks

           	//new BusinessClothesModel(0, "Schwein", CLOTHES_MASK, 1, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Totenkopf", ClothesMask, 2, SexNone, 3500),
            //new BusinessClothesModel(0, "Affe", CLOTHES_MASK, 3, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hockey", ClothesMask, 4, SexNone, 3500),
            /*new BusinessClothesModel(0, "Anderer Affe", CLOTHES_MASK, 5, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Farbiges Lächeln", CLOTHES_MASK, 6, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Gárgola", CLOTHES_MASK, 7, SaEX_NONE, 0),
            new BusinessClothesModel(0, "Santa", CLOTHES_MASK, 8, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Reno", CLOTHES_MASK, 9, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Frosty", CLOTHES_MASK, 10, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Antifaz", CLOTHES_MASK, 11, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Pinocho veneciano", CLOTHES_MASK, 12, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Cupido", CLOTHES_MASK, 13, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Hockey (Blau)", ClothesMask, 14, SexNone, 3500),
            /*new BusinessClothesModel(0, "Hockey calavera", CLOTHES_MASK, 15, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hannibal Lecter", CLOTHES_MASK, 16, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Gato", CLOTHES_MASK, 17, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Zorro", CLOTHES_MASK, 18, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Búho", CLOTHES_MASK, 19, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Tejón", CLOTHES_MASK, 20, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Oso", CLOTHES_MASK, 21, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Bisonte", CLOTHES_MASK, 22, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Toro", CLOTHES_MASK, 23, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Águila", CLOTHES_MASK, 24, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Grulla turbia", CLOTHES_MASK, 25, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Lobo", CLOTHES_MASK, 26, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Gorro de aviador", CLOTHES_MASK, 27, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Calavera negra", CLOTHES_MASK, 29, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Hockey (Jason)", ClothesMask, 30, SexNone, 3500),
            /*new BusinessClothesModel(0, "Pingüino", CLOTHES_MASK, 31, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Media roja", CLOTHES_MASK, 32, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Jengibre feliz", CLOTHES_MASK, 33, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Duende", CLOTHES_MASK, 34, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Sturmhaube", ClothesMask, 35, SexNone, 3500),
            new BusinessClothesModel(0, "Sturmhaube (Strumpf)", ClothesMask, 37, SexNone, 3500),
            /*new BusinessClothesModel(0, "Zombie", CLOTHES_MASK, 39, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Momia", CLOTHES_MASK, 40, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Vampiro", CLOTHES_MASK, 41, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Reconstruído", CLOTHES_MASK, 42, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Superhéroe", CLOTHES_MASK, 43, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Waifu", CLOTHES_MASK, 44, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Detective", CLOTHES_MASK, 45, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Polizeibandc", ClothesMask, 47, SexNone, 3500),
            new BusinessClothesModel(0, "Tape", ClothesMask, 48, SexNone, 3500),
            new BusinessClothesModel(0, "Papiertüte", ClothesMask, 49, SexNone, 3500),
            //new BusinessClothesModel(0, "Estatua", CLOTHES_MASK, 50, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Bandana", ClothesMask, 51, SexNone, 3500),
            /*new BusinessClothesModel(0, "Capucha", CLOTHES_MASK, 53, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Camiseta", CLOTHES_MASK, 54, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Gorro", CLOTHES_MASK, 55, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Pasamontañas azul", CLOTHES_MASK, 56, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Sturmhaube (Wolle)", ClothesMask, 57, SexNone, 3500),
            /*new BusinessClothesModel(0, "Pasamontañas rallado", CLOTHES_MASK, 58, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hombre lobo", CLOTHES_MASK, 59, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Calabaza maligna", CLOTHES_MASK, 60, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Viejo zombie", CLOTHES_MASK, 61, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Freddy Krueger", CLOTHES_MASK, 62, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Shingeki no kyojin", CLOTHES_MASK, 63, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Calavera vomitada", CLOTHES_MASK, 64, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Perro lobo cabreado", CLOTHES_MASK, 65, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Moscardon con lengua", CLOTHES_MASK, 66, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Orco de mordor", CLOTHES_MASK, 67, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Demonio con cuernos", CLOTHES_MASK, 68, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hombre del saco", CLOTHES_MASK, 69, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Calavera mexicana zombie", CLOTHES_MASK, 70, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Bruja piruja", CLOTHES_MASK, 71, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Demonio con cuernos bronceado", CLOTHES_MASK, 72, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Sin pelo", CLOTHES_MASK, 73, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Jengibre enfadado bronceado", CLOTHES_MASK, 74, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Jengibre enfadado", CLOTHES_MASK, 75, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Papa noel grumete", CLOTHES_MASK, 76, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Arbol de navidad cutre", CLOTHES_MASK, 77, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Bizcocho de chocolate con crema pastelera", CLOTHES_MASK, 78, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Otro hombre lobo muy peludo", CLOTHES_MASK, 79, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hombre lobo con gorra LS", CLOTHES_MASK, 80, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hombre lobo listo para jugar al tenis", CLOTHES_MASK, 81, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hombre lobo gym", CLOTHES_MASK, 82, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hombre lobo os desea feliz navidad", CLOTHES_MASK, 83, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Yeti de las nieves aburrido", CLOTHES_MASK, 84, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Pollo relleno de cara", CLOTHES_MASK, 85, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Vieja muy muy pasada de todo", CLOTHES_MASK, 86, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Abuelo con mala leche", CLOTHES_MASK, 87, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Vieja despues de proyecto hombre", CLOTHES_MASK, 88, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Tipo motorista negra", CLOTHES_MASK, 89, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Media cara nariz boca roja", CLOTHES_MASK, 90, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Casco del espacio", CLOTHES_MASK, 91, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Cthulhu adolescente", CLOTHES_MASK, 92, SEX_NONE, 3500),
            new BusinessClothesModel(0, "T-REX", CLOTHES_MASK, 93, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Oni, demonio japones", CLOTHES_MASK, 94, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Payaso sin gracia", CLOTHES_MASK, 95, SEX_NONE, 3500),
            new BusinessClothesModel(0, "King Kong", CLOTHES_MASK, 96, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Caballo", CLOTHES_MASK, 97, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Unicornio", CLOTHES_MASK, 98, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Calavera roja con trazos dorados", CLOTHES_MASK, 99, SEX_NONE, 3500),
            new BusinessClothesModel(0, "PUG", CLOTHES_MASK, 100, SEX_NONE, 3500),
            new BusinessClothesModel(0, "BIGNESS media cara nariz boca", CLOTHES_MASK, 101, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Dibujado por niños", CLOTHES_MASK, 102, SEX_NONE, 3500),*/
                
                
                
            // Female pants
                
            new BusinessClothesModel(0, "Dunkle schmale Jeans", ClothesLegs, 0, SexFemale, 5500),
            new BusinessClothesModel(0, "Dunkle weite Jeans", ClothesLegs, 1, SexFemale, 5500),
            new BusinessClothesModel(0, "Weiße Jogginghose", ClothesLegs, 2, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", ClothesLegs, 3, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Cowyboy Hose", ClothesLegs, 4, SexFemale, 5500),
            new BusinessClothesModel(0, "Bermudashorts", ClothesLegs, 5, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", ClothesLegs, 6, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarzer Rock", ClothesLegs, 7, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarzer Minirock", ClothesLegs, 8, SexFemale, 5500),
            new BusinessClothesModel(0, "Gemusterter Minirock", ClothesLegs, 9, SexFemale, 5500),
            new BusinessClothesModel(0, "Kurze Sporthose (Weiß)", ClothesLegs, 10, SexFemale, 5500),
            new BusinessClothesModel(0, "Braune Cowboy Hose", ClothesLegs, 11, SexFemale, 5500),
            new BusinessClothesModel(0, "Karierter Minirock", ClothesLegs, 12, SexFemale, 5500),
            new BusinessClothesModel(0, "Shorts (Blau)", ClothesLegs, 14, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarzer Bikini", ClothesLegs, 15, SexFemale, 5500),
            new BusinessClothesModel(0, "Shorts (Gelb)", ClothesLegs, 16, SexFemale, 5500),
            new BusinessClothesModel(0, "Weißer Bikini", ClothesLegs, 17, SexFemale, 5500),
            new BusinessClothesModel(0, "Roter Rock", ClothesLegs, 18, SexFemale, 5500),
            new BusinessClothesModel(0, "Weißer Slip", ClothesLegs, 19, SexFemale, 5500),
            new BusinessClothesModel(0, "Weißer Slip mit Strumpfhose", ClothesLegs, 20, SexFemale, 5500),
            new BusinessClothesModel(0, "Roter Bikini", ClothesLegs, 21, SexFemale, 5500),
            new BusinessClothesModel(0, "Weiße Hose", ClothesLegs, 23, SexFemale, 5500),
            new BusinessClothesModel(0, "Comic Rock", ClothesLegs, 24, SexFemale, 5500),
            new BusinessClothesModel(0, "Hot Pants", ClothesLegs, 25, SexFemale, 5500),
            new BusinessClothesModel(0, "Leoparden Minirock", ClothesLegs, 26, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Latex Hose", ClothesLegs, 27, SexFemale, 5500),
            new BusinessClothesModel(0, "Rot, weißer Minirock", ClothesLegs, 28, SexFemale, 5500),
            new BusinessClothesModel(0, "Graue Hose mit Griffen", ClothesLegs, 29, SexFemale, 5500),
            new BusinessClothesModel(0, "Lockere Schwarze Hose", ClothesLegs, 30, SexFemale, 5500),
            new BusinessClothesModel(0, "Rote Leggings", ClothesLegs, 31, SexFemale, 5500),
            //new BusinessClothesModel(0, "ancho negro con rodilleras", CLOTHES_LEGS, 33, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Normale schwarze Hose", ClothesLegs, 34, SexFemale, 5500),
            new BusinessClothesModel(0, "Hose mit Reflektoren", ClothesLegs, 35, SexFemale, 5500),
            new BusinessClothesModel(0, "Grauer Rock", ClothesLegs, 36, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Stoffhose", ClothesLegs, 37, SexFemale, 5500),
            new BusinessClothesModel(0, "Rote Stoffhose", ClothesLegs, 38, SexFemale, 5500),
            new BusinessClothesModel(0, "Graue Stoffhose", ClothesLegs, 41, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Hose mir Griffen", ClothesLegs, 42, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Hose mit rissen (Vorne)", ClothesLegs, 43, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Hose mit rissen (Seite)", ClothesLegs, 44, SexFemale, 5500),
            new BusinessClothesModel(0, "Militärische grüne Hose", ClothesLegs, 45, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Seidenhose", ClothesLegs, 47, SexFemale, 5500),
            //new BusinessClothesModel(0, "ancho marron rodilleras cinturon negro", CLOTHES_LEGS, 48, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Braune Hose", ClothesLegs, 49, SexFemale, 5500),
            new BusinessClothesModel(0, "Beige Hose", ClothesLegs, 50, SexFemale, 5500),
            new BusinessClothesModel(0, "Beige Leggings", ClothesLegs, 51, SexFemale, 5500),
            new BusinessClothesModel(0, "Violette Hose", ClothesLegs, 52, SexFemale, 5500),
            new BusinessClothesModel(0, "Dunkel gemusterte Hose", ClothesLegs, 53, SexFemale, 5500),
            new BusinessClothesModel(0, "Violette Leggings", ClothesLegs, 54, SexFemale, 5500),
            new BusinessClothesModel(0, "Dunkel gemusterte Leggings", ClothesLegs, 55, SexFemale, 5500),
            new BusinessClothesModel(0, "Rosa Bikini", ClothesLegs, 56, SexFemale, 5500),
            new BusinessClothesModel(0, "Weißer Rock", ClothesLegs, 57, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Jogginghose", ClothesLegs, 58, SexFemale, 5500),
            new BusinessClothesModel(0, "Rot karierte Schlafhose", ClothesLegs, 60, SexFemale, 5500),
            new BusinessClothesModel(0, "Pinker Slip", ClothesLegs, 62, SexFemale, 5500),
            new BusinessClothesModel(0, "Pinker Slip mit Strumpfhose", ClothesLegs, 63, SexFemale, 5500),
            new BusinessClothesModel(0, "Hellbraune Hose", ClothesLegs, 64, SexFemale, 5500),
            new BusinessClothesModel(0, "Blaue Jogginghose", ClothesLegs, 66, SexFemale, 5500),
            new BusinessClothesModel(0, "Hellblaue Schlafhose", ClothesLegs, 67, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarz, Graue Jogginghose", ClothesLegs, 68, SexFemale, 5500),
            new BusinessClothesModel(0, "Totenkopf Schlafhose", ClothesLegs, 71, SexFemale, 5500),
            new BusinessClothesModel(0, "Blaue Cowboy Hose", ClothesLegs, 73, SexFemale, 5500),
            new BusinessClothesModel(0, "Blaue zerissene Jeans", ClothesLegs, 74, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Cowboy Hose", ClothesLegs, 75, SexFemale, 5500),
            new BusinessClothesModel(0, "Blaue Hotpants mit Strumpfhose", ClothesLegs, 78, SexFemale, 5500),
            new BusinessClothesModel(0, "Dunkelbraune Trainingshose", ClothesLegs, 80, SexFemale, 5500),
            new BusinessClothesModel(0, "Schwarze Trainingshose", ClothesLegs, 81, SexFemale, 5500),
            new BusinessClothesModel(0, "Kurze dunkelbraune Trainingshose", ClothesLegs, 82, SexFemale, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Trainingshose", ClothesLegs, 83, SexFemale, 5500),
            new BusinessClothesModel(0, "Camouflage Leggings (Schwarz, Grau)", ClothesLegs, 87, SexFemale, 5500),
            //new BusinessClothesModel(0, "leggins rayas Rgbaes fosforitos", CLOTHES_LEGS, 88, SEX_FEMALE, 5500),
            //Neu hinzugefügt//
            new BusinessClothesModel(0, "Camouflage Hose (Blau)", ClothesLegs, 89, SexFemale, 5500),
            new BusinessClothesModel(0, "Kurze camouflage Hose (Blau)", ClothesLegs, 91, SexFemale, 5500),
            new BusinessClothesModel(0, "Blaue Hose", ClothesLegs, 103, SexFemale, 5500),
            new BusinessClothesModel(0, "Gemusterte Hose", ClothesLegs, 104, SexFemale, 5500),
            new BusinessClothesModel(0, "Grüne Hose", ClothesLegs, 105, SexFemale, 5500),
            new BusinessClothesModel(0, "Orangene zerissene Hose", ClothesLegs, 106, SexFemale, 5500),
            new BusinessClothesModel(0, "Gelbe Shorts", ClothesLegs, 107, SexFemale, 5500),
            new BusinessClothesModel(0, "Bunter Minirock", ClothesLegs, 108, SexFemale, 5500),
            new BusinessClothesModel(0, "Hellblaue Hose", ClothesLegs, 111, SexFemale, 5500),
 
                
                
            // Male pants
                
            new BusinessClothesModel(0, "Blaue Jeans", ClothesLegs, 0, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Jeans", ClothesLegs, 1, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze karierte Shorts", ClothesLegs, 2, SexMale, 5500),
            new BusinessClothesModel(0, "Weiße Stoffhose", ClothesLegs, 3, SexMale, 5500),
            new BusinessClothesModel(0, "Enge schwarze Jeans", ClothesLegs, 4, SexMale, 5500),
            new BusinessClothesModel(0, "Weiße JogginghosePimm", ClothesLegs, 5, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze weiße Hose", ClothesLegs, 6, SexMale, 5500),
            new BusinessClothesModel(0, "Weite schwarze Hose", ClothesLegs, 7, SexMale, 5500),
            new BusinessClothesModel(0, "Weite graue Hose", ClothesLegs, 8, SexMale, 5500),
            new BusinessClothesModel(0, "Weite graue Hose mit Taschen", ClothesLegs, 9, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Stoffhose", ClothesLegs, 10, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Shorts", ClothesLegs, 12, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", ClothesLegs, 13, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze Badehose (Blau)", ClothesLegs, 14, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze beige Hose", ClothesLegs, 15, SexMale, 5500),
            new BusinessClothesModel(0, "Badehose (Blau, Pink)", ClothesLegs, 16, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze braune Hose", ClothesLegs, 17, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze Badehose (Gelb)", ClothesLegs, 18, SexMale, 5500),
            new BusinessClothesModel(0, "Rote Hose", ClothesLegs, 19, SexMale, 5500),
            new BusinessClothesModel(0, "Weiße Hose", ClothesLegs, 20, SexMale, 5500),
            new BusinessClothesModel(0, "Boxershorts mit Herzen", ClothesLegs, 21, SexMale, 5500),
            new BusinessClothesModel(0, "Graue Hose", ClothesLegs, 22, SexMale, 5500),
            //new BusinessClothesModel(0, "pitillo negro", CLOTHES_LEGS, 24, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "normal negro hebilla negra", CLOTHES_LEGS, 25, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", ClothesLegs, 26, SexMale, 5500),
            new BusinessClothesModel(0, "Gelbe Hose", ClothesLegs, 27, SexMale, 5500),
            new BusinessClothesModel(0, "Rot, weiß gestreifte Hose", ClothesLegs, 29, SexMale, 5500),
            //new BusinessClothesModel(0, "ancho verde oscuro agarres", CLOTHES_LEGS, 30, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "pitillo negro ancho", CLOTHES_LEGS, 31, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Lange rote Unterhose", ClothesLegs, 32, SexMale, 5500),
            //new BusinessClothesModel(0, "ancho negro rodilleras", CLOTHES_LEGS, 34, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Graue Hose mit Reflektoren", ClothesLegs, 36, SexMale, 5500),
            new BusinessClothesModel(0, "Graue Stoffhose", ClothesLegs, 37, SexMale, 5500),
            //new BusinessClothesModel(0, "ancho rojo oscuro", CLOTHES_LEGS, 38, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ancho negro agarres", CLOTHES_LEGS, 41, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Hose", ClothesLegs, 42, SexMale, 5500),
            new BusinessClothesModel(0, "Jeans", ClothesLegs, 43, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Schlafhose", ClothesLegs, 45, SexMale, 5500),
            //new BusinessClothesModel(0, "ancho marron rodilleras", CLOTHES_LEGS, 46, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Braune Hose", ClothesLegs, 47, SexMale, 5500),
            new BusinessClothesModel(0, "Weite beige Hose", ClothesLegs, 48, SexMale, 5500),
            new BusinessClothesModel(0, "Enge beige Hose", ClothesLegs, 49, SexMale, 5500),
            new BusinessClothesModel(0, "Rote Hose", ClothesLegs, 50, SexMale, 5500),
            new BusinessClothesModel(0, "Gemusterte Hose", ClothesLegs, 51, SexMale, 5500),
            new BusinessClothesModel(0, "Enge rote Hose", ClothesLegs, 52, SexMale, 5500),
            new BusinessClothesModel(0, "Enge gemusterte Hose", ClothesLegs, 53, SexMale, 5500),
            new BusinessClothesModel(0, "Blau gemusterte Shorts", ClothesLegs, 54, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Jogginghose", ClothesLegs, 55, SexMale, 5500),
            //new BusinessClothesModel(0, "falda blanca lazo", CLOTHES_LEGS, 56, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Rot karierte Schlafhose", ClothesLegs, 58, SexMale, 5500),
            new BusinessClothesModel(0, "Blau gemusterte Schlafhose", ClothesLegs, 60, SexMale, 5500),
            new BusinessClothesModel(0, "Weiße Boxershorts", ClothesLegs, 61, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Hose", ClothesLegs, 62, SexMale, 5500),
            new BusinessClothesModel(0, "Weite Jeans", ClothesLegs, 63, SexMale, 5500),
            new BusinessClothesModel(0, "Blaue Jogginghose", ClothesLegs, 64, SexMale, 5500),
            new BusinessClothesModel(0, "Hellblaue Schlafhose", ClothesLegs, 65, SexMale, 5500),
            //new BusinessClothesModel(0, "chandal negro y blanco", CLOTHES_LEGS, 66, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Totenkopf Schlafhose", ClothesLegs, 69, SexMale, 5500),
            //new BusinessClothesModel(0, "cuero negro", CLOTHES_LEGS, 71, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Blaue Cowboy Hose", ClothesLegs, 75, SexMale, 5500),
            new BusinessClothesModel(0, "Zerissene Jeans", ClothesLegs, 76, SexMale, 5500),
            //new BusinessClothesModel(0, "pitillo con motivos fosforito", CLOTHES_LEGS, 77, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Braune Schlafhose", ClothesLegs, 78, SexMale, 5500),
            new BusinessClothesModel(0, "Schwarze Schlafhose", ClothesLegs, 79, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze braune Schlafhose", ClothesLegs, 80, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Schlafhose", ClothesLegs, 81, SexMale, 5500),
            //new BusinessClothesModel(0, "vaquero oscuro pitillo", CLOTHES_LEGS, 82, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "pitillo negro", CLOTHES_LEGS, 83, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ajustado con motivos Rgbaidos", CLOTHES_LEGS, 85, SEX_MALE, 5500),
            //Neu hinzugefügt//
            new BusinessClothesModel(0, "Camouflage Hose (blau)", ClothesLegs, 86, SexMale, 5500),
            new BusinessClothesModel(0, "Kurze camouflage Hose (blau)", ClothesLegs, 88, SexMale, 5500),
            new BusinessClothesModel(0, "Blaue Hose", ClothesLegs, 99, SexMale, 5500),
            new BusinessClothesModel(0, "Gemusterte Hose", ClothesLegs, 100, SexMale, 5500),
            new BusinessClothesModel(0, "Grüne Hose", ClothesLegs, 101, SexMale, 5500),
            new BusinessClothesModel(0, "Hellblaue Hose", ClothesLegs, 104, SexMale, 5500),
 
                
                
            // Bags
                
            //Komplett entfernen//  
            /*new BusinessClothesModel(0, "Gris, blanca y negra con rayas azules", CLOTHES_BAGS, 1, SEX_NONE, 0),
            new BusinessClothesModel(0, "Bandera EEUU", CLOTHES_BAGS, 10, SEX_NONE, 0),
            new BusinessClothesModel(0, "Blanca cruz azul", CLOTHES_BAGS, 21, SEX_NONE, 0),
            new BusinessClothesModel(0, "Negra", CLOTHES_BAGS, 31, SEX_NONE, 0),
            new BusinessClothesModel(0, "Marron grande", CLOTHES_BAGS, 40, SEX_NONE, 0),
            new BusinessClothesModel(0, "Negra grande", CLOTHES_BAGS, 44, SEX_NONE, 0),
            new BusinessClothesModel(0, "Verde y negra", CLOTHES_BAGS, 52, SEX_NONE, 0),*/
 
                
                
            // Female shoes
                
            new BusinessClothesModel(0, "Schwarze Pumps (Abgerundet)", ClothesFeet, 0, SexFemale, 4500),
            new BusinessClothesModel(0, "Weiße Sneaker", ClothesFeet, 1, SexFemale, 4500),
            new BusinessClothesModel(0, "Beige Boots", ClothesFeet, 2, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Converse", ClothesFeet, 3, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Sneaker", ClothesFeet, 4, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Flip Flops", ClothesFeet, 5, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Pumps (Spitz)", ClothesFeet, 6, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefeletten", ClothesFeet, 7, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze offene Stiefeletten", ClothesFeet, 8, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", ClothesFeet, 9, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarz, Lilane Sneaker", ClothesFeet, 10, SexFemale, 4500),
            new BusinessClothesModel(0, "Weiß, Lilane Sneaker", ClothesFeet, 11, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Ballerina", ClothesFeet, 13, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze offene Pumps", ClothesFeet, 14, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Sandalen", ClothesFeet, 15, SexFemale, 4500),
            new BusinessClothesModel(0, "Graue Flip Flops", ClothesFeet, 16, SexFemale, 4500),
            //new BusinessClothesModel(0, "Duende verde", CLOTHES_FEET, 17, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Graue Pumps", ClothesFeet, 18, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Pumps", ClothesFeet, 19, SexFemale, 4500),
            new BusinessClothesModel(0, "Leoparden Pumps", ClothesFeet, 20, SexFemale, 4500),
            new BusinessClothesModel(0, "Gelbe Stiefel", ClothesFeet, 21, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Boots", ClothesFeet, 22, SexFemale, 4500),
            new BusinessClothesModel(0, "Blaue Pumps", ClothesFeet, 23, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Boots", ClothesFeet, 24, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Boots mit Schnürsenkel", ClothesFeet, 25, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Turnschuhe", ClothesFeet, 27, SexFemale, 4500),
            //new BusinessClothesModel(0, "Zapatillas negra marca lateral", CLOTHES_FEET, 28, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", ClothesFeet, 29, SexFemale, 4500),
            new BusinessClothesModel(0, "Hohe schwarze Pumps", ClothesFeet, 30, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Sneaker", ClothesFeet, 31, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarz, weiß, gelbe Turnschuhe", ClothesFeet, 32, SexFemale, 4500),
            new BusinessClothesModel(0, "Gelb, weiße Converse mit Strumpf", ClothesFeet, 33, SexFemale, 4500),
            new BusinessClothesModel(0, "Barfuß", ClothesFeet, 35, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", ClothesFeet, 36, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Clocks", ClothesFeet, 37, SexFemale, 4500),
            new BusinessClothesModel(0, "Hohe schwarze Cowboy Stiefel", ClothesFeet, 38, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Cowboy Stiefel", ClothesFeet, 39, SexFemale, 4500),
            new BusinessClothesModel(0, "Rosa Pumps", ClothesFeet, 42, SexFemale, 4500),
            new BusinessClothesModel(0, "Gelbe Stiefeletten", ClothesFeet, 43, SexFemale, 4500),
            new BusinessClothesModel(0, "Gelb, schwarze Stiefeletten", ClothesFeet, 44, SexFemale, 4500),
            new BusinessClothesModel(0, "Hohe blaue Cowboy Stiefel", ClothesFeet, 45, SexFemale, 4500),
            new BusinessClothesModel(0, "Blaue Cowboy Stiefe", ClothesFeet, 46, SexFemale, 4500),
            new BusinessClothesModel(0, "Weiß, blaue Turnschuhe", ClothesFeet, 47, SexFemale, 4500),
            //new BusinessClothesModel(0, "Botas verde y negro", CLOTHES_FEET, 48, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Converse (hoch)", ClothesFeet, 49, SexFemale, 4500),
            new BusinessClothesModel(0, "Gelbe Converse (hoch)", ClothesFeet, 50, SexFemale, 4500),
            new BusinessClothesModel(0, "Graue Boots", ClothesFeet, 51, SexFemale, 4500),
            new BusinessClothesModel(0, "Graue Schuhe", ClothesFeet, 52, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Boots", ClothesFeet, 53, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Boots mit Schnürsenkel", ClothesFeet, 54, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", ClothesFeet, 55, SexFemale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", ClothesFeet, 56, SexFemale, 4500),
            //new BusinessClothesModel(0, "Normal negra hebilla", CLOTHES_FEET, 57, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Turnschuhe mit gelben Strichen", ClothesFeet, 58, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Clocks", ClothesFeet, 59, SexFemale, 4500),
            new BusinessClothesModel(0, "Kamelschuhe", ClothesFeet, 60, SexFemale, 4500),
            //new BusinessClothesModel(0, "Plano negro rayas rosa y celeste", CLOTHES_FEET, 61, SEX_FEMALE, 4500),
            //Neue Schuhe//
            new BusinessClothesModel(0, "Blaue camouflage Sneaker", ClothesFeet, 62, SexFemale, 4500),
            new BusinessClothesModel(0, "Braune Boots mit Schnürsenkel", ClothesFeet, 68, SexFemale, 4500),
            new BusinessClothesModel(0, "Weiß, gelbe Socken", ClothesFeet, 87, SexFemale, 4500),
 
                
                
            // Male shoes
                
            new BusinessClothesModel(0, "Karierte Boots", ClothesFeet, 0, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Converse", ClothesFeet, 1, SexMale, 4500),
            new BusinessClothesModel(0, "Karierte Sneaker", ClothesFeet, 2, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarz, graue Lederschuhe", ClothesFeet, 3, SexMale, 4500),
            new BusinessClothesModel(0, "Blau, weiße Converse (Hoch)", ClothesFeet, 4, SexMale, 4500),
            new BusinessClothesModel(0, "Weiße Flip Flops", ClothesFeet, 5, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Sandallen mit weißen Socken", ClothesFeet, 6, SexMale, 4500),
            new BusinessClothesModel(0, "Weiße Sneaker mit Socken", ClothesFeet, 7, SexMale, 4500),
            new BusinessClothesModel(0, "Weiß, schwarze Sneaker mit Socken", ClothesFeet, 9, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Leaderschuhe mit Socken", ClothesFeet, 10, SexMale, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", ClothesFeet, 12, SexMale, 4500),
            new BusinessClothesModel(0, "Graue Stiefel", ClothesFeet, 14, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", ClothesFeet, 15, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Flip Flops", ClothesFeet, 16, SexMale, 4500),
            //new BusinessClothesModel(0, "Duende verde", CLOTHES_FEET, 17, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Schuhe mit Socken", ClothesFeet, 18, SexMale, 4500),
            new BusinessClothesModel(0, "Weiß, schwarze Lederschuhe", ClothesFeet, 19, SexMale, 4500),
            new BusinessClothesModel(0, "Braune Lederschuhe", ClothesFeet, 20, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", ClothesFeet, 21, SexMale, 4500),
            new BusinessClothesModel(0, "Hellblaue Converse (Hoch)", ClothesFeet, 22, SexMale, 4500),
            new BusinessClothesModel(0, "Braune, gelbe Schuhe", ClothesFeet, 23, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", ClothesFeet, 24, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel mit Schnürsenkel", ClothesFeet, 25, SexMale, 4500),
            //new BusinessClothesModel(0, "Converse azul oscuro tobillo alto", CLOTHES_FEET, 26, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiße Stiefel mit Spikes", ClothesFeet, 28, SexMale, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", ClothesFeet, 29, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Schuhe", ClothesFeet, 30, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarz, weiß, gelbe Turnschuhe", ClothesFeet, 31, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Stiefel", ClothesFeet, 32, SexMale, 4500),
            new BusinessClothesModel(0, "Barfuß", ClothesFeet, 34, SexMale, 4500),
            new BusinessClothesModel(0, "Graue Stiefel", ClothesFeet, 35, SexMale, 4500),
            new BusinessClothesModel(0, "Braune Schuhe", ClothesFeet, 36, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Cowboy Stiefel", ClothesFeet, 37, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Cowboy Stiefel (Niedrig)", ClothesFeet, 38, SexMale, 4500),
            new BusinessClothesModel(0, "Blaue Schuhe mit Socken", ClothesFeet, 40, SexMale, 4500),
            new BusinessClothesModel(0, "Rot, schwarze Schuhe", ClothesFeet, 41, SexMale, 4500),
            new BusinessClothesModel(0, "Graue Sneaker", ClothesFeet, 42, SexMale, 4500),
            new BusinessClothesModel(0, "Gelbe Boots", ClothesFeet, 43, SexMale, 4500),
            new BusinessClothesModel(0, "Türkise Cowboy Stiefel", ClothesFeet, 44, SexMale, 4500),
            new BusinessClothesModel(0, "Türkise Cowboy Stiefel (Niedrig)", ClothesFeet, 45, SexMale, 4500),
            new BusinessClothesModel(0, "Blau, weiße Schuhe", ClothesFeet, 46, SexMale, 4500),
            //new BusinessClothesModel(0, "Bota alta verde y blanca", CLOTHES_FEET, 47, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Converse (Hoch)", ClothesFeet, 48, SexMale, 4500),
            new BusinessClothesModel(0, "Gelbe Converse (Hoch)", ClothesFeet, 49, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", ClothesFeet, 50, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", ClothesFeet, 51, SexMale, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", ClothesFeet, 52, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", ClothesFeet, 53, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", ClothesFeet, 54, SexMale, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe mit gelben Strichen", ClothesFeet, 55, SexMale, 4500),
            new BusinessClothesModel(0, "Braune Schuhe", ClothesFeet, 56, SexMale, 4500),
            new BusinessClothesModel(0, "Beige Schuhe", ClothesFeet, 57, SexMale, 4500),
            //new BusinessClothesModel(0, "Plano negro rayas rojas y celestes", CLOTHES_FEET, 58, SEX_MALE, 4500),
            //Neue Schuhe//
            new BusinessClothesModel(0, "Türkise Sneaker", ClothesFeet, 74, SexMale, 4500),
            new BusinessClothesModel(0, "Weiß, lilane Sneaker", ClothesFeet, 75, SexMale, 4500),
            new BusinessClothesModel(0, "Weiß, türkise LED Sneaker", ClothesFeet, 77, SexMale, 4500),
            new BusinessClothesModel(0, "Weiß, gelbe Socken", ClothesFeet, 83, SexMale, 4500),
 
                
                
            // Female accessories
                
            new BusinessClothesModel(0, "Goldene breite Creolen", ClothesAccessories, 1, SexFemale, 30000),
            new BusinessClothesModel(0, "Goldene schmale Creolen", ClothesAccessories, 2, SexFemale, 20000),
            new BusinessClothesModel(0, "Schwarzes Armband (Rechts)", ClothesAccessories, 3, SexFemale, 10000),
            new BusinessClothesModel(0, "Kariertes Armband (Rechts)", ClothesAccessories, 4, SexFemale, 10000),
            new BusinessClothesModel(0, "Karierte Armringe (Rechts)", ClothesAccessories, 5, SexFemale, 10000),
            new BusinessClothesModel(0, "Hufeisenanhänger aus dunkelgoldenem Edelstein", ClothesAccessories, 6, SexFemale, 10000),
            new BusinessClothesModel(0, "Hängende Schwarz- und Goldseile mit Kreis und goldenem Herzen", ClothesAccessories, 7, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarzweiss Palästina", ClothesAccessories, 9, SexFemale, 10000),
            new BusinessClothesModel(0, "Buntes Armband", ClothesAccessories, 10, SexFemale, 10000),
            new BusinessClothesModel(0, "Anhänger schwarz und gold Seil mit goldenem Kreis und dunklem Herzen", ClothesAccessories, 11, SexFemale, 10000),
            new BusinessClothesModel(0, "Perlen Kette", ClothesAccessories, 12, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarzes, weiß gepunktetes Halstuch", ClothesAccessories, 13, SexFemale, 10000),
            new BusinessClothesModel(0, "Metall Armband", ClothesAccessories, 14, SexFemale, 10000),
            new BusinessClothesModel(0, "Roter Palästina", ClothesAccessories, 15, SexFemale, 10000),
            //new BusinessClothesModel(0, "Bufanda buscando a Wally", CLOTHES_ACCESSORIES, 17, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege (Wild)", ClothesAccessories, 19, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarze Krawatte (Wild)", ClothesAccessories, 20, SexFemale, 10000),
            new BusinessClothesModel(0, "Weiße Krawatte", ClothesAccessories, 21, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarze Krawatte", ClothesAccessories, 22, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege", ClothesAccessories, 23, SexFemale, 10000),
            //new BusinessClothesModel(0, "", CLOTHES_ACCESSORIES, 24, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Goldkette mit Anhänger G", ClothesAccessories, 29, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkette Anhänger Totenkopf Gold rote Augen", ClothesAccessories, 30, SexFemale, 30000),
            new BusinessClothesModel(0, "Silberkette Anhänger Totenkopf Silber rote Augen", ClothesAccessories, 31, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldplatte Goldkette", ClothesAccessories, 32, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkette mit €", ClothesAccessories, 33, SexFemale, 40000),
            new BusinessClothesModel(0, "Silberkette Silberanhänger", ClothesAccessories, 34, SexFemale, 15000),
            new BusinessClothesModel(0, "Gold breite goldene Anhänger Kette", ClothesAccessories, 35, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkette mit $ (Außen)", ClothesAccessories, 36, SexFemale, 10000),
            new BusinessClothesModel(0, "Goldkette mit Totenkopf", ClothesAccessories, 37, SexFemale, 10000),
            new BusinessClothesModel(0, "Silberkette mit Sturmmaske (Außen)", ClothesAccessories, 38, SexFemale, 15000),
            new BusinessClothesModel(0, "Goldkette Anhänger Platte Silber (Außen)", ClothesAccessories, 39, SexFemale, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger C (Außen)", ClothesAccessories, 40, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger DIX (Außen)", ClothesAccessories, 41, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger Goldbuchstaben (Außen)", ClothesAccessories, 42, SexFemale, 10000),
            new BusinessClothesModel(0, "Leichte Goldkette ohne Anhänger", ClothesAccessories, 53, SexFemale, 25000),
            new BusinessClothesModel(0, "Goldkette ohne Anhänger", ClothesAccessories, 54, SexFemale, 25000),
            //new BusinessClothesModel(0, "Cadena oro ancha", CLOTHES_ACCESSORIES, 55, SEX_FEMALE, 10000),
            //new BusinessClothesModel(0, "Cadena oro claro ancha", CLOTHES_ACCESSORIES, 56, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Brauner Palästina", ClothesAccessories, 83, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarze Perlenkette", ClothesAccessories, 84, SexFemale, 10000),
            new BusinessClothesModel(0, "Rote Kopfhörer", ClothesAccessories, 85, SexFemale, 10000),
            //new BusinessClothesModel(0, "Corbata azul y rosa", CLOTHES_ACCESSORIES, 86, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Grüne Krawatte", ClothesAccessories, 87, SexFemale, 10000),
            new BusinessClothesModel(0, "Schwarze Hosenträger", ClothesAccessories, 88, SexFemale, 10000),
            new BusinessClothesModel(0, "Goldkette mit rotem Stern", ClothesAccessories, 89, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkette mit rotem Stern (Außen)", ClothesAccessories, 90, SexFemale, 20000),
            new BusinessClothesModel(0, "Goldkette mit goldenem Stern", ClothesAccessories, 91, SexFemale, 30000),
            new BusinessClothesModel(0, "Goldkette mit goldenem Stern (Außen)", ClothesAccessories, 92, SexFemale, 30000),
            new BusinessClothesModel(0, "Hellbraune Perlenkette", ClothesAccessories, 93, SexFemale, 15000),
            new BusinessClothesModel(0, "Blaue Kopfhörer", ClothesAccessories, 94, SexFemale, 10000),
 
                
                
            // Male accessories
                
            new BusinessClothesModel(0, "Weiße breite Krawatte", ClothesAccessories, 10, SexMale, 10000),
            new BusinessClothesModel(0, "Karierte Fliege", ClothesAccessories, 11, SexMale, 10000),
            new BusinessClothesModel(0, "Weiße schmale Krawatte", ClothesAccessories, 12, SexMale, 10000),
            new BusinessClothesModel(0, "Silberkette", ClothesAccessories, 16, SexMale, 10000),
            new BusinessClothesModel(0, "Silberkette (Außen)", ClothesAccessories, 17, SexMale, 10000),
            new BusinessClothesModel(0, "Rote breite Krawatte", ClothesAccessories, 18, SexMale, 10000),
            new BusinessClothesModel(0, "Rote schmale Krawatte", ClothesAccessories, 19, SexMale, 10000),
            new BusinessClothesModel(0, "Dunkelrote Krawatte (Kurz)", ClothesAccessories, 20, SexMale, 10000),
            new BusinessClothesModel(0, "Blaue breite Krawatte", ClothesAccessories, 21, SexMale, 10000),
            new BusinessClothesModel(0, "Weiße Fliege", ClothesAccessories, 22, SexMale, 10000),
            new BusinessClothesModel(0, "Blaue schmale Krawatte", ClothesAccessories, 23, SexMale, 10000),
            new BusinessClothesModel(0, "Weiße breite Krawatte (Kurz)", ClothesAccessories, 24, SexMale, 10000),
            new BusinessClothesModel(0, "Weiße schmale Krawatte (Kurz)", ClothesAccessories, 25, SexMale, 10000),
            new BusinessClothesModel(0, "Weißer Schal", ClothesAccessories, 30, SexMale, 10000),
            new BusinessClothesModel(0, "Rot, weiß, blaue Fliege", ClothesAccessories, 32, SexMale, 10000),
            new BusinessClothesModel(0, "Rot, weißer Schal", ClothesAccessories, 34, SexMale, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege", ClothesAccessories, 36, SexMale, 10000),
            new BusinessClothesModel(0, "Breite schwarze Krawatte (Wild)", ClothesAccessories, 37, SexMale, 10000),
            new BusinessClothesModel(0, "Breite schwarze Krawatte (Angepasst)", ClothesAccessories, 38, SexMale, 10000),
            new BusinessClothesModel(0, "Breite schwarze Krawatte (Lose)", ClothesAccessories, 39, SexMale, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger NS", ClothesAccessories, 42, SexMale, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger Totenkopf", ClothesAccessories, 43, SexMale, 20000),
            new BusinessClothesModel(0, "Silberkettenanhänger Sturmmaske", ClothesAccessories, 44, SexMale, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger Platte", ClothesAccessories, 45, SexMale, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger LC", ClothesAccessories, 46, SexMale, 30000),
            new BusinessClothesModel(0, "Goldmedaillon", ClothesAccessories, 47, SexMale, 10000),
            new BusinessClothesModel(0, "Maskierter Silberkettenanhänger", ClothesAccessories, 51, SexMale, 10000),
            new BusinessClothesModel(0, "Goldkette", ClothesAccessories, 74, SexMale, 35000),
            new BusinessClothesModel(0, "Goldkette (Außen)", ClothesAccessories, 75, SexMale, 32500),
            //new BusinessClothesModel(0, "Dunkel Goldkette", CLOTHES_ACCESSORIES, 76, SEX_MALE, 40000),
            //new BusinessClothesModel(0, "Cadena grande clara", CLOTHES_ACCESSORIES, 85, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Dunkler Schal", ClothesAccessories, 112, SexMale, 10000),
            new BusinessClothesModel(0, "Halskette Perlen braun", ClothesAccessories, 113, SexMale, 10000),
            new BusinessClothesModel(0, "Rote Kopfhörer", ClothesAccessories, 114, SexMale, 10000),
            //new BusinessClothesModel(0, "Corbata azul y rosa", CLOTHES_ACCESSORIES, 115, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Grüne schmale Krawatte", ClothesAccessories, 117, SexMale, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege", ClothesAccessories, 118, SexMale, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger roter Stern", ClothesAccessories, 119, SexMale, 25000),
            new BusinessClothesModel(0, "Goldkettenanhänger goldener Stern", ClothesAccessories, 120, SexMale, 30000),
            new BusinessClothesModel(0, "Goldkettenanhänger roter Stern (Außen)", ClothesAccessories, 121, SexMale, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger goldener Stern (Außen)", ClothesAccessories, 122, SexMale, 30000),
            new BusinessClothesModel(0, "Perlenkette hellbraun", ClothesAccessories, 123, SexMale, 10000),
            new BusinessClothesModel(0, "Blaue Kopfhörer", ClothesAccessories, 124, SexMale, 10000),
 
                
                
            // Female torsos
                
            /*new BusinessClothesModel(0, "Guantes largos morado", CLOTHES_TORSO, 16, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes verde", CLOTHES_TORSO, 17, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes negro", CLOTHES_TORSO, 45, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes negros dedos fuera", CLOTHES_TORSO, 71, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes negros exterior", CLOTHES_TORSO, 31, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes amarillo y blanco", CLOTHES_TORSO, 84, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes blancos", CLOTHES_TORSO, 97, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes celeste", CLOTHES_TORSO, 110, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes verde oscuro", CLOTHES_TORSO, 126, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes verde y blanco moto", CLOTHES_TORSO, 127, SEX_FEMALE, 0),
            new BusinessClothesModel(0, "Guantes rosa y blanco moto", CLOTHES_TORSO, 128, SEX_FEMALE, 0),*/
            new BusinessClothesModel(0, "Ohne Handschuhe", ClothesTorso, 0, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 2", ClothesTorso, 1, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 3", ClothesTorso, 2, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 4", ClothesTorso, 3, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 5", ClothesTorso, 5, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 6", ClothesTorso, 6, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 7", ClothesTorso, 7, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 8", ClothesTorso, 10, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 9", ClothesTorso, 12, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 10", ClothesTorso, 13, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 11", ClothesTorso, 14, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 12", ClothesTorso, 131, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 13", ClothesTorso, 161, SexFemale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 14", ClothesTorso, 130, SexFemale, 250),
 
                
                
            // Male torsos
                
            /*new BusinessClothesModel(0, "Guantes verde", CLOTHES_TORSO, 16, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes negro", CLOTHES_TORSO, 17, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes negro dedos fuera", CLOTHES_TORSO, 18, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes negros exterior", CLOTHES_TORSO, 19, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes negros basicos", CLOTHES_TORSO, 30, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes amarillo y blanco", CLOTHES_TORSO, 63, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes blancos", CLOTHES_TORSO, 74, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes celestes", CLOTHES_TORSO, 121, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes negros altos", CLOTHES_TORSO, 96, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes verde oscuro", CLOTHES_TORSO, 99, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes verde y blanco moto", CLOTHES_TORSO, 110, SEX_MALE, 250),
            new BusinessClothesModel(0, "Guantes rosa y blanco moto", CLOTHES_TORSO, 111, SEX_MALE, 250),*/
            new BusinessClothesModel(0, "Ohne Handschuhe", ClothesTorso, 0, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 2", ClothesTorso, 0, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 3", ClothesTorso, 1, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 4", ClothesTorso, 2, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 5", ClothesTorso, 3, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 6", ClothesTorso, 4, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 7", ClothesTorso, 5, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 8", ClothesTorso, 6, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 9", ClothesTorso, 7, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 10", ClothesTorso, 8, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 11", ClothesTorso, 9, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 12", ClothesTorso, 10, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 13", ClothesTorso, 11, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 14", ClothesTorso, 12, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 15", ClothesTorso, 13, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 16", ClothesTorso, 14, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 17", ClothesTorso, 15, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 18", ClothesTorso, 112, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 19", ClothesTorso, 113, SexMale, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 20", ClothesTorso, 114, SexMale, 250),
 
                
                
            // Female tops
                
            new BusinessClothesModel(0, "Graues Shirt", ClothesTops, 0, SexFemale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke", ClothesTops, 1, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Locker)", ClothesTops, 2, SexFemale, 5900),
            new BusinessClothesModel(0, "Graue Strickjacke", ClothesTops, 3, SexFemale, 5900),
            new BusinessClothesModel(0, "Kariertes Tanktop", ClothesTops, 4, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Tanktop", ClothesTops, 5, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", ClothesTops, 6, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket", ClothesTops, 7, SexFemale, 5900),
            new BusinessClothesModel(0, "Dunkelgraue Jacke", ClothesTops, 8, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd (Hochgekrempelt)", ClothesTops, 9, SexFemale, 5900),
            new BusinessClothesModel(0, "Joggingjacke", ClothesTops, 10, SexFemale, 5900),
            new BusinessClothesModel(0, "Sport Tanktop", ClothesTops, 11, SexFemale, 5900),
            new BusinessClothesModel(0, "Kariertes Tanktop (Locker)", ClothesTops, 12, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Trägerloses-Top", ClothesTops, 13, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Hemd-Shirt", ClothesTops, 14, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer BH", ClothesTops, 15, SexFemale, 5900),
            new BusinessClothesModel(0, "Rotes Tanktop", ClothesTops, 16, SexFemale, 5900),
            new BusinessClothesModel(0, "Urlaubs Hemd", ClothesTops, 17, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißer BH", ClothesTops, 18, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 19, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, weißes Jacket", ClothesTops, 20, SexFemale, 5900),
            new BusinessClothesModel(0, "Lilanes Kleid", ClothesTops, 21, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißer Dessous", ClothesTops, 22, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 23, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grau, schwarzes Jacket", ClothesTops, 24, SexFemale, 5900),
            new BusinessClothesModel(0, "Rotes Jacket", ClothesTops, 25, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes oberteil", ClothesTops, 26, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Hemd (Kurzärmlig)", ClothesTops, 27, SexFemale, 5900),
            new BusinessClothesModel(0, "Graue Weste", ClothesTops, 28, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 29, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 30, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau, schwarze Jeansjacke", ClothesTops, 31, SexFemale, 5900),
            new BusinessClothesModel(0, "Leoparden Tanktop", ClothesTops, 32, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Oberteil", ClothesTops, 33, SexFemale, 5900),
            new BusinessClothesModel(0, "Camouflage Jacket", ClothesTops, 34, SexFemale, 5900),
            new BusinessClothesModel(0, "Gelbe Jacke", ClothesTops, 35, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Tanktop", ClothesTops, 36, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Blumenkleid", ClothesTops, 37, SexFemale, 5900),
            new BusinessClothesModel(0, "Grünes Shirt (Locker)", ClothesTops, 38, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 39, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaues Shirt (Locker)", ClothesTops, 40, SexFemale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 41, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 42, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 43, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 44, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 45, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 46, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 47, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 48, SEX_FEMALE, 5900),*/
            new BusinessClothesModel(0, "Dunkelgraues Tshirt", ClothesTops, 49, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 50, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 51, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Jacket (Offen)", ClothesTops, 52, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Jacket (Geschlossen)", ClothesTops, 53, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 54, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 55, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd (Hochgekrempelt)", ClothesTops, 56, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Offen)", ClothesTops, 57, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Geschlossen)", ClothesTops, 58, SexFemale, 5900),
            new BusinessClothesModel(0, "Rotes Hemd", ClothesTops, 59, SexFemale, 5900),
            new BusinessClothesModel(0, "Rotes Hemd (Kurzärmlig)", ClothesTops, 60, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 61, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 62, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie (Offen)", ClothesTops, 63, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißer Mantel", ClothesTops, 64, SexFemale, 5900),
            new BusinessClothesModel(0, "Rote Jacke", ClothesTops, 65, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 66, SexFemale, 5900),
            new BusinessClothesModel(0, "Grünes Shirt (Locker)", ClothesTops, 67, SexFemale, 5900),
            new BusinessClothesModel(0, "Braunes Shirt mit Muster", ClothesTops, 68, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 69, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißer Mantel (Geschlossen)", ClothesTops, 70, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemusterter Pullover", ClothesTops, 71, SexFemale, 5900),
            new BusinessClothesModel(0, "Rot, weiße Footbal Jacke", ClothesTops, 72, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", ClothesTops, 73, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Top", ClothesTops, 74, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, gelber Pullover", ClothesTops, 75, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Tshirt", ClothesTops, 76, SexFemale, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", ClothesTops, 77, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 78, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Pullover", ClothesTops, 79, SexFemale, 5900),
            new BusinessClothesModel(0, "Weiße Football Jacke", ClothesTops, 80, SexFemale, 5900),
            new BusinessClothesModel(0, "Rot, weiße Football Jacke", ClothesTops, 81, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 82, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", ClothesTops, 83, SexFemale, 5900),
            new BusinessClothesModel(0, "Andreas Shirt (Außen)", ClothesTops, 84, SexFemale, 5900),
            new BusinessClothesModel(0, "Andreas Shirt (Innen)", ClothesTops, 85, SexFemale, 5900),
            new BusinessClothesModel(0, "Jeans Hemd", ClothesTops, 86, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau, weißer Hoodie", ClothesTops, 87, SexFemale, 5900),
            new BusinessClothesModel(0, "Braunes Tshirt", ClothesTops, 88, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 89, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket", ClothesTops, 90, SexFemale, 5900),
            new BusinessClothesModel(0, "Beiges Jacket (Geschlossen)", ClothesTops, 91, SexFemale, 5900),
            new BusinessClothesModel(0, "Lilanes Jacket", ClothesTops, 92, SexFemale, 5900),
            new BusinessClothesModel(0, "Lilanes Jacket (Geschlossen)", ClothesTops, 93, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemustertes Jacket", ClothesTops, 94, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemustertes Jacket (Geschlossen)", ClothesTops, 95, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemustertes Hemd", ClothesTops, 96, SexFemale, 5900),
            new BusinessClothesModel(0, "Blaue Jacke", ClothesTops, 97, SexFemale, 5900),
            new BusinessClothesModel(0, "Weiße Asiatische Jacke", ClothesTops, 98, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, rote Jacke", ClothesTops, 99, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Top", ClothesTops, 100, SexFemale, 5900),
            new BusinessClothesModel(0, "Lilaner BH", ClothesTops, 101, SexFemale, 5900),
            new BusinessClothesModel(0, "Brauner Mantel", ClothesTops, 102, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Pullover", ClothesTops, 103, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 104, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Top", ClothesTops, 105, SexFemale, 5900),
            new BusinessClothesModel(0, "Rot, weiß, blaue Jacke", ClothesTops, 106, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", ClothesTops, 107, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 108, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot kariertes Hemd", ClothesTops, 109, SexFemale, 5900),
            new BusinessClothesModel(0, "Grün, schwarze Motorrad Jacke", ClothesTops, 110, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, pinkes Dessous", ClothesTops, 111, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau gemustertes Kleid", ClothesTops, 112, SexFemale, 5900),
            new BusinessClothesModel(0, "Braun gemustertes Kleid", ClothesTops, 113, SexFemale, 5900),
            new BusinessClothesModel(0, "Rot gemustertes Kleid", ClothesTops, 114, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz gemustertes Kleid", ClothesTops, 115, SexFemale, 5900),
            new BusinessClothesModel(0, "Weiß gemustertes Kleid", ClothesTops, 116, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt (Innen)", ClothesTops, 117, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt (Außen)", ClothesTops, 118, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes kurzärmliges Hemd", ClothesTops, 119, SexFemale, 5900),
            new BusinessClothesModel(0, "Grau kariertes Hemd (Offen)", ClothesTops, 120, SexFemale, 5900),
            new BusinessClothesModel(0, "Grau kariertes Hemd (Geschlossen)", ClothesTops, 121, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 122, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Oberteil", ClothesTops, 123, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes bauchfreies Top", ClothesTops, 124, SexFemale, 5900),
            new BusinessClothesModel(0, "Grünes lockeres Shirt", ClothesTops, 125, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes lockeres Shirt", ClothesTops, 126, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 127, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Außen)", ClothesTops, 128, SexFemale, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Innen)", ClothesTops, 129, SexFemale, 5900),
            new BusinessClothesModel(0, "Grau, weißes Hemd (Hochgekrempelt)", ClothesTops, 130, SexFemale, 5900),
            new BusinessClothesModel(0, "Liberty Hoodie", ClothesTops, 131, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemustertes Shirt", ClothesTops, 132, SexFemale, 5900),
            new BusinessClothesModel(0, "Dunkle Jacke", ClothesTops, 133, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, grauer Pullunder", ClothesTops, 134, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarz, brauner Mantel", ClothesTops, 135, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Oberteil", ClothesTops, 136, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau, graues Jacket", ClothesTops, 137, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau, weiße Sportjacke", ClothesTops, 138, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", ClothesTops, 139, SexFemale, 5900),
            new BusinessClothesModel(0, "Grün, weiße Football Jacke", ClothesTops, 140, SexFemale, 5900),
            new BusinessClothesModel(0, "Hellblaues Tshirt", ClothesTops, 141, SexFemale, 5900),
            new BusinessClothesModel(0, "Hellblaues Hemd", ClothesTops, 142, SexFemale, 5900),
            new BusinessClothesModel(0, "Hellblauer Mantel", ClothesTops, 143, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 144, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke", ClothesTops, 145, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 146, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, gelbe gemusterte Jacke", ClothesTops, 147, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 148, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 149, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke", ClothesTops, 150, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit Italien Flagge", ClothesTops, 151, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 152, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 153, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Weste (Offen)", ClothesTops, 154, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Weste (Geschlossen)", ClothesTops, 155, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel (Geschlossen)", ClothesTops, 156, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel (Offen)", ClothesTops, 157, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke (Geschlossen)", ClothesTops, 158, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke ohne Ärmel (Geschlossen)", ClothesTops, 159, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke (Offen)", ClothesTops, 160, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Shirt", ClothesTops, 161, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 162, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 163, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rote Winterjacke", ClothesTops, 164, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Strickjacke", ClothesTops, 165, SexFemale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke", ClothesTops, 166, SexFemale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke ohne Ärmel", ClothesTops, 167, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 168, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 169, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 170, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", ClothesTops, 171, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 172, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", ClothesTops, 173, SexFemale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit aufdrucken", ClothesTops, 174, SexFemale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit aufdrucken und ohne Ärmel", ClothesTops, 175, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit aufdrucken", ClothesTops, 176, SexFemale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit aufdrucken und ohne Ärmel", ClothesTops, 177, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke mit aufdrucken und ohne Ärmel", ClothesTops, 178, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 179, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 180, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 181, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 182, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke (Offen)", ClothesTops, 183, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 184, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", ClothesTops, 185, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Regenmantel", ClothesTops, 186, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Regenmantel (Offen)", ClothesTops, 187, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 188, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", ClothesTops, 189, SexFemale, 5900),
            new BusinessClothesModel(0, "Orangener Regenmantel", ClothesTops, 190, SexFemale, 5900),
            new BusinessClothesModel(0, "Orangener Regenmantel (Offen)", ClothesTops, 191, SexFemale, 5900),
            new BusinessClothesModel(0, "Grau gemusteter Pullover", ClothesTops, 192, SexFemale, 5900),
            new BusinessClothesModel(0, "Camouflage Jacke", ClothesTops, 193, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", ClothesTops, 194, SexFemale, 5900),
            new BusinessClothesModel(0, "Güffy Shirt", ClothesTops, 195, SexFemale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 196, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 197, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 198, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 199, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 200, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 201, SEX_FEMALE, 5900),*/
            new BusinessClothesModel(0, "Gelb, orange gemusteter Hoodie", ClothesTops, 202, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 203, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel (Geschlossen)", ClothesTops, 204, SexFemale, 5900),
            new BusinessClothesModel(0, "Gelb, orange gemusteter Hoodie (Geschlossen)", ClothesTops, 205, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel", ClothesTops, 206, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", ClothesTops, 207, SexFemale, 5900),
            new BusinessClothesModel(0, "Bigness Shirt (Innen)", ClothesTops, 208, SexFemale, 5900),
            new BusinessClothesModel(0, "Bigness Shirt (Außen)", ClothesTops, 209, SexFemale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 210, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 211, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 212, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 213, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 214, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 215, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 216, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 217, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 218, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 219, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 220, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 221, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 222, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 223, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 224, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 225, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 226, SEX_FEMALE, 5900),*/
            new BusinessClothesModel(0, "Grauer Regenmantel", ClothesTops, 227, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Regenmantel (Geschlossen)", ClothesTops, 228, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 229, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 230, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 231, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 232, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 233, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 234, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau, weißer Pulli", ClothesTops, 235, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarzes Tshirt", ClothesTops, 236, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 237, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 238, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke (Geschlossen)", ClothesTops, 239, SexFemale, 5900),
            new BusinessClothesModel(0, "Grüne Jacke (Offen)", ClothesTops, 240, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 241, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüner Parker", ClothesTops, 242, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 243, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", ClothesTops, 244, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 245, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, grau, weißes Bowling Shirt", ClothesTops, 246, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Tanktop", ClothesTops, 247, SexFemale, 5900),
            new BusinessClothesModel(0, "Graue Jacke mit Fell", ClothesTops, 248, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Außen)", ClothesTops, 249, SexFemale, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Innen)", ClothesTops, 250, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 251, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 252, SexFemale, 5900),
            new BusinessClothesModel(0, "Grün gemusteter Pullover", ClothesTops, 253, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 254, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 255, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 256, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaue Jacke", ClothesTops, 257, SexFemale, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", ClothesTops, 258, SexFemale, 5900),
            new BusinessClothesModel(0, "Regen Jacke", ClothesTops, 259, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 260, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Regen Jacke (Geschlossen)", ClothesTops, 261, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Joggingjacke", ClothesTops, 262, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 263, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemusterter Pulli", ClothesTops, 264, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemusterte Football Jacke", ClothesTops, 265, SexFemale, 5900),
            new BusinessClothesModel(0, "Weiße Jacke", ClothesTops, 266, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau kariertes Hemd", ClothesTops, 267, SexFemale, 5900),
            new BusinessClothesModel(0, "Blau gemusterter Pullover", ClothesTops, 268, SexFemale, 5900),
            new BusinessClothesModel(0, "Rot gemustertes Hemd", ClothesTops, 269, SexFemale, 5900),
            new BusinessClothesModel(0, "Gemusterte Football Jacke (Offen)", ClothesTops, 270, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Hoodie", ClothesTops, 271, SexFemale, 5900),
            new BusinessClothesModel(0, "Grauer Hoodie (Geschlossen)", ClothesTops, 272, SexFemale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 273, SexFemale, 5900),
            new BusinessClothesModel(0, "Lila gepunktete Jacke (Geschlossen)", ClothesTops, 274, SexFemale, 5900),
            new BusinessClothesModel(0, "Lila gepunktete Jacke", ClothesTops, 275, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 276, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 277, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Bunte Winterjacke", ClothesTops, 278, SexFemale, 5900),
            new BusinessClothesModel(0, "Leoparden BH", ClothesTops, 279, SexFemale, 5900),
            new BusinessClothesModel(0, "Hellgraues Tshirt (Außen)", ClothesTops, 280, SexFemale, 5900),
            new BusinessClothesModel(0, "Hellgraues Tshirt (Innen)", ClothesTops, 281, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 282, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Leoparden Tanktop", ClothesTops, 283, SexFemale, 5900),
            new BusinessClothesModel(0, "Camouflage Tanktop", ClothesTops, 284, SexFemale, 5900),
            new BusinessClothesModel(0, "Hellblaue Jacke", ClothesTops, 285, SexFemale, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", ClothesTops, 286, SexFemale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 287, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 288, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 289, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 290, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 291, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Benedict Hoodie", ClothesTops, 292, SexFemale, 5900),
            new BusinessClothesModel(0, "Benedict Hoodie (Geschlossen)", ClothesTops, 293, SexFemale, 5900),
            new BusinessClothesModel(0, "Burger Pulli", ClothesTops, 294, SexFemale, 5900),
            new BusinessClothesModel(0, "Burger Shirt", ClothesTops, 295, SexFemale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 296, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 297, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 298, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 299, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 300, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 301, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 302, SEX_FEMALE, 5900),*/
           
                
                
            // Male tops
                
            new BusinessClothesModel(0, "Weißes Shirt", ClothesTops, 0, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Hemd", ClothesTops, 1, SexMale, 5900),
            new BusinessClothesModel(0, "Kariertes Tanktop", ClothesTops, 2, SexMale, 5900),
            new BusinessClothesModel(0, "Weiße Jogging Jacke", ClothesTops, 3, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket", ClothesTops, 4, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Tanktop", ClothesTops, 5, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 6, SexMale, 5900),
            new BusinessClothesModel(0, "Weiße Strickjacke", ClothesTops, 7, SexMale, 5900),
            new BusinessClothesModel(0, "Rot, blaues Tshirt", ClothesTops, 8, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Hemd", ClothesTops, 9, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Geschlossen)", ClothesTops, 10, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Weste", ClothesTops, 11, SexMale, 5900),
            new BusinessClothesModel(0, "Hellgraues Hemd (Innen)", ClothesTops, 12, SexMale, 5900),
            new BusinessClothesModel(0, "Hellgraues Hemd (Außen)", ClothesTops, 13, SexMale, 5900),
            new BusinessClothesModel(0, "Blau kariertes Hemd", ClothesTops, 14, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 15, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt", ClothesTops, 16, SexMale, 5900),
            new BusinessClothesModel(0, "Blaues Tanktop", ClothesTops, 17, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 18, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, weißes Jacket", ClothesTops, 19, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Jacket", ClothesTops, 20, SexMale, 5900),
            new BusinessClothesModel(0, "Hellgraue Weste", ClothesTops, 21, SexMale, 5900),
            new BusinessClothesModel(0, "Hellgraues Shirt", ClothesTops, 22, SexMale, 5900),
            new BusinessClothesModel(0, "Braunes Jacket", ClothesTops, 23, SexMale, 5900),
            new BusinessClothesModel(0, "Hellgraues Jacket (Geschlossen)", ClothesTops, 24, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Weste", ClothesTops, 25, SexMale, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", ClothesTops, 26, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 27, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Geschlossen)", ClothesTops, 28, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket", ClothesTops, 29, SexMale, 5900),
            //new BusinessClothesModel(0, "" (Geschlossen)", CLOTHES_TOPS, 30, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 31, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 32, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grau, weißes Shirt", ClothesTops, 33, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Shirt", ClothesTops, 34, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", ClothesTops, 35, SexMale, 5900),
            new BusinessClothesModel(0, "Weiß, grau, blaues Tanktop", ClothesTops, 36, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 37, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarz, graue Pulli", ClothesTops, 38, SexMale, 5900),
            new BusinessClothesModel(0, "Rotes Shirt", ClothesTops, 39, SexMale, 5900),
            new BusinessClothesModel(0, "Rote Weste", ClothesTops, 40, SexMale, 5900),
            new BusinessClothesModel(0, "Rot kariertes Hemd", ClothesTops, 41, SexMale, 5900),
            new BusinessClothesModel(0, "Blaues Hemd mit Hosenträger (Geschlossen)", ClothesTops, 42, SexMale, 5900),
            new BusinessClothesModel(0, "Blaues Hemd mit Hosenträger", ClothesTops, 43, SexMale, 5900),
            new BusinessClothesModel(0, "Grünes Shirt", ClothesTops, 44, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 45, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 46, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Tshirt", ClothesTops, 47, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 48, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 49, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 50, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 51, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 52, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 53, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 54, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 55, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Graues Shirt", ClothesTops, 56, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Hoodie", ClothesTops, 57, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 58, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Jacket", ClothesTops, 59, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Jacket (Geschlossen)", ClothesTops, 60, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Jacke", ClothesTops, 61, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 62, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", ClothesTops, 63, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke (Geschlossen)", ClothesTops, 64, SexMale, 5900),
            new BusinessClothesModel(0, "Rote Jacke", ClothesTops, 65, SexMale, 5900),
            new BusinessClothesModel(0, "Rote Jacke ohne Ärmel", ClothesTops, 66, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 67, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke (Geschlossen)", ClothesTops, 68, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke", ClothesTops, 69, SexMale, 5900),
            new BusinessClothesModel(0, "Brauner Mantel mit Pelz", ClothesTops, 70, SexMale, 5900),
            new BusinessClothesModel(0, "Beiges Shirt", ClothesTops, 71, SexMale, 5900),
            new BusinessClothesModel(0, "Hellbrauner Mantel", ClothesTops, 72, SexMale, 5900),
            new BusinessClothesModel(0, "Braunes Shirt mit motiven", ClothesTops, 73, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven", ClothesTops, 74, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven (Geschlossen)", ClothesTops, 75, SexMale, 5900),
            new BusinessClothesModel(0, "Beiger Mantel (Geschlossen)", ClothesTops, 76, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", ClothesTops, 77, SexMale, 5900),
            new BusinessClothesModel(0, "Gemusterter Pulli", ClothesTops, 78, SexMale, 5900),
            new BusinessClothesModel(0, "Rot, weiße Football Jacke", ClothesTops, 79, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Shirt", ClothesTops, 80, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Shirt", ClothesTops, 81, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Tshirt", ClothesTops, 82, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Shirt", ClothesTops, 83, SexMale, 5900),
            new BusinessClothesModel(0, "Corkeers Pulli", ClothesTops, 84, SexMale, 5900),
            new BusinessClothesModel(0, "Blaue Hemden", ClothesTops, 85, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 86, SexMale, 5900),
            new BusinessClothesModel(0, "Rote Football Jacke (Geschlossen)", ClothesTops, 87, SexMale, 5900),
            new BusinessClothesModel(0, "Rote Football Jacke", ClothesTops, 88, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Pulli", ClothesTops, 89, SexMale, 5900),
            new BusinessClothesModel(0, "Weiße Football Jacke", ClothesTops, 90, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 91, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", ClothesTops, 92, SexMale, 5900),
            new BusinessClothesModel(0, "Andreas Tshirt (Außen)", ClothesTops, 93, SexMale, 5900),
            new BusinessClothesModel(0, "Andreas Tshirt (Innen)", ClothesTops, 94, SexMale, 5900),
            new BusinessClothesModel(0, "Jeans Hemd", ClothesTops, 95, SexMale, 5900),
            new BusinessClothesModel(0, "Hellblauer Hoodie", ClothesTops, 96, SexMale, 5900),
            new BusinessClothesModel(0, "Hellbraunes Tshirt", ClothesTops, 97, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 98, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket", ClothesTops, 99, SexMale, 5900),
            new BusinessClothesModel(0, "Beiges Jacket (Geschlossen)", ClothesTops, 100, SexMale, 5900),
            new BusinessClothesModel(0, "Violetes Jacket", ClothesTops, 101, SexMale, 5900),
            new BusinessClothesModel(0, "Violetes Jacket (Geschlossen)", ClothesTops, 102, SexMale, 5900),
            new BusinessClothesModel(0, "Braun gemustertes Jacket", ClothesTops, 103, SexMale, 5900),
            new BusinessClothesModel(0, "Braun gemustertes Jacket (Geschlossen)", ClothesTops, 104, SexMale, 5900),
            new BusinessClothesModel(0, "Weiß gemustertes Hemd", ClothesTops, 105, SexMale, 5900),
            new BusinessClothesModel(0, "Blaue Jacke", ClothesTops, 106, SexMale, 5900),
            new BusinessClothesModel(0, "Weiße Asiatische Jacke", ClothesTops, 107, SexMale, 5900),
            new BusinessClothesModel(0, "Rot, schwarzes Jacket", ClothesTops, 108, SexMale, 5900),
            new BusinessClothesModel(0, "Weißer Pullunder", ClothesTops, 109, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 110, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 111, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket (Geschlossen)", ClothesTops, 112, SexMale, 5900),
            new BusinessClothesModel(0, "Rot, schwarze Joggingjacke", ClothesTops, 113, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Oberteil", ClothesTops, 114, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", ClothesTops, 115, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 116, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot kariertes Hemd", ClothesTops, 117, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 118, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Jacket", ClothesTops, 119, SexMale, 5900),
            new BusinessClothesModel(0, "Blaue Weste", ClothesTops, 120, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißer Hoodie", ClothesTops, 121, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 122, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Hemd", ClothesTops, 123, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke", ClothesTops, 124, SexMale, 5900),
            new BusinessClothesModel(0, "Hellbraune Jacke", ClothesTops, 125, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Hemd (Geschlossen)", ClothesTops, 126, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Hemd", ClothesTops, 127, SexMale, 5900),
            new BusinessClothesModel(0, "Grünes Shirt", ClothesTops, 128, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 129, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 130, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Außen)", ClothesTops, 131, SexMale, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Innen)", ClothesTops, 132, SexMale, 5900),
            new BusinessClothesModel(0, "Pinkes Hemd", ClothesTops, 133, SexMale, 5900),
            new BusinessClothesModel(0, "Liberty Hoodie", ClothesTops, 134, SexMale, 5900),
            new BusinessClothesModel(0, "Hemd mit motiven", ClothesTops, 135, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Jacke", ClothesTops, 136, SexMale, 5900),
            new BusinessClothesModel(0, "Karierter Pullunder", ClothesTops, 137, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke (Geschlossen)", ClothesTops, 138, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Pulli", ClothesTops, 139, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", ClothesTops, 140, SexMale, 5900),
            new BusinessClothesModel(0, "Blau, weiße Jogging Jacke", ClothesTops, 141, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", ClothesTops, 142, SexMale, 5900),
            new BusinessClothesModel(0, "Grün, weiße Football Jacke", ClothesTops, 143, SexMale, 5900),
            new BusinessClothesModel(0, "Hellblaues Hemd", ClothesTops, 144, SexMale, 5900),
            new BusinessClothesModel(0, "Hellblauer Mantel", ClothesTops, 145, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", ClothesTops, 146, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 147, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 148, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 149, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Lilane Football Jacke", ClothesTops, 150, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 151, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 152, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke", ClothesTops, 153, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit Italien Flagge", ClothesTops, 154, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 155, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke (Geschlossen)", ClothesTops, 156, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", ClothesTops, 157, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 158, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Weste", ClothesTops, 159, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", ClothesTops, 160, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 161, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", ClothesTops, 162, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 163, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Shirt", ClothesTops, 164, SexMale, 5900),
            new BusinessClothesModel(0, "Blauer Pulli", ClothesTops, 165, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 166, SexMale, 5900),
            new BusinessClothesModel(0, "Rote Winterjackes", ClothesTops, 167, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 168, SexMale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke", ClothesTops, 169, SexMale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke ohne Ärmel", ClothesTops, 170, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 171, SexMale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit motiven", ClothesTops, 172, SexMale, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit motiven und ohne Ärmel", ClothesTops, 173, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven", ClothesTops, 174, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven und ohne Ärmel", ClothesTops, 175, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke mit motiven und ohne Ärmel", ClothesTops, 176, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 177, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 178, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 179, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 180, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 181, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 182, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", ClothesTops, 183, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke (Geschlossen)", ClothesTops, 184, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke", ClothesTops, 185, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 186, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke", ClothesTops, 187, SexMale, 5900),
            new BusinessClothesModel(0, "Orangene Regenjacke (Geschlossen)", ClothesTops, 188, SexMale, 5900),
            new BusinessClothesModel(0, "Orangene Regenjacke", ClothesTops, 189, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Pulli", ClothesTops, 190, SexMale, 5900),
            new BusinessClothesModel(0, "Camouflage Jacke", ClothesTops, 191, SexMale, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", ClothesTops, 192, SexMale, 5900),
            new BusinessClothesModel(0, "Güffy Shirt", ClothesTops, 193, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 194, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 195, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 196, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 197, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 198, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 199, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Gelber Hoodie", ClothesTops, 200, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 201, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel (Geschlossen)", ClothesTops, 202, SexMale, 5900),
            new BusinessClothesModel(0, "Gelber Hoodie (Geschlossen)", ClothesTops, 203, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke (Geschlossen)", ClothesTops, 204, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel", ClothesTops, 205, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 206, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 207, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 208, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 209, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 210, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 211, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 212, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 213, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 214, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 215, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 216, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Graue Regenjacke", ClothesTops, 217, SexMale, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke (Geschlossen)", ClothesTops, 218, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 219, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 220, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 221, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 222, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", ClothesTops, 223, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 224, SexMale, 5900),
            new BusinessClothesModel(0, "Blau, weißer Pulli", ClothesTops, 225, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzes Tshirt", ClothesTops, 226, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 227, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 228, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke (Geschlossen)", ClothesTops, 229, SexMale, 5900),
            new BusinessClothesModel(0, "Grüne Jacke", ClothesTops, 230, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 231, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 232, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 233, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", ClothesTops, 234, SexMale, 5900),
            new BusinessClothesModel(0, "Rot, weiß, graues Bowlingshirt (Außem)", ClothesTops, 235, SexMale, 5900),
            new BusinessClothesModel(0, "Rot, weiß, graues Bowlingshirt (Innen)", ClothesTops, 236, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Tanktop", ClothesTops, 237, SexMale, 5900),
            new BusinessClothesModel(0, "Hellgraues Shirt", ClothesTops, 238, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 239, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel mit Pelz", ClothesTops, 240, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Außen)", ClothesTops, 241, SexMale, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Innen)", ClothesTops, 242, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 243, SexMale, 5900),
            new BusinessClothesModel(0, "Braune Jacke", ClothesTops, 244, SexMale, 5900),
            new BusinessClothesModel(0, "Grün gemusteter Pulli", ClothesTops, 245, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 246, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 247, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 248, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Blaue Jacke", ClothesTops, 249, SexMale, 5900),
            new BusinessClothesModel(0, "Blauer Hemd", ClothesTops, 250, SexMale, 5900),
            new BusinessClothesModel(0, "Brauner Regenmantel", ClothesTops, 251, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 252, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Brauner Regenmantel (Geschlossen)", ClothesTops, 253, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 254, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißer Pulli", ClothesTops, 255, SexMale, 5900),
            new BusinessClothesModel(0, "Bunte Football Jacke (Geschlossen)", ClothesTops, 256, SexMale, 5900),
            new BusinessClothesModel(0, "Weiße Jacke", ClothesTops, 257, SexMale, 5900),
            new BusinessClothesModel(0, "Blau kariertes Hemd", ClothesTops, 258, SexMale, 5900),
            new BusinessClothesModel(0, "Blauer Pulli", ClothesTops, 259, SexMale, 5900),
            new BusinessClothesModel(0, "Buntes Hemd", ClothesTops, 260, SexMale, 5900),
            new BusinessClothesModel(0, "Bunte Football Jacke", ClothesTops, 261, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", ClothesTops, 262, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie (Geschlossen)", ClothesTops, 263, SexMale, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", ClothesTops, 264, SexMale, 5900),
            new BusinessClothesModel(0, "Blau gepunktete Jacke (Geschlossen)", ClothesTops, 265, SexMale, 5900),
            new BusinessClothesModel(0, "Blau gepunktete Jacke", ClothesTops, 266, SexMale, 5900),
            new BusinessClothesModel(0, "Grüner Regenmantel (Geschlossen)", ClothesTops, 267, SexMale, 5900),
            new BusinessClothesModel(0, "Grüner Regenmantel", ClothesTops, 268, SexMale, 5900),
            new BusinessClothesModel(0, "Bunte Winterjacke", ClothesTops, 269, SexMale, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 270, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellblaues Shirt", ClothesTops, 271, SexMale, 5900),
            new BusinessClothesModel(0, "Hellblaue Jacke", ClothesTops, 272, SexMale, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", ClothesTops, 273, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 274, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 275, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 276, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 277, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 278, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Benedict Hoodie", ClothesTops, 279, SexMale, 5900),
            new BusinessClothesModel(0, "Benedict Hoodie (Geschlossen)", ClothesTops, 280, SexMale, 5900),
            new BusinessClothesModel(0, "Burger Pulli", ClothesTops, 281, SexMale, 5900),
            new BusinessClothesModel(0, "Burger Shirt", ClothesTops, 282, SexMale, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 283, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 284, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 285, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 286, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 287, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 288, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 289, SEX_MALE, 5900),*/
 
                
                
            // Female undershirt








            new BusinessClothesModel(0, "0", ClothesUndershirt, 0, SexFemale, 3900),
            new BusinessClothesModel(0, "1", ClothesUndershirt, 1, SexFemale, 3900),
            new BusinessClothesModel(0, "2", ClothesUndershirt, 2, SexFemale, 3900),
            new BusinessClothesModel(0, "3", ClothesUndershirt, 3, SexFemale, 3900),
            new BusinessClothesModel(0, "4", ClothesUndershirt, 4, SexFemale, 3900),
            new BusinessClothesModel(0, "5", ClothesUndershirt, 5, SexFemale, 3900),
            new BusinessClothesModel(0, "6", ClothesUndershirt, 6, SexFemale, 3900),
            new BusinessClothesModel(0, "7", ClothesUndershirt, 7, SexFemale, 3900),
            new BusinessClothesModel(0, "8", ClothesUndershirt, 8, SexFemale, 3900),
            new BusinessClothesModel(0, "9", ClothesUndershirt, 9, SexFemale, 3900),
            new BusinessClothesModel(0, "10", ClothesUndershirt, 10, SexFemale, 3900),
            new BusinessClothesModel(0, "11", ClothesUndershirt, 11, SexFemale, 3900),
            new BusinessClothesModel(0, "12", ClothesUndershirt, 12, SexFemale, 3900),
            new BusinessClothesModel(0, "13", ClothesUndershirt, 13, SexFemale, 3900),
            new BusinessClothesModel(0, "14", ClothesUndershirt, 14, SexFemale, 3900),
            new BusinessClothesModel(0, "15", ClothesUndershirt, 15, SexFemale, 3900),
            new BusinessClothesModel(0, "16", ClothesUndershirt, 16, SexFemale, 3900),
            new BusinessClothesModel(0, "17", ClothesUndershirt, 17, SexFemale, 3900),

            new BusinessClothesModel(0, "0", ClothesUndershirt, 0, SexMale, 3900),
            new BusinessClothesModel(0, "1", ClothesUndershirt, 1, SexMale, 3900),
            new BusinessClothesModel(0, "2", ClothesUndershirt, 2, SexMale, 3900),
            new BusinessClothesModel(0, "3", ClothesUndershirt, 3, SexMale, 3900),
            new BusinessClothesModel(0, "4", ClothesUndershirt, 4, SexMale, 3900),
            new BusinessClothesModel(0, "5", ClothesUndershirt, 5, SexMale, 3900),
            new BusinessClothesModel(0, "6", ClothesUndershirt, 6, SexMale, 3900),
            new BusinessClothesModel(0, "7", ClothesUndershirt, 7, SexMale, 3900),
            new BusinessClothesModel(0, "8", ClothesUndershirt, 8, SexMale, 3900),
            new BusinessClothesModel(0, "9", ClothesUndershirt, 9, SexMale, 3900),
            new BusinessClothesModel(0, "10", ClothesUndershirt, 10, SexMale, 3900),
            new BusinessClothesModel(0, "11", ClothesUndershirt, 11, SexMale, 3900),
            new BusinessClothesModel(0, "12", ClothesUndershirt, 12, SexMale, 3900),
            new BusinessClothesModel(0, "13", ClothesUndershirt, 13, SexMale, 3900),
            new BusinessClothesModel(0, "14", ClothesUndershirt, 14, SexMale, 3900),
            new BusinessClothesModel(0, "15", ClothesUndershirt, 15, SexMale, 3900),
            new BusinessClothesModel(0, "16", ClothesUndershirt, 16, SexMale, 3900),
            new BusinessClothesModel(0, "17", ClothesUndershirt, 17, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 18, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 19, SEX_MALE, 3900),
            new BusinessClothesModel(0, "18", ClothesUndershirt, 20, SexMale, 3900),
            new BusinessClothesModel(0, "19", ClothesUndershirt, 21, SexMale, 3900),
            new BusinessClothesModel(0, "20", ClothesUndershirt, 22, SexMale, 3900),
            new BusinessClothesModel(0, "21", ClothesUndershirt, 23, SexMale, 3900),
            new BusinessClothesModel(0, "22", ClothesUndershirt, 24, SexMale, 3900),
            new BusinessClothesModel(0, "23", ClothesUndershirt, 25, SexMale, 3900),
            new BusinessClothesModel(0, "24", ClothesUndershirt, 26, SexMale, 3900),
            new BusinessClothesModel(0, "25", ClothesUndershirt, 27, SexMale, 3900),
            new BusinessClothesModel(0, "26", ClothesUndershirt, 28, SexMale, 3900),
            new BusinessClothesModel(0, "27", ClothesUndershirt, 29, SexMale, 3900),
            new BusinessClothesModel(0, "28", ClothesUndershirt, 30, SexMale, 3900),
            new BusinessClothesModel(0, "29", ClothesUndershirt, 31, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 32, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 33, SEX_MALE, 3900),
            new BusinessClothesModel(0, "30", ClothesUndershirt, 34, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 35, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 36, SEX_MALE, 3900),
            new BusinessClothesModel(0, "31", ClothesUndershirt, 37, SexMale, 3900),
            new BusinessClothesModel(0, "32", ClothesUndershirt, 38, SexMale, 3900),
            new BusinessClothesModel(0, "33", ClothesUndershirt, 39, SexMale, 3900),
            new BusinessClothesModel(0, "34", ClothesUndershirt, 40, SexMale, 3900),
            new BusinessClothesModel(0, "35", ClothesUndershirt, 41, SexMale, 3900),
            new BusinessClothesModel(0, "36", ClothesUndershirt, 42, SexMale, 3900),
            new BusinessClothesModel(0, "37", ClothesUndershirt, 43, SexMale, 3900),
            new BusinessClothesModel(0, "38", ClothesUndershirt, 44, SexMale, 3900),
            new BusinessClothesModel(0, "39", ClothesUndershirt, 45, SexMale, 3900),
            new BusinessClothesModel(0, "40", ClothesUndershirt, 46, SexMale, 3900),
            new BusinessClothesModel(0, "41", ClothesUndershirt, 47, SexMale, 3900),
            new BusinessClothesModel(0, "42", ClothesUndershirt, 48, SexMale, 3900),
            new BusinessClothesModel(0, "43", ClothesUndershirt, 49, SexMale, 3900),
            new BusinessClothesModel(0, "44", ClothesUndershirt, 50, SexMale, 3900),
            new BusinessClothesModel(0, "45", ClothesUndershirt, 51, SexMale, 3900),
            new BusinessClothesModel(0, "46", ClothesUndershirt, 52, SexMale, 3900),
            new BusinessClothesModel(0, "47", ClothesUndershirt, 53, SexMale, 3900),
            new BusinessClothesModel(0, "48", ClothesUndershirt, 54, SexMale, 3900),
            new BusinessClothesModel(0, "49", ClothesUndershirt, 55, SexMale, 3900),
            new BusinessClothesModel(0, "50", ClothesUndershirt, 56, SexMale, 3900),
            new BusinessClothesModel(0, "51", ClothesUndershirt, 57, SexMale, 3900),
            new BusinessClothesModel(0, "52", ClothesUndershirt, 58, SexMale, 3900),
            new BusinessClothesModel(0, "53", ClothesUndershirt, 59, SexMale, 3900),
            new BusinessClothesModel(0, "54", ClothesUndershirt, 60, SexMale, 3900),
            new BusinessClothesModel(0, "55", ClothesUndershirt, 61, SexMale, 3900),
            new BusinessClothesModel(0, "56", ClothesUndershirt, 62, SexMale, 3900),
            new BusinessClothesModel(0, "57", ClothesUndershirt, 63, SexMale, 3900),
            new BusinessClothesModel(0, "58", ClothesUndershirt, 64, SexMale, 3900),
            new BusinessClothesModel(0, "59", ClothesUndershirt, 65, SexMale, 3900),
            new BusinessClothesModel(0, "60", ClothesUndershirt, 66, SexMale, 3900),
            new BusinessClothesModel(0, "61", ClothesUndershirt, 67, SexMale, 3900),
            new BusinessClothesModel(0, "62", ClothesUndershirt, 68, SexMale, 3900),
            new BusinessClothesModel(0, "63", ClothesUndershirt, 69, SexMale, 3900),
            new BusinessClothesModel(0, "64", ClothesUndershirt, 70, SexMale, 3900),
            new BusinessClothesModel(0, "65", ClothesUndershirt, 71, SexMale, 3900),
            new BusinessClothesModel(0, "66", ClothesUndershirt, 72, SexMale, 3900),
            new BusinessClothesModel(0, "67", ClothesUndershirt, 73, SexMale, 3900),
            new BusinessClothesModel(0, "68", ClothesUndershirt, 74, SexMale, 3900),
            new BusinessClothesModel(0, "69", ClothesUndershirt, 75, SexMale, 3900),
            new BusinessClothesModel(0, "70", ClothesUndershirt, 76, SexMale, 3900),
            new BusinessClothesModel(0, "71", ClothesUndershirt, 77, SexMale, 3900),
            new BusinessClothesModel(0, "72", ClothesUndershirt, 78, SexMale, 3900),
            new BusinessClothesModel(0, "73", ClothesUndershirt, 79, SexMale, 3900),
            new BusinessClothesModel(0, "74", ClothesUndershirt, 80, SexMale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 81, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 82, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 83, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 84, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 85, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "75", ClothesUndershirt, 86, SexMale, 3900),
            new BusinessClothesModel(0, "76", ClothesUndershirt, 87, SexMale, 3900),
            new BusinessClothesModel(0, "77", ClothesUndershirt, 88, SexMale, 3900),
            new BusinessClothesModel(0, "78", ClothesUndershirt, 89, SexMale, 3900),
            new BusinessClothesModel(0, "79", ClothesUndershirt, 90, SexMale, 3900),
            new BusinessClothesModel(0, "80", ClothesUndershirt, 91, SexMale, 3900),
            new BusinessClothesModel(0, "81", ClothesUndershirt, 92, SexMale, 3900),
            new BusinessClothesModel(0, "82", ClothesUndershirt, 93, SexMale, 3900),
            new BusinessClothesModel(0, "83", ClothesUndershirt, 94, SexMale, 3900),
            new BusinessClothesModel(0, "84", ClothesUndershirt, 95, SexMale, 3900),
            new BusinessClothesModel(0, "85", ClothesUndershirt, 96, SexMale, 3900),
            new BusinessClothesModel(0, "86", ClothesUndershirt, 97, SexMale, 3900),
            new BusinessClothesModel(0, "87", ClothesUndershirt, 98, SexMale, 3900),
            new BusinessClothesModel(0, "88", ClothesUndershirt, 99, SexMale, 3900),
            new BusinessClothesModel(0, "89", ClothesUndershirt, 100, SexMale, 3900),
            new BusinessClothesModel(0, "90", ClothesUndershirt, 101, SexFemale, 3900),
            new BusinessClothesModel(0, "91", ClothesUndershirt, 102, SexFemale, 3900),
            new BusinessClothesModel(0, "92", ClothesUndershirt, 103, SexFemale, 3900),
            new BusinessClothesModel(0, "93", ClothesUndershirt, 104, SexFemale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 105, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "94", ClothesUndershirt, 106, SexFemale, 3900),
            new BusinessClothesModel(0, "95", ClothesUndershirt, 107, SexFemale, 3900),
            new BusinessClothesModel(0, "96", ClothesUndershirt, 108, SexFemale, 3900),
            new BusinessClothesModel(0, "97", ClothesUndershirt, 109, SexFemale, 3900),
            new BusinessClothesModel(0, "98", ClothesUndershirt, 110, SexFemale, 3900),
            new BusinessClothesModel(0, "99", ClothesUndershirt, 111, SexFemale, 3900),
            new BusinessClothesModel(0, "100", ClothesUndershirt, 112, SexFemale, 3900),
            new BusinessClothesModel(0, "101", ClothesUndershirt, 113, SexFemale, 3900),
            new BusinessClothesModel(0, "102", ClothesUndershirt, 114, SexFemale, 3900),
            new BusinessClothesModel(0, "103", ClothesUndershirt, 115, SexFemale, 3900),
            new BusinessClothesModel(0, "104", ClothesUndershirt, 116, SexFemale, 3900),
            new BusinessClothesModel(0, "105", ClothesUndershirt, 117, SexFemale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 118, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 119, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 120, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 121, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 122, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 123, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 124, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 125, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 126, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 127, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 128, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 129, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 130, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 131, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 132, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 133, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 134, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 135, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 136, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 137, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 138, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 139, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 140, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 141, SEX_FEMALE, 3900),*/
            new BusinessClothesModel(0, "106", ClothesUndershirt, 142, SexFemale, 3900),
            new BusinessClothesModel(0, "107", ClothesUndershirt, 143, SexFemale, 3900),
            new BusinessClothesModel(0, "108", ClothesUndershirt, 144, SexFemale, 3900),
            new BusinessClothesModel(0, "109", ClothesUndershirt, 145, SexFemale, 3900),
            new BusinessClothesModel(0, "110", ClothesUndershirt, 146, SexFemale, 3900),
            new BusinessClothesModel(0, "111", ClothesUndershirt, 147, SexFemale, 3900),
            new BusinessClothesModel(0, "112", ClothesUndershirt, 148, SexFemale, 3900),
            new BusinessClothesModel(0, "113", ClothesUndershirt, 149, SexFemale, 3900),
            new BusinessClothesModel(0, "114", ClothesUndershirt, 150, SexFemale, 3900),
            new BusinessClothesModel(0, "115", ClothesUndershirt, 151, SexFemale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 152, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 153, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 154, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 155, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 156, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 157, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 158, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 159, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 160, SEX_FEMALE, 3900),*/
            new BusinessClothesModel(0, "116", ClothesUndershirt, 161, SexFemale, 3900),
            new BusinessClothesModel(0, "117", ClothesUndershirt, 162, SexFemale, 3900),
            new BusinessClothesModel(0, "118", ClothesUndershirt, 163, SexFemale, 3900),
            new BusinessClothesModel(0, "119", ClothesUndershirt, 164, SexFemale, 3900),
            new BusinessClothesModel(0, "120", ClothesUndershirt, 165, SexFemale, 3900),
            new BusinessClothesModel(0, "121", ClothesUndershirt, 166, SexFemale, 3900),
            new BusinessClothesModel(0, "122", ClothesUndershirt, 167, SexFemale, 3900),
            new BusinessClothesModel(0, "123", ClothesUndershirt, 168, SexFemale, 3900),
            new BusinessClothesModel(0, "124", ClothesUndershirt, 170, SexFemale, 3900),
            new BusinessClothesModel(0, "125", ClothesUndershirt, 171, SexFemale, 3900),
            new BusinessClothesModel(0, "126", ClothesUndershirt, 172, SexFemale, 3900),
            new BusinessClothesModel(0, "127", ClothesUndershirt, 173, SexFemale, 3900),
            new BusinessClothesModel(0, "128", ClothesUndershirt, 174, SexFemale, 3900),
            new BusinessClothesModel(0, "129", ClothesUndershirt, 175, SexFemale, 3900),
            new BusinessClothesModel(0, "130", ClothesUndershirt, 176, SexFemale, 3900),
            new BusinessClothesModel(0, "131", ClothesUndershirt, 177, SexFemale, 3900),
            new BusinessClothesModel(0, "132", ClothesUndershirt, 178, SexFemale, 3900),
            new BusinessClothesModel(0, "133", ClothesUndershirt, 179, SexFemale, 3900),
            new BusinessClothesModel(0, "134", ClothesUndershirt, 180, SexFemale, 3900),
            new BusinessClothesModel(0, "135", ClothesUndershirt, 181, SexFemale, 3900),
            new BusinessClothesModel(0, "136", ClothesUndershirt, 182, SexFemale, 3900),
            new BusinessClothesModel(0, "137", ClothesUndershirt, 183, SexFemale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 184, SEX_FEMALE, 3900),
 
                
                
            // Male undershirt
                
            new BusinessClothesModel(0, "0", ClothesUndershirt, 0, SexMale, 3900),
            new BusinessClothesModel(0, "1", ClothesUndershirt, 1, SexMale, 3900),
            new BusinessClothesModel(0, "2", ClothesUndershirt, 2, SexMale, 3900),
            new BusinessClothesModel(0, "3", ClothesUndershirt, 3, SexMale, 3900),
            new BusinessClothesModel(0, "4", ClothesUndershirt, 4, SexMale, 3900),
            new BusinessClothesModel(0, "5", ClothesUndershirt, 5, SexMale, 3900),
            new BusinessClothesModel(0, "6", ClothesUndershirt, 6, SexMale, 3900),
            new BusinessClothesModel(0, "7", ClothesUndershirt, 7, SexMale, 3900),
            new BusinessClothesModel(0, "8", ClothesUndershirt, 8, SexMale, 3900),
            new BusinessClothesModel(0, "9", ClothesUndershirt, 9, SexMale, 3900),
            new BusinessClothesModel(0, "10", ClothesUndershirt, 10, SexMale, 3900),
            new BusinessClothesModel(0, "11", ClothesUndershirt, 11, SexMale, 3900),
            new BusinessClothesModel(0, "12", ClothesUndershirt, 12, SexMale, 3900),
            new BusinessClothesModel(0, "13", ClothesUndershirt, 13, SexMale, 3900),
            new BusinessClothesModel(0, "14", ClothesUndershirt, 14, SexMale, 3900),
            new BusinessClothesModel(0, "15", ClothesUndershirt, 15, SexMale, 3900),
            new BusinessClothesModel(0, "16", ClothesUndershirt, 16, SexMale, 3900),
            new BusinessClothesModel(0, "17", ClothesUndershirt, 17, SexMale, 3900),
            new BusinessClothesModel(0, "18", ClothesUndershirt, 18, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 19, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 20, SEX_MALE, 3900),
            new BusinessClothesModel(0, "19", ClothesUndershirt, 21, SexMale, 3900),
            new BusinessClothesModel(0, "20", ClothesUndershirt, 22, SexMale, 3900),
            new BusinessClothesModel(0, "21", ClothesUndershirt, 23, SexMale, 3900),
            new BusinessClothesModel(0, "22", ClothesUndershirt, 24, SexMale, 3900),
            new BusinessClothesModel(0, "23", ClothesUndershirt, 25, SexMale, 3900),
            new BusinessClothesModel(0, "24", ClothesUndershirt, 26, SexMale, 3900),
            new BusinessClothesModel(0, "25", ClothesUndershirt, 27, SexMale, 3900),
            new BusinessClothesModel(0, "26", ClothesUndershirt, 28, SexMale, 3900),
            new BusinessClothesModel(0, "27", ClothesUndershirt, 29, SexMale, 3900),
            new BusinessClothesModel(0, "28", ClothesUndershirt, 30, SexMale, 3900),
            new BusinessClothesModel(0, "29", ClothesUndershirt, 31, SexMale, 3900),
            new BusinessClothesModel(0, "30", ClothesUndershirt, 32, SexMale, 3900),
            new BusinessClothesModel(0, "31", ClothesUndershirt, 33, SexMale, 3900),
            new BusinessClothesModel(0, "32", ClothesUndershirt, 34, SexMale, 3900),
            new BusinessClothesModel(0, "33", ClothesUndershirt, 35, SexMale, 3900),
            new BusinessClothesModel(0, "34", ClothesUndershirt, 36, SexMale, 3900),
            new BusinessClothesModel(0, "35", ClothesUndershirt, 37, SexMale, 3900),
            new BusinessClothesModel(0, "36", ClothesUndershirt, 38, SexMale, 3900),
            new BusinessClothesModel(0, "37", ClothesUndershirt, 39, SexMale, 3900),
            new BusinessClothesModel(0, "38", ClothesUndershirt, 40, SexMale, 3900),
            new BusinessClothesModel(0, "39", ClothesUndershirt, 41, SexMale, 3900),
            new BusinessClothesModel(0, "40", ClothesUndershirt, 42, SexMale, 3900),
            new BusinessClothesModel(0, "41", ClothesUndershirt, 43, SexMale, 3900),
            new BusinessClothesModel(0, "42", ClothesUndershirt, 44, SexMale, 3900),
            new BusinessClothesModel(0, "43", ClothesUndershirt, 45, SexMale, 3900),
            new BusinessClothesModel(0, "44", ClothesUndershirt, 46, SexMale, 3900),
            new BusinessClothesModel(0, "45", ClothesUndershirt, 47, SexMale, 3900),
            new BusinessClothesModel(0, "46", ClothesUndershirt, 48, SexMale, 3900),
            new BusinessClothesModel(0, "47", ClothesUndershirt, 49, SexMale, 3900),
            new BusinessClothesModel(0, "48", ClothesUndershirt, 50, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 51, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 52, SEX_MALE, 3900),
            new BusinessClothesModel(0, "49", ClothesUndershirt, 53, SexMale, 3900),
            new BusinessClothesModel(0, "50", ClothesUndershirt, 54, SexMale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 55, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 56, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 57, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 58, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 59, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "51", ClothesUndershirt, 60, SexMale, 3900),
            new BusinessClothesModel(0, "52", ClothesUndershirt, 61, SexMale, 3900),
            new BusinessClothesModel(0, "53", ClothesUndershirt, 62, SexMale, 3900),
            new BusinessClothesModel(0, "54", ClothesUndershirt, 63, SexMale, 3900),
            new BusinessClothesModel(0, "55", ClothesUndershirt, 64, SexMale, 3900),
            new BusinessClothesModel(0, "56", ClothesUndershirt, 65, SexMale, 3900),
            new BusinessClothesModel(0, "57", ClothesUndershirt, 66, SexMale, 3900),
            new BusinessClothesModel(0, "58", ClothesUndershirt, 67, SexMale, 3900),
            new BusinessClothesModel(0, "59", ClothesUndershirt, 68, SexMale, 3900),
            new BusinessClothesModel(0, "60", ClothesUndershirt, 69, SexMale, 3900),
            new BusinessClothesModel(0, "61", ClothesUndershirt, 70, SexMale, 3900),
            new BusinessClothesModel(0, "62", ClothesUndershirt, 71, SexMale, 3900),
            new BusinessClothesModel(0, "63", ClothesUndershirt, 72, SexMale, 3900),
            new BusinessClothesModel(0, "64", ClothesUndershirt, 73, SexMale, 3900),
            new BusinessClothesModel(0, "65", ClothesUndershirt, 74, SexMale, 3900),
            new BusinessClothesModel(0, "66", ClothesUndershirt, 75, SexMale, 3900),
            new BusinessClothesModel(0, "67", ClothesUndershirt, 76, SexMale, 3900),
            new BusinessClothesModel(0, "68", ClothesUndershirt, 77, SexMale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 78, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 79, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 80, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "69", ClothesUndershirt, 81, SexMale, 3900),
            new BusinessClothesModel(0, "70", ClothesUndershirt, 82, SexMale, 3900),
            new BusinessClothesModel(0, "71", ClothesUndershirt, 83, SexMale, 3900),
            new BusinessClothesModel(0, "72", ClothesUndershirt, 84, SexMale, 3900),
            new BusinessClothesModel(0, "73", ClothesUndershirt, 85, SexMale, 3900),
            new BusinessClothesModel(0, "74", ClothesUndershirt, 86, SexMale, 3900),
            new BusinessClothesModel(0, "75", ClothesUndershirt, 87, SexMale, 3900),
            new BusinessClothesModel(0, "76", ClothesUndershirt, 88, SexMale, 3900),
            new BusinessClothesModel(0, "77", ClothesUndershirt, 89, SexMale, 3900),
            new BusinessClothesModel(0, "78", ClothesUndershirt, 90, SexMale, 3900),
            new BusinessClothesModel(0, "79", ClothesUndershirt, 91, SexMale, 3900),
            new BusinessClothesModel(0, "80", ClothesUndershirt, 92, SexMale, 3900),
            new BusinessClothesModel(0, "81", ClothesUndershirt, 93, SexMale, 3900),
            new BusinessClothesModel(0, "82", ClothesUndershirt, 94, SexMale, 3900),
            new BusinessClothesModel(0, "83", ClothesUndershirt, 95, SexMale, 3900),
            new BusinessClothesModel(0, "84", ClothesUndershirt, 96, SexMale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 97, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 98, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 99, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 100, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 101, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 102, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "85", ClothesUndershirt, 103, SexMale, 3900),
            new BusinessClothesModel(0, "86", ClothesUndershirt, 104, SexMale, 3900),
            new BusinessClothesModel(0, "87", ClothesUndershirt, 105, SexMale, 3900),
            new BusinessClothesModel(0, "88", ClothesUndershirt, 106, SexMale, 3900),
            new BusinessClothesModel(0, "89", ClothesUndershirt, 107, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 108, SEX_MALE, 3900),
            new BusinessClothesModel(0, "90", ClothesUndershirt, 109, SexMale, 3900),
            new BusinessClothesModel(0, "91", ClothesUndershirt, 110, SexMale, 3900),
            new BusinessClothesModel(0, "92", ClothesUndershirt, 111, SexMale, 3900),
            new BusinessClothesModel(0, "93", ClothesUndershirt, 112, SexMale, 3900),
            new BusinessClothesModel(0, "94", ClothesUndershirt, 113, SexMale, 3900),
            new BusinessClothesModel(0, "95", ClothesUndershirt, 114, SexMale, 3900),
            new BusinessClothesModel(0, "96", ClothesUndershirt, 115, SexMale, 3900),
            new BusinessClothesModel(0, "97", ClothesUndershirt, 116, SexMale, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 117, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 118, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 119, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 120, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 121, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 122, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 123, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 124, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 125, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 126, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 127, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 128, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 129, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 130, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 131, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "98", ClothesUndershirt, 132, SexMale, 3900),
            new BusinessClothesModel(0, "99", ClothesUndershirt, 133, SexMale, 3900),
            new BusinessClothesModel(0, "100", ClothesUndershirt, 134, SexMale, 3900),
            new BusinessClothesModel(0, "101", ClothesUndershirt, 135, SexMale, 3900),
            new BusinessClothesModel(0, "102", ClothesUndershirt, 136, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 137, SEX_MALE, 3900),
            new BusinessClothesModel(0, "103", ClothesUndershirt, 138, SexMale, 3900),
            new BusinessClothesModel(0, "104", ClothesUndershirt, 139, SexMale, 3900),
            new BusinessClothesModel(0, "105", ClothesUndershirt, 140, SexMale, 3900),
            new BusinessClothesModel(0, "106", ClothesUndershirt, 141, SexMale, 3900),
            new BusinessClothesModel(0, "107", ClothesUndershirt, 142, SexMale, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 143, SEX_MALE, 3900),
 
                
                
            // Female hats
                
            //new BusinessClothesModel(1, "Auriculares rojos", ACCESSORY_HATS, 0, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Cono blanco", ACCESSORY_HATS, 1, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Karierte Cowboy Hut", AccessoryHats, 2, SexFemale, 2500),
            //new BusinessClothesModel(1, "Achatado cuadros negro y blanco", ACCESSORY_HATS, 3, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Los Santos Basecap", AccessoryHats, 4, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze Mütze", AccessoryHats, 5, SexFemale, 2500),
            //new BusinessClothesModel(1, "Gorra negra", ACCESSORY_HATS, 6, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Blaue abgeflachte Mütze", AccessoryHats, 7, SexFemale, 2500),
            new BusinessClothesModel(1, "Karierter Hut", AccessoryHats, 8, SexFemale, 2500),
            new BusinessClothesModel(1, "iFruit Basecap", AccessoryHats, 9, SexFemale, 2500),
            new BusinessClothesModel(1, "Karierte Basecap", AccessoryHats, 10, SexFemale, 2500),
            new BusinessClothesModel(1, "Karierter Sonnenhut", AccessoryHats, 11, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze Mütze", AccessoryHats, 12, SexFemale, 2500),
            new BusinessClothesModel(1, "Stroh Hut mit schwarzem Band", AccessoryHats, 13, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze Maler Mütze", AccessoryHats, 14, SexFemale, 2500),
            new BusinessClothesModel(1, "Weiße Kopfhörer", AccessoryHats, 15, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Casco amarillo rojo y negro", ACCESSORY_HATS, 16, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco abierto azul y negro", ACCESSORY_HATS, 17, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro", ACCESSORY_HATS, 18, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Cowboy Hut", AccessoryHats, 20, SexFemale, 2500),
            new BusinessClothesModel(1, "Pinker Sonnenhut", AccessoryHats, 21, SexFemale, 2500),
            new BusinessClothesModel(1, "Strand Hut", AccessoryHats, 22, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Papa noel", ACCESSORY_HATS, 23, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Duende", ACCESSORY_HATS, 24, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Reno", ACCESSORY_HATS, 25, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Chaplin Hut", AccessoryHats, 26, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarzer Zylinder", AccessoryHats, 27, SexFemale, 2500),
            new BusinessClothesModel(1, "Brauner Hut mit schwarzem Band", AccessoryHats, 28, SexFemale, 2500),
            new BusinessClothesModel(1, "Lila Mütze", AccessoryHats, 29, SexFemale, 2500),
            new BusinessClothesModel(1, "U.S.A. Hut", AccessoryHats, 30, SexFemale, 2500),
            new BusinessClothesModel(1, "U.S.A. Zylinder", AccessoryHats, 31, SexFemale, 2500),
            //new BusinessClothesModel(1, "Choose you tercero", ACCESSORY_HATS, 32, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Wollmütze", AccessoryHats, 33, SexFemale, 2500),
            new BusinessClothesModel(1, "U.S.A. Motiv", AccessoryHats, 34, SexFemale, 2500),
            new BusinessClothesModel(1, "U.S.A. Sterne", AccessoryHats, 35, SexFemale, 2500),
            new BusinessClothesModel(1, "Pißwasser Getränkhalter", AccessoryHats, 36, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Casco caballo", ACCESSORY_HATS, 38, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Arbol navidad", ACCESSORY_HATS, 39, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Postre", ACCESSORY_HATS, 40, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Navideño", ACCESSORY_HATS, 41, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Mama noel", ACCESSORY_HATS, 42, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra Naughty", ACCESSORY_HATS, 43, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Rote Basecap (Hinten)", AccessoryHats, 44, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Casco visera negro", ACCESSORY_HATS, 47, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro opaco", ACCESSORY_HATS, 49, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro espejo", ACCESSORY_HATS, 50, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra verde simbolo", ACCESSORY_HATS, 53, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Brauner Sonnenhut", AccessoryHats, 54, SexFemale, 2500),
            new BusinessClothesModel(1, "Broker Basecap", AccessoryHats, 55, SexFemale, 2500),
            new BusinessClothesModel(1, "Lagnetics Basecap", AccessoryHats, 56, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Gorra marron clarito", ACCESSORY_HATS, 58, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco caballo verde", ACCESSORY_HATS, 59, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Lana verde", ACCESSORY_HATS, 60, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Schwarzer Hut mit grünem Band", AccessoryHats, 61, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Casco verde", ACCESSORY_HATS, 62, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra verde", ACCESSORY_HATS, 63, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra negra triangulo rojo y blanco", ACCESSORY_HATS, 64, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra negra hacia atras", ACCESSORY_HATS, 65, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco oscuro abierta visera", ACCESSORY_HATS, 66, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro abierta visera", ACCESSORY_HATS, 67, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera espejo abierta", ACCESSORY_HATS, 68, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco verde visera abierta", ACCESSORY_HATS, 71, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco verde abierto", ACCESSORY_HATS, 74, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Atomic Basecap", AccessoryHats, 75, SexFemale, 2500),
            new BusinessClothesModel(1, "Blaue Basecao (Hinten)", AccessoryHats, 76, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze Mütze", AccessoryHats, 82, SexFemale, 2500),
            /*new BusinessClothesModel(1, "Casco guerra con pinchos", ACCESSORY_HATS, 83, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco guerra negro", ACCESSORY_HATS, 84, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco cresta", ACCESSORY_HATS, 86, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco trinchera", ACCESSORY_HATS, 88, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco trinchera plata", ACCESSORY_HATS, 89, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas", ACCESSORY_HATS, 90, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas visera abierta", ACCESSORY_HATS, 91, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco abierto blanco y azul", ACCESSORY_HATS, 92, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Beiger Sonnenhut", AccessoryHats, 93, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarzer hut mit weißem Band", AccessoryHats, 94, SexFemale, 2500),
            new BusinessClothesModel(1, "Bigness Basecap", AccessoryHats, 95, SexFemale, 2500),
            //new BusinessClothesModel(1, "Cuernos reno punta roja", ACCESSORY_HATS, 100, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Basecap", AccessoryHats, 101, SexFemale, 2500),
            //Neu hinzugefügt//
            new BusinessClothesModel(1, "Gemusteter Sonnenhut", AccessoryHats, 131, SexFemale, 2500),
 
                
                
            // Male hats
                
            //new BusinessClothesModel(1, "Auriculares rojos", ACCESSORY_HATS, 0, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Cono blanco", ACCESSORY_HATS, 1, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Lana negro", ACCESSORY_HATS, 2, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Karierter Sonnenhut", AccessoryHats, 3, SexMale, 2500),
            new BusinessClothesModel(1, "LS Basecap", AccessoryHats, 4, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarze Wollmütze", AccessoryHats, 5, SexMale, 2500),
            //new BusinessClothesModel(1, "Gorra verde", ACCESSORY_HATS, 6, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorrilla blanca", ACCESSORY_HATS, 7, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra hacia atras cuadrados negros y blancos", ACCESSORY_HATS, 9, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Karierte Baseballcap", AccessoryHats, 10, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarzer Hut", AccessoryHats, 12, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarzer Cowboy Hut", AccessoryHats, 13, SexMale, 2500),
            //new BusinessClothesModel(1, "Pañuelo blanco motivos negros", ACCESSORY_HATS, 14, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Blau, weiße Kopfhörer", AccessoryHats, 15, SexMale, 2500),
            //new BusinessClothesModel(1, "Casco amarillo negro y rojo", ACCESSORY_HATS, 16, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco abierto azul y negro", ACCESSORY_HATS, 17, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco negro", ACCESSORY_HATS, 18, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Grüner Sonnenhut", AccessoryHats, 20, SexMale, 2500),
            new BusinessClothesModel(1, "Gelber Sonnenhut", AccessoryHats, 21, SexMale, 2500),
            //new BusinessClothesModel(1, "Papa noel", ACCESSORY_HATS, 22, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Duende navidad", ACCESSORY_HATS, 23, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Reno", ACCESSORY_HATS, 24, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Dunkelblauer Hut", AccessoryHats, 25, SexMale, 2500),
            new BusinessClothesModel(1, "Chaplin Hut", AccessoryHats, 26, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarzer Zylinder", AccessoryHats, 27, SexMale, 2500),
            new BusinessClothesModel(1, "Blaue Wollfmütze", AccessoryHats, 28, SexMale, 2500),
            new BusinessClothesModel(1, "Graue Mütze", AccessoryHats, 29, SexMale, 2500),
            new BusinessClothesModel(1, "Roter Hut mit schwarzem Band", AccessoryHats, 30, SexMale, 2500),
            new BusinessClothesModel(1, "U.S.A. Hut", AccessoryHats, 31, SexMale, 2500),
            new BusinessClothesModel(1, "U.S.A. Zylinder", AccessoryHats, 32, SexMale, 2500),
            //new BusinessClothesModel(1, "Choose you tercero", ACCESSORY_HATS, 33, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Wollmütze", AccessoryHats, 34, SexMale, 2500),
            new BusinessClothesModel(1, "U.S.A. Motiv", AccessoryHats, 35, SexMale, 2500),
            new BusinessClothesModel(1, "U.S.A. Sterne", AccessoryHats, 36, SexMale, 2500),
            new BusinessClothesModel(1, "Pißwasser Getränkhalter", AccessoryHats, 37, SexMale, 2500),
            /*new BusinessClothesModel(1, "Negro caballo", ACCESSORY_HATS, 39, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Arbol navidad", ACCESSORY_HATS, 40, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Postre", ACCESSORY_HATS, 41, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Navideño", ACCESSORY_HATS, 42, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Papa noel a cuadros", ACCESSORY_HATS, 43, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gorra roja y blanca con letras", ACCESSORY_HATS, 44, SEX_MALE, 2500),*/
            new BusinessClothesModel(1, "Rote Basecap", AccessoryHats, 45, SexMale, 2500),
            //new BusinessClothesModel(1, "Casco visera hacia delante negro", ACCESSORY_HATS, 48, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco negro opaco", ACCESSORY_HATS, 50, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco negro visera espejo", ACCESSORY_HATS, 51, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra verde letra", ACCESSORY_HATS, 54, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Broker Basecap", AccessoryHats, 55, SexMale, 2500),
            new BusinessClothesModel(1, "Lagnetics Basecap", AccessoryHats, 56, SexMale, 2500),
            //new BusinessClothesModel(1, "Gorra maron", ACCESSORY_HATS, 58, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco caballo verde", ACCESSORY_HATS, 59, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra verde", ACCESSORY_HATS, 60, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Hut mit grünem Band", AccessoryHats, 61, SexMale, 2500),
            //new BusinessClothesModel(1, "Casco verde", ACCESSORY_HATS, 62, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Grüne Basecap", AccessoryHats, 63, SexMale, 2500),
            new BusinessClothesModel(1, "Blauer Hut", AccessoryHats, 64, SexMale, 2500),
            /*new BusinessClothesModel(1, "Gorra negra triangulo rojo y blanco", ACCESSORY_HATS, 65, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gorra negra hacia atras", ACCESSORY_HATS, 66, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera abierta", ACCESSORY_HATS, 67, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera opaca abierta", ACCESSORY_HATS, 68, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera espejo abierta", ACCESSORY_HATS, 69, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco abierto verde", ACCESSORY_HATS, 75, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gorra azul y amarilla con letras", ACCESSORY_HATS, 76, SEX_MALE, 2500),*/
            new BusinessClothesModel(1, "Blaue Basecap", AccessoryHats, 77, SexMale, 2500),
            new BusinessClothesModel(1, "Kurze schwarze Wollfmütze", AccessoryHats, 83, SexMale, 2500),
            /*new BusinessClothesModel(1, "Casco guerra pinchos", ACCESSORY_HATS, 84, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra", ACCESSORY_HATS, 85, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra visera", ACCESSORY_HATS, 86, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra cresta", ACCESSORY_HATS, 87, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra negro", ACCESSORY_HATS, 89, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra plata", ACCESSORY_HATS, 90, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas", ACCESSORY_HATS, 91, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas visera abierta", ACCESSORY_HATS, 92, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco abierto blanco con diana", ACCESSORY_HATS, 93, SEX_MALE, 2500),*/
            new BusinessClothesModel(1, "Beiger Sonnenhut", AccessoryHats, 94, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarzer Hut mit beigen Band", AccessoryHats, 95, SexMale, 2500),
            //new BusinessClothesModel(1, "Gorra negra BIGNESS", ACCESSORY_HATS, 96, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Reno puntas rojas", ACCESSORY_HATS, 101, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarze Basecap", AccessoryHats, 102, SexMale, 2500),
            //Neu hinzugefügt//
            new BusinessClothesModel(1, "Schwarze Wollmütze", AccessoryHats, 120, SexMale, 2500),
 
                
                
            // Female glasses
                
            new BusinessClothesModel(1, "Braune Sonnenbrille", AccessoryGlasses, 0, SexFemale, 2500),
            new BusinessClothesModel(1, "Große Sonnenbrille", AccessoryGlasses, 1, SexFemale, 2500),
            new BusinessClothesModel(1, "Große schwarze Sonnenbrille", AccessoryGlasses, 2, SexFemale, 2500),
            //new BusinessClothesModel(1, "Rectas cristal marron", ACCESSORY_GLASSES, 3, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Leoparden Sonnenbrille", AccessoryGlasses, 4, SexFemale, 2500),
            new BusinessClothesModel(1, "Silberne Sonnenbrille", AccessoryGlasses, 6, SexFemale, 2500),
            new BusinessClothesModel(1, "Helle, silberne Sonnenbrille", AccessoryGlasses, 7, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze transperente Brille", AccessoryGlasses, 8, SexFemale, 2500),
            new BusinessClothesModel(1, "Grüne Sportbrille", AccessoryGlasses, 9, SexFemale, 2500),
            new BusinessClothesModel(1, "Grün zu blau farbige Brille", AccessoryGlasses, 10, SexFemale, 2500),
            new BusinessClothesModel(1, "Blau, silberne Brille", AccessoryGlasses, 11, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze transperente Brille", AccessoryGlasses, 14, SexFemale, 2500),
            new BusinessClothesModel(1, "Gold, schwarze Sonnenbrille", AccessoryGlasses, 16, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze Brille", AccessoryGlasses, 17, SexFemale, 2500),
            new BusinessClothesModel(1, "Sportlich graue Brille", AccessoryGlasses, 18, SexFemale, 2500),
            new BusinessClothesModel(1, "Sportlich schwarze Brille", AccessoryGlasses, 19, SexFemale, 2500),
            //new BusinessClothesModel(1, "Redondas negras cristal transparente oscuro", ACCESSORY_GLASSES, 20, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze transperente Brille", AccessoryGlasses, 21, SexFemale, 2500),
            new BusinessClothesModel(1, "U.S.A. Sternbrille", AccessoryGlasses, 22, SexFemale, 2500),
            new BusinessClothesModel(1, "U.S.A. Brille", AccessoryGlasses, 23, SexFemale, 2500),
            new BusinessClothesModel(1, "Schwarze Sonnenbrille", AccessoryGlasses, 24, SexFemale, 2500),
            new BusinessClothesModel(1, "Sportlich grüne Brille", AccessoryGlasses, 25, SexFemale, 2500),
            //new BusinessClothesModel(1, "Piloto", ACCESSORY_GLASSES, 26, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Snow", ACCESSORY_GLASSES, 27, SEX_FEMALE, 2500),
 
                
                
            // Male glasses
                
            new BusinessClothesModel(1, "Feine schwarze und weiße Quadrate", AccessoryGlasses, 1, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarz umrandete Sonnenbrille", AccessoryGlasses, 2, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarze Brille", AccessoryGlasses, 3, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarze halb umrandete Sonnenbrille", AccessoryGlasses, 4, SexMale, 2500),
            new BusinessClothesModel(1, "Blau, goldene Sonnenbrille", AccessoryGlasses, 5, SexMale, 2500),
            new BusinessClothesModel(1, "Blau, silberne Sonnenbrille", AccessoryGlasses, 8, SexMale, 2500),
            new BusinessClothesModel(1, "Sportlich schwarze Brille", AccessoryGlasses, 9, SexMale, 2500),
            new BusinessClothesModel(1, "Gold, schwarze quadratische Brille", AccessoryGlasses, 10, SexMale, 2500),
            new BusinessClothesModel(1, "Goldbraune Brille", AccessoryGlasses, 12, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarze Sonnenbrille", AccessoryGlasses, 13, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarz, gelbe Schutzbrille", AccessoryGlasses, 15, SexMale, 2500),
            new BusinessClothesModel(1, "Sportlich schwarze Sonnenbrille", AccessoryGlasses, 16, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarz, silberne Brille", AccessoryGlasses, 17, SexMale, 2500),
            new BusinessClothesModel(1, "Goldene Sonnenbrille", AccessoryGlasses, 18, SexMale, 2500),
            new BusinessClothesModel(1, "Altmodische Sonnenbrille", AccessoryGlasses, 19, SexMale, 2500),
            new BusinessClothesModel(1, "Schwarz, gelbe transparente Brille", AccessoryGlasses, 20, SexMale, 2500),
            new BusinessClothesModel(1, "U.S.A. Sternbrille", AccessoryGlasses, 21, SexMale, 2500),
            new BusinessClothesModel(1, "U.S.A. Brille", AccessoryGlasses, 22, SexMale, 2500),
            new BusinessClothesModel(1, "Sportlich grüne Sonnenbrille", AccessoryGlasses, 23, SexMale, 2500),
            //new BusinessClothesModel(1, "Piloto", ACCESSORY_GLASSES, 24, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Snow", ACCESSORY_GLASSES, 25, SEX_MALE, 2500),
 
                
                
            // Female earrings
                
            new BusinessClothesModel(1, "Schwarz, weißes Headset", AccessoryEars, 0, SexFemale, 1500),
            new BusinessClothesModel(1, "Schwarzes Headset", AccessoryEars, 1, SexFemale, 1500),
            new BusinessClothesModel(1, "Schwarzes Headset (Dick)", AccessoryEars, 2, SexFemale, 1500),
            new BusinessClothesModel(1, "Silberner Ohrring (Lang)", AccessoryEars, 3, SexFemale, 1500),
            new BusinessClothesModel(1, "Brauner Ohrring (Lang)", AccessoryEars, 4, SexFemale, 1500),
            new BusinessClothesModel(1, "Silberohrring", AccessoryEars, 5, SexFemale, 1500),
            new BusinessClothesModel(1, "Goldene Raute", AccessoryEars, 6, SexFemale, 1500),
            new BusinessClothesModel(1, "Goldener Ohrring (Lang)", AccessoryEars, 7, SexFemale, 1500),
            new BusinessClothesModel(1, "Goldene Kugel (Lang)", AccessoryEars, 8, SexFemale, 1500),
            new BusinessClothesModel(1, "Goldvorhang", AccessoryEars, 9, SexFemale, 1500),
            new BusinessClothesModel(1, "Grüne hängende Kugel", AccessoryEars, 10, SexFemale, 1500),
            new BusinessClothesModel(1, "Langes gold", AccessoryEars, 11, SexFemale, 1500),
            new BusinessClothesModel(1, "Kleiner Ohrring", AccessoryEars, 12, SexFemale, 1500),
            new BusinessClothesModel(1, "Gold Ring (Waffe)", AccessoryEars, 13, SexFemale, 1500),
            new BusinessClothesModel(1, "Gold Ring (Gemustert)", AccessoryEars, 14, SexFemale, 1500),
            new BusinessClothesModel(1, "Gold Ring (Glatt)", AccessoryEars, 15, SexFemale, 1500),
            new BusinessClothesModel(1, "Gold Ring (Fuck)", AccessoryEars, 16, SexFemale, 1500),
            new BusinessClothesModel(1, "Gold Ring (Scream)", AccessoryEars, 17, SexFemale, 1500),
 
                
                
            // Male earrings
                
            new BusinessClothesModel(1, "Schwarz, weißes Headset", AccessoryEars, 0, SexMale, 1500),
            new BusinessClothesModel(1, "Schwarzes Headset", AccessoryEars, 1, SexMale, 1500),
            new BusinessClothesModel(1, "Goldener Ohrring", AccessoryEars, 4, SexMale, 1500),
            new BusinessClothesModel(1, "Kleiner Goldener Kreis", AccessoryEars, 7, SexMale, 1500),
            new BusinessClothesModel(1, "Goldene Pyramide", AccessoryEars, 10, SexMale, 1500),
            new BusinessClothesModel(1, "Goldenes Quadrat", AccessoryEars, 13, SexMale, 1500),
            new BusinessClothesModel(1, "Diamant", AccessoryEars, 16, SexMale, 1500),
            new BusinessClothesModel(1, "Weißdorn", AccessoryEars, 22, SexMale, 1500),
            new BusinessClothesModel(1, "Silbener Schädel", AccessoryEars, 25, SexMale, 1500),
            new BusinessClothesModel(1, "Metall Stecker", AccessoryEars, 28, SexMale, 1500),
            new BusinessClothesModel(1, "Schwarzes Quadrat", AccessoryEars, 31, SexMale, 1500),
            new BusinessClothesModel(1, "Silbernes Quadrat", AccessoryEars, 35, SexMale, 1500)


        };

        // Tattoo list
        public static List<BusinessTattooModel> TattooList = new List<BusinessTattooModel>
        {
            // Torso
            new BusinessTattooModel(TattooZoneTorso, "Refined Hustler", "mpbusiness_overlays", "MP_Buis_M_Stomach_000", string.Empty, 200),
            new BusinessTattooModel(TattooZoneTorso, "Rich", "mpbusiness_overlays", "MP_Buis_M_Chest_000", string.Empty, 150),
            new BusinessTattooModel(TattooZoneTorso, "$$$", "mpbusiness_overlays", "MP_Buis_M_Chest_001", string.Empty, 150),
            new BusinessTattooModel(TattooZoneTorso, "Makin' Paper", "mpbusiness_overlays", "MP_Buis_M_Back_000", string.Empty, 200),
            new BusinessTattooModel(TattooZoneTorso, "High Roller", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Chest_000", 200),
            new BusinessTattooModel(TattooZoneTorso, "Makin' Money", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Chest_001", 200),
            new BusinessTattooModel(TattooZoneTorso, "Love Money", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Chest_002", 100),
            new BusinessTattooModel(TattooZoneTorso, "Diamond Back", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Stom_000", 200),
            new BusinessTattooModel(TattooZoneTorso, "Santo Capra Logo", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Stom_001", 100),
            new BusinessTattooModel(TattooZoneTorso, "Money Bag", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Stom_002", 100),
            new BusinessTattooModel(TattooZoneTorso, "Respect", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Back_000", 200),
            new BusinessTattooModel(TattooZoneTorso, "Gold Digger", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Back_001", 150),
            new BusinessTattooModel(TattooZoneTorso, "Carp Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_005", "MP_Xmas2_F_Tat_005", 230),
            new BusinessTattooModel(TattooZoneTorso, "Carp Shaded", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_006", "MP_Xmas2_F_Tat_006", 350),
            new BusinessTattooModel(TattooZoneTorso, "Time To Die", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_009", "MP_Xmas2_F_Tat_009", 250),
            new BusinessTattooModel(TattooZoneTorso, "Roaring Tiger", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_011", "MP_Xmas2_F_Tat_011", 300),
            new BusinessTattooModel(TattooZoneTorso, "Lizard", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_013", "MP_Xmas2_F_Tat_013", 250),
            new BusinessTattooModel(TattooZoneTorso, "Japanese Warrior", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_015", "MP_Xmas2_F_Tat_015", 400),
            new BusinessTattooModel(TattooZoneTorso, "Loose Lips Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_016", "MP_Xmas2_F_Tat_016", 200),
            new BusinessTattooModel(TattooZoneTorso, "Loose Lips Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_017", "MP_Xmas2_F_Tat_017", 250),
            new BusinessTattooModel(TattooZoneTorso, "Royal Dagger Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_018", "MP_Xmas2_F_Tat_018", 300),
            new BusinessTattooModel(TattooZoneTorso, "Royal Dagger Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_019", "MP_Xmas2_F_Tat_019", 350),
            new BusinessTattooModel(TattooZoneTorso, "Executioner", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_028", "MP_Xmas2_F_Tat_028", 250),
            new BusinessTattooModel(TattooZoneTorso, "Bullet Proof", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_000_M", "MP_Gunrunning_Tattoo_000_F", 320),
            new BusinessTattooModel(TattooZoneTorso, "Crossed Weapons", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_001_M", "MP_Gunrunning_Tattoo_001_F", 320),
            new BusinessTattooModel(TattooZoneTorso, "Butterfly Knife", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_009_M", "MP_Gunrunning_Tattoo_009_F", 320),
            new BusinessTattooModel(TattooZoneTorso, "Cash Money", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_010_M", "MP_Gunrunning_Tattoo_010_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Dollar Daggers", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_012_M", "MP_Gunrunning_Tattoo_012_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Wolf Insignia", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_013_M", "MP_Gunrunning_Tattoo_013_F", 450),
            new BusinessTattooModel(TattooZoneTorso, "Backstabber", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_014_M", "MP_Gunrunning_Tattoo_014_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Dog Tags", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_017_M", "MP_Gunrunning_Tattoo_017_F", 120),
            new BusinessTattooModel(TattooZoneTorso, "Dual Wield Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_018_M", "MP_Gunrunning_Tattoo_018_F", 270),
            new BusinessTattooModel(TattooZoneTorso, "Pistol Wings", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_019_M", "MP_Gunrunning_Tattoo_019_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Crowned Weapons", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_020_M", "MP_Gunrunning_Tattoo_020_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Explosive Heart", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_022_M", "MP_Gunrunning_Tattoo_022_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Micro SMG Chain", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_028_M", "MP_Gunrunning_Tattoo_028_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Win Some Lose Some", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_029_M", "MP_Gunrunning_Tattoo_029_F", 280),
            new BusinessTattooModel(TattooZoneTorso, "Crossed Arrows", "mphipster_overlays", "FM_Hip_M_Tat_000", "FM_Hip_F_Tat_000", 300),
            new BusinessTattooModel(TattooZoneTorso, "Chemistry", "mphipster_overlays", "FM_Hip_M_Tat_002", "FM_Hip_F_Tat_002", 100),
            new BusinessTattooModel(TattooZoneTorso, "Feather Birds", "mphipster_overlays", "FM_Hip_M_Tat_006", "FM_Hip_F_Tat_006", 200),
            new BusinessTattooModel(TattooZoneTorso, "Infinity", "mphipster_overlays", "FM_Hip_M_Tat_011", "FM_Hip_F_Tat_011", 100),
            new BusinessTattooModel(TattooZoneTorso, "Antlers", "mphipster_overlays", "FM_Hip_M_Tat_012", "FM_Hip_F_Tat_012", 100),
            new BusinessTattooModel(TattooZoneTorso, "Boombox", "mphipster_overlays", "FM_Hip_M_Tat_013", "FM_Hip_F_Tat_013", 100),
            new BusinessTattooModel(TattooZoneTorso, "Pyramid", "mphipster_overlays", "FM_Hip_M_Tat_024", "FM_Hip_F_Tat_024", 100),
            new BusinessTattooModel(TattooZoneTorso, "Watch Your Step", "mphipster_overlays", "FM_Hip_M_Tat_025", "FM_Hip_F_Tat_025", 150),
            new BusinessTattooModel(TattooZoneTorso, "Sad", "mphipster_overlays", "FM_Hip_M_Tat_029", "FM_Hip_F_Tat_029", 100),
            new BusinessTattooModel(TattooZoneTorso, "Shark Fin", "mphipster_overlays", "FM_Hip_M_Tat_030", "FM_Hip_F_Tat_030", 100),
            new BusinessTattooModel(TattooZoneTorso, "Skateboard", "mphipster_overlays", "FM_Hip_M_Tat_031", "FM_Hip_F_Tat_031", 100),
            new BusinessTattooModel(TattooZoneTorso, "Paper Plane", "mphipster_overlays", "FM_Hip_M_Tat_032", "FM_Hip_F_Tat_032", 150),
            new BusinessTattooModel(TattooZoneTorso, "Stag", "mphipster_overlays", "FM_Hip_M_Tat_033", "FM_Hip_F_Tat_033", 200),
            new BusinessTattooModel(TattooZoneTorso, "Sewn Heart", "mphipster_overlays", "FM_Hip_M_Tat_035", "FM_Hip_F_Tat_035", 100),
            new BusinessTattooModel(TattooZoneTorso, "Tooth", "mphipster_overlays", "FM_Hip_M_Tat_041", "FM_Hip_F_Tat_041", 100),
            new BusinessTattooModel(TattooZoneTorso, "Triangles", "mphipster_overlays", "FM_Hip_M_Tat_046", "FM_Hip_F_Tat_046", 100),
            new BusinessTattooModel(TattooZoneTorso, "Cassette", "mphipster_overlays", "FM_Hip_M_Tat_047", "FM_Hip_F_Tat_047", 100),
            new BusinessTattooModel(TattooZoneTorso, "Block Back", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_000_M", "MP_MP_ImportExport_Tat_000_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Power Plant", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_001_M", "MP_MP_ImportExport_Tat_001_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Tuned to Death", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_002_M", "MP_MP_ImportExport_Tat_002_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Serpents of Destruction", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_009_M", "MP_MP_ImportExport_Tat_009_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Take the Wheel", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_010_M", "MP_MP_ImportExport_Tat_010_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Talk Shit Get Hit", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_011_M", "MP_MP_ImportExport_Tat_011_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "King Fight", "mplowrider_overlays", "MP_LR_Tat_001_M", "MP_LR_Tat_001_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Holy Mary", "mplowrider_overlays", "MP_LR_Tat_002_M", "MP_LR_Tat_002_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Gun Mic", "mplowrider_overlays", "MP_LR_Tat_004_M", "MP_LR_Tat_004_F", 150),
            new BusinessTattooModel(TattooZoneTorso, "Amazon", "mplowrider_overlays", "MP_LR_Tat_009_M", "MP_LR_Tat_009_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Bad Angel", "mplowrider_overlays", "MP_LR_Tat_010_M", "MP_LR_Tat_010_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Love Gamble", "mplowrider_overlays", "MP_LR_Tat_013_M", "MP_LR_Tat_013_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Love is Blind", "mplowrider_overlays", "MP_LR_Tat_014_M", "MP_LR_Tat_014_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Sad Angel", "mplowrider_overlays", "MP_LR_Tat_021_M", "MP_LR_Tat_021_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Royal Takeover", "mplowrider_overlays", "MP_LR_Tat_026_M", "MP_LR_Tat_026_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Turbulence", "mpairraces_overlays", "MP_Airraces_Tattoo_000_M", "MP_Airraces_Tattoo_000_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Pilot Skull", "mpairraces_overlays", "MP_Airraces_Tattoo_001_M", "MP_Airraces_Tattoo_001_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Winged Bombshell", "mpairraces_overlays", "MP_Airraces_Tattoo_002_M", "MP_Airraces_Tattoo_002_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Balloon Pioneer", "mpairraces_overlays", "MP_Airraces_Tattoo_004_M", "MP_Airraces_Tattoo_004_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Parachute Belle", "mpairraces_overlays", "MP_Airraces_Tattoo_005_M", "MP_Airraces_Tattoo_005_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Bombs Away", "mpairraces_overlays", "MP_Airraces_Tattoo_006_M", "MP_Airraces_Tattoo_006_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Eagle Eyes", "mpairraces_overlays", "MP_Airraces_Tattoo_007_M", "MP_Airraces_Tattoo_007_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Demon Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_000_M", "MP_MP_Biker_Tat_000_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Both Barrels", "mpbiker_overlays", "MP_MP_Biker_Tat_001_M", "MP_MP_Biker_Tat_001_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Web Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_003_M", "MP_MP_Biker_Tat_003_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Made In America", "mpbiker_overlays", "MP_MP_Biker_Tat_005_M", "MP_MP_Biker_Tat_005_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Chopper Freedom", "mpbiker_overlays", "MP_MP_Biker_Tat_006_M", "MP_MP_Biker_Tat_006_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Freedom Wheels", "mpbiker_overlays", "MP_MP_Biker_Tat_008_M", "MP_MP_Biker_Tat_008_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Skull Of Taurus", "mpbiker_overlays", "MP_MP_Biker_Tat_010_M", "MP_MP_Biker_Tat_010_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "R.I.P. My Brothers", "mpbiker_overlays", "MP_MP_Biker_Tat_011_M", "MP_MP_Biker_Tat_011_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Demon Crossbones", "mpbiker_overlays", "MP_MP_Biker_Tat_013_M", "MP_MP_Biker_Tat_013_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Clawed Beast", "mpbiker_overlays", "MP_MP_Biker_Tat_017_M", "MP_MP_Biker_Tat_017_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Skeletal Chopper", "mpbiker_overlays", "MP_MP_Biker_Tat_018_M", "MP_MP_Biker_Tat_018_F", 100),
            new BusinessTattooModel(TattooZoneTorso, "Gruesome Talons", "mpbiker_overlays", "MP_MP_Biker_Tat_019_M", "MP_MP_Biker_Tat_019_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Flaming Reaper", "mpbiker_overlays", "MP_MP_Biker_Tat_021_M", "MP_MP_Biker_Tat_021_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Western MC", "mpbiker_overlays", "MP_MP_Biker_Tat_023_M", "MP_MP_Biker_Tat_023_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "American Dream", "mpbiker_overlays", "MP_MP_Biker_Tat_026_M", "MP_MP_Biker_Tat_026_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Bone Wrench", "mpbiker_overlays", "MP_MP_Biker_Tat_029_M", "MP_MP_Biker_Tat_029_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Brothers For Life", "mpbiker_overlays", "MP_MP_Biker_Tat_030_M", "MP_MP_Biker_Tat_030_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Gear Head", "mpbiker_overlays", "MP_MP_Biker_Tat_031_M", "MP_MP_Biker_Tat_031_F", 150),
            new BusinessTattooModel(TattooZoneTorso, "Western Eagle", "mpbiker_overlays", "MP_MP_Biker_Tat_032_M", "MP_MP_Biker_Tat_032_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Brotherhood of Bikes", "mpbiker_overlays", "MP_MP_Biker_Tat_034_M", "MP_MP_Biker_Tat_034_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Gas Guzzler", "mpbiker_overlays", "MP_MP_Biker_Tat_039_M", "MP_MP_Biker_Tat_039_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "No Regrets", "mpbiker_overlays", "MP_MP_Biker_Tat_041_M", "MP_MP_Biker_Tat_041_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Ride Forever", "mpbiker_overlays", "MP_MP_Biker_Tat_043_M", "MP_MP_Biker_Tat_043_F", 150),
            new BusinessTattooModel(TattooZoneTorso, "Unforgiven", "mpbiker_overlays", "MP_MP_Biker_Tat_050_M", "MP_MP_Biker_Tat_050_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Biker Mount", "mpbiker_overlays", "MP_MP_Biker_Tat_052_M", "MP_MP_Biker_Tat_052_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Reaper Vulture", "mpbiker_overlays", "MP_MP_Biker_Tat_058_M", "MP_MP_Biker_Tat_058_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Faggio", "mpbiker_overlays", "MP_MP_Biker_Tat_059_M", "MP_MP_Biker_Tat_059_F", 150),
            new BusinessTattooModel(TattooZoneTorso, "We Are The Mods!", "mpbiker_overlays", "MP_MP_Biker_Tat_060_M", "MP_MP_Biker_Tat_060_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "SA Assault", "mplowrider2_overlays", "MP_LR_Tat_000_M", "MP_LR_Tat_000_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Love the Game", "mplowrider2_overlays", "MP_LR_Tat_008_M", "MP_LR_Tat_008_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Lady Liberty", "mplowrider2_overlays", "MP_LR_Tat_011_M", "MP_LR_Tat_011_F", 100),
            new BusinessTattooModel(TattooZoneTorso, "Royal Kiss", "mplowrider2_overlays", "MP_LR_Tat_012_M", "MP_LR_Tat_012_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Two Face", "mplowrider2_overlays", "MP_LR_Tat_016_M", "MP_LR_Tat_016_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Death Behind", "mplowrider2_overlays", "MP_LR_Tat_019_M", "MP_LR_Tat_019_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Dead Pretty", "mplowrider2_overlays", "MP_LR_Tat_031_M", "MP_LR_Tat_031_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Reign Over", "mplowrider2_overlays", "MP_LR_Tat_032_M", "MP_LR_Tat_032_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Abstract Skull", "mpluxe_overlays", "MP_LUXE_TAT_003_M", "MP_LUXE_TAT_003_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Eye of the Griffin", "mpluxe_overlays", "MP_LUXE_TAT_007_M", "MP_LUXE_TAT_007_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Flying Eye", "mpluxe_overlays", "MP_LUXE_TAT_008_M", "MP_LUXE_TAT_008_F", 100),
            new BusinessTattooModel(TattooZoneTorso, "Ancient Queen", "mpluxe_overlays", "MP_LUXE_TAT_014_M", "MP_LUXE_TAT_014_F", 150),
            new BusinessTattooModel(TattooZoneTorso, "Smoking Sisters", "mpluxe_overlays", "MP_LUXE_TAT_015_M", "MP_LUXE_TAT_015_F", 150),
            new BusinessTattooModel(TattooZoneTorso, "Feather Mural", "mpluxe_overlays", "MP_LUXE_TAT_024_M", "MP_LUXE_TAT_024_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "The Howler", "mpluxe2_overlays", "MP_LUXE_TAT_002_M", "MP_LUXE_TAT_002_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Geometric Galaxy", "mpluxe2_overlays", "MP_LUXE_TAT_012_M", "MP_LUXE_TAT_012_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Cloaked Angel", "mpluxe2_overlays", "MP_LUXE_TAT_022_M", "MP_LUXE_TAT_022_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Reaper Sway", "mpluxe2_overlays", "MP_LUXE_TAT_025_M", "MP_LUXE_TAT_025_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Cobra Dawn", "mpluxe2_overlays", "MP_LUXE_TAT_027_M", "MP_LUXE_TAT_027_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Geometric Design", "mpluxe2_overlays", "MP_LUXE_TAT_029_M", "MP_LUXE_TAT_029_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Bless The Dead", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_000_M", "MP_Smuggler_Tattoo_000_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Dead Lies", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_002_M", "MP_Smuggler_Tattoo_002_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Give Nothing Back", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_003_M", "MP_Smuggler_Tattoo_003_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Never Surrender", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_006_M", "MP_Smuggler_Tattoo_006_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "No Honor", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_007_M", "MP_Smuggler_Tattoo_007_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Tall Ship Conflict", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_009_M", "MP_Smuggler_Tattoo_009_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "See You In Hell", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_010_M", "MP_Smuggler_Tattoo_010_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Torn Wings", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_013_M", "MP_Smuggler_Tattoo_013_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Jolly Roger", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_015_M", "MP_Smuggler_Tattoo_015_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Skull Compass", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_016_M", "MP_Smuggler_Tattoo_016_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Framed Tall Ship", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_017_M", "MP_Smuggler_Tattoo_017_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Finders Keepers", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_018_M", "MP_Smuggler_Tattoo_018_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Lost At Sea", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_019_M", "MP_Smuggler_Tattoo_019_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Dead Tales", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_021_M", "MP_Smuggler_Tattoo_021_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "X Marks The Spot", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_022_M", "MP_Smuggler_Tattoo_022_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Pirate Captain", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_024_M", "MP_Smuggler_Tattoo_024_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Claimed By The Beast", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_025_M", "MP_Smuggler_Tattoo_025_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Wheels of Death", "mpstunt_overlays", "MP_MP_Stunt_Tat_011_M", "MP_MP_Stunt_Tat_011_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Punk Biker", "mpstunt_overlays", "MP_MP_Stunt_Tat_012_M", "MP_MP_Stunt_Tat_012_F", 250),
            new BusinessTattooModel(TattooZoneTorso, "Bat Cat of Spades", "mpstunt_overlays", "MP_MP_Stunt_Tat_014_M", "MP_MP_Stunt_Tat_014_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Vintage Bully", "mpstunt_overlays", "MP_MP_Stunt_Tat_018_M", "MP_MP_Stunt_Tat_018_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Engine Heart", "mpstunt_overlays", "MP_MP_Stunt_Tat_019_M", "MP_MP_Stunt_Tat_019_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Road Kill", "mpstunt_overlays", "MP_MP_Stunt_Tat_024_M", "MP_MP_Stunt_Tat_024_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Winged Wheel", "mpstunt_overlays", "MP_MP_Stunt_Tat_026_M", "MP_MP_Stunt_Tat_026_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Punk Road Hog", "mpstunt_overlays", "MP_MP_Stunt_Tat_027_M", "MP_MP_Stunt_Tat_027_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Majestic Finish", "mpstunt_overlays", "MP_MP_Stunt_Tat_029_M", "MP_MP_Stunt_Tat_029_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Man's Ruin", "mpstunt_overlays", "MP_MP_Stunt_Tat_030_M", "MP_MP_Stunt_Tat_030_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Sugar Skull Trucker", "mpstunt_overlays", "MP_MP_Stunt_Tat_033_M", "MP_MP_Stunt_Tat_033_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Feather Road Kill", "mpstunt_overlays", "MP_MP_Stunt_Tat_034_M", "MP_MP_Stunt_Tat_034_F", 350),
            new BusinessTattooModel(TattooZoneTorso, "Big Grills", "mpstunt_overlays", "MP_MP_Stunt_Tat_037_M", "MP_MP_Stunt_Tat_037_F", 200),
            new BusinessTattooModel(TattooZoneTorso, "Monkey Chopper", "mpstunt_overlays", "MP_MP_Stunt_Tat_040_M", "MP_MP_Stunt_Tat_040_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Brapp", "mpstunt_overlays", "MP_MP_Stunt_Tat_041_M", "MP_MP_Stunt_Tat_041_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Ram Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_044_M", "MP_MP_Stunt_Tat_044_F", 300),
            new BusinessTattooModel(TattooZoneTorso, "Full Throttle", "mpstunt_overlays", "MP_MP_Stunt_Tat_046_M", "MP_MP_Stunt_Tat_046_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Racing Doll", "mpstunt_overlays", "MP_MP_Stunt_Tat_048_M", "MP_MP_Stunt_Tat_048_F", 400),
            new BusinessTattooModel(TattooZoneTorso, "Blackjack", "multiplayer_overlays", "FM_Tat_Award_M_003", "FM_Tat_Award_F_003", 200),
            new BusinessTattooModel(TattooZoneTorso, "Hustler", "multiplayer_overlays", "FM_Tat_Award_M_004", "FM_Tat_Award_F_004", 300),
            new BusinessTattooModel(TattooZoneTorso, "Angel", "multiplayer_overlays", "FM_Tat_Award_M_005", "FM_Tat_Award_F_005", 400),
            new BusinessTattooModel(TattooZoneTorso, "Los Santos Customs", "multiplayer_overlays", "FM_Tat_Award_M_008", "FM_Tat_Award_F_008", 200),
            new BusinessTattooModel(TattooZoneTorso, "Blank Scroll", "multiplayer_overlays", "FM_Tat_Award_M_011", "FM_Tat_Award_F_011", 100),
            new BusinessTattooModel(TattooZoneTorso, "Embellished Scroll", "multiplayer_overlays", "FM_Tat_Award_M_012", "FM_Tat_Award_F_012", 100),
            new BusinessTattooModel(TattooZoneTorso, "Seven Deadly Sins", "multiplayer_overlays", "FM_Tat_Award_M_013", "FM_Tat_Award_F_013", 150),
            new BusinessTattooModel(TattooZoneTorso, "Trust No One", "multiplayer_overlays", "FM_Tat_Award_M_014", "FM_Tat_Award_F_014", 200),
            new BusinessTattooModel(TattooZoneTorso, "Clown", "multiplayer_overlays", "FM_Tat_Award_M_016", "FM_Tat_Award_F_016", 200),
            new BusinessTattooModel(TattooZoneTorso, "Clown and Gun", "multiplayer_overlays", "FM_Tat_Award_M_017", "FM_Tat_Award_F_017", 220),
            new BusinessTattooModel(TattooZoneTorso, "Clown Dual Wield", "multiplayer_overlays", "FM_Tat_Award_M_018", "FM_Tat_Award_F_018", 240),
            new BusinessTattooModel(TattooZoneTorso, "Clown Dual Wield Dollars", "multiplayer_overlays", "FM_Tat_Award_M_019", "FM_Tat_Award_F_019", 260),
            new BusinessTattooModel(TattooZoneTorso, "Faith", "multiplayer_overlays", "FM_Tat_M_004", "FM_Tat_F_004", 350),
            new BusinessTattooModel(TattooZoneTorso, "Skull on the Cross", "multiplayer_overlays", "FM_Tat_M_009", "FM_Tat_F_009", 400),
            new BusinessTattooModel(TattooZoneTorso, "LS Flames", "multiplayer_overlays", "FM_Tat_M_010", "FM_Tat_F_010", 200),
            new BusinessTattooModel(TattooZoneTorso, "LS IScript", "multiplayer_overlays", "FM_Tat_M_011", "FM_Tat_F_011", 100),
            new BusinessTattooModel(TattooZoneTorso, "Los Santos Bills", "multiplayer_overlays", "FM_Tat_M_012", "FM_Tat_F_012", 350),
            new BusinessTattooModel(TattooZoneTorso, "Eagle and Serpent", "multiplayer_overlays", "FM_Tat_M_013", "FM_Tat_F_013", 200),
            new BusinessTattooModel(TattooZoneTorso, "Evil Clown", "multiplayer_overlays", "FM_Tat_M_016", "FM_Tat_F_016", 450),
            new BusinessTattooModel(TattooZoneTorso, "The Wages of Sin", "multiplayer_overlays", "FM_Tat_M_019", "FM_Tat_F_019", 450),
            new BusinessTattooModel(TattooZoneTorso, "Dragon", "multiplayer_overlays", "FM_Tat_M_020", "FM_Tat_F_020", 420),
            new BusinessTattooModel(TattooZoneTorso, "Flaming Cross", "multiplayer_overlays", "FM_Tat_M_024", "FM_Tat_F_024", 350),
            new BusinessTattooModel(TattooZoneTorso, "LS Bold", "multiplayer_overlays", "FM_Tat_M_025", "FM_Tat_F_025", 200),
            new BusinessTattooModel(TattooZoneTorso, "Trinity Knot", "multiplayer_overlays", "FM_Tat_M_029", "FM_Tat_F_029", 100),
            new BusinessTattooModel(TattooZoneTorso, "Lucky Celtic Dogs", "multiplayer_overlays", "FM_Tat_M_030", "FM_Tat_F_030", 200),
            new BusinessTattooModel(TattooZoneTorso, "Flaming Shamrock", "multiplayer_overlays", "FM_Tat_M_034", "FM_Tat_F_034", 150),
            new BusinessTattooModel(TattooZoneTorso, "Way of the Gun", "multiplayer_overlays", "FM_Tat_M_036", "FM_Tat_F_036", 250),
            new BusinessTattooModel(TattooZoneTorso, "Stone Cross", "multiplayer_overlays", "FM_Tat_M_044", "FM_Tat_F_044", 250),
            new BusinessTattooModel(TattooZoneTorso, "Skulls and Rose", "multiplayer_overlays", "FM_Tat_M_045", "FM_Tat_F_045", 400),
            
            // Head
            new BusinessTattooModel(TattooZoneHead, "Cash is King", "mpbusiness_overlays", "MP_Buis_M_Neck_000", string.Empty, 100),
            new BusinessTattooModel(TattooZoneHead, "Bold Dollar Sign", "mpbusiness_overlays", "MP_Buis_M_Neck_001", string.Empty, 100),
            new BusinessTattooModel(TattooZoneHead, "IScript Dollar Sign", "mpbusiness_overlays", "MP_Buis_M_Neck_002", string.Empty, 100),
            new BusinessTattooModel(TattooZoneHead, "$100", "mpbusiness_overlays", "MP_Buis_M_Neck_003", string.Empty, 150),
            new BusinessTattooModel(TattooZoneHead, "Val-de-Grace Logo", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Neck_000", 100),
            new BusinessTattooModel(TattooZoneHead, "Money Rose", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Neck_001", 100),
            new BusinessTattooModel(TattooZoneHead, "Los Muertos", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_007", "MP_Xmas2_F_Tat_007", 150),
            new BusinessTattooModel(TattooZoneHead, "Snake Head Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_024", "MP_Xmas2_F_Tat_024", 100),
            new BusinessTattooModel(TattooZoneHead, "Snake Head Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_025", "MP_Xmas2_F_Tat_025", 150),
            new BusinessTattooModel(TattooZoneHead, "Beautiful Death", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_029", "MP_Xmas2_F_Tat_029", 150),
            new BusinessTattooModel(TattooZoneHead, "Lock & Load", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_003_M", "MP_Gunrunning_Tattoo_003_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Beautiful Eye", "mphipster_overlays", "FM_Hip_M_Tat_005", "FM_Hip_F_Tat_005", 100),
            new BusinessTattooModel(TattooZoneHead, "Geo Fox", "mphipster_overlays", "FM_Hip_M_Tat_021", "FM_Hip_F_Tat_021", 100),
            new BusinessTattooModel(TattooZoneHead, "Morbid Arachnid", "mpbiker_overlays", "MP_MP_Biker_Tat_009_M", "MP_MP_Biker_Tat_009_F", 100),
            new BusinessTattooModel(TattooZoneHead, "FTW", "mpbiker_overlays", "MP_MP_Biker_Tat_038_M", "MP_MP_Biker_Tat_038_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Western Stylized", "mpbiker_overlays", "MP_MP_Biker_Tat_051_M", "MP_MP_Biker_Tat_051_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Sinner", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_011_M", "MP_Smuggler_Tattoo_011_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Thief", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_012_M", "MP_Smuggler_Tattoo_012_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Stunt Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_000_M", "MP_MP_Stunt_Tat_000_F", 150),
            new BusinessTattooModel(TattooZoneHead, "Scorpion", "mpstunt_overlays", "MP_MP_Stunt_Tat_004_M", "MP_MP_Stunt_Tat_004_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Toxic Spider", "mpstunt_overlays", "MP_MP_Stunt_Tat_006_M", "MP_MP_Stunt_Tat_006_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Bat Wheel", "mpstunt_overlays", "MP_MP_Stunt_Tat_017_M", "MP_MP_Stunt_Tat_017_F", 100),
            new BusinessTattooModel(TattooZoneHead, "Flaming Quad", "mpstunt_overlays", "MP_MP_Stunt_Tat_042_M", "MP_MP_Stunt_Tat_042_F", 150),
            new BusinessTattooModel(TattooZoneHead, "Skull", "multiplayer_overlays", "FM_Tat_Award_M_000", "FM_Tat_Award_F_000", 100),

            // Left arm
            new BusinessTattooModel(TattooZoneLeftArm, "$100 Bill", "mpbusiness_overlays", "MP_Buis_M_LeftArm_000", string.Empty, 200),
            new BusinessTattooModel(TattooZoneLeftArm, "All-Seeing Eye", "mpbusiness_overlays", "MP_Buis_M_LeftArm_001", string.Empty, 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Greed is Good", "mpbusiness_overlays", string.Empty, "MP_Buis_F_LArm_000", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Skull Rider", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_000", "MP_Xmas2_F_Tat_000", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "Electric Snake", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_010", "MP_Xmas2_F_Tat_010", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "8 Ball Skull", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_012", "MP_Xmas2_F_Tat_012", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "Time's Up Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_020", "MP_Xmas2_F_Tat_020", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Time's Up Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_021", "MP_Xmas2_F_Tat_021", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Sidearm", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_004_M", "MP_Gunrunning_Tattoo_004_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Bandolier", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_008_M", "MP_Gunrunning_Tattoo_008_F", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Spiked Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_015_M", "MP_Gunrunning_Tattoo_015_F", 400),
            new BusinessTattooModel(TattooZoneLeftArm, "Blood Money", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_016_M", "MP_Gunrunning_Tattoo_016_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Praying Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_025_M", "MP_Gunrunning_Tattoo_025_F", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "Serpent Revolver", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_027_M", "MP_Gunrunning_Tattoo_027_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Diamond Sparkle", "mphipster_overlays", "FM_Hip_M_Tat_003", "FM_Hip_F_Tat_003", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Bricks", "mphipster_overlays", "FM_Hip_M_Tat_007", "FM_Hip_F_Tat_007", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Mustache", "mphipster_overlays", "FM_Hip_M_Tat_015", "FM_Hip_F_Tat_015", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Lightning Bolt", "mphipster_overlays", "FM_Hip_M_Tat_016", "FM_Hip_F_Tat_016", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Pizza", "mphipster_overlays", "FM_Hip_M_Tat_026", "FM_Hip_F_Tat_026", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Padlock", "mphipster_overlays", "FM_Hip_M_Tat_027", "FM_Hip_F_Tat_027", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Thorny Rose", "mphipster_overlays", "FM_Hip_M_Tat_028", "FM_Hip_F_Tat_028", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Stop", "mphipster_overlays", "FM_Hip_M_Tat_034", "FM_Hip_F_Tat_034", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Sunrise", "mphipster_overlays", "FM_Hip_M_Tat_037", "FM_Hip_F_Tat_037", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Sleeve", "mphipster_overlays", "FM_Hip_M_Tat_039", "FM_Hip_F_Tat_039", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Triangle White", "mphipster_overlays", "FM_Hip_M_Tat_043", "FM_Hip_F_Tat_043", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Peace", "mphipster_overlays", "FM_Hip_M_Tat_048", "FM_Hip_F_Tat_048", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Piston Sleeve", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_004_M", "MP_MP_ImportExport_Tat_004_F", 300),
            new BusinessTattooModel(TattooZoneLeftArm, "Scarlett", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_008_M", "MP_MP_ImportExport_Tat_008_F", 350),
            new BusinessTattooModel(TattooZoneLeftArm, "No Evil", "mplowrider_overlays", "MP_LR_Tat_005_M", "MP_LR_Tat_005_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Los Santos Life", "mplowrider_overlays", "MP_LR_Tat_027_M", "MP_LR_Tat_027_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "City Sorrow", "mplowrider_overlays", "MP_LR_Tat_033_M", "MP_LR_Tat_033_F", 300),
            new BusinessTattooModel(TattooZoneLeftArm, "Toxic Trails", "mpairraces_overlays", "MP_Airraces_Tattoo_003_M", "MP_Airraces_Tattoo_003_F", 350),
            new BusinessTattooModel(TattooZoneLeftArm, "Urban Stunter", "mpbiker_overlays", "MP_MP_Biker_Tat_012_M", "MP_MP_Biker_Tat_012_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Macabre Tree", "mpbiker_overlays", "MP_MP_Biker_Tat_016_M", "MP_MP_Biker_Tat_016_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Cranial Rose", "mpbiker_overlays", "MP_MP_Biker_Tat_020_M", "MP_MP_Biker_Tat_020_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Live to Ride", "mpbiker_overlays", "MP_MP_Biker_Tat_024_M", "MP_MP_Biker_Tat_024_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Good Luck", "mpbiker_overlays", "MP_MP_Biker_Tat_025_M", "MP_MP_Biker_Tat_025_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Chain Fist", "mpbiker_overlays", "MP_MP_Biker_Tat_035_M", "MP_MP_Biker_Tat_035_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Ride Hard Die Fast", "mpbiker_overlays", "MP_MP_Biker_Tat_045_M", "MP_MP_Biker_Tat_045_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Muffler Helmet", "mpbiker_overlays", "MP_MP_Biker_Tat_053_M", "MP_MP_Biker_Tat_053_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Poison Scorpion", "mpbiker_overlays", "MP_MP_Biker_Tat_055_M", "MP_MP_Biker_Tat_055_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Love Hustle", "mplowrider2_overlays", "MP_LR_Tat_006_M", "MP_LR_Tat_006_F", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "Skeleton Party", "mplowrider2_overlays", "MP_LR_Tat_018_M", "MP_LR_Tat_018_F", 400),
            new BusinessTattooModel(TattooZoneLeftArm, "My Crazy Life", "mplowrider2_overlays", "MP_LR_Tat_022_M", "MP_LR_Tat_022_F", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "Archangel & Mary", "mpluxe_overlays", "MP_LUXE_TAT_020_M", "MP_LUXE_TAT_020_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Gabriel", "mpluxe_overlays", "MP_LUXE_TAT_021_M", "MP_LUXE_TAT_021_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Fatal Dagger", "mpluxe2_overlays", "MP_LUXE_TAT_005_M", "MP_LUXE_TAT_005_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Egyptian Mural", "mpluxe2_overlays", "MP_LUXE_TAT_016_M", "MP_LUXE_TAT_016_F", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Divine Goddess", "mpluxe2_overlays", "MP_LUXE_TAT_018_M", "MP_LUXE_TAT_018_F", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Python Skull", "mpluxe2_overlays", "MP_LUXE_TAT_028_M", "MP_LUXE_TAT_028_F", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Geometric Design", "mpluxe2_overlays", "MP_LUXE_TAT_031_M", "MP_LUXE_TAT_031_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Honor", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_004_M", "MP_Smuggler_Tattoo_004_F", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Horrors Of The Deep", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_008_M", "MP_Smuggler_Tattoo_008_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Mermaid's Curse", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_014_M", "MP_Smuggler_Tattoo_014_F", 400),
            new BusinessTattooModel(TattooZoneLeftArm, "8 Eyed Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_001_M", "MP_MP_Stunt_Tat_001_F", 300),
            new BusinessTattooModel(TattooZoneLeftArm, "Big Cat", "mpstunt_overlays", "MP_MP_Stunt_Tat_002_M", "MP_MP_Stunt_Tat_002_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Moonlight Ride", "mpstunt_overlays", "MP_MP_Stunt_Tat_008_M", "MP_MP_Stunt_Tat_008_F", 250),
            new BusinessTattooModel(TattooZoneLeftArm, "Piston Head", "mpstunt_overlays", "MP_MP_Stunt_Tat_022_M", "MP_MP_Stunt_Tat_022_F", 300),
            new BusinessTattooModel(TattooZoneLeftArm, "Tanked", "mpstunt_overlays", "MP_MP_Stunt_Tat_023_M", "MP_MP_Stunt_Tat_023_F", 450),
            new BusinessTattooModel(TattooZoneLeftArm, "Stuntman's End", "mpstunt_overlays", "MP_MP_Stunt_Tat_035_M", "MP_MP_Stunt_Tat_035_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Kaboom", "mpstunt_overlays", "MP_MP_Stunt_Tat_039_M", "MP_MP_Stunt_Tat_039_F", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Engine Arm", "mpstunt_overlays", "MP_MP_Stunt_Tat_043_M", "MP_MP_Stunt_Tat_043_F", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Burning Heart", "multiplayer_overlays", "FM_Tat_Award_M_001", "FM_Tat_Award_F_001", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Racing Blonde", "multiplayer_overlays", "FM_Tat_Award_M_007", "FM_Tat_Award_F_007", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Racing Brunette", "multiplayer_overlays", "FM_Tat_Award_M_015", "FM_Tat_Award_F_015", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Serpents", "multiplayer_overlays", "FM_Tat_M_005", "FM_Tat_F_005", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Oriental Mural", "multiplayer_overlays", "FM_Tat_M_006", "FM_Tat_F_006", 150),
            new BusinessTattooModel(TattooZoneLeftArm, "Zodiac Skull", "multiplayer_overlays", "FM_Tat_M_015", "FM_Tat_F_015", 100),
            new BusinessTattooModel(TattooZoneLeftArm, "Lady M", "multiplayer_overlays", "FM_Tat_M_031", "FM_Tat_F_031", 200),
            new BusinessTattooModel(TattooZoneLeftArm, "Dope Skull", "multiplayer_overlays", "FM_Tat_M_041", "FM_Tat_F_041", 100),

            // Right arm
            new BusinessTattooModel(TattooZoneRightArm, "Dollar Skull", "mpbusiness_overlays", "MP_Buis_M_RightArm_000", string.Empty, 150),
            new BusinessTattooModel(TattooZoneRightArm, "Green", "mpbusiness_overlays", "MP_Buis_M_RightArm_001", string.Empty, 150),
            new BusinessTattooModel(TattooZoneRightArm, "Dollar Sign", "mpbusiness_overlays", string.Empty, "MP_Buis_F_RArm_000", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Snake Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_003", "MP_Xmas2_F_Tat_003", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Snake Shaded", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_004", "MP_Xmas2_F_Tat_004", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Death Before Dishonor", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_008", "MP_Xmas2_F_Tat_008", 250),
            new BusinessTattooModel(TattooZoneRightArm, "You're Next Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_022", "MP_Xmas2_F_Tat_022", 200),
            new BusinessTattooModel(TattooZoneRightArm, "You're Next Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_023", "MP_Xmas2_F_Tat_023", 250),
            new BusinessTattooModel(TattooZoneRightArm, "Fuck Luck Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_026", "MP_Xmas2_F_Tat_026", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Fuck Luck Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_027", "MP_Xmas2_F_Tat_027", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Grenade", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_002_M", "MP_Gunrunning_Tattoo_002_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Have a Nice Day", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_021_M", "MP_Gunrunning_Tattoo_021_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Combat Reaper", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_024_M", "MP_Gunrunning_Tattoo_024_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Single Arrow", "mphipster_overlays", "FM_Hip_M_Tat_001", "FM_Hip_F_Tat_001", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Bone", "mphipster_overlays", "FM_Hip_M_Tat_004", "FM_Hip_F_Tat_004", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Cube", "mphipster_overlays", "FM_Hip_M_Tat_008", "FM_Hip_F_Tat_008", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Horseshoe", "mphipster_overlays", "FM_Hip_M_Tat_010", "FM_Hip_F_Tat_010", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Spray Can", "mphipster_overlays", "FM_Hip_M_Tat_014", "FM_Hip_F_Tat_014", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Eye Triangle", "mphipster_overlays", "FM_Hip_M_Tat_017", "FM_Hip_F_Tat_017", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Origami", "mphipster_overlays", "FM_Hip_M_Tat_018", "FM_Hip_F_Tat_018", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Geo Pattern", "mphipster_overlays", "FM_Hip_M_Tat_020", "FM_Hip_F_Tat_020", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Pencil", "mphipster_overlays", "FM_Hip_M_Tat_022", "FM_Hip_F_Tat_022", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Smiley", "mphipster_overlays", "FM_Hip_M_Tat_023", "FM_Hip_F_Tat_023", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Shapes", "mphipster_overlays", "FM_Hip_M_Tat_036", "FM_Hip_F_Tat_036", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Triangle Black", "mphipster_overlays", "FM_Hip_M_Tat_044", "FM_Hip_F_Tat_044", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Mesh Band", "mphipster_overlays", "FM_Hip_M_Tat_045", "FM_Hip_F_Tat_045", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Mechanical Sleeve", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_003_M", "MP_MP_ImportExport_Tat_003_F", 250),
            new BusinessTattooModel(TattooZoneRightArm, "Dialed In", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_005_M", "MP_MP_ImportExport_Tat_005_F", 300),
            new BusinessTattooModel(TattooZoneRightArm, "Engulfed Block", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_006_M", "MP_MP_ImportExport_Tat_006_F", 300),
            new BusinessTattooModel(TattooZoneRightArm, "Drive Forever", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_007_M", "MP_MP_ImportExport_Tat_007_F", 300),
            new BusinessTattooModel(TattooZoneRightArm, "Seductress", "mplowrider_overlays", "MP_LR_Tat_015_M", "MP_LR_Tat_015_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Swooping Eagle", "mpbiker_overlays", "MP_MP_Biker_Tat_007_M", "MP_MP_Biker_Tat_007_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Lady Mortality", "mpbiker_overlays", "MP_MP_Biker_Tat_014_M", "MP_MP_Biker_Tat_014_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Eagle Emblem", "mpbiker_overlays", "MP_MP_Biker_Tat_033_M", "MP_MP_Biker_Tat_033_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Grim Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_042_M", "MP_MP_Biker_Tat_042_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Skull Chain", "mpbiker_overlays", "MP_MP_Biker_Tat_046_M", "MP_MP_Biker_Tat_046_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Snake Bike", "mpbiker_overlays", "MP_MP_Biker_Tat_047_M", "MP_MP_Biker_Tat_047_F", 300),
            new BusinessTattooModel(TattooZoneRightArm, "These Rgbas Don't Run", "mpbiker_overlays", "MP_MP_Biker_Tat_049_M", "MP_MP_Biker_Tat_049_F", 250),
            new BusinessTattooModel(TattooZoneRightArm, "Mum", "mpbiker_overlays", "MP_MP_Biker_Tat_054_M", "MP_MP_Biker_Tat_054_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Lady Vamp", "mplowrider2_overlays", "MP_LR_Tat_003_M", "MP_LR_Tat_003_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Loving Los Muertos", "mplowrider2_overlays", "MP_LR_Tat_028_M", "MP_LR_Tat_028_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Black Tears", "mplowrider2_overlays", "MP_LR_Tat_035_M", "MP_LR_Tat_035_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Floral Raven", "mpluxe_overlays", "MP_LUXE_TAT_004_M", "MP_LUXE_TAT_004_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Mermaid Harpist", "mpluxe_overlays", "MP_LUXE_TAT_013_M", "MP_LUXE_TAT_013_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Geisha Bloom", "mpluxe_overlays", "MP_LUXE_TAT_019_M", "MP_LUXE_TAT_019_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Intrometric", "mpluxe2_overlays", "MP_LUXE_TAT_010_M", "MP_LUXE_TAT_010_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Heavenly Deity", "mpluxe2_overlays", "MP_LUXE_TAT_017_M", "MP_LUXE_TAT_017_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Floral Print", "mpluxe2_overlays", "MP_LUXE_TAT_026_M", "MP_LUXE_TAT_026_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Geometric Design", "mpluxe2_overlays", "MP_LUXE_TAT_030_M", "MP_LUXE_TAT_030_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Crackshot", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_001_M", "MP_Smuggler_Tattoo_001_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Mutiny", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_005_M", "MP_Smuggler_Tattoo_005_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Stylized Kraken", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_023_M", "MP_Smuggler_Tattoo_023_F", 400),
            new BusinessTattooModel(TattooZoneRightArm, "Poison Wrench", "mpstunt_overlays", "MP_MP_Stunt_Tat_003_M", "MP_MP_Stunt_Tat_003_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Arachnid of Death", "mpstunt_overlays", "MP_MP_Stunt_Tat_009_M", "MP_MP_Stunt_Tat_009_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Grave Vulture", "mpstunt_overlays", "MP_MP_Stunt_Tat_010_M", "MP_MP_Stunt_Tat_010_F", 150),
            new BusinessTattooModel(TattooZoneRightArm, "Coffin Racer", "mpstunt_overlays", "MP_MP_Stunt_Tat_016_M", "MP_MP_Stunt_Tat_016_F", 350),
            new BusinessTattooModel(TattooZoneRightArm, "Biker Stallion", "mpstunt_overlays", "MP_MP_Stunt_Tat_036_M", "MP_MP_Stunt_Tat_036_F", 100),
            new BusinessTattooModel(TattooZoneRightArm, "One Down Five Up", "mpstunt_overlays", "MP_MP_Stunt_Tat_038_M", "MP_MP_Stunt_Tat_038_F", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Seductive Mechanic", "mpstunt_overlays", "MP_MP_Stunt_Tat_049_M", "MP_MP_Stunt_Tat_049_F", 400),
            new BusinessTattooModel(TattooZoneRightArm, "Grim Reaper Smoking Gun", "multiplayer_overlays", "FM_Tat_Award_M_002", "FM_Tat_Award_F_002", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Ride or Die", "multiplayer_overlays", "FM_Tat_Award_M_010", "FM_Tat_Award_F_010", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Brotherhood", "multiplayer_overlays", "FM_Tat_M_000", "FM_Tat_F_000", 300),
            new BusinessTattooModel(TattooZoneRightArm, "Dragons", "multiplayer_overlays", "FM_Tat_M_001", "FM_Tat_F_001", 350),
            new BusinessTattooModel(TattooZoneRightArm, "Dragons and Skull", "multiplayer_overlays", "FM_Tat_M_003", "FM_Tat_F_003", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Flower Mural", "multiplayer_overlays", "FM_Tat_M_014", "FM_Tat_F_014", 300),
            new BusinessTattooModel(TattooZoneRightArm, "Serpent Skull", "multiplayer_overlays", "FM_Tat_M_018", "FM_Tat_F_018", 350),
            new BusinessTattooModel(TattooZoneRightArm, "Virgin Mary", "multiplayer_overlays", "FM_Tat_M_027", "FM_Tat_F_027", 300),
            new BusinessTattooModel(TattooZoneRightArm, "Mermaid", "multiplayer_overlays", "FM_Tat_M_028", "FM_Tat_F_028", 200),
            new BusinessTattooModel(TattooZoneRightArm, "Dagger", "multiplayer_overlays", "FM_Tat_M_038", "FM_Tat_F_038", 100),
            new BusinessTattooModel(TattooZoneRightArm, "Lion", "multiplayer_overlays", "FM_Tat_M_047", "FM_Tat_F_047", 100),

            // Left leg
            new BusinessTattooModel(TattooZoneLeftLeg, "Single", "mpbusiness_overlays", string.Empty, "MP_Buis_F_LLeg_000", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Spider Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_001", "MP_Xmas2_F_Tat_001", 300),
            new BusinessTattooModel(TattooZoneLeftLeg, "Spider Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_002", "MP_Xmas2_F_Tat_002", 350),
            new BusinessTattooModel(TattooZoneLeftLeg, "Patriot Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_005_M", "MP_Gunrunning_Tattoo_005_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Stylized Tiger", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_007_M", "MP_Gunrunning_Tattoo_007_F", 100),
            new BusinessTattooModel(TattooZoneLeftLeg, "Death Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_011_M", "MP_Gunrunning_Tattoo_011_F", 400),
            new BusinessTattooModel(TattooZoneLeftLeg, "Rose Revolver", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_023_M", "MP_Gunrunning_Tattoo_023_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Squares", "mphipster_overlays", "FM_Hip_M_Tat_009", "FM_Hip_F_Tat_009", 100),
            new BusinessTattooModel(TattooZoneLeftLeg, "Charm", "mphipster_overlays", "FM_Hip_M_Tat_019", "FM_Hip_F_Tat_019", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Black Anchor", "mphipster_overlays", "FM_Hip_M_Tat_040", "FM_Hip_F_Tat_040", 100),
            new BusinessTattooModel(TattooZoneLeftLeg, "LS Serpent", "mplowrider_overlays", "MP_LR_Tat_007_M", "MP_LR_Tat_007_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Presidents", "mplowrider_overlays", "MP_LR_Tat_020_M", "MP_LR_Tat_020_F", 250),
            new BusinessTattooModel(TattooZoneLeftLeg, "Rose Tribute", "mpbiker_overlays", "MP_MP_Biker_Tat_002_M", "MP_MP_Biker_Tat_002_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Ride or Die", "mpbiker_overlays", "MP_MP_Biker_Tat_015_M", "MP_MP_Biker_Tat_015_F", 100),
            new BusinessTattooModel(TattooZoneLeftLeg, "Bad Luck", "mpbiker_overlays", "MP_MP_Biker_Tat_027_M", "MP_MP_Biker_Tat_027_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Engulfed Skull", "mpbiker_overlays", "MP_MP_Biker_Tat_036_M", "MP_MP_Biker_Tat_036_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Scorched Soul", "mpbiker_overlays", "MP_MP_Biker_Tat_037_M", "MP_MP_Biker_Tat_037_F", 300),
            new BusinessTattooModel(TattooZoneLeftLeg, "Ride Free", "mpbiker_overlays", "MP_MP_Biker_Tat_044_M", "MP_MP_Biker_Tat_044_F", 300),
            new BusinessTattooModel(TattooZoneLeftLeg, "Bone Cruiser", "mpbiker_overlays", "MP_MP_Biker_Tat_056_M", "MP_MP_Biker_Tat_056_F", 300),
            new BusinessTattooModel(TattooZoneLeftLeg, "Laughing Skull", "mpbiker_overlays", "MP_MP_Biker_Tat_057_M", "MP_MP_Biker_Tat_057_F", 400),
            new BusinessTattooModel(TattooZoneLeftLeg, "Death Us Do Part", "mplowrider2_overlays", "MP_LR_Tat_029_M", "MP_LR_Tat_029_F", 300),
            new BusinessTattooModel(TattooZoneLeftLeg, "Serpent of Death", "mpluxe_overlays", "MP_LUXE_TAT_000_M", "MP_LUXE_TAT_000_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Cross of Roses", "mpluxe2_overlays", "MP_LUXE_TAT_011_M", "MP_LUXE_TAT_011_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Dagger Devil", "mpstunt_overlays", "MP_MP_Stunt_Tat_007_M", "MP_MP_Stunt_Tat_007_F", 150),
            new BusinessTattooModel(TattooZoneLeftLeg, "Dirt Track Hero", "mpstunt_overlays", "MP_MP_Stunt_Tat_013_M", "MP_MP_Stunt_Tat_013_F", 250),
            new BusinessTattooModel(TattooZoneLeftLeg, "Golden Cobra", "mpstunt_overlays", "MP_MP_Stunt_Tat_021_M", "MP_MP_Stunt_Tat_021_F", 400),
            new BusinessTattooModel(TattooZoneLeftLeg, "Quad Goblin", "mpstunt_overlays", "MP_MP_Stunt_Tat_028_M", "MP_MP_Stunt_Tat_028_F", 250),
            new BusinessTattooModel(TattooZoneLeftLeg, "Stunt Jesus", "mpstunt_overlays", "MP_MP_Stunt_Tat_031_M", "MP_MP_Stunt_Tat_031_F", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Dragon and Dagger", "multiplayer_overlays", "FM_Tat_Award_M_009", "FM_Tat_Award_F_009", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Melting Skull", "multiplayer_overlays", "FM_Tat_M_002", "FM_Tat_F_002", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Dragon Mural", "multiplayer_overlays", "FM_Tat_M_008", "FM_Tat_F_008", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Serpent Skull", "multiplayer_overlays", "FM_Tat_M_021", "FM_Tat_F_021", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Hottie", "multiplayer_overlays", "FM_Tat_M_023", "FM_Tat_F_023", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Smoking Dagger", "multiplayer_overlays", "FM_Tat_M_026", "FM_Tat_F_026", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Faith", "multiplayer_overlays", "FM_Tat_M_032", "FM_Tat_F_032", 200),
            new BusinessTattooModel(TattooZoneLeftLeg, "Chinese Dragon", "multiplayer_overlays", "FM_Tat_M_033", "FM_Tat_F_033", 300),
            new BusinessTattooModel(TattooZoneLeftLeg, "Dragon", "multiplayer_overlays", "FM_Tat_M_035", "FM_Tat_F_035", 250),
            new BusinessTattooModel(TattooZoneLeftLeg, "Grim Reaper", "multiplayer_overlays", "FM_Tat_M_037", "FM_Tat_F_037", 200),
            
            // Right leg
            new BusinessTattooModel(TattooZoneRightLeg, "Diamond Crown", "mpbusiness_overlays", string.Empty, "MP_Buis_F_RLeg_000", 100),
            new BusinessTattooModel(TattooZoneRightLeg, "Floral Dagger", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_014", "MP_Xmas2_F_Tat_014", 250),
            new BusinessTattooModel(TattooZoneRightLeg, "Combat Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_006_M", "MP_Gunrunning_Tattoo_006_F", 150),
            new BusinessTattooModel(TattooZoneRightLeg, "Restless Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_026_M", "MP_Gunrunning_Tattoo_026_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Pistol Ace", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_030_M", "MP_Gunrunning_Tattoo_030_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Grub", "mphipster_overlays", "FM_Hip_M_Tat_038", "FM_Hip_F_Tat_038", 100),
            new BusinessTattooModel(TattooZoneRightLeg, "Sparkplug", "mphipster_overlays", "FM_Hip_M_Tat_042", "FM_Hip_F_Tat_042", 100),
            new BusinessTattooModel(TattooZoneRightLeg, "Ink Me", "mplowrider_overlays", "MP_LR_Tat_017_M", "MP_LR_Tat_017_F", 150),
            new BusinessTattooModel(TattooZoneRightLeg, "Dance of Hearts", "mplowrider_overlays", "MP_LR_Tat_023_M", "MP_LR_Tat_023_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Dragon's Fury", "mpbiker_overlays", "MP_MP_Biker_Tat_004_M", "MP_MP_Biker_Tat_004_F", 400),
            new BusinessTattooModel(TattooZoneRightLeg, "Western Insignia", "mpbiker_overlays", "MP_MP_Biker_Tat_022_M", "MP_MP_Biker_Tat_022_F", 150),
            new BusinessTattooModel(TattooZoneRightLeg, "Dusk Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_028_M", "MP_MP_Biker_Tat_028_F", 150),
            new BusinessTattooModel(TattooZoneRightLeg, "American Made", "mpbiker_overlays", "MP_MP_Biker_Tat_040_M", "MP_MP_Biker_Tat_040_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "STFU", "mpbiker_overlays", "MP_MP_Biker_Tat_048_M", "MP_MP_Biker_Tat_048_F", 250),
            new BusinessTattooModel(TattooZoneRightLeg, "San Andreas Prayer", "mplowrider2_overlays", "MP_LR_Tat_030_M", "MP_LR_Tat_030_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Elaborate Los Muertos", "mpluxe_overlays", "MP_LUXE_TAT_001_M", "MP_LUXE_TAT_001_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Starmetric", "mpluxe2_overlays", "MP_LUXE_TAT_023_M", "MP_LUXE_TAT_023_F", 300),
            new BusinessTattooModel(TattooZoneRightLeg, "Homeward Bound", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_020_M", "MP_Smuggler_Tattoo_020_F", 400),
            new BusinessTattooModel(TattooZoneRightLeg, "Demon Spark Plug", "mpstunt_overlays", "MP_MP_Stunt_Tat_005_M", "MP_MP_Stunt_Tat_005_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Praying Gloves", "mpstunt_overlays", "MP_MP_Stunt_Tat_015_M", "MP_MP_Stunt_Tat_015_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Piston Angel", "mpstunt_overlays", "MP_MP_Stunt_Tat_020_M", "MP_MP_Stunt_Tat_020_F", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Speed Freak", "mpstunt_overlays", "MP_MP_Stunt_Tat_025_M", "MP_MP_Stunt_Tat_025_F", 150),
            new BusinessTattooModel(TattooZoneRightLeg, "Wheelie Mouse", "mpstunt_overlays", "MP_MP_Stunt_Tat_032_M", "MP_MP_Stunt_Tat_032_F", 250),
            new BusinessTattooModel(TattooZoneRightLeg, "Severed Hand", "mpstunt_overlays", "MP_MP_Stunt_Tat_045_M", "MP_MP_Stunt_Tat_045_F", 400),
            new BusinessTattooModel(TattooZoneRightLeg, "Brake Knife", "mpstunt_overlays", "MP_MP_Stunt_Tat_047_M", "MP_MP_Stunt_Tat_047_F", 250),
            new BusinessTattooModel(TattooZoneRightLeg, "Skull and Sword", "multiplayer_overlays", "FM_Tat_Award_M_006", "FM_Tat_Award_F_006", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "The Warrior", "multiplayer_overlays", "FM_Tat_M_007", "FM_Tat_F_007", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Tribal", "multiplayer_overlays", "FM_Tat_M_017", "FM_Tat_F_017", 250),
            new BusinessTattooModel(TattooZoneRightLeg, "Fiery Dragon", "multiplayer_overlays", "FM_Tat_M_022", "FM_Tat_F_022", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Broken Skull", "multiplayer_overlays", "FM_Tat_M_039", "FM_Tat_F_039", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Flaming Skull", "multiplayer_overlays", "FM_Tat_M_040", "FM_Tat_F_040", 300),
            new BusinessTattooModel(TattooZoneRightLeg, "Flaming Scorpion", "multiplayer_overlays", "FM_Tat_M_042", "FM_Tat_F_042", 200),
            new BusinessTattooModel(TattooZoneRightLeg, "Indian Ram", "multiplayer_overlays", "FM_Tat_M_043", "FM_Tat_F_043", 200)
        };

        // Car dealer's IVehicles
        public static List<CarShopVehicleModel> CarshopVehicleList = new List<CarShopVehicleModel>
        {
            // Compacts
            new CarShopVehicleModel("Blista", VehicleModel.Blista, 0, VehicleClassCompacts, 34750),
            //new CarShopVehicleModel("Brioso", AltV.Net.Enums.VehicleModel.Brioso, 0, VEHICLE_CLASS_COMPACTS, 15000),
            new CarShopVehicleModel("Dilettante", VehicleModel.Dilettante, 0, VehicleClassCompacts, 21430),
            new CarShopVehicleModel("Issi2", VehicleModel.Issi2, 0, VehicleClassCompacts, 21750),
            new CarShopVehicleModel("Panto", VehicleModel.Panto, 0, VehicleClassCompacts, 39810),
            new CarShopVehicleModel("Prairie", VehicleModel.Prairie, 0, VehicleClassCompacts, 69540),
            new CarShopVehicleModel("Rhapsody", VehicleModel.Rhapsody, 0, VehicleClassCompacts, 29850),

            // Coupes
            new CarShopVehicleModel("CogCabrio", VehicleModel.CogCabrio, 0, VehicleClassCoupes, 78750),
            new CarShopVehicleModel("Exemplar", VehicleModel.Exemplar, 0, VehicleClassCoupes, 65000),
            new CarShopVehicleModel("F620", VehicleModel.F620, 0, VehicleClassCoupes, 86320),
            new CarShopVehicleModel("Felon", VehicleModel.Felon, 0, VehicleClassCoupes, 91540),
            new CarShopVehicleModel("Felon2", VehicleModel.Felon2, 0, VehicleClassCoupes, 90140),
            //new CarShopVehicleModel("Jackal", AltV.Net.Enums.VehicleModel.Jackal, 0, VEHICLE_CLASS_COUPES, 43200),
            //new CarShopVehicleModel("Oracle", AltV.Net.Enums.VehicleModel.Oracle, 0, VEHICLE_CLASS_COUPES, 28000),
            new CarShopVehicleModel("Oracle2", VehicleModel.Oracle2, 0, VehicleClassCoupes, 85000),
            new CarShopVehicleModel("Sentinel", VehicleModel.Sentinel, 0, VehicleClassCoupes, 76550),
            new CarShopVehicleModel("Sentinel2", VehicleModel.Sentinel2, 0, VehicleClassCoupes, 83540),
            //new CarShopVehicleModel("Windsor", AltV.Net.Enums.VehicleModel.Windsor, 0, VEHICLE_CLASS_COUPES, 55000),
            //new CarShopVehicleModel("Windsor2", AltV.Net.Enums.VehicleModel.Windsor2, 0, VEHICLE_CLASS_COUPES, 63000),
            new CarShopVehicleModel("Zion", VehicleModel.Zion, 0, VehicleClassCoupes, 69550),
            new CarShopVehicleModel("Zion2", VehicleModel.Zion2, 0, VehicleClassCoupes, 76540),

            // Muscle
            //new CarShopVehicleModel("Blade", AltV.Net.Enums.VehicleModel.Blade, 0, VEHICLE_CLASS_MUSCLE, 8000),
            new CarShopVehicleModel("Buccaneer", VehicleModel.Buccaneer, 0, VehicleClassMuscle, 90750),
            new CarShopVehicleModel("Buccaneer2", VehicleModel.Buccaneer2, 0, VehicleClassMuscle, 110740),
            new CarShopVehicleModel("Chino", VehicleModel.Chino, 0, VehicleClassMuscle, 135000),
            new CarShopVehicleModel("Chino2", VehicleModel.Chino2, 0, VehicleClassMuscle, 137500),
            new CarShopVehicleModel("Dominator", VehicleModel.Dominator, 0, VehicleClassMuscle, 175000),
            new CarShopVehicleModel("Dukes", VehicleModel.Dukes, 0, VehicleClassMuscle, 145400),
            new CarShopVehicleModel("Faction", VehicleModel.Faction, 0, VehicleClassMuscle, 55780),
            new CarShopVehicleModel("Faction2", VehicleModel.Faction2, 0, VehicleClassMuscle, 146950),
            new CarShopVehicleModel("Gauntlet", VehicleModel.Gauntlet, 0, VehicleClassMuscle, 175000),
            new CarShopVehicleModel("Moonbeam", VehicleModel.Moonbeam, 0, VehicleClassMuscle, 67950),
            new CarShopVehicleModel("Phoenix", VehicleModel.Phoenix, 0, VehicleClassMuscle, 20900),
            new CarShopVehicleModel("Picador", VehicleModel.Picador, 0, VehicleClassMuscle, 23000),
            new CarShopVehicleModel("Ruiner", VehicleModel.Ruiner, 0, VehicleClassMuscle, 64950),
            new CarShopVehicleModel("SabreGT", VehicleModel.SabreGt, 0, VehicleClassMuscle, 89620),
            new CarShopVehicleModel("Stalion", VehicleModel.Stalion, 0, VehicleClassMuscle, 75320),
            new CarShopVehicleModel("Tampa", VehicleModel.Tampa, 0, VehicleClassMuscle, 75000),
            new CarShopVehicleModel("Vigero", VehicleModel.Vigero, 0, VehicleClassMuscle, 100600),
            new CarShopVehicleModel("Voodoo", VehicleModel.Voodoo, 0, VehicleClassMuscle, 49750),
            new CarShopVehicleModel("Voodoo2", VehicleModel.Voodoo2, 0, VehicleClassMuscle, 45000),

            // Off-Road
            new CarShopVehicleModel("Bifta", VehicleModel.Bifta, 0, VehicleClassOffroad, 67950),
            //new CarShopVehicleModel("Sandking", AltV.Net.Enums.VehicleModel.Sandking, 0, VEHICLE_CLASS_OFFROAD, 21000),

            // SUVs
            new CarShopVehicleModel("Baller", VehicleModel.Baller, 0, VehicleClassSuvs, 45000),
            new CarShopVehicleModel("Baller2", VehicleModel.Baller2, 0, VehicleClassSuvs, 49000),
            new CarShopVehicleModel("Baller3", VehicleModel.Baller3, 0, VehicleClassSuvs, 41000),
            new CarShopVehicleModel("Cavalcade", VehicleModel.Cavalcade, 0, VehicleClassSuvs, 56200),
            new CarShopVehicleModel("Cavalcade2", VehicleModel.Cavalcade2, 0, VehicleClassSuvs, 45900),
            new CarShopVehicleModel("Contender", VehicleModel.Contender, 0, VehicleClassSuvs, 43200),
            new CarShopVehicleModel("Dubsta", VehicleModel.Dubsta, 0, VehicleClassSuvs, 85400),
            new CarShopVehicleModel("Dubsta2", VehicleModel.Dubsta2, 0, VehicleClassSuvs, 95400),
            new CarShopVehicleModel("FQ2", VehicleModel.Fq2, 0, VehicleClassSuvs, 120000),
            new CarShopVehicleModel("Gresley", VehicleModel.Gresley, 0, VehicleClassSuvs, 95000),
            new CarShopVehicleModel("Habanero", VehicleModel.Habanero, 0, VehicleClassSuvs, 39000),
            new CarShopVehicleModel("Huntley", VehicleModel.Huntley, 0, VehicleClassSuvs, 43100),
            new CarShopVehicleModel("Landstalker", VehicleModel.Landstalker, 0, VehicleClassSuvs, 35000),
            new CarShopVehicleModel("Patriot", VehicleModel.Patriot, 0, VehicleClassSuvs, 78500),
            new CarShopVehicleModel("Radi", VehicleModel.Radi, 0, VehicleClassSuvs, 32000),
            new CarShopVehicleModel("Rocoto", VehicleModel.Rocoto, 0, VehicleClassSuvs, 150000),
            new CarShopVehicleModel("Seminole", VehicleModel.Seminole, 0, VehicleClassSuvs, 85750),
            new CarShopVehicleModel("Serrano", VehicleModel.Serrano, 0, VehicleClassSuvs, 49750),
            new CarShopVehicleModel("XLS", VehicleModel.Xls, 0, VehicleClassSuvs, 112650),
           //new CarShopVehicleModel("Rumpo", AltV.Net.Enums.VehicleModel.Rumpo, 0, VEHICLE_CLASS_SUVS, 65000),

            // Sedans
            new CarShopVehicleModel("Asea", VehicleModel.Asea, 0, VehicleClassSedans, 6750),
            new CarShopVehicleModel("Asterope", VehicleModel.Asterope, 0, VehicleClassSedans, 7000),
            new CarShopVehicleModel("Emperor", VehicleModel.Emperor, 0, VehicleClassSedans, 7500),
            new CarShopVehicleModel("Fugitive", VehicleModel.Fugitive, 0, VehicleClassSedans, 19800),
            new CarShopVehicleModel("Ingot", VehicleModel.Ingot, 0, VehicleClassSedans, 11500),
            new CarShopVehicleModel("Intruder", VehicleModel.Intruder, 0, VehicleClassSedans, 14000),
            new CarShopVehicleModel("Premier", VehicleModel.Premier, 0, VehicleClassSedans, 16500),
            new CarShopVehicleModel("Primo", VehicleModel.Primo, 0, VehicleClassSedans, 19850),
            new CarShopVehicleModel("Regina", VehicleModel.Regina, 0, VehicleClassSedans, 18500),
            new CarShopVehicleModel("Stanier", VehicleModel.Stanier, 0, VehicleClassSedans, 26500),
            new CarShopVehicleModel("Washington", VehicleModel.Washington, 0, VehicleClassSedans, 25000),
            new CarShopVehicleModel("Stratum", VehicleModel.Stratum, 0, VehicleClassSedans, 32000),
            //new CarShopVehicleModel("Stretch", AltV.Net.Enums.VehicleModel.Stretch, 0, VEHICLE_CLASS_SEDANS, 1250000),

            // Sports
            new CarShopVehicleModel("Alpha", VehicleModel.Alpha, 0, VehicleClassSports, 195000),
            new CarShopVehicleModel("Banshee", VehicleModel.Banshee, 0, VehicleClassSports, 305450),
            new CarShopVehicleModel("BestiaGTS", VehicleModel.Bestiagts, 0, VehicleClassSports, 270000),
            new CarShopVehicleModel("Buffalo", VehicleModel.Buffalo, 0, VehicleClassSports, 340000),
            new CarShopVehicleModel("Blista2", VehicleModel.Blista2, 0, VehicleClassSports, 175300),
            new CarShopVehicleModel("Carbonizzare", VehicleModel.Carbonizzare, 0, VehicleClassSports, 375500),
            new CarShopVehicleModel("Comet2", VehicleModel.Comet2, 0, VehicleClassSports, 325000),
            new CarShopVehicleModel("Elegy", VehicleModel.Elegy, 0, VehicleClassSports, 310000),
            new CarShopVehicleModel("Elegy2", VehicleModel.Elegy2, 0, VehicleClassSports, 365000),
            new CarShopVehicleModel("Feltzer2", VehicleModel.Feltzer2, 0, VehicleClassSports, 395000),
            new CarShopVehicleModel("Furoregt", VehicleModel.Furoregt, 0, VehicleClassSports, 485000),
            new CarShopVehicleModel("Fusilade", VehicleModel.Fusilade, 0, VehicleClassSports, 300000),
            new CarShopVehicleModel("Jester", VehicleModel.Jester, 0, VehicleClassSports, 365000),
            new CarShopVehicleModel("Khamelion", VehicleModel.Khamelion, 0, VehicleClassSports, 330000),
            new CarShopVehicleModel("Kuruma", VehicleModel.Kuruma, 0, VehicleClassSports, 575000),
            new CarShopVehicleModel("Lynx", VehicleModel.Lynx, 0, VehicleClassSports, 395000),
            new CarShopVehicleModel("Massacro", VehicleModel.Massacro, 0, VehicleClassSports, 535000),
            new CarShopVehicleModel("Ninef2", VehicleModel.Ninef2, 0, VehicleClassSports, 450000),
            new CarShopVehicleModel("Penumbra", VehicleModel.Penumbra, 0, VehicleClassSports, 475000),
            new CarShopVehicleModel("RapidGT2", VehicleModel.RapidGt2, 0, VehicleClassSports, 465000),
            new CarShopVehicleModel("Schafter2", VehicleModel.Schafter2, 0, VehicleClassSports, 120000),
            new CarShopVehicleModel("Schafter3", VehicleModel.Schafter3, 0, VehicleClassSports, 265000),
            new CarShopVehicleModel("Schwarzer", VehicleModel.Schwarzer, 0, VehicleClassSports, 265000),
            new CarShopVehicleModel("Seven70", VehicleModel.Seven70, 0, VehicleClassSports, 450000),
            new CarShopVehicleModel("Sultan", VehicleModel.Sultan, 0, VehicleClassSports, 220000),
            new CarShopVehicleModel("Surano", VehicleModel.Surano, 0, VehicleClassSports, 465000),
            new CarShopVehicleModel("SultanRS", VehicleModel.SultanRs, 0, VehicleClassSports, 195000),
            
            // Classic sports
            new CarShopVehicleModel("Infernus", VehicleModel.Infernus, 0, VehicleClassSports, 390000)

		    // Super sports
            /*
            new CarShopVehicleModel("Cyclone", AltV.Net.Enums.VehicleModel.Cyclone, 0, VEHICLE_CLASS_SPORTS, 375000),
            new CarShopVehicleModel("Voltic", AltV.Net.Enums.VehicleModel.Voltic, 0, VEHICLE_CLASS_SPORTS, 132000),
            new CarShopVehicleModel("GP1", AltV.Net.Enums.VehicleModel.GP1, 0, VEHICLE_CLASS_SPORTS, 245000),
            new CarShopVehicleModel("Infernus", AltV.Net.Enums.VehicleModel.Infernus, 0, VEHICLE_CLASS_SPORTS, 135000),
            new CarShopVehicleModel("Bullet", AltV.Net.Enums.VehicleModel.Bullet, 0, VEHICLE_CLASS_SPORTS, 140000),
            new CarShopVehicleModel("Italigtb2", AltV.Net.Enums.VehicleModel.ItaliGTB2, 0, VEHICLE_CLASS_SPORTS, 355000),
            new CarShopVehicleModel("Italigtb", AltV.Net.Enums.VehicleModel.ItaliGTB, 0, VEHICLE_CLASS_SPORTS, 330000),
            new CarShopVehicleModel("Zentorno", AltV.Net.Enums.VehicleModel.Zentorno, 0, VEHICLE_CLASS_SPORTS, 295000),
            new CarShopVehicleModel("Visione", AltV.Net.Enums.VehicleModel.Visione, 0, VEHICLE_CLASS_SPORTS, 390000),
            new CarShopVehicleModel("Vagner", AltV.Net.Enums.VehicleModel.Vagner, 0, VEHICLE_CLASS_SPORTS, 395000),
            new CarShopVehicleModel("Vacca", AltV.Net.Enums.VehicleModel.Vacca, 0, VEHICLE_CLASS_SPORTS, 198000),
            new CarShopVehicleModel("Turismor", AltV.Net.Enums.VehicleModel.Turismor, 0, VEHICLE_CLASS_SPORTS, 270000),
            new CarShopVehicleModel("Turismo2", AltV.Net.Enums.VehicleModel.Turismo2, 0, VEHICLE_CLASS_SPORTS, 260000),
            new CarShopVehicleModel("Tempesta", AltV.Net.Enums.VehicleModel.Tempesta, 0, VEHICLE_CLASS_SPORTS, 340000),
            new CarShopVehicleModel("T20", AltV.Net.Enums.VehicleModel.T20, 0, VEHICLE_CLASS_SPORTS, 385000),
            new CarShopVehicleModel("Reaper", AltV.Net.Enums.VehicleModel.Reaper, 0, VEHICLE_CLASS_SPORTS, 337000),
            new CarShopVehicleModel("Prototipo", AltV.Net.Enums.VehicleModel.Prototipo, 0, VEHICLE_CLASS_SPORTS, 400000),
            new CarShopVehicleModel("Pfister811", AltV.Net.Enums.VehicleModel.Pfister811, 0, VEHICLE_CLASS_SPORTS, 335000),
            new CarShopVehicleModel("Penetrator", AltV.Net.Enums.VehicleModel.Penetrator, 0, VEHICLE_CLASS_SPORTS, 192000),
            new CarShopVehicleModel("Osiris", AltV.Net.Enums.VehicleModel.Osiris, 0, VEHICLE_CLASS_SPORTS, 341000),
            new CarShopVehicleModel("Nero2", AltV.Net.Enums.VehicleModel.Nero2, 0, VEHICLE_CLASS_SPORTS, 392000),
            new CarShopVehicleModel("Nero", AltV.Net.Enums.VehicleModel.Nero, 0, VEHICLE_CLASS_SPORTS, 380000),
            new CarShopVehicleModel("XA21", AltV.Net.Enums.VehicleModel.XA21, 0, VEHICLE_CLASS_SPORTS, 389000),
            new CarShopVehicleModel("FMJ", AltV.Net.Enums.VehicleModel.FMJ, 0, VEHICLE_CLASS_SPORTS, 347000),
            new CarShopVehicleModel("EntityXF", AltV.Net.Enums.VehicleModelXF, 0, VEHICLE_CLASS_SPORTS, 325000),
            new CarShopVehicleModel("Cheetah", AltV.Net.Enums.VehicleModel.Cheetah, 0, VEHICLE_CLASS_SPORTS, 260000),
            new CarShopVehicleModel("Adder", AltV.Net.Enums.VehicleModel.Adder, 0, VEHICLE_CLASS_SPORTS, 310000),
            new CarShopVehicleModel("Sheava", AltV.Net.Enums.VehicleModel.Sheava, 0, VEHICLE_CLASS_SPORTS, 368000),
            */
            /*
            // Motorcycles
            new CarShopVehicleModel("Akuma", AltV.Net.Enums.VehicleModel.Akuma, 1, VEHICLE_CLASS_MOTORCYCLES, 85000),
            new CarShopVehicleModel("Avarus", AltV.Net.Enums.VehicleModel.Avarus, 1, VEHICLE_CLASS_MOTORCYCLES, 75000),
            new CarShopVehicleModel("Bagger", AltV.Net.Enums.VehicleModel.Bagger, 1, VEHICLE_CLASS_MOTORCYCLES, 25000),
            new CarShopVehicleModel("Bati", AltV.Net.Enums.VehicleModel.Bati, 1, VEHICLE_CLASS_MOTORCYCLES, 67000),
            new CarShopVehicleModel("Bati2", AltV.Net.Enums.VehicleModel.Bati2, 1, VEHICLE_CLASS_MOTORCYCLES, 70000),
            new CarShopVehicleModel("BF400", AltV.Net.Enums.VehicleModel.BF400, 1, VEHICLE_CLASS_MOTORCYCLES, 47000),
            new CarShopVehicleModel("Blazer4", AltV.Net.Enums.VehicleModel.Blazer4, 1, VEHICLE_CLASS_MOTORCYCLES, 27000),
            new CarShopVehicleModel("CarbonRS", AltV.Net.Enums.VehicleModel.CarbonRS, 1, VEHICLE_CLASS_MOTORCYCLES, 56000),
            new CarShopVehicleModel("Chimera", AltV.Net.Enums.VehicleModel.Chimera, 1, VEHICLE_CLASS_MOTORCYCLES, 41800),
            new CarShopVehicleModel("Cliffhanger", AltV.Net.Enums.VehicleModel.Cliffhanger, 1, VEHICLE_CLASS_MOTORCYCLES, 28000),
            new CarShopVehicleModel("Daemon", AltV.Net.Enums.VehicleModel.Daemon, 1, VEHICLE_CLASS_MOTORCYCLES, 10000),
            new CarShopVehicleModel("Daemon2", AltV.Net.Enums.VehicleModel.Daemon2, 1, VEHICLE_CLASS_MOTORCYCLES, 12500),
            new CarShopVehicleModel("Defiler", AltV.Net.Enums.VehicleModel.Defiler, 1, VEHICLE_CLASS_MOTORCYCLES, 61900),
            new CarShopVehicleModel("Double", AltV.Net.Enums.VehicleModel.Double, 1, VEHICLE_CLASS_MOTORCYCLES, 58000),
            new CarShopVehicleModel("Enduro", AltV.Net.Enums.VehicleModel.Enduro, 1, VEHICLE_CLASS_MOTORCYCLES, 7000),
            new CarShopVehicleModel("Esskey", AltV.Net.Enums.VehicleModel.Esskey, 1, VEHICLE_CLASS_MOTORCYCLES, 22400),
            new CarShopVehicleModel("Faggio", AltV.Net.Enums.VehicleModel.Faggio, 1, VEHICLE_CLASS_MOTORCYCLES, 2100),
            new CarShopVehicleModel("Faggio2", AltV.Net.Enums.VehicleModel.Faggio2, 1, VEHICLE_CLASS_MOTORCYCLES, 1500),
            new CarShopVehicleModel("Faggio3", AltV.Net.Enums.VehicleModel.Faggio3, 1, VEHICLE_CLASS_MOTORCYCLES, 2000),
            new CarShopVehicleModel("Fcr", AltV.Net.Enums.VehicleModel.FCR, 1, VEHICLE_CLASS_MOTORCYCLES, 27000),
            new CarShopVehicleModel("Fcr2", AltV.Net.Enums.VehicleModel.FCR2, 1, VEHICLE_CLASS_MOTORCYCLES, 32000),
            new CarShopVehicleModel("Gargoyle", AltV.Net.Enums.VehicleModel.Gargoyle, 1, VEHICLE_CLASS_MOTORCYCLES, 46700),
            new CarShopVehicleModel("Hakuchou", AltV.Net.Enums.VehicleModel.Hakuchou, 1, VEHICLE_CLASS_MOTORCYCLES, 72000),
            new CarShopVehicleModel("Hakuchou2", AltV.Net.Enums.VehicleModel.Hakuchou2, 1, VEHICLE_CLASS_MOTORCYCLES, 100000),
            new CarShopVehicleModel("Hexer", AltV.Net.Enums.VehicleModel.Hexer, 1, VEHICLE_CLASS_MOTORCYCLES, 12500),
            new CarShopVehicleModel("Innovation", AltV.Net.Enums.VehicleModel.Innovation, 1, VEHICLE_CLASS_MOTORCYCLES, 16000),
            new CarShopVehicleModel("Lectro", AltV.Net.Enums.VehicleModel.Lectro, 1, VEHICLE_CLASS_MOTORCYCLES, 31800),
            new CarShopVehicleModel("Manchez", AltV.Net.Enums.VehicleModel.Manchez, 1, VEHICLE_CLASS_MOTORCYCLES, 19000),
            new CarShopVehicleModel("Nemesis", AltV.Net.Enums.VehicleModel.Nemesis, 1, VEHICLE_CLASS_MOTORCYCLES, 29700),
            new CarShopVehicleModel("Nightblade", AltV.Net.Enums.VehicleModel.Nightblade, 1, VEHICLE_CLASS_MOTORCYCLES, 35700),
            new CarShopVehicleModel("PCJ", AltV.Net.Enums.VehicleModel.PCJ, 1, VEHICLE_CLASS_MOTORCYCLES, 33000),
            new CarShopVehicleModel("Ratbike", AltV.Net.Enums.VehicleModel.RatBike, 1, VEHICLE_CLASS_MOTORCYCLES, 2500),
            new CarShopVehicleModel("Ruffian", AltV.Net.Enums.VehicleModel.Ruffian, 1, VEHICLE_CLASS_MOTORCYCLES, 32300),
            new CarShopVehicleModel("Sanchez", AltV.Net.Enums.VehicleModel.Sanchez, 1, VEHICLE_CLASS_MOTORCYCLES, 13100),
            new CarShopVehicleModel("Sanchez2", AltV.Net.Enums.VehicleModel.Sanchez2, 1, VEHICLE_CLASS_MOTORCYCLES, 23000),
            new CarShopVehicleModel("Sanctus", AltV.Net.Enums.VehicleModel.Sanctus, 1, VEHICLE_CLASS_MOTORCYCLES, 95000),
            new CarShopVehicleModel("Sovereign", AltV.Net.Enums.VehicleModel.Sovereign, 1, VEHICLE_CLASS_MOTORCYCLES, 42300),
            new CarShopVehicleModel("Thrust", AltV.Net.Enums.VehicleModel.Thrust, 1, VEHICLE_CLASS_MOTORCYCLES, 24500),
            new CarShopVehicleModel("Vader", AltV.Net.Enums.VehicleModel.Vader, 1, VEHICLE_CLASS_MOTORCYCLES, 28100),
            new CarShopVehicleModel("Vindicator", AltV.Net.Enums.VehicleModel.Vindicator, 1, VEHICLE_CLASS_MOTORCYCLES, 39000),
            new CarShopVehicleModel("Vortex", AltV.Net.Enums.VehicleModel.Vortex, 1, VEHICLE_CLASS_MOTORCYCLES, 65560),
            new CarShopVehicleModel("Wolfsbane", AltV.Net.Enums.VehicleModel.Wolfsbane, 1, VEHICLE_CLASS_MOTORCYCLES, 27600),
            new CarShopVehicleModel("Zombiea", AltV.Net.Enums.VehicleModel.ZombieA, 1, VEHICLE_CLASS_MOTORCYCLES, 24900),
            new CarShopVehicleModel("Zombieb", AltV.Net.Enums.VehicleModel.ZombieB, 1, VEHICLE_CLASS_MOTORCYCLES, 26100),
            new CarShopVehicleModel("Bmx", AltV.Net.Enums.VehicleModel.Bmx, 1, VEHICLE_CLASS_MOTORCYCLES, 600),
            new CarShopVehicleModel("Cruiser", AltV.Net.Enums.VehicleModel.Cruiser, 1, VEHICLE_CLASS_MOTORCYCLES, 350),
            new CarShopVehicleModel("Fixter", AltV.Net.Enums.VehicleModel.Fixter, 1, VEHICLE_CLASS_MOTORCYCLES, 620),
            new CarShopVehicleModel("Scorcher", AltV.Net.Enums.VehicleModel.Scorcher, 1, VEHICLE_CLASS_MOTORCYCLES, 500),
            new CarShopVehicleModel("TriBike", AltV.Net.Enums.VehicleModel.TriBike, 1, VEHICLE_CLASS_MOTORCYCLES, 900),
            new CarShopVehicleModel("Diablous", AltV.Net.Enums.VehicleModel.Diablous, 1, VEHICLE_CLASS_MOTORCYCLES, 45000),
            new CarShopVehicleModel("Diablous2", AltV.Net.Enums.VehicleModel.Diablous2, 1, VEHICLE_CLASS_MOTORCYCLES, 40000),

            // Boats
            new CarShopVehicleModel("Dinghy", AltV.Net.Enums.VehicleModel.Dinghy, 2, VEHICLE_CLASS_BOATS, 25000),
            new CarShopVehicleModel("Dinghy2", AltV.Net.Enums.VehicleModel.Dinghy2, 2, VEHICLE_CLASS_BOATS, 32000),
            new CarShopVehicleModel("Dinghy3", AltV.Net.Enums.VehicleModel.Dinghy3, 2, VEHICLE_CLASS_BOATS, 40000),
            new CarShopVehicleModel("Dinghy4", AltV.Net.Enums.VehicleModel.Dinghy4, 2, VEHICLE_CLASS_BOATS, 55000),
            new CarShopVehicleModel("Jetmax", AltV.Net.Enums.VehicleModel.Jetmax, 2, VEHICLE_CLASS_BOATS, 80000),
            new CarShopVehicleModel("Marquis", AltV.Net.Enums.VehicleModel.Marquis, 2, VEHICLE_CLASS_BOATS, 60000),
            new CarShopVehicleModel("Seashark", AltV.Net.Enums.VehicleModel.Seashark, 2, VEHICLE_CLASS_BOATS, 15000),
            new CarShopVehicleModel("Seashark3", AltV.Net.Enums.VehicleModel.Seashark3, 2, VEHICLE_CLASS_BOATS, 35000),
            new CarShopVehicleModel("Speeder", AltV.Net.Enums.VehicleModel.Speeder, 2, VEHICLE_CLASS_BOATS, 72500),
            new CarShopVehicleModel("Speeder2", AltV.Net.Enums.VehicleModel.Speeder2, 2, VEHICLE_CLASS_BOATS, 90000),
            new CarShopVehicleModel("Suntrap", AltV.Net.Enums.VehicleModel.Suntrap, 2, VEHICLE_CLASS_BOATS, 30000),
            new CarShopVehicleModel("Squalo", AltV.Net.Enums.VehicleModel.Squalo, 2, VEHICLE_CLASS_BOATS, 55000),
            new CarShopVehicleModel("Toro", AltV.Net.Enums.VehicleModel.Toro, 2, VEHICLE_CLASS_BOATS, 90000),
            new CarShopVehicleModel("Toro2", AltV.Net.Enums.VehicleModel.Toro2, 2, VEHICLE_CLASS_BOATS, 120000),
            new CarShopVehicleModel("Tropic", AltV.Net.Enums.VehicleModel.Tropic, 2, VEHICLE_CLASS_BOATS, 50000),
            new CarShopVehicleModel("Tropic2", AltV.Net.Enums.VehicleModel.Tropic2, 2, VEHICLE_CLASS_BOATS, 60000),
            new CarShopVehicleModel("Tug", AltV.Net.Enums.VehicleModel.Tug, 2, VEHICLE_CLASS_BOATS, 175000)
            */
        };

        // IVehicle's doors
        public const int DriverFrontDoor = 0;
        public const int PassengerFrontDoor = 1;
        public const int DriverRearDoor = 2;
        public const int PassengerRearDoor = 3;
        public const int VehicleHood = 4;
        public const int VehicleTrunk = 5;

        public static List<Position> CarshopSpawns = new List<Position>
        {
            new Position(-47.8021f, -1116.419f, 26.43427f),
            new Position(-50.66175f, -1116.753f, 26.4342f),
            new Position(-53.51776f, -1116.721f, 26.43449f),
            new Position(-56.41209f, -1116.901f, 26.43442f)
        };

        public static List<Position> BikeshopSpawns = new List<Position>
        {
            new Position(265.2711f, -1149.21f, 29.29169f),
            new Position(262.4801f, -1149.25f, 29.29169f),
            new Position(259.3696f, -1149.42f, 29.29169f),
            new Position(256.2483f, -1149.431f, 29.29169f),
            new Position(250.0457f, -1149.472f, 29.28539f)
        };

        public static List<Position> ShipSpawns = new List<Position>
        {
            new Position(-727.1069f, -1327.44f, -0.4730833f),
            new Position(-731.7827f, -1334.567f, -0.4733995f),
            new Position(-737.4061f, -1340.965f, -0.4733122f),
            new Position(-743.5413f, -1347.753f, -0.473477f)
        };

        public static List<TunningPriceModel> TunningPriceList = new List<TunningPriceModel>
        {
            new TunningPriceModel(VehicleModSpoiler, 250),
            new TunningPriceModel(VehicleModFrontBumper, 250),
            new TunningPriceModel(VehicleModRearBumper, 250),
            new TunningPriceModel(VehicleModSideSkirt, 250),
            new TunningPriceModel(VehicleModExhaust, 100),
            new TunningPriceModel(VehicleModFrame, 500),
            new TunningPriceModel(VehicleModGrille, 200),
            new TunningPriceModel(VehicleModHood, 300),
            new TunningPriceModel(VehicleModFender, 100),
            new TunningPriceModel(VehicleModRightFender, 100),
            new TunningPriceModel(VehicleModRoof, 400),
            new TunningPriceModel(VehicleModHorn, 100),
            new TunningPriceModel(VehicleModSuspension, 900),
            new TunningPriceModel(VehicleModXenon, 150),
            new TunningPriceModel(VehicleModFrontWheels, 100),
            new TunningPriceModel(VehicleModBackWheels, 100),
            new TunningPriceModel(VehicleModPlateHolders, 100),
            new TunningPriceModel(VehicleModTrimDesign, 800),
            new TunningPriceModel(VehicleModOrnamients, 150),
            new TunningPriceModel(VehicleModSteeringWheel, 100),
            new TunningPriceModel(VehicleModShifterLeavers, 100),
            new TunningPriceModel(VehicleModHydraulics, 1200),
            new TunningPriceModel(VehicleModEngine, 5000),
        };

        // ATMs
        public static List<Position> AtmList = new List<Position>
        {
            new Position(-846.6537f, -341.509f, 37.6685f), // 1
            new Position(1153.747f, -326.7634f, 69.2050f), // 2
            new Position(285.6829f, 143.4019f, 104.169f), //3
            new Position(-847.204f, -340.4291f, 37.6793f), // 4
            new Position(-1410.736f, -98.9279f, 51.397f), //5
            new Position(-1410.183f, -100.6454f, 51.3965f), //6
            new Position(-2295.853f, 357.9348f, 173.6014f), //7
            new Position(-2295.069f, 356.2556f, 173.6014f),//8
            new Position(-2294.3f, 354.6056f, 173.6014f), //9
            new Position(-282.7141f, 6226.43f, 30.4965f), //10
            new Position(-386.4596f, 6046.411f, 30.474f), // 11
            new Position(24.5933f, -945.543f, 28.333f), // 12
            new Position(5.686f, -919.9551f, 28.4809f), //13
            new Position(296.1756f, -896.2318f, 28.2901f), //14
            new Position(296.8775f, -894.3196f, 28.2615f), //15
            new Position(-846.6537f, -341.509f, 37.6685f), //16
            new Position(-847.204f, -340.4291f, 37.6793f), //17
            new Position(-1410.736f, -98.9279f, 51.397f), //18
            new Position(-1410.183f, -100.6454f, 51.3965f), //19
            new Position(-2295.853f, 357.9348f, 173.6014f), //20
            new Position(-2295.069f, 356.2556f, 173.6014f), //21
            new Position(-2294.3f, 354.6056f, 173.6014f), //22
            new Position(-282.7141f, 6226.43f, 30.4965f), //23
            new Position(-386.4596f, 6046.411f, 30.474f), //24
            new Position(24.5933f, -945.543f, 28.333f), //25
            new Position(5.686f, -919.9551f, 28.4809f), //26
            new Position(296.1756f, -896.2318f, 28.2901f), //27
            new Position(296.8775f, -894.3196f, 28.2615f),
            new Position(-712.9357f, -818.4827f, 22.7407f),
            new Position(-710.0828f, -818.4756f, 22.7363f),
            new Position(289.53f, -1256.788f, 28.4406f),
            new Position(289.2679f, -1282.32f, 28.6552f),
            new Position(-1569.84f, -547.0309f, 33.9322f),
            new Position(-1570.765f, -547.7035f, 33.9322f),
            new Position(-1305.708f, -706.6881f, 24.3145f),
            new Position(-2071.928f, -317.2862f, 12.3181f),
            new Position(-821.8936f, -1081.555f, 10.1366f),
            new Position(-712.9357f, -818.4827f, 22.7407f),
            new Position(-710.0828f, -818.4756f, 22.7363f),
            new Position(289.53f, -1256.788f, 28.4406f),
            new Position(289.2679f, -1282.32f, 28.6552f),
            new Position(-1569.84f, -547.0309f, 33.9322f),
            new Position(-1570.765f, -547.7035f, 33.9322f),
            new Position(-1305.708f, -706.6881f, 24.3145f),
            new Position(-2071.928f, -317.2862f, 12.3181f),
            new Position(-821.8936f, -1081.555f, 10.1366f),
            new Position(-867.013f, -187.9928f, 36.8822f),
            new Position(-867.9745f, -186.3419f, 36.8822f),
            new Position(-3043.835f, 594.1639f, 6.7328f),
            new Position(-3241.455f, 997.9085f, 11.5484f),
            new Position(-204.0193f, -861.0091f, 29.2713f),
            new Position(118.6416f, -883.5695f, 30.1395f),
            new Position(-256.6386f, -715.8898f, 32.7883f),
            new Position(-259.2767f, -723.2652f, 32.7015f),
            new Position(-254.5219f, -692.8869f, 32.5783f),
            new Position(-867.013f, -187.9928f, 36.8822f),
            new Position(-867.9745f, -186.3419f, 36.8822f),
            new Position(-3043.835f, 594.1639f, 6.7328f),
            new Position(-3241.455f, 997.9085f, 11.5484f),
            new Position(-204.0193f, -861.0091f, 29.2713f),
            new Position(118.6416f, -883.5695f, 30.1395f),
            new Position(-256.6386f, -715.8898f, 32.7883f),
            new Position(-259.2767f, -723.2652f, 32.7015f),
            new Position(-254.5219f, -692.8869f, 32.5783f),
            new Position(89.8134f, 2.8803f, 67.3521f),
            new Position(-617.8035f, -708.8591f, 29.0432f),
            new Position(-617.8035f, -706.8521f, 29.0432f),
            new Position(-614.5187f, -705.5981f, 30.224f),
            new Position(-611.8581f, -705.5981f, 30.224f),
            new Position(-537.8052f, -854.9357f, 28.2754f),
            new Position(-526.7791f, -1223.374f, 17.4527f),
            new Position(-1315.416f, -834.431f, 15.9523f),
            new Position(-1314.466f, -835.6913f, 15.9523f),
            new Position(89.8134f, 2.8803f, 67.3521f),
            new Position(-617.8035f, -708.8591f, 29.0432f),
            new Position(-617.8035f, -706.8521f, 29.0432f),
            new Position(-614.5187f, -705.5981f, 30.224f),
            new Position(-611.8581f, -705.5981f, 30.224f),
            new Position(-537.8052f, -854.9357f, 28.2754f),
            new Position(-526.7791f, -1223.374f, 17.4527f),
            new Position(-1315.416f, -834.431f, 15.9523f),
            new Position(-1314.466f, -835.6913f, 15.9523f),
            new Position(-1205.378f, -326.5286f, 36.851f),
            new Position(-1206.142f, -325.0316f, 36.851f),
            new Position(147.4731f, -1036.218f, 28.3678f),
            new Position(145.8392f, -1035.625f, 28.3678f),
            new Position(-1205.378f, -326.5286f, 36.851f),
            new Position(-1206.142f, -325.0316f, 36.851f),
            new Position(147.4731f, -1036.218f, 28.3678f),
            new Position(145.8392f, -1035.625f, 28.3678f),
            new Position(-1109.797f, -1690.808f, 4.375014f),
            new Position(-721.1284f, -415.5296f, 34.98175f),
            new Position(130.1186f, -1292.669f, 29.26953f),
            new Position(129.7023f, -1291.954f, 29.26953f),
            new Position(129.2096f, -1291.14f, 29.26953f),
            new Position(288.8256f, -1282.364f, 29.64128f),
            new Position(1077.768f, -776.4548f, 58.23997f),
            new Position(527.2687f, -160.7156f, 57.08937f),
            new Position(-57.64693f, -92.66162f, 57.77995f),
            new Position(527.3583f, -160.6381f, 57.0933f),
            new Position(-165.1658f, 234.8314f, 94.92194f),
            new Position(-165.1503f, 232.7887f, 94.92194f),
            new Position(-1091.462f, 2708.637f, 18.95291f),
            new Position(1172.492f, 2702.492f, 38.17477f),
            new Position(1171.537f, 2702.492f, 38.17542f),
            new Position(1822.637f, 3683.131f, 34.27678f),
            new Position(1686.753f, 4815.806f, 42.00874f),
            new Position(1701.209f, 6426.569f, 32.76408f),
            new Position(-1091.42f, 2708.629f, 18.95568f),
            new Position(-660.703f, -853.971f, 24.484f),
            new Position(-660.703f, -853.971f, 24.484f),
            new Position(-1409.782f, -100.41f, 52.387f),
            new Position(-1410.279f, -98.649f, 52.436f),
            new Position(-2975.014f,380.129f,14.99909f),
            new Position(155.9642f,6642.763f,31.60284f),
            new Position(174.1721f,6637.943f,31.57305f),
            new Position(-97.33363f,6455.411f,31.46716f),
            new Position(-95.49733f,6457.243f,31.46098f),
            new Position(-303.2701f,-829.7642f,32.41727f),
            new Position(-301.6767f,-830.1f,32.41727f),
            new Position(-717.6539f,-915.6808f,19.21559f),
            new Position(-1391.023f, -590.3637f, 30.31957f),
            new Position(1138.311f, -468.941f, 66.73091f),
            new Position(1167.086f, -456.1151f, 66.79015f)
        };


        // ZAPFSÄULEN Liste
        public static List<Position> AutoZapfList = new List<Position>
        {
            // 1
            new Position(-711.3199f,-935.8979f,18.77238f),

            new Position(-719.7664f,-936.0695f,18.7734f),

            new Position(-728.4735f,-936.0673f,18.77255f),

            new Position(-735.385f,-935.6021f,18.77277f),

            // 2
            new Position(822.8326f, -1028.975f, 25.55556f),

            new Position(814.7797f, -1028.667f, 25.55352f),

            new Position(806.8304f, -1028.883f, 25.49467f),

            new Position(831.0402f, -1028.6f, 26.09239f),

            // 3
            new Position(-74.92104f, -1759.587f, 29.08676f),

            new Position(-66.4446f, -1763.204f, 28.78927f),

            new Position(-60.08352f, -1765.587f, 28.60159f),

            new Position(-81.94812f, -1757.733f, 29.16162f),

            // 4
            new Position(178.7718f, -1558.537f, 28.78064f),

            new Position(171.9593f, -1564.907f, 28.8188f),

            new Position(177.6252f, -1569.554f, 28.83885f),

            new Position(184.2121f, -1563.75f, 28.8189f),
            new Position(174.0527f, -1553.771f, 28.75146f),
            new Position(166.7723f, -1560.449f, 28.79087f),

            // 5

            new Position(-1808.733f, 794.0587f, 138.5135f),
            new Position(-1803.501f, 800.8792f, 138.5134f),
            new Position(-1796.041f, 806.0646f, 138.5134f),
            new Position(-1789.986f, 811.0816f, 138.5136f),

            //6
            new Position(-2554.69f, 2322.689f, 33.0604f),
            new Position(-2554.69f, 2330.745f, 33.06004f),
            new Position(-2554.69f, 2338.03f, 33.05991f),
            new Position(-2554.69f, 2345.263f, 33.05988f),


            // 7 
            new Position(169.6152f, 6600.386f, 31.84894f),
            new Position(176.2929f, 6600.386f, 31.84888f),
            new Position(183.7375f, 6600.386f, 31.84901f),
            new Position(191.0141f, 6604.201f, 31.85022f),

            //8
            new Position(2676.9f, 3266.23f, 55.24054f),
            new Position(2681.836f, 3263.412f, 55.24055f),

            //9
            new Position(2006.533f, 3771.577f, 32.18081f),
            new Position(2006.533f, 3771.577f, 32.18081f),

            // 10
            new Position(1782.791f, 3328.84f, 41.25505f),    
            
            // 11
            new Position(1205.083f, 2658.599f, 37.82508f),
            new Position(1209.717f, 2662.477f, 37.80997f),

            // 12
            new Position(263.5242f, 2609.86f, 44.86242f),
            new Position(264.7417f, 2603.701f, 44.84059f),
        };

        // ZAPFSÄULEN Liste
        public static List<Position> AutoZapfListBlips = new List<Position>
        {
            new Position(-719.7007f, -935.3601f, 18.30604f), //  1
            new Position(814.3843f, -1028.826f, 25.55414f), // 2
            new Position(-66.18435f, -1761.592f, 28.80148f), // 3
            new Position(174.7879f, -1562.761f, 28.80456f), // 4
            new Position(-1799.254f, 802.8502f, 138.6512f), // 5
            new Position(-2555.179f, 2334.358f, 33.07804f), // 6
            new Position(179.8759f, 6602.881f, 31.86819f), // 7
            new Position(2679.718f, 3264.873f, 55.40913f), // 8
            new Position(2005.233f, 3773.966f, 32.40395f), // 9
            new Position(1782.791f, 3328.84f, 41.25505f), // 10
            new Position(1208.164f, 2660.351f, 37.89971f), // 11
            new Position(264.0676f, 2606.484f, 44.98285f), // 12
        };
    }
}
