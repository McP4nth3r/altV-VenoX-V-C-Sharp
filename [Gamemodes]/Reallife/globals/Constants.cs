using AltV.Net.Data;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.Globals
{
    public class Constants
    {
        // Gamemode version
        public const string GM_VERSION = "v1.1.3";


        // Sex
        public const int SEX_NONE = -1;
        public const int SEX_MALE = 0;
        public const int SEX_FEMALE = 1;

        // Chat
        public const int CHAT_LENGTH = 85;
        public const int CHAT_RANGES = 5;

        // Administrative ranks

        public const int ADMINLVL_NONE = 0;
        public const int ADMINLVL_NULLD = 1;
        public const int ADMINLVL_TSUPPORTER = 2;
        public const int ADMINLVL_SUPPORTER = 3;
        public const int ADMINLVL_MODERATOR = 4;
        public const int ADMINLVL_ADMINISTRATOR = 5;
        public const int ADMINLVL_STELLVP = 6;
        public const int ADMINLVL_PROJEKTLEITER = 7;

        public const int CLOTHES_MASK = 1;
        public const int CLOTHES_TORSO = 3;
        public const int CLOTHES_LEGS = 4;
        public const int CLOTHES_BAGS = 5;
        public const int CLOTHES_FEET = 6;
        public const int CLOTHES_ACCESSORIES = 7;
        public const int CLOTHES_UNDERSHIRT = 8;
        public const int CLOTHES_TOPS = 11;

        // Tattoo zones
        public const int TATTOO_ZONE_TORSO = 0;
        public const int TATTOO_ZONE_HEAD = 1;
        public const int TATTOO_ZONE_LEFT_ARM = 2;
        public const int TATTOO_ZONE_RIGHT_ARM = 3;
        public const int TATTOO_ZONE_LEFT_LEG = 4;
        public const int TATTOO_ZONE_RIGHT_LEG = 5;

        // Accessory types
        public const int ACCESSORY_HATS = 0;
        public const int ACCESSORY_GLASSES = 1;
        public const int ACCESSORY_EARS = 2;

        // IVehicle components
        public const int VEHICLE_MOD_SPOILER = 0;
        public const int VEHICLE_MOD_FRONT_BUMPER = 1;
        public const int VEHICLE_MOD_REAR_BUMPER = 2;
        public const int VEHICLE_MOD_SIDE_SKIRT = 3;
        public const int VEHICLE_MOD_EXHAUST = 4;
        public const int VEHICLE_MOD_FRAME = 5;
        public const int VEHICLE_MOD_GRILLE = 6;
        public const int VEHICLE_MOD_HOOD = 7;
        public const int VEHICLE_MOD_FENDER = 8;
        public const int VEHICLE_MOD_RIGHT_FENDER = 9;
        public const int VEHICLE_MOD_ROOF = 10;
        public const int VEHICLE_MOD_ENGINE = 11;
        public const int VEHICLE_MOD_BRAKES = 12;
        public const int VEHICLE_MOD_TRANSMISSION = 13;
        public const int VEHICLE_MOD_HORN = 14;
        public const int VEHICLE_MOD_SUSPENSION = 15;
        public const int VEHICLE_MOD_ARMOR = 16;
        public const int VEHICLE_MOD_XENON = 22;
        public const int VEHICLE_MOD_FRONT_WHEELS = 23;
        public const int VEHICLE_MOD_BACK_WHEELS = 24;
        public const int VEHICLE_MOD_PLATE_HOLDERS = 25;
        public const int VEHICLE_MOD_TRIM_DESIGN = 27;
        public const int VEHICLE_MOD_ORNAMIENTS = 28;
        public const int VEHICLE_MOD_DIAL_DESIGN = 30;
        public const int VEHICLE_MOD_STEERING_WHEEL = 33;
        public const int VEHICLE_MOD_SHIFTER_LEAVERS = 34;
        public const int VEHICLE_MOD_PLAQUES = 35;
        public const int VEHICLE_MOD_HYDRAULICS = 38;
        public const int VEHICLE_MOD_LIVERY = 48;



        public const int VEHICLE_OFFLINE_DIM = 95;
        public const int VEHICLE_JOB_OFFLINE_DIM = 180;



        //
        public const int BUSINESS_TYPE_NONE = -1;
        public const int BUSINESS_TYPE_24_7 = 1;
        public const int BUSINESS_TYPE_ELECTRONICS = 2;
        public const int BUSINESS_TYPE_HARDWARE = 3;
        public const int BUSINESS_TYPE_CLOTHES = 4;
        public const int BUSINESS_TYPE_BAR = 5;
        public const int BUSINESS_TYPE_DISCO = 6;
        public const int BUSINESS_TYPE_AMMUNATION = 7;
        public const int BUSINESS_TYPE_WAREHOUSE = 8;
        public const int BUSINESS_TYPE_JEWELRY = 9;
        public const int BUSINESS_TYPE_PRIVATE_OFFICE = 10;
        public const int BUSINESS_TYPE_CLUBHOUSE = 11;
        public const int BUSINESS_TYPE_GAS_STATION = 12;
        public const int BUSINESS_TYPE_SLAUGHTERHOUSE = 13;
        public const int BUSINESS_TYPE_BARBER_SHOP = 14;
        public const int BUSINESS_TYPE_FACTORY = 15;
        public const int BUSINESS_TYPE_TORTURE_ROOM = 16;
        public const int BUSINESS_TYPE_GARAGE_LOW_END = 17;
        public const int BUSINESS_TYPE_WAREHOUSE_MEDIUM = 18;
        public const int BUSINESS_TYPE_SOCIAL_CLUB = 19;
        public const int BUSINESS_TYPE_MECHANIC = 20;
        public const int BUSINESS_TYPE_TATTOO_SHOP = 21;
        public const int BUSINESS_TYPE_BENNYS_WHORKSHOP = 22;
        public const int BUSINESS_TYPE_VANILLA = 23;
        public const int BUSINESS_TYPE_FISHING = 24;

        // Item types
        public const int ITEM_TYPE_CONSUMABLE = 0;
        public const int ITEM_TYPE_EQUIPABLE = 1;
        public const int ITEM_TYPE_OPENABLE = 2;
        public const int ITEM_TYPE_WEAPON = 3;
        public const int ITEM_TYPE_AMMUNITION = 4;
        public const int ITEM_TYPE_MISC = 5;

        // Amount of items when container opened
        public const int ITEM_OPEN_BEER_AMOUNT = 6;



        // ALLGEMEINE ITEMS : 

        public const string ITEM_HASH_WEED = "1233311452";
        public const string ITEM_HASH_KOKS = "1243355452";
        public const string ITEM_HASH_BENZINKANNISTER = "1243844452";
        public const string ITEM_HASH_TANKSTELLENSNACK = "1243344492";
        public const string ITEM_HASH_LEBKUCHENMAENNCHEN = "1243444492";
        public const string ITEM_HASH_MILCH = "1243544492";
        public const string ITEM_HASH_COOKIES = "1243644492";
        public const string ITEM_HASH_GLUEHWEIN = "1243744492";
        public const string ITEM_HASH_SPARERIPS = "1243844492";
        public const string ITEM_HASH_SCHOKOLADE = "1243944492";
        public const string ITEM_HASH_HEISSESCHOKOLADE = "1244044492";
        public const string ITEM_HASH_MATS = "1246355452";



        // Item - Arten 

        public const string ITEM_ART_WAFFE = "Waffe";
        public const string ITEM_ART_DROGEN = "Drogen";
        public const string ITEM_ART_NUTZ_ITEM = "NUTZ_ITEM";
        public const string ITEM_ART_MAGAZIN = "Magazin";
        public const string ITEM_ART_FALLSCHIRM = "Fallschirm";
        public const string ITEM_ART_BUSINESS = "Business";


        // Waffen items 

        public const string ITEM_HASH_FALLSCHIRM = "Parachute";

        public const string ITEM_HASH_SWITCHBLADE = "SwitchBlade";

        public const string ITEM_HASH_BROKENBOTTLE = "Broken Bottle";

        public const string ITEM_HASH_HAMMER = "Hammer";

        public const string ITEM_HASH_SNOWBALL = "Snowball";

        public const string ITEM_HASH_NIGHTSTICK = "NightStick";

        public const string ITEM_HASH_BASEBALL = "Bat";

        public const string ITEM_HASH_TAZER = "STUNGUN";

        public const string ITEM_HASH_VINTAGEPISTOL = "Vintage Pistol";

        public const string ITEM_HASH_MINISMG = "Mini SMG";

        public const string ITEM_HASH_PISTOLE = "Pistol";

        public const string ITEM_HASH_PISTOLE50 = "Pistol50";

        public const string ITEM_HASH_REVOLVER = "Revolver";

        public const string ITEM_HASH_PISTOL_AMMO = "PistolAmmo";



        public const string ITEM_HASH_SHOTGUN = "PumpShotgun";

        public const string ITEM_HASH_PDW = "CombatPDW";

        public const string ITEM_HASH_MP5 = "SMG";

        public const string ITEM_HASH_KARABINER = "CarbineRifle";

        public const string ITEM_HASH_AK47 = "AssaultRifle";

        public const string ITEM_HASH_ADVANCEDRIFLE = "AdvancedRifle";

        public const string ITEM_HASH_RIFLE = "Musket";

        public const string ITEM_HASH_RPG = "RPG";

        public const string ITEM_HASH_SNIPERRIFLE = "SniperRifle";



        // Waffen Namen 
        public const string ITEM_NAME_PISTOLAMMO = "Pistolen Magazin";



        //Waffenlager Dinge

        public const int BASEBALL_LAGER = 65;
        public const int BASEBALL_MAX_LAGER = 100;

        public const int NIGHTSTICK_LAGER = 65;
        public const int NIGHTSTICK_MAX_LAGER = 100;

        public const int STUNGUN_LAGER = 115;
        public const int STUNGUN_MAX_LAGER = 100;


        public const int PISTOL_LAGER = 135;
        public const int PISTOL_AMMO_LAGER = 45;

        public const int PISTOL_MAX_LAGER = 60;
        public const int PISTOL_AMMO_MAX_LAGER = 120;


        public const int PISTOL50_LAGER = 245;
        public const int PISTOL50_AMMO_LAGER = 85;
        public const int PISTOL50_MAX_LAGER = 45;
        public const int PISTOL50_AMMO_MAX_LAGER = 90;


        public const int REVOLVER_LAGER = 275;
        public const int REVOLVER_AMMO_LAGER = 110;
        public const int REVOLVER_MAX_LAGER = 35;
        public const int REVOLVER_AMMO_MAX_LAGER = 75;


        public const int SHOTGUN_LAGER = 290;
        public const int SHOTGUN_AMMO_LAGER = 85;
        public const int SHOTGUN_MAX_LAGER = 100;
        public const int SHOTGUN_AMMO_MAX_LAGER = 175;



        public const int MP5_LAGER = 550;
        public const int MP5_AMMO_LAGER = 210;
        public const int MP5_MAX_LAGER = 45;
        public const int MP5_AMMO_MAX_LAGER = 90;


        public const int COMBATPDW_LAGER = 550;
        public const int COMBATPDW_AMMO_LAGER = 210;
        public const int COMBATPDW_MAX_LAGER = 45;
        public const int COMBATPDW_AMMO_MAX_LAGER = 90;



        public const int AK47_LAGER = 650;
        public const int AK47_MAX_LAGER = 40;
        public const int AK47_AMMO_LAGER = 210;
        public const int AK47_AMMO_MAX_LAGER = 80;


        public const int KARABINER_LAGER = 650;
        public const int KARABINER_MAX_LAGER = 40;
        public const int KARABINER_AMMO_LAGER = 210;
        public const int KARABINER_AMMO_MAX_LAGER = 80;



        public const int RIFLE_LAGER = 750;
        public const int RIFLE_AMMO_LAGER = 310;
        public const int RIFLE_MAX_LAGER = 35;
        public const int RIFLE_AMMO_MAX_LAGER = 70;

        public const int ADVANCEDRIFLE_LAGER = 750;
        public const int ADVANCEDRIFLE_AMMO_LAGER = 310;
        public const int ADVANCEDRIFLE_MAX_LAGER = 35;
        public const int ADVANCEDRIFLE_AMMO_MAX_LAGER = 70;



        public const int SNIPER_LAGER = 1200;
        public const int SNIPER_AMMO_LAGER = 420;
        public const int SNIPER_MAX_LAGER = 10;
        public const int SNIPER_AMMO_MAX_LAGER = 30;


        public const int RPG_LAGER = 5000;
        public const int RPG_AMMO_LAGER = 500;
        public const int RPG_MAX_LAGER = 10;
        public const int RPG_AMMO_MAX_LAGER = 30;


        public const int TRAENENGAS_LAGER = 100;
        public const int TRAENENGAS_MAX_LAGER = 40;

        public const int MOLOTOV_LAGER = 250;
        public const int MOLOTOV_MAX_LAGER = 40;





        // IVehicle Rgba types
        public const int VEHICLE_Rgba_TYPE_PREDEFINED = 0;
        public const int VEHICLE_Rgba_TYPE_CUSTOM = 1;

        // IVehicle types
        public const int VEHICLE_CLASS_COMPACTS = 0;
        public const int VEHICLE_CLASS_SEDANS = 1;
        public const int VEHICLE_CLASS_SUVS = 2;
        public const int VEHICLE_CLASS_COUPES = 3;
        public const int VEHICLE_CLASS_MUSCLE = 4;
        public const int VEHICLE_CLASS_SPORTS = 5;
        public const int VEHICLE_CLASS_CLASSICS = 6;
        public const int VEHICLE_CLASS_SUPER = 7;
        public const int VEHICLE_CLASS_MOTORCYCLES = 8;
        public const int VEHICLE_CLASS_OFFROAD = 9;
        public const int VEHICLE_CLASS_INDUSTRIAL = 10;
        public const int VEHICLE_CLASS_UTILITY = 11;
        public const int VEHICLE_CLASS_VANS = 12;
        public const int VEHICLE_CLASS_CYCLES = 13;
        public const int VEHICLE_CLASS_BOATS = 14;
        public const int VEHICLE_CLASS_HELICOPTERS = 15;
        public const int VEHICLE_CLASS_PLANES = 16;
        public const int VEHICLE_CLASS_SERVICE = 17;
        public const int VEHICLE_CLASS_EMERGENCY = 18;
        public const int VEHICLE_CLASS_MILITARY = 19;
        public const int VEHICLE_CLASS_COMMERCIAL = 20;
        public const int VEHICLE_CLASS_TRAINS = 21;

        // Tax percentage
        public const float TAXES_IVehicle = 0.0025f;
        public const float TAXES_HOUSE = 0.0030f;

        public const float VIP_BONI_BRONZE = 0.025f;
        public const float VIP_BONI_SILBER = 0.050f;
        public const float VIP_BONI_GOLD = 0.1f;
        public const float VIP_BONI_RED = 0.15f;
        public const float VIP_BONI_PLATIN = 0.20f;
        public const float VIP_BONI_TOP = 0.25f;

        public const float VIP_BONI_AUTOSTEUER_SILVER = 0.1f;
        public const float VIP_BONI_AUTOSTEUER_GOLD = 0.2f;
        public const float VIP_BONI_AUTOSTEUER_ULTIMATERED = 0.3f;
        public const float VIP_BONI_AUTOSTEUER_PLATIN = 0.4f;
        public const float VIP_BONI_AUTOSTEUER_TOPDONATOR = 0.5f;

        // Gargabe route money
        public const int MONEY_GARBAGE_ROUTE = 350;

        // Factions
        public const int FACTION_NONE = 0;
        public const int FACTION_POLICE = 1;
        public const int FACTION_COSANOSTRA = 2;
        public const int FACTION_YAKUZA = 3;
        public const int FACTION_TERRORCLOSED = 0;
        public const int FACTION_NEWS = 5;
        public const int FACTION_FBI = 6;
        public const int FACTION_MS13 = 7;
        public const int FACTION_USARMY = 8;
        public const int FACTION_SAMCRO = 9;
        public const int FACTION_EMERGENCY = 10;
        public const int FACTION_MECHANIK = 11;
        public const int FACTION_BALLAS = 12;
        public const int FACTION_GROVE = 13;

        public const string FACTION_NONE_NAME = "Zivilist";
        public const string FACTION_POLICE_NAME = "Los Santos Police Department";
        public const string FACTION_COSANOSTRA_NAME = "La Cosa Nostra";
        public const string FACTION_YAKUZA_NAME = "Yakuza";
        public const string FACTION_TERRORCLOSED_NAME = "CLOSED";
        public const string FACTION_NEWS_NAME = "SAN NEWS";
        public const string FACTION_FBI_NAME = "Federal Investigation Bureau";
        public const string FACTION_MS13_NAME = "Narcos";
        public const string FACTION_USARMY_NAME = "U.S Army";
        public const string FACTION_SAMCRO_NAME = "Samcro Redwoods";
        public const string FACTION_EMERGENCY_NAME = "Medic";
        public const string FACTION_MECHANIK_NAME = "Mechaniker";
        public const string FACTION_BALLAS_NAME = "Rollin Height Ballas";
        public const string FACTION_GROVE_NAME = "Compton Family´s";


        public const int FACTION_ADMIN = 90;
        public const int MAX_FACTION_IVehicleS = 100;

        // Jobs
        public const string JOB_NONE = "Arbeitslos";
        public const string JOB_CITY_TRANSPORT = "VENOX_CITY_TRANSPORT";
        public const string JOB_AIRPORT = "VENOX_AIRPORT";
        public const string JOB_BUS = "VENOX_BUSCENTER";






        // House status
        public const int HOUSE_STATE_NONE = 0;
        public const int HOUSE_STATE_RENTABLE = 1;
        public const int HOUSE_STATE_BUYABLE = 2;

        // Chat message types
        public const int MESSAGE_TALK = 0;
        public const int MESSAGE_YELL = 1;
        public const int MESSAGE_WHISPER = 2;
        public const int MESSAGE_ME = 3;
        public const int MESSAGE_DO = 4;
        public const int MESSAGE_SU_TRUE = 6;
        public const int MESSAGE_SU_FALSE = 7;
        public const int MESSAGE_NEWS = 8;
        public const int MESSAGE_PHONE = 9;
        public const int MESSAGE_DISCONNECT = 10;
        public const int MESSAGE_MEGAPHONE = 11;
        public const int MESSAGE_RADIO = 12;

        // Chat Rgbas
        public const string Rgba_CHAT_CLOSE = "{E6E6E6}";
        public const string Rgba_CHAT_NEAR = "{C8C8C8}";
        public const string Rgba_CHAT_MEDIUM = "{AAAAAA}";
        public const string Rgba_CHAT_FAR = "{8C8C8C}";
        public const string Rgba_CHAT_LIMIT = "{6E6E6E}";
        public const string Rgba_CHAT_ME = "{C2A2DA}";
        public const string Rgba_CHAT_DO = "{0F9622}";
        public const string Rgba_CHAT_FACTION = "{27F7C8}";
        public const string Rgba_CHAT_PHONE = "{27F7C8}";
        public const string Rgba_ADMIN_INFO = "{00FCFF}";
        public const string Rgba_ADMIN_CLANTAG = "{00C8FF}[VnX]{FFFFFF}";
        public const string Rgba_ADMIN_NEWS = "{F93131}";
        public const string Rgba_ADMIN_MP = "{F93131}";
        public const string Rgba_SUCCESS = "{33B517}";
        public const string Rgba_ERROR = "{E10000}";
        public const string Rgba_INFO = "{FDFE8B}";
        public const string Rgba_HELP = "{FFFFFF}";
        public const string Rgba_SU_POSITIVE = "{E3E47D}";
        public const string Rgba_NEWS = "{805CC9}";


        // Generic interiors
        public static List<InteriorModel> INTERIOR_LIST = new List<InteriorModel>
        {
            new InteriorModel("Krankenhaus", new Position(355.45f, -596.153f, 28.77341f), new Position(275.446f, -1361.11f, 24.5378f), "Coroner_Int_On", 153, "Krankenhaus", 255,255,255, 1),
            new InteriorModel("Weazel News", new Position(-598.51f, -929.95f, 23.87f), new Position(-1082.433f, -258.7667f, 37.76331f), "facelobby", 459, "Weazel News",  255,255,255,0),
            new InteriorModel("Los Santos Police Department", new Position(434.4719f,-982.0015f,30.71084f), new Position(434.4719f,-982.0015f,30.71084f), string.Empty, 60, "Los Santos Police Department",255,255,255, 0),
            //new InteriorModel("Rathaus", Rathaus.RathausMarkerEingang.position, Rathaus.RathausMarkerImInterior.position, string.Empty, 1, "Rathaus", 255,255,255, 64),

        };


        // House interiors from the game
        public static List<HouseIplModel> HOUSE_IPL_LIST = new List<HouseIplModel>
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
        public static List<FactionModel> FACTION_RANK_LIST = new List<FactionModel>
        {
            new FactionModel(Messages.FAC_NONE_M, Messages.FAC_NONE_F, FACTION_NONE, 0, 500),
            new FactionModel(Messages.FAC_NONE_M, Messages.FAC_NONE_F, FACTION_NONE, 1, 500),
            new FactionModel(Messages.FAC_NONE_M, Messages.FAC_NONE_F, FACTION_NONE, 2, 500),
            new FactionModel(Messages.FAC_NONE_M, Messages.FAC_NONE_F, FACTION_NONE, 3, 500),
            new FactionModel(Messages.FAC_NONE_M, Messages.FAC_NONE_F, FACTION_NONE, 4, 500),
            new FactionModel(Messages.FAC_NONE_M, Messages.FAC_NONE_F, FACTION_NONE, 5, 500),

            // Police department
            new FactionModel(Messages.FAC_LSPD_0_M, Messages.FAC_LSPD_0_F, FACTION_POLICE, 0, 625),
            new FactionModel(Messages.FAC_LSPD_1_M, Messages.FAC_LSPD_1_F, FACTION_POLICE, 1, 750),
            new FactionModel(Messages.FAC_LSPD_2_M, Messages.FAC_LSPD_2_F, FACTION_POLICE, 2, 1000),
            new FactionModel(Messages.FAC_LSPD_3_M, Messages.FAC_LSPD_3_F, FACTION_POLICE, 3, 1350),
            new FactionModel(Messages.FAC_LSPD_4_M, Messages.FAC_LSPD_4_F, FACTION_POLICE, 4, 1500),
            new FactionModel(Messages.FAC_LSPD_5_M, Messages.FAC_LSPD_5_F, FACTION_POLICE, 5, 1750),

            // Mafia 
            new FactionModel(Messages.FAC_MAFIA_0_M, Messages.FAC_MAFIA_0_F, FACTION_COSANOSTRA, 0, 480),
            new FactionModel(Messages.FAC_MAFIA_1_M, Messages.FAC_MAFIA_1_F, FACTION_COSANOSTRA, 1, 600),
            new FactionModel(Messages.FAC_MAFIA_2_M, Messages.FAC_MAFIA_2_F, FACTION_COSANOSTRA, 2, 700),
            new FactionModel(Messages.FAC_MAFIA_3_M, Messages.FAC_MAFIA_3_F, FACTION_COSANOSTRA, 3, 900),
            new FactionModel(Messages.FAC_MAFIA_4_M, Messages.FAC_MAFIA_4_F, FACTION_COSANOSTRA, 4, 1200),
            new FactionModel(Messages.FAC_MAFIA_5_M, Messages.FAC_MAFIA_5_F, FACTION_COSANOSTRA, 5, 1400),

            // YAKUZA 
            new FactionModel(Messages.FAC_YAKUZA_0_M, Messages.FAC_YAKUZA_0_F, FACTION_YAKUZA, 0, 480),
            new FactionModel(Messages.FAC_YAKUZA_1_M, Messages.FAC_YAKUZA_1_F, FACTION_YAKUZA, 1, 600),
            new FactionModel(Messages.FAC_YAKUZA_2_M, Messages.FAC_YAKUZA_2_F, FACTION_YAKUZA, 2, 700),
            new FactionModel(Messages.FAC_YAKUZA_3_M, Messages.FAC_YAKUZA_3_F, FACTION_YAKUZA, 3, 900),
            new FactionModel(Messages.FAC_YAKUZA_4_M, Messages.FAC_YAKUZA_4_F, FACTION_YAKUZA, 4, 1200),
            new FactionModel(Messages.FAC_YAKUZA_5_M, Messages.FAC_YAKUZA_5_F, FACTION_YAKUZA, 5, 1400),


            // NEWS 
            new FactionModel(Messages.FAC_NEWS_0_M, Messages.FAC_NEWS_0_F, FACTION_NEWS, 0, 1000),
            new FactionModel(Messages.FAC_NEWS_1_M, Messages.FAC_NEWS_1_F, FACTION_NEWS, 1, 1250),
            new FactionModel(Messages.FAC_NEWS_2_M, Messages.FAC_NEWS_2_F, FACTION_NEWS, 2, 1500),
            new FactionModel(Messages.FAC_NEWS_3_M, Messages.FAC_NEWS_3_F, FACTION_NEWS, 3, 1600),
            new FactionModel(Messages.FAC_NEWS_4_M, Messages.FAC_NEWS_4_F, FACTION_NEWS, 4, 1850),
            new FactionModel(Messages.FAC_NEWS_5_M, Messages.FAC_NEWS_5_F, FACTION_NEWS, 5, 1900),

            // FBI 
            new FactionModel(Messages.FAC_FBI_0_M, Messages.FAC_FBI_0_F, FACTION_FBI, 0, 825),
            new FactionModel(Messages.FAC_FBI_1_M, Messages.FAC_FBI_1_F, FACTION_FBI, 1, 950),
            new FactionModel(Messages.FAC_FBI_2_M, Messages.FAC_FBI_2_F, FACTION_FBI, 2, 1200),
            new FactionModel(Messages.FAC_FBI_3_M, Messages.FAC_FBI_3_F, FACTION_FBI, 3, 1550),
            new FactionModel(Messages.FAC_FBI_4_M, Messages.FAC_FBI_4_F, FACTION_FBI, 4, 1750),
            new FactionModel(Messages.FAC_FBI_5_M, Messages.FAC_FBI_5_F, FACTION_FBI, 5, 1950),

            // MS13 
            new FactionModel(Messages.FAC_MS13_0_M, Messages.FAC_MS13_0_F, FACTION_MS13, 0, 480),
            new FactionModel(Messages.FAC_MS13_1_M, Messages.FAC_MS13_1_F, FACTION_MS13, 1, 600),
            new FactionModel(Messages.FAC_MS13_2_M, Messages.FAC_MS13_2_F, FACTION_MS13, 2, 700),
            new FactionModel(Messages.FAC_MS13_3_M, Messages.FAC_MS13_3_F, FACTION_MS13, 3, 900),
            new FactionModel(Messages.FAC_MS13_4_M, Messages.FAC_MS13_4_F, FACTION_MS13, 4, 1200),
            new FactionModel(Messages.FAC_MS13_5_M, Messages.FAC_MS13_5_F, FACTION_MS13, 5, 1400),

            // USARMY 
            new FactionModel(Messages.FAC_USARMY_0_M, Messages.FAC_USARMY_0_F, FACTION_USARMY, 0, 0),
            new FactionModel(Messages.FAC_USARMY_1_M, Messages.FAC_USARMY_1_F, FACTION_USARMY, 1, 1250),
            new FactionModel(Messages.FAC_USARMY_2_M, Messages.FAC_USARMY_2_F, FACTION_USARMY, 2, 1388),
            new FactionModel(Messages.FAC_USARMY_3_M, Messages.FAC_USARMY_3_F, FACTION_USARMY, 3, 1685),
            new FactionModel(Messages.FAC_USARMY_4_M, Messages.FAC_USARMY_4_F, FACTION_USARMY, 4, 2056),
            new FactionModel(Messages.FAC_USARMY_5_M, Messages.FAC_USARMY_5_F, FACTION_USARMY, 5, 2420),

            // AOD 
            new FactionModel(Messages.FAC_SAMCRO_0_M, Messages.FAC_SAMCRO_0_F, FACTION_SAMCRO, 0, 480),
            new FactionModel(Messages.FAC_SAMCRO_1_M, Messages.FAC_SAMCRO_1_F, FACTION_SAMCRO, 1, 600),
            new FactionModel(Messages.FAC_SAMCRO_2_M, Messages.FAC_SAMCRO_2_F, FACTION_SAMCRO, 2, 700),
            new FactionModel(Messages.FAC_SAMCRO_3_M, Messages.FAC_SAMCRO_3_F, FACTION_SAMCRO, 3, 900),
            new FactionModel(Messages.FAC_SAMCRO_4_M, Messages.FAC_SAMCRO_4_F, FACTION_SAMCRO, 4, 1200),
            new FactionModel(Messages.FAC_SAMCRO_5_M, Messages.FAC_SAMCRO_5_F, FACTION_SAMCRO, 5, 1400),

            // MEDIC 
            new FactionModel(Messages.FAC_MEDIC_0_M, Messages.FAC_MEDIC_0_F, FACTION_EMERGENCY, 0, 1200),
            new FactionModel(Messages.FAC_MEDIC_1_M, Messages.FAC_MEDIC_1_F, FACTION_EMERGENCY, 1, 1300),
            new FactionModel(Messages.FAC_MEDIC_2_M, Messages.FAC_MEDIC_2_F, FACTION_EMERGENCY, 2, 1500),
            new FactionModel(Messages.FAC_MEDIC_3_M, Messages.FAC_MEDIC_3_F, FACTION_EMERGENCY, 3, 1650),
            new FactionModel(Messages.FAC_MEDIC_4_M, Messages.FAC_MEDIC_4_F, FACTION_EMERGENCY, 4, 1850),
            new FactionModel(Messages.FAC_MEDIC_5_M, Messages.FAC_MEDIC_5_F, FACTION_EMERGENCY, 5, 2000),

            // MECHANIKER 
            new FactionModel(Messages.FAC_MECHANIKER_0_M, Messages.FAC_MECHANIKER_0_F, FACTION_MECHANIK, 0, 200),
            new FactionModel(Messages.FAC_MECHANIKER_1_M, Messages.FAC_MECHANIKER_1_F, FACTION_MECHANIK, 1, 600),
            new FactionModel(Messages.FAC_MECHANIKER_2_M, Messages.FAC_MECHANIKER_2_F, FACTION_MECHANIK, 2, 750),
            new FactionModel(Messages.FAC_MECHANIKER_3_M, Messages.FAC_MECHANIKER_3_F, FACTION_MECHANIK, 3, 950),
            new FactionModel(Messages.FAC_MECHANIKER_4_M, Messages.FAC_MECHANIKER_4_F, FACTION_MECHANIK, 4, 1350),
            new FactionModel(Messages.FAC_MECHANIKER_5_M, Messages.FAC_MECHANIKER_5_F, FACTION_MECHANIK, 5, 1500),

            // BALLAS 
            new FactionModel(Messages.FAC_BALLAS_0_M, Messages.FAC_BALLAS_0_F, FACTION_BALLAS, 0, 480),
            new FactionModel(Messages.FAC_BALLAS_1_M, Messages.FAC_BALLAS_1_F, FACTION_BALLAS, 1, 600),
            new FactionModel(Messages.FAC_BALLAS_2_M, Messages.FAC_BALLAS_2_F, FACTION_BALLAS, 2, 700),
            new FactionModel(Messages.FAC_BALLAS_3_M, Messages.FAC_BALLAS_3_F, FACTION_BALLAS, 3, 900),
            new FactionModel(Messages.FAC_BALLAS_4_M, Messages.FAC_BALLAS_4_F, FACTION_BALLAS, 4, 1200),
            new FactionModel(Messages.FAC_BALLAS_5_M, Messages.FAC_BALLAS_5_F, FACTION_BALLAS, 5, 1400),

            // Compton 
            new FactionModel(Messages.FAC_COMPTON_0_M, Messages.FAC_COMPTON_0_F, FACTION_GROVE, 0, 480),
            new FactionModel(Messages.FAC_COMPTON_1_M, Messages.FAC_COMPTON_1_F, FACTION_GROVE, 1, 600),
            new FactionModel(Messages.FAC_COMPTON_2_M, Messages.FAC_COMPTON_2_F, FACTION_GROVE, 2, 700),
            new FactionModel(Messages.FAC_COMPTON_3_M, Messages.FAC_COMPTON_3_F, FACTION_GROVE, 3, 900),
            new FactionModel(Messages.FAC_COMPTON_4_M, Messages.FAC_COMPTON_4_F, FACTION_GROVE, 4, 1200),
            new FactionModel(Messages.FAC_COMPTON_5_M, Messages.FAC_COMPTON_5_F, FACTION_GROVE, 5, 1400),
        };


        // Uniform list
        public static List<UniformModel> UNIFORM_LIST = new List<UniformModel>
        {  
            // Male police uniform
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 0, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 3, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 4, 35, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 5, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 6, 25, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 7, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 8, 58, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 10, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_MALE, 11, 55, 0),

            // Female police uniform
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 0, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 3, 14, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 4, 34, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 5, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 6, 25, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 7, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 8, 35, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 10, 0, 0),
            new UniformModel(0, FACTION_POLICE, SEX_FEMALE, 11, 48, 0),


            //////////////////////////////////////////////


            // Male Mafia uniform
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 0, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 3, 4, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 4, 28, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 5, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 6, 21, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 7, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 8, 33, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 10, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_MALE, 11, 29, 0),

            // Female Mafia uniform
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 0, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 3, 3, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 4, 37, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 5, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 6, 29, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 7, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 8, 147, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 10, 0, 0),
            new UniformModel(0, FACTION_COSANOSTRA, SEX_FEMALE, 11, 7, 0),
            //////////////////////////////////////////////


            // Male YAKUZA uniform


            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 2, -1, -1),


            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 5, 0, 0),

            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 7, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 10, 0, 0),

            // Move
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 0, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 1, -1, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 11, 107, 2),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 3, 33, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 4, 33, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_MALE, 6, 81, 0),


            // Female YAKUZA uniform
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 0, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 3, 3, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 4, 23, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 5, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 6, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 7, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 8, 15, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 10, 0, 0),
            new UniformModel(0, FACTION_YAKUZA, SEX_FEMALE, 11, 98, 0),

            // Male NEWS uniform
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 0, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 3, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 4, 1, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 5, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 6, 9, 1),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 7, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 10, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_MALE, 11, 9, 15),

            // Female NEWS uniform
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 0, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 3, 3, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 4, 23, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 5, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 6, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 7, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 8, 15, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 10, 0, 0),
            new UniformModel(0, FACTION_NEWS, SEX_FEMALE, 11, 98, 0),




            // Male FBI uniform
            new UniformModel(0, FACTION_FBI, SEX_MALE, 0, -1, -1),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 3, 11, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 4, 10, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 5, -1, -1),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 6, 10, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 7, 12, 2),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 10, -1, 0),
            new UniformModel(0, FACTION_FBI, SEX_MALE, 11,13, 0),

            // Female FBI uniform
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 0, -1, -1),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 3, 85, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 4, 96, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 5, -1, -1),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 6, 51, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 7, 127, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 8, 129, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 10, 58, 0),
            new UniformModel(0, FACTION_FBI, SEX_FEMALE, 11, 250, 0),



            
            // Male AZTECAS uniform
            new UniformModel(0, FACTION_MS13, SEX_MALE, 0, 8, -1),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 3, 11, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 4, 22, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 5, 0, -1),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 6, 21, 5),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 7, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 10, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_MALE, 11,13, 1),

            // Female AZTECAS uniform
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 0, -1, -1),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 3, 85, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 4, 96, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 5, -1, -1),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 6, 51, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 7, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 8, 129, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 10, 58, 0),
            new UniformModel(0, FACTION_MS13, SEX_FEMALE, 11, 250, 0),


                        
            // Male ROCKER uniform
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 0, -1, -1),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 3, 2, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 4, 76, 1),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 5, -1, -1),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 6, 25, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 7, 0, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 8, 14, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 10, -1, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_MALE, 11,175,3),

            // Female ROCKER uniform
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 0, -1, -1),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 3, 85, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 4, 96, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 5, -1, -1),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 6, 51, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 7, 127, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 8, 129, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 10, 58, 0),
            new UniformModel(0, FACTION_SAMCRO, SEX_FEMALE, 11, 250, 0),




            // Male paramedic uniform
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 0, -1, -1),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 1, 0, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 3, 90, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 4, 96, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 5, -1, -1),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 6, 51, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 7, 126, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 10, 57, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_MALE, 11,249, 0),

            // Female paramedic uniform
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 0, -1, -1),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 1, 0, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 3, 85, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 4, 96, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 5, -1, -1),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 6, 51, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 7, 127, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 8, 129, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 10, 58, 0),
            new UniformModel(0, FACTION_EMERGENCY, SEX_FEMALE, 11, 250, 0),

            // Male BALLAS uniform
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 0, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 1, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 3, 5, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 4, 5, 9),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 5, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 6, 9, 1),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 7, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 10, -1, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_MALE, 11,237,11),

            // Female BALLAS uniform
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 0, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 1, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 3, 85, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 4, 96, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 5, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 6, 51, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 7, -1, -1),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 8, 129, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 10, 58, 0),
            new UniformModel(0, FACTION_BALLAS, SEX_FEMALE, 11, 250, 0),
            
            // Male GROVE uniform
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 0, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 1, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 2, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 3, 5, 0),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 4, 27, 10),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 5, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 6, 9, 1),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 7, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 8, 15, 0),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 9, 0, 0),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 10, -1, 0),
            new UniformModel(0, FACTION_GROVE, SEX_MALE, 11,237,14),

            // Female GROVE uniform
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 0, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 1, -1, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 2, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 3, 85, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 4, 96, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 5, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 6, 51, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 7, -1, -1),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 8, 129, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 9, 0, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 10, 58, 0),
            new UniformModel(0, FACTION_GROVE, SEX_FEMALE, 11, 250, 0),
        };



        // Jail positions
        public static List<Position> JAIL_SPAWNS = new List<Position>
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
        public const int INVENTORY_TARGET_SELF = 0;
        public const int INVENTORY_TARGET_PLAYER = 1;
        public const int INVENTORY_TARGET_HOUSE = 2;
        public const int INVENTORY_TARGET_VEHICLE_TRUNK = 3;
        public const int INVENTORY_TARGET_VEHICLE_PLAYER = 4;


        // Business sellable items
        public static List<BusinessItemModel> BUSINESS_ITEM_LIST = new List<BusinessItemModel>
        {
            // 24-7
            new BusinessItemModel("Benzinkannister", ITEM_HASH_BENZINKANNISTER, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Tankstellen Snack", ITEM_HASH_TANKSTELLENSNACK, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Lebkuchenmännchen", ITEM_HASH_LEBKUCHENMAENNCHEN, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Cookies", ITEM_HASH_COOKIES, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Schokolade", ITEM_HASH_SCHOKOLADE, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Spareribs", ITEM_HASH_SPARERIPS, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Lebkuchenmännchen", ITEM_HASH_TANKSTELLENSNACK, ITEM_TYPE_CONSUMABLE, 60, 0.1f, 0, 1, new Position(0.0f, 0.0f, 0.0f), new Rotation(0.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Glühwein", ITEM_HASH_GLUEHWEIN, ITEM_TYPE_CONSUMABLE, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Milch", ITEM_HASH_MILCH, ITEM_TYPE_CONSUMABLE, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Heiße Schokolade", ITEM_HASH_HEISSESCHOKOLADE, ITEM_TYPE_CONSUMABLE, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Schokolade", ITEM_HASH_SCHOKOLADE, ITEM_TYPE_CONSUMABLE, 5, 0.1f, 10, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(180.0f, 180.0f, 90.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Kokain", ITEM_HASH_KOKS, ITEM_TYPE_CONSUMABLE, 8, 0.1f, -2, 1, new Position(0.06f, 0.0f, -0.02f), new Rotation(270.0f, 0.0f, 0.0f), BUSINESS_TYPE_24_7, 0.0f),
            new BusinessItemModel("Gras", ITEM_HASH_WEED, ITEM_TYPE_CONSUMABLE, 5, 0.1f, 5, 1, new Position(0.05f, -0.03f, 0.0f), new Rotation(270.0f, 20.0f, -20.0f), BUSINESS_TYPE_24_7, 0.0f),
        };

        // Clothes list
        public static List<BusinessClothesModel> BUSINESS_CLOTHES_LIST = new List<BusinessClothesModel>
        {
            // Masks

           	//new BusinessClothesModel(0, "Schwein", CLOTHES_MASK, 1, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Totenkopf", CLOTHES_MASK, 2, SEX_NONE, 3500),
            //new BusinessClothesModel(0, "Affe", CLOTHES_MASK, 3, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Hockey", CLOTHES_MASK, 4, SEX_NONE, 3500),
            /*new BusinessClothesModel(0, "Anderer Affe", CLOTHES_MASK, 5, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Farbiges Lächeln", CLOTHES_MASK, 6, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Gárgola", CLOTHES_MASK, 7, SaEX_NONE, 0),
            new BusinessClothesModel(0, "Santa", CLOTHES_MASK, 8, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Reno", CLOTHES_MASK, 9, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Frosty", CLOTHES_MASK, 10, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Antifaz", CLOTHES_MASK, 11, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Pinocho veneciano", CLOTHES_MASK, 12, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Cupido", CLOTHES_MASK, 13, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Hockey (Blau)", CLOTHES_MASK, 14, SEX_NONE, 3500),
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
            new BusinessClothesModel(0, "Hockey (Jason)", CLOTHES_MASK, 30, SEX_NONE, 3500),
            /*new BusinessClothesModel(0, "Pingüino", CLOTHES_MASK, 31, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Media roja", CLOTHES_MASK, 32, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Jengibre feliz", CLOTHES_MASK, 33, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Duende", CLOTHES_MASK, 34, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Sturmhaube", CLOTHES_MASK, 35, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Sturmhaube (Strumpf)", CLOTHES_MASK, 37, SEX_NONE, 3500),
            /*new BusinessClothesModel(0, "Zombie", CLOTHES_MASK, 39, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Momia", CLOTHES_MASK, 40, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Vampiro", CLOTHES_MASK, 41, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Reconstruído", CLOTHES_MASK, 42, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Superhéroe", CLOTHES_MASK, 43, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Waifu", CLOTHES_MASK, 44, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Detective", CLOTHES_MASK, 45, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Polizeibandc", CLOTHES_MASK, 47, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Tape", CLOTHES_MASK, 48, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Papiertüte", CLOTHES_MASK, 49, SEX_NONE, 3500),
            //new BusinessClothesModel(0, "Estatua", CLOTHES_MASK, 50, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Bandana", CLOTHES_MASK, 51, SEX_NONE, 3500),
            /*new BusinessClothesModel(0, "Capucha", CLOTHES_MASK, 53, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Camiseta", CLOTHES_MASK, 54, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Gorro", CLOTHES_MASK, 55, SEX_NONE, 3500),
            new BusinessClothesModel(0, "Pasamontañas azul", CLOTHES_MASK, 56, SEX_NONE, 3500),*/
            new BusinessClothesModel(0, "Sturmhaube (Wolle)", CLOTHES_MASK, 57, SEX_NONE, 3500),
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
                
            new BusinessClothesModel(0, "Dunkle schmale Jeans", CLOTHES_LEGS, 0, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Dunkle weite Jeans", CLOTHES_LEGS, 1, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Weiße Jogginghose", CLOTHES_LEGS, 2, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", CLOTHES_LEGS, 3, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Cowyboy Hose", CLOTHES_LEGS, 4, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Bermudashorts", CLOTHES_LEGS, 5, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", CLOTHES_LEGS, 6, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarzer Rock", CLOTHES_LEGS, 7, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarzer Minirock", CLOTHES_LEGS, 8, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Gemusterter Minirock", CLOTHES_LEGS, 9, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Kurze Sporthose (Weiß)", CLOTHES_LEGS, 10, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Braune Cowboy Hose", CLOTHES_LEGS, 11, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Karierter Minirock", CLOTHES_LEGS, 12, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Shorts (Blau)", CLOTHES_LEGS, 14, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarzer Bikini", CLOTHES_LEGS, 15, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Shorts (Gelb)", CLOTHES_LEGS, 16, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Weißer Bikini", CLOTHES_LEGS, 17, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Roter Rock", CLOTHES_LEGS, 18, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Weißer Slip", CLOTHES_LEGS, 19, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Weißer Slip mit Strumpfhose", CLOTHES_LEGS, 20, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Roter Bikini", CLOTHES_LEGS, 21, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Weiße Hose", CLOTHES_LEGS, 23, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Comic Rock", CLOTHES_LEGS, 24, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Hot Pants", CLOTHES_LEGS, 25, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Leoparden Minirock", CLOTHES_LEGS, 26, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Latex Hose", CLOTHES_LEGS, 27, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Rot, weißer Minirock", CLOTHES_LEGS, 28, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Graue Hose mit Griffen", CLOTHES_LEGS, 29, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Lockere Schwarze Hose", CLOTHES_LEGS, 30, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Rote Leggings", CLOTHES_LEGS, 31, SEX_FEMALE, 5500),
            //new BusinessClothesModel(0, "ancho negro con rodilleras", CLOTHES_LEGS, 33, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Normale schwarze Hose", CLOTHES_LEGS, 34, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Hose mit Reflektoren", CLOTHES_LEGS, 35, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Grauer Rock", CLOTHES_LEGS, 36, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Stoffhose", CLOTHES_LEGS, 37, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Rote Stoffhose", CLOTHES_LEGS, 38, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Graue Stoffhose", CLOTHES_LEGS, 41, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose mir Griffen", CLOTHES_LEGS, 42, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose mit rissen (Vorne)", CLOTHES_LEGS, 43, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose mit rissen (Seite)", CLOTHES_LEGS, 44, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Militärische grüne Hose", CLOTHES_LEGS, 45, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Seidenhose", CLOTHES_LEGS, 47, SEX_FEMALE, 5500),
            //new BusinessClothesModel(0, "ancho marron rodilleras cinturon negro", CLOTHES_LEGS, 48, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Braune Hose", CLOTHES_LEGS, 49, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Beige Hose", CLOTHES_LEGS, 50, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Beige Leggings", CLOTHES_LEGS, 51, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Violette Hose", CLOTHES_LEGS, 52, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Dunkel gemusterte Hose", CLOTHES_LEGS, 53, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Violette Leggings", CLOTHES_LEGS, 54, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Dunkel gemusterte Leggings", CLOTHES_LEGS, 55, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Rosa Bikini", CLOTHES_LEGS, 56, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Weißer Rock", CLOTHES_LEGS, 57, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Jogginghose", CLOTHES_LEGS, 58, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Rot karierte Schlafhose", CLOTHES_LEGS, 60, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Pinker Slip", CLOTHES_LEGS, 62, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Pinker Slip mit Strumpfhose", CLOTHES_LEGS, 63, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Hellbraune Hose", CLOTHES_LEGS, 64, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Blaue Jogginghose", CLOTHES_LEGS, 66, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Hellblaue Schlafhose", CLOTHES_LEGS, 67, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarz, Graue Jogginghose", CLOTHES_LEGS, 68, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Totenkopf Schlafhose", CLOTHES_LEGS, 71, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Blaue Cowboy Hose", CLOTHES_LEGS, 73, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Blaue zerissene Jeans", CLOTHES_LEGS, 74, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Cowboy Hose", CLOTHES_LEGS, 75, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Blaue Hotpants mit Strumpfhose", CLOTHES_LEGS, 78, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Dunkelbraune Trainingshose", CLOTHES_LEGS, 80, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Schwarze Trainingshose", CLOTHES_LEGS, 81, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Kurze dunkelbraune Trainingshose", CLOTHES_LEGS, 82, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Trainingshose", CLOTHES_LEGS, 83, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Camouflage Leggings (Schwarz, Grau)", CLOTHES_LEGS, 87, SEX_FEMALE, 5500),
            //new BusinessClothesModel(0, "leggins rayas Rgbaes fosforitos", CLOTHES_LEGS, 88, SEX_FEMALE, 5500),
            //Neu hinzugefügt//
            new BusinessClothesModel(0, "Camouflage Hose (Blau)", CLOTHES_LEGS, 89, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Kurze camouflage Hose (Blau)", CLOTHES_LEGS, 91, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Blaue Hose", CLOTHES_LEGS, 103, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Gemusterte Hose", CLOTHES_LEGS, 104, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Grüne Hose", CLOTHES_LEGS, 105, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Orangene zerissene Hose", CLOTHES_LEGS, 106, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Gelbe Shorts", CLOTHES_LEGS, 107, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Bunter Minirock", CLOTHES_LEGS, 108, SEX_FEMALE, 5500),
            new BusinessClothesModel(0, "Hellblaue Hose", CLOTHES_LEGS, 111, SEX_FEMALE, 5500),
 
                
                
            // Male pants
                
            new BusinessClothesModel(0, "Blaue Jeans", CLOTHES_LEGS, 0, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Jeans", CLOTHES_LEGS, 1, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze karierte Shorts", CLOTHES_LEGS, 2, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weiße Stoffhose", CLOTHES_LEGS, 3, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Enge schwarze Jeans", CLOTHES_LEGS, 4, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weiße JogginghosePimm", CLOTHES_LEGS, 5, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze weiße Hose", CLOTHES_LEGS, 6, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weite schwarze Hose", CLOTHES_LEGS, 7, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weite graue Hose", CLOTHES_LEGS, 8, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weite graue Hose mit Taschen", CLOTHES_LEGS, 9, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Stoffhose", CLOTHES_LEGS, 10, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Shorts", CLOTHES_LEGS, 12, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", CLOTHES_LEGS, 13, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze Badehose (Blau)", CLOTHES_LEGS, 14, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze beige Hose", CLOTHES_LEGS, 15, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Badehose (Blau, Pink)", CLOTHES_LEGS, 16, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze braune Hose", CLOTHES_LEGS, 17, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze Badehose (Gelb)", CLOTHES_LEGS, 18, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Rote Hose", CLOTHES_LEGS, 19, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weiße Hose", CLOTHES_LEGS, 20, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Boxershorts mit Herzen", CLOTHES_LEGS, 21, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Graue Hose", CLOTHES_LEGS, 22, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "pitillo negro", CLOTHES_LEGS, 24, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "normal negro hebilla negra", CLOTHES_LEGS, 25, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Hose", CLOTHES_LEGS, 26, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Gelbe Hose", CLOTHES_LEGS, 27, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Rot, weiß gestreifte Hose", CLOTHES_LEGS, 29, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ancho verde oscuro agarres", CLOTHES_LEGS, 30, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "pitillo negro ancho", CLOTHES_LEGS, 31, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Lange rote Unterhose", CLOTHES_LEGS, 32, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ancho negro rodilleras", CLOTHES_LEGS, 34, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Graue Hose mit Reflektoren", CLOTHES_LEGS, 36, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Graue Stoffhose", CLOTHES_LEGS, 37, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ancho rojo oscuro", CLOTHES_LEGS, 38, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ancho negro agarres", CLOTHES_LEGS, 41, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Hose", CLOTHES_LEGS, 42, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Jeans", CLOTHES_LEGS, 43, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Schlafhose", CLOTHES_LEGS, 45, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ancho marron rodilleras", CLOTHES_LEGS, 46, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Braune Hose", CLOTHES_LEGS, 47, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weite beige Hose", CLOTHES_LEGS, 48, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Enge beige Hose", CLOTHES_LEGS, 49, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Rote Hose", CLOTHES_LEGS, 50, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Gemusterte Hose", CLOTHES_LEGS, 51, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Enge rote Hose", CLOTHES_LEGS, 52, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Enge gemusterte Hose", CLOTHES_LEGS, 53, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Blau gemusterte Shorts", CLOTHES_LEGS, 54, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Jogginghose", CLOTHES_LEGS, 55, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "falda blanca lazo", CLOTHES_LEGS, 56, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Rot karierte Schlafhose", CLOTHES_LEGS, 58, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Blau gemusterte Schlafhose", CLOTHES_LEGS, 60, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weiße Boxershorts", CLOTHES_LEGS, 61, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Hose", CLOTHES_LEGS, 62, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Weite Jeans", CLOTHES_LEGS, 63, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Blaue Jogginghose", CLOTHES_LEGS, 64, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Hellblaue Schlafhose", CLOTHES_LEGS, 65, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "chandal negro y blanco", CLOTHES_LEGS, 66, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Totenkopf Schlafhose", CLOTHES_LEGS, 69, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "cuero negro", CLOTHES_LEGS, 71, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Blaue Cowboy Hose", CLOTHES_LEGS, 75, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Zerissene Jeans", CLOTHES_LEGS, 76, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "pitillo con motivos fosforito", CLOTHES_LEGS, 77, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Braune Schlafhose", CLOTHES_LEGS, 78, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Schwarze Schlafhose", CLOTHES_LEGS, 79, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze braune Schlafhose", CLOTHES_LEGS, 80, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze schwarze Schlafhose", CLOTHES_LEGS, 81, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "vaquero oscuro pitillo", CLOTHES_LEGS, 82, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "pitillo negro", CLOTHES_LEGS, 83, SEX_MALE, 5500),
            //new BusinessClothesModel(0, "ajustado con motivos Rgbaidos", CLOTHES_LEGS, 85, SEX_MALE, 5500),
            //Neu hinzugefügt//
            new BusinessClothesModel(0, "Camouflage Hose (blau)", CLOTHES_LEGS, 86, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Kurze camouflage Hose (blau)", CLOTHES_LEGS, 88, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Blaue Hose", CLOTHES_LEGS, 99, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Gemusterte Hose", CLOTHES_LEGS, 100, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Grüne Hose", CLOTHES_LEGS, 101, SEX_MALE, 5500),
            new BusinessClothesModel(0, "Hellblaue Hose", CLOTHES_LEGS, 104, SEX_MALE, 5500),
 
                
                
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
                
            new BusinessClothesModel(0, "Schwarze Pumps (Abgerundet)", CLOTHES_FEET, 0, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Weiße Sneaker", CLOTHES_FEET, 1, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Beige Boots", CLOTHES_FEET, 2, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Converse", CLOTHES_FEET, 3, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Sneaker", CLOTHES_FEET, 4, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Flip Flops", CLOTHES_FEET, 5, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Pumps (Spitz)", CLOTHES_FEET, 6, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefeletten", CLOTHES_FEET, 7, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze offene Stiefeletten", CLOTHES_FEET, 8, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", CLOTHES_FEET, 9, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarz, Lilane Sneaker", CLOTHES_FEET, 10, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Weiß, Lilane Sneaker", CLOTHES_FEET, 11, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Ballerina", CLOTHES_FEET, 13, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze offene Pumps", CLOTHES_FEET, 14, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Sandalen", CLOTHES_FEET, 15, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Graue Flip Flops", CLOTHES_FEET, 16, SEX_FEMALE, 4500),
            //new BusinessClothesModel(0, "Duende verde", CLOTHES_FEET, 17, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Graue Pumps", CLOTHES_FEET, 18, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Pumps", CLOTHES_FEET, 19, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Leoparden Pumps", CLOTHES_FEET, 20, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Gelbe Stiefel", CLOTHES_FEET, 21, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Boots", CLOTHES_FEET, 22, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Blaue Pumps", CLOTHES_FEET, 23, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Boots", CLOTHES_FEET, 24, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Boots mit Schnürsenkel", CLOTHES_FEET, 25, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Turnschuhe", CLOTHES_FEET, 27, SEX_FEMALE, 4500),
            //new BusinessClothesModel(0, "Zapatillas negra marca lateral", CLOTHES_FEET, 28, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", CLOTHES_FEET, 29, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Hohe schwarze Pumps", CLOTHES_FEET, 30, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Sneaker", CLOTHES_FEET, 31, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiß, gelbe Turnschuhe", CLOTHES_FEET, 32, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Gelb, weiße Converse mit Strumpf", CLOTHES_FEET, 33, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Barfuß", CLOTHES_FEET, 35, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", CLOTHES_FEET, 36, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Clocks", CLOTHES_FEET, 37, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Hohe schwarze Cowboy Stiefel", CLOTHES_FEET, 38, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Cowboy Stiefel", CLOTHES_FEET, 39, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Rosa Pumps", CLOTHES_FEET, 42, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Gelbe Stiefeletten", CLOTHES_FEET, 43, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Gelb, schwarze Stiefeletten", CLOTHES_FEET, 44, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Hohe blaue Cowboy Stiefel", CLOTHES_FEET, 45, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Blaue Cowboy Stiefe", CLOTHES_FEET, 46, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Weiß, blaue Turnschuhe", CLOTHES_FEET, 47, SEX_FEMALE, 4500),
            //new BusinessClothesModel(0, "Botas verde y negro", CLOTHES_FEET, 48, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Converse (hoch)", CLOTHES_FEET, 49, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Gelbe Converse (hoch)", CLOTHES_FEET, 50, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Graue Boots", CLOTHES_FEET, 51, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Graue Schuhe", CLOTHES_FEET, 52, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Boots", CLOTHES_FEET, 53, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Boots mit Schnürsenkel", CLOTHES_FEET, 54, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", CLOTHES_FEET, 55, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", CLOTHES_FEET, 56, SEX_FEMALE, 4500),
            //new BusinessClothesModel(0, "Normal negra hebilla", CLOTHES_FEET, 57, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Schwarze Turnschuhe mit gelben Strichen", CLOTHES_FEET, 58, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Clocks", CLOTHES_FEET, 59, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Kamelschuhe", CLOTHES_FEET, 60, SEX_FEMALE, 4500),
            //new BusinessClothesModel(0, "Plano negro rayas rosa y celeste", CLOTHES_FEET, 61, SEX_FEMALE, 4500),
            //Neue Schuhe//
            new BusinessClothesModel(0, "Blaue camouflage Sneaker", CLOTHES_FEET, 62, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Braune Boots mit Schnürsenkel", CLOTHES_FEET, 68, SEX_FEMALE, 4500),
            new BusinessClothesModel(0, "Weiß, gelbe Socken", CLOTHES_FEET, 87, SEX_FEMALE, 4500),
 
                
                
            // Male shoes
                
            new BusinessClothesModel(0, "Karierte Boots", CLOTHES_FEET, 0, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Converse", CLOTHES_FEET, 1, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Karierte Sneaker", CLOTHES_FEET, 2, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, graue Lederschuhe", CLOTHES_FEET, 3, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Blau, weiße Converse (Hoch)", CLOTHES_FEET, 4, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiße Flip Flops", CLOTHES_FEET, 5, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Sandallen mit weißen Socken", CLOTHES_FEET, 6, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiße Sneaker mit Socken", CLOTHES_FEET, 7, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiß, schwarze Sneaker mit Socken", CLOTHES_FEET, 9, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Leaderschuhe mit Socken", CLOTHES_FEET, 10, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", CLOTHES_FEET, 12, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Graue Stiefel", CLOTHES_FEET, 14, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", CLOTHES_FEET, 15, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Flip Flops", CLOTHES_FEET, 16, SEX_MALE, 4500),
            //new BusinessClothesModel(0, "Duende verde", CLOTHES_FEET, 17, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Schuhe mit Socken", CLOTHES_FEET, 18, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiß, schwarze Lederschuhe", CLOTHES_FEET, 19, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune Lederschuhe", CLOTHES_FEET, 20, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", CLOTHES_FEET, 21, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Hellblaue Converse (Hoch)", CLOTHES_FEET, 22, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune, gelbe Schuhe", CLOTHES_FEET, 23, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", CLOTHES_FEET, 24, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel mit Schnürsenkel", CLOTHES_FEET, 25, SEX_MALE, 4500),
            //new BusinessClothesModel(0, "Converse azul oscuro tobillo alto", CLOTHES_FEET, 26, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiße Stiefel mit Spikes", CLOTHES_FEET, 28, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", CLOTHES_FEET, 29, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Schuhe", CLOTHES_FEET, 30, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiß, gelbe Turnschuhe", CLOTHES_FEET, 31, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarz, weiße Stiefel", CLOTHES_FEET, 32, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Barfuß", CLOTHES_FEET, 34, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Graue Stiefel", CLOTHES_FEET, 35, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune Schuhe", CLOTHES_FEET, 36, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Cowboy Stiefel", CLOTHES_FEET, 37, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Cowboy Stiefel (Niedrig)", CLOTHES_FEET, 38, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Blaue Schuhe mit Socken", CLOTHES_FEET, 40, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Rot, schwarze Schuhe", CLOTHES_FEET, 41, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Graue Sneaker", CLOTHES_FEET, 42, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Gelbe Boots", CLOTHES_FEET, 43, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Türkise Cowboy Stiefel", CLOTHES_FEET, 44, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Türkise Cowboy Stiefel (Niedrig)", CLOTHES_FEET, 45, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Blau, weiße Schuhe", CLOTHES_FEET, 46, SEX_MALE, 4500),
            //new BusinessClothesModel(0, "Bota alta verde y blanca", CLOTHES_FEET, 47, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Converse (Hoch)", CLOTHES_FEET, 48, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Gelbe Converse (Hoch)", CLOTHES_FEET, 49, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", CLOTHES_FEET, 50, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", CLOTHES_FEET, 51, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune Stiefel", CLOTHES_FEET, 52, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Stiefel", CLOTHES_FEET, 53, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe", CLOTHES_FEET, 54, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Schwarze Schuhe mit gelben Strichen", CLOTHES_FEET, 55, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Braune Schuhe", CLOTHES_FEET, 56, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Beige Schuhe", CLOTHES_FEET, 57, SEX_MALE, 4500),
            //new BusinessClothesModel(0, "Plano negro rayas rojas y celestes", CLOTHES_FEET, 58, SEX_MALE, 4500),
            //Neue Schuhe//
            new BusinessClothesModel(0, "Türkise Sneaker", CLOTHES_FEET, 74, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiß, lilane Sneaker", CLOTHES_FEET, 75, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiß, türkise LED Sneaker", CLOTHES_FEET, 77, SEX_MALE, 4500),
            new BusinessClothesModel(0, "Weiß, gelbe Socken", CLOTHES_FEET, 83, SEX_MALE, 4500),
 
                
                
            // Female accessories
                
            new BusinessClothesModel(0, "Goldene breite Creolen", CLOTHES_ACCESSORIES, 1, SEX_FEMALE, 30000),
            new BusinessClothesModel(0, "Goldene schmale Creolen", CLOTHES_ACCESSORIES, 2, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Schwarzes Armband (Rechts)", CLOTHES_ACCESSORIES, 3, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Kariertes Armband (Rechts)", CLOTHES_ACCESSORIES, 4, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Karierte Armringe (Rechts)", CLOTHES_ACCESSORIES, 5, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Hufeisenanhänger aus dunkelgoldenem Edelstein", CLOTHES_ACCESSORIES, 6, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Hängende Schwarz- und Goldseile mit Kreis und goldenem Herzen", CLOTHES_ACCESSORIES, 7, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarzweiss Palästina", CLOTHES_ACCESSORIES, 9, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Buntes Armband", CLOTHES_ACCESSORIES, 10, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Anhänger schwarz und gold Seil mit goldenem Kreis und dunklem Herzen", CLOTHES_ACCESSORIES, 11, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Perlen Kette", CLOTHES_ACCESSORIES, 12, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarzes, weiß gepunktetes Halstuch", CLOTHES_ACCESSORIES, 13, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Metall Armband", CLOTHES_ACCESSORIES, 14, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Roter Palästina", CLOTHES_ACCESSORIES, 15, SEX_FEMALE, 10000),
            //new BusinessClothesModel(0, "Bufanda buscando a Wally", CLOTHES_ACCESSORIES, 17, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege (Wild)", CLOTHES_ACCESSORIES, 19, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Krawatte (Wild)", CLOTHES_ACCESSORIES, 20, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Weiße Krawatte", CLOTHES_ACCESSORIES, 21, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Krawatte", CLOTHES_ACCESSORIES, 22, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege", CLOTHES_ACCESSORIES, 23, SEX_FEMALE, 10000),
            //new BusinessClothesModel(0, "", CLOTHES_ACCESSORIES, 24, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Goldkette mit Anhänger G", CLOTHES_ACCESSORIES, 29, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkette Anhänger Totenkopf Gold rote Augen", CLOTHES_ACCESSORIES, 30, SEX_FEMALE, 30000),
            new BusinessClothesModel(0, "Silberkette Anhänger Totenkopf Silber rote Augen", CLOTHES_ACCESSORIES, 31, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldplatte Goldkette", CLOTHES_ACCESSORIES, 32, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkette mit €", CLOTHES_ACCESSORIES, 33, SEX_FEMALE, 40000),
            new BusinessClothesModel(0, "Silberkette Silberanhänger", CLOTHES_ACCESSORIES, 34, SEX_FEMALE, 15000),
            new BusinessClothesModel(0, "Gold breite goldene Anhänger Kette", CLOTHES_ACCESSORIES, 35, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkette mit $ (Außen)", CLOTHES_ACCESSORIES, 36, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Goldkette mit Totenkopf", CLOTHES_ACCESSORIES, 37, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Silberkette mit Sturmmaske (Außen)", CLOTHES_ACCESSORIES, 38, SEX_FEMALE, 15000),
            new BusinessClothesModel(0, "Goldkette Anhänger Platte Silber (Außen)", CLOTHES_ACCESSORIES, 39, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger C (Außen)", CLOTHES_ACCESSORIES, 40, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger DIX (Außen)", CLOTHES_ACCESSORIES, 41, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger Goldbuchstaben (Außen)", CLOTHES_ACCESSORIES, 42, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Leichte Goldkette ohne Anhänger", CLOTHES_ACCESSORIES, 53, SEX_FEMALE, 25000),
            new BusinessClothesModel(0, "Goldkette ohne Anhänger", CLOTHES_ACCESSORIES, 54, SEX_FEMALE, 25000),
            //new BusinessClothesModel(0, "Cadena oro ancha", CLOTHES_ACCESSORIES, 55, SEX_FEMALE, 10000),
            //new BusinessClothesModel(0, "Cadena oro claro ancha", CLOTHES_ACCESSORIES, 56, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Brauner Palästina", CLOTHES_ACCESSORIES, 83, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Perlenkette", CLOTHES_ACCESSORIES, 84, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Rote Kopfhörer", CLOTHES_ACCESSORIES, 85, SEX_FEMALE, 10000),
            //new BusinessClothesModel(0, "Corbata azul y rosa", CLOTHES_ACCESSORIES, 86, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Grüne Krawatte", CLOTHES_ACCESSORIES, 87, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Schwarze Hosenträger", CLOTHES_ACCESSORIES, 88, SEX_FEMALE, 10000),
            new BusinessClothesModel(0, "Goldkette mit rotem Stern", CLOTHES_ACCESSORIES, 89, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkette mit rotem Stern (Außen)", CLOTHES_ACCESSORIES, 90, SEX_FEMALE, 20000),
            new BusinessClothesModel(0, "Goldkette mit goldenem Stern", CLOTHES_ACCESSORIES, 91, SEX_FEMALE, 30000),
            new BusinessClothesModel(0, "Goldkette mit goldenem Stern (Außen)", CLOTHES_ACCESSORIES, 92, SEX_FEMALE, 30000),
            new BusinessClothesModel(0, "Hellbraune Perlenkette", CLOTHES_ACCESSORIES, 93, SEX_FEMALE, 15000),
            new BusinessClothesModel(0, "Blaue Kopfhörer", CLOTHES_ACCESSORIES, 94, SEX_FEMALE, 10000),
 
                
                
            // Male accessories
                
            new BusinessClothesModel(0, "Weiße breite Krawatte", CLOTHES_ACCESSORIES, 10, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Karierte Fliege", CLOTHES_ACCESSORIES, 11, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Weiße schmale Krawatte", CLOTHES_ACCESSORIES, 12, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Silberkette", CLOTHES_ACCESSORIES, 16, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Silberkette (Außen)", CLOTHES_ACCESSORIES, 17, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Rote breite Krawatte", CLOTHES_ACCESSORIES, 18, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Rote schmale Krawatte", CLOTHES_ACCESSORIES, 19, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Dunkelrote Krawatte (Kurz)", CLOTHES_ACCESSORIES, 20, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Blaue breite Krawatte", CLOTHES_ACCESSORIES, 21, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Weiße Fliege", CLOTHES_ACCESSORIES, 22, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Blaue schmale Krawatte", CLOTHES_ACCESSORIES, 23, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Weiße breite Krawatte (Kurz)", CLOTHES_ACCESSORIES, 24, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Weiße schmale Krawatte (Kurz)", CLOTHES_ACCESSORIES, 25, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Weißer Schal", CLOTHES_ACCESSORIES, 30, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Rot, weiß, blaue Fliege", CLOTHES_ACCESSORIES, 32, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Rot, weißer Schal", CLOTHES_ACCESSORIES, 34, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege", CLOTHES_ACCESSORIES, 36, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Breite schwarze Krawatte (Wild)", CLOTHES_ACCESSORIES, 37, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Breite schwarze Krawatte (Angepasst)", CLOTHES_ACCESSORIES, 38, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Breite schwarze Krawatte (Lose)", CLOTHES_ACCESSORIES, 39, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger NS", CLOTHES_ACCESSORIES, 42, SEX_MALE, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger Totenkopf", CLOTHES_ACCESSORIES, 43, SEX_MALE, 20000),
            new BusinessClothesModel(0, "Silberkettenanhänger Sturmmaske", CLOTHES_ACCESSORIES, 44, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger Platte", CLOTHES_ACCESSORIES, 45, SEX_MALE, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger LC", CLOTHES_ACCESSORIES, 46, SEX_MALE, 30000),
            new BusinessClothesModel(0, "Goldmedaillon", CLOTHES_ACCESSORIES, 47, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Maskierter Silberkettenanhänger", CLOTHES_ACCESSORIES, 51, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Goldkette", CLOTHES_ACCESSORIES, 74, SEX_MALE, 35000),
            new BusinessClothesModel(0, "Goldkette (Außen)", CLOTHES_ACCESSORIES, 75, SEX_MALE, 32500),
            //new BusinessClothesModel(0, "Dunkel Goldkette", CLOTHES_ACCESSORIES, 76, SEX_MALE, 40000),
            //new BusinessClothesModel(0, "Cadena grande clara", CLOTHES_ACCESSORIES, 85, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Dunkler Schal", CLOTHES_ACCESSORIES, 112, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Halskette Perlen braun", CLOTHES_ACCESSORIES, 113, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Rote Kopfhörer", CLOTHES_ACCESSORIES, 114, SEX_MALE, 10000),
            //new BusinessClothesModel(0, "Corbata azul y rosa", CLOTHES_ACCESSORIES, 115, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Grüne schmale Krawatte", CLOTHES_ACCESSORIES, 117, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Schwarze Fliege", CLOTHES_ACCESSORIES, 118, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Goldkettenanhänger roter Stern", CLOTHES_ACCESSORIES, 119, SEX_MALE, 25000),
            new BusinessClothesModel(0, "Goldkettenanhänger goldener Stern", CLOTHES_ACCESSORIES, 120, SEX_MALE, 30000),
            new BusinessClothesModel(0, "Goldkettenanhänger roter Stern (Außen)", CLOTHES_ACCESSORIES, 121, SEX_MALE, 20000),
            new BusinessClothesModel(0, "Goldkettenanhänger goldener Stern (Außen)", CLOTHES_ACCESSORIES, 122, SEX_MALE, 30000),
            new BusinessClothesModel(0, "Perlenkette hellbraun", CLOTHES_ACCESSORIES, 123, SEX_MALE, 10000),
            new BusinessClothesModel(0, "Blaue Kopfhörer", CLOTHES_ACCESSORIES, 124, SEX_MALE, 10000),
 
                
                
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
            new BusinessClothesModel(0, "Ohne Handschuhe", CLOTHES_TORSO, 0, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 2", CLOTHES_TORSO, 1, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 3", CLOTHES_TORSO, 2, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 4", CLOTHES_TORSO, 3, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 5", CLOTHES_TORSO, 5, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 6", CLOTHES_TORSO, 6, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 7", CLOTHES_TORSO, 7, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 8", CLOTHES_TORSO, 10, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 9", CLOTHES_TORSO, 12, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 10", CLOTHES_TORSO, 13, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 11", CLOTHES_TORSO, 14, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 12", CLOTHES_TORSO, 131, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 13", CLOTHES_TORSO, 161, SEX_FEMALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 14", CLOTHES_TORSO, 130, SEX_FEMALE, 250),
 
                
                
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
            new BusinessClothesModel(0, "Ohne Handschuhe", CLOTHES_TORSO, 0, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 2", CLOTHES_TORSO, 0, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 3", CLOTHES_TORSO, 1, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 4", CLOTHES_TORSO, 2, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 5", CLOTHES_TORSO, 3, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 6", CLOTHES_TORSO, 4, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 7", CLOTHES_TORSO, 5, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 8", CLOTHES_TORSO, 6, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 9", CLOTHES_TORSO, 7, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 10", CLOTHES_TORSO, 8, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 11", CLOTHES_TORSO, 9, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 12", CLOTHES_TORSO, 10, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 13", CLOTHES_TORSO, 11, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 14", CLOTHES_TORSO, 12, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 15", CLOTHES_TORSO, 13, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 16", CLOTHES_TORSO, 14, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 17", CLOTHES_TORSO, 15, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 18", CLOTHES_TORSO, 112, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 19", CLOTHES_TORSO, 113, SEX_MALE, 250),
            new BusinessClothesModel(0, "Ohne Handschuhe 20", CLOTHES_TORSO, 114, SEX_MALE, 250),
 
                
                
            // Female tops
                
            new BusinessClothesModel(0, "Graues Shirt", CLOTHES_TOPS, 0, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke", CLOTHES_TOPS, 1, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Locker)", CLOTHES_TOPS, 2, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graue Strickjacke", CLOTHES_TOPS, 3, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Kariertes Tanktop", CLOTHES_TOPS, 4, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Tanktop", CLOTHES_TOPS, 5, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", CLOTHES_TOPS, 6, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket", CLOTHES_TOPS, 7, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Dunkelgraue Jacke", CLOTHES_TOPS, 8, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd (Hochgekrempelt)", CLOTHES_TOPS, 9, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Joggingjacke", CLOTHES_TOPS, 10, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Sport Tanktop", CLOTHES_TOPS, 11, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Kariertes Tanktop (Locker)", CLOTHES_TOPS, 12, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Trägerloses-Top", CLOTHES_TOPS, 13, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Hemd-Shirt", CLOTHES_TOPS, 14, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer BH", CLOTHES_TOPS, 15, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rotes Tanktop", CLOTHES_TOPS, 16, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Urlaubs Hemd", CLOTHES_TOPS, 17, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißer BH", CLOTHES_TOPS, 18, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 19, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, weißes Jacket", CLOTHES_TOPS, 20, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Lilanes Kleid", CLOTHES_TOPS, 21, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißer Dessous", CLOTHES_TOPS, 22, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 23, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grau, schwarzes Jacket", CLOTHES_TOPS, 24, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rotes Jacket", CLOTHES_TOPS, 25, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes oberteil", CLOTHES_TOPS, 26, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Hemd (Kurzärmlig)", CLOTHES_TOPS, 27, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graue Weste", CLOTHES_TOPS, 28, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 29, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 30, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau, schwarze Jeansjacke", CLOTHES_TOPS, 31, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Leoparden Tanktop", CLOTHES_TOPS, 32, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Oberteil", CLOTHES_TOPS, 33, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Camouflage Jacket", CLOTHES_TOPS, 34, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gelbe Jacke", CLOTHES_TOPS, 35, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Tanktop", CLOTHES_TOPS, 36, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Blumenkleid", CLOTHES_TOPS, 37, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grünes Shirt (Locker)", CLOTHES_TOPS, 38, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 39, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaues Shirt (Locker)", CLOTHES_TOPS, 40, SEX_FEMALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 41, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 42, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 43, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 44, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 45, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 46, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 47, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 48, SEX_FEMALE, 5900),*/
            new BusinessClothesModel(0, "Dunkelgraues Tshirt", CLOTHES_TOPS, 49, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 50, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 51, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Jacket (Offen)", CLOTHES_TOPS, 52, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Jacket (Geschlossen)", CLOTHES_TOPS, 53, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 54, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 55, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd (Hochgekrempelt)", CLOTHES_TOPS, 56, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Offen)", CLOTHES_TOPS, 57, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Geschlossen)", CLOTHES_TOPS, 58, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rotes Hemd", CLOTHES_TOPS, 59, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rotes Hemd (Kurzärmlig)", CLOTHES_TOPS, 60, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 61, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 62, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie (Offen)", CLOTHES_TOPS, 63, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißer Mantel", CLOTHES_TOPS, 64, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke", CLOTHES_TOPS, 65, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 66, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grünes Shirt (Locker)", CLOTHES_TOPS, 67, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braunes Shirt mit Muster", CLOTHES_TOPS, 68, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 69, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißer Mantel (Geschlossen)", CLOTHES_TOPS, 70, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemusterter Pullover", CLOTHES_TOPS, 71, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, weiße Footbal Jacke", CLOTHES_TOPS, 72, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", CLOTHES_TOPS, 73, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Top", CLOTHES_TOPS, 74, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, gelber Pullover", CLOTHES_TOPS, 75, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Tshirt", CLOTHES_TOPS, 76, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", CLOTHES_TOPS, 77, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 78, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Pullover", CLOTHES_TOPS, 79, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weiße Football Jacke", CLOTHES_TOPS, 80, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, weiße Football Jacke", CLOTHES_TOPS, 81, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 82, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", CLOTHES_TOPS, 83, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Andreas Shirt (Außen)", CLOTHES_TOPS, 84, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Andreas Shirt (Innen)", CLOTHES_TOPS, 85, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Jeans Hemd", CLOTHES_TOPS, 86, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau, weißer Hoodie", CLOTHES_TOPS, 87, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braunes Tshirt", CLOTHES_TOPS, 88, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 89, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket", CLOTHES_TOPS, 90, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket (Geschlossen)", CLOTHES_TOPS, 91, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Lilanes Jacket", CLOTHES_TOPS, 92, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Lilanes Jacket (Geschlossen)", CLOTHES_TOPS, 93, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemustertes Jacket", CLOTHES_TOPS, 94, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemustertes Jacket (Geschlossen)", CLOTHES_TOPS, 95, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemustertes Hemd", CLOTHES_TOPS, 96, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaue Jacke", CLOTHES_TOPS, 97, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weiße Asiatische Jacke", CLOTHES_TOPS, 98, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, rote Jacke", CLOTHES_TOPS, 99, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Top", CLOTHES_TOPS, 100, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Lilaner BH", CLOTHES_TOPS, 101, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Brauner Mantel", CLOTHES_TOPS, 102, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Pullover", CLOTHES_TOPS, 103, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 104, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Top", CLOTHES_TOPS, 105, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, weiß, blaue Jacke", CLOTHES_TOPS, 106, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", CLOTHES_TOPS, 107, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 108, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot kariertes Hemd", CLOTHES_TOPS, 109, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grün, schwarze Motorrad Jacke", CLOTHES_TOPS, 110, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, pinkes Dessous", CLOTHES_TOPS, 111, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau gemustertes Kleid", CLOTHES_TOPS, 112, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braun gemustertes Kleid", CLOTHES_TOPS, 113, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot gemustertes Kleid", CLOTHES_TOPS, 114, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz gemustertes Kleid", CLOTHES_TOPS, 115, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weiß gemustertes Kleid", CLOTHES_TOPS, 116, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt (Innen)", CLOTHES_TOPS, 117, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt (Außen)", CLOTHES_TOPS, 118, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes kurzärmliges Hemd", CLOTHES_TOPS, 119, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grau kariertes Hemd (Offen)", CLOTHES_TOPS, 120, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grau kariertes Hemd (Geschlossen)", CLOTHES_TOPS, 121, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 122, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Oberteil", CLOTHES_TOPS, 123, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes bauchfreies Top", CLOTHES_TOPS, 124, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grünes lockeres Shirt", CLOTHES_TOPS, 125, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes lockeres Shirt", CLOTHES_TOPS, 126, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 127, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Außen)", CLOTHES_TOPS, 128, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Innen)", CLOTHES_TOPS, 129, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grau, weißes Hemd (Hochgekrempelt)", CLOTHES_TOPS, 130, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Liberty Hoodie", CLOTHES_TOPS, 131, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemustertes Shirt", CLOTHES_TOPS, 132, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Dunkle Jacke", CLOTHES_TOPS, 133, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, grauer Pullunder", CLOTHES_TOPS, 134, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, brauner Mantel", CLOTHES_TOPS, 135, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Oberteil", CLOTHES_TOPS, 136, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau, graues Jacket", CLOTHES_TOPS, 137, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau, weiße Sportjacke", CLOTHES_TOPS, 138, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", CLOTHES_TOPS, 139, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grün, weiße Football Jacke", CLOTHES_TOPS, 140, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Hellblaues Tshirt", CLOTHES_TOPS, 141, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Hellblaues Hemd", CLOTHES_TOPS, 142, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Hellblauer Mantel", CLOTHES_TOPS, 143, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 144, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke", CLOTHES_TOPS, 145, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 146, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, gelbe gemusterte Jacke", CLOTHES_TOPS, 147, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 148, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 149, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke", CLOTHES_TOPS, 150, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit Italien Flagge", CLOTHES_TOPS, 151, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 152, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 153, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Weste (Offen)", CLOTHES_TOPS, 154, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Weste (Geschlossen)", CLOTHES_TOPS, 155, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel (Geschlossen)", CLOTHES_TOPS, 156, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel (Offen)", CLOTHES_TOPS, 157, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke (Geschlossen)", CLOTHES_TOPS, 158, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke ohne Ärmel (Geschlossen)", CLOTHES_TOPS, 159, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke (Offen)", CLOTHES_TOPS, 160, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt", CLOTHES_TOPS, 161, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 162, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 163, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rote Winterjacke", CLOTHES_TOPS, 164, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Strickjacke", CLOTHES_TOPS, 165, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke", CLOTHES_TOPS, 166, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke ohne Ärmel", CLOTHES_TOPS, 167, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 168, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 169, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 170, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", CLOTHES_TOPS, 171, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 172, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", CLOTHES_TOPS, 173, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit aufdrucken", CLOTHES_TOPS, 174, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit aufdrucken und ohne Ärmel", CLOTHES_TOPS, 175, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit aufdrucken", CLOTHES_TOPS, 176, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit aufdrucken und ohne Ärmel", CLOTHES_TOPS, 177, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke mit aufdrucken und ohne Ärmel", CLOTHES_TOPS, 178, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 179, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 180, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 181, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 182, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke (Offen)", CLOTHES_TOPS, 183, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 184, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", CLOTHES_TOPS, 185, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Regenmantel", CLOTHES_TOPS, 186, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Regenmantel (Offen)", CLOTHES_TOPS, 187, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 188, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", CLOTHES_TOPS, 189, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Orangener Regenmantel", CLOTHES_TOPS, 190, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Orangener Regenmantel (Offen)", CLOTHES_TOPS, 191, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grau gemusteter Pullover", CLOTHES_TOPS, 192, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Camouflage Jacke", CLOTHES_TOPS, 193, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", CLOTHES_TOPS, 194, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Güffy Shirt", CLOTHES_TOPS, 195, SEX_FEMALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 196, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 197, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 198, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 199, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 200, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 201, SEX_FEMALE, 5900),*/
            new BusinessClothesModel(0, "Gelb, orange gemusteter Hoodie", CLOTHES_TOPS, 202, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 203, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel (Geschlossen)", CLOTHES_TOPS, 204, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gelb, orange gemusteter Hoodie (Geschlossen)", CLOTHES_TOPS, 205, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel", CLOTHES_TOPS, 206, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", CLOTHES_TOPS, 207, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Bigness Shirt (Innen)", CLOTHES_TOPS, 208, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Bigness Shirt (Außen)", CLOTHES_TOPS, 209, SEX_FEMALE, 5900),
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
            new BusinessClothesModel(0, "Grauer Regenmantel", CLOTHES_TOPS, 227, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Regenmantel (Geschlossen)", CLOTHES_TOPS, 228, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 229, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 230, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 231, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 232, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 233, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 234, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau, weißer Pulli", CLOTHES_TOPS, 235, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Tshirt", CLOTHES_TOPS, 236, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 237, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 238, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke (Geschlossen)", CLOTHES_TOPS, 239, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke (Offen)", CLOTHES_TOPS, 240, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 241, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grüner Parker", CLOTHES_TOPS, 242, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 243, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", CLOTHES_TOPS, 244, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 245, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot, grau, weißes Bowling Shirt", CLOTHES_TOPS, 246, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Tanktop", CLOTHES_TOPS, 247, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graue Jacke mit Fell", CLOTHES_TOPS, 248, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Außen)", CLOTHES_TOPS, 249, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Innen)", CLOTHES_TOPS, 250, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 251, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 252, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grün gemusteter Pullover", CLOTHES_TOPS, 253, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 254, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 255, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 256, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaue Jacke", CLOTHES_TOPS, 257, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", CLOTHES_TOPS, 258, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Regen Jacke", CLOTHES_TOPS, 259, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 260, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Regen Jacke (Geschlossen)", CLOTHES_TOPS, 261, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Joggingjacke", CLOTHES_TOPS, 262, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 263, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemusterter Pulli", CLOTHES_TOPS, 264, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemusterte Football Jacke", CLOTHES_TOPS, 265, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weiße Jacke", CLOTHES_TOPS, 266, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau kariertes Hemd", CLOTHES_TOPS, 267, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Blau gemusterter Pullover", CLOTHES_TOPS, 268, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Rot gemustertes Hemd", CLOTHES_TOPS, 269, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Gemusterte Football Jacke (Offen)", CLOTHES_TOPS, 270, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Hoodie", CLOTHES_TOPS, 271, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Grauer Hoodie (Geschlossen)", CLOTHES_TOPS, 272, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 273, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Lila gepunktete Jacke (Geschlossen)", CLOTHES_TOPS, 274, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Lila gepunktete Jacke", CLOTHES_TOPS, 275, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 276, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 277, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Bunte Winterjacke", CLOTHES_TOPS, 278, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Leoparden BH", CLOTHES_TOPS, 279, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Tshirt (Außen)", CLOTHES_TOPS, 280, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Tshirt (Innen)", CLOTHES_TOPS, 281, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 282, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Leoparden Tanktop", CLOTHES_TOPS, 283, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Camouflage Tanktop", CLOTHES_TOPS, 284, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Hellblaue Jacke", CLOTHES_TOPS, 285, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", CLOTHES_TOPS, 286, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 287, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 288, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 289, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 290, SEX_FEMALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 291, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Benedict Hoodie", CLOTHES_TOPS, 292, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Benedict Hoodie (Geschlossen)", CLOTHES_TOPS, 293, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Burger Pulli", CLOTHES_TOPS, 294, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "Burger Shirt", CLOTHES_TOPS, 295, SEX_FEMALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 296, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 297, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 298, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 299, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 300, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 301, SEX_FEMALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 302, SEX_FEMALE, 5900),*/
           
                
                
            // Male tops
                
            new BusinessClothesModel(0, "Weißes Shirt", CLOTHES_TOPS, 0, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Hemd", CLOTHES_TOPS, 1, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Kariertes Tanktop", CLOTHES_TOPS, 2, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiße Jogging Jacke", CLOTHES_TOPS, 3, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket", CLOTHES_TOPS, 4, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Tanktop", CLOTHES_TOPS, 5, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 6, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiße Strickjacke", CLOTHES_TOPS, 7, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, blaues Tshirt", CLOTHES_TOPS, 8, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Hemd", CLOTHES_TOPS, 9, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Geschlossen)", CLOTHES_TOPS, 10, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Weste", CLOTHES_TOPS, 11, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Hemd (Innen)", CLOTHES_TOPS, 12, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Hemd (Außen)", CLOTHES_TOPS, 13, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blau kariertes Hemd", CLOTHES_TOPS, 14, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 15, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt", CLOTHES_TOPS, 16, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Tanktop", CLOTHES_TOPS, 17, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 18, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, weißes Jacket", CLOTHES_TOPS, 19, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Jacket", CLOTHES_TOPS, 20, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellgraue Weste", CLOTHES_TOPS, 21, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Shirt", CLOTHES_TOPS, 22, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braunes Jacket", CLOTHES_TOPS, 23, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Jacket (Geschlossen)", CLOTHES_TOPS, 24, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Weste", CLOTHES_TOPS, 25, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd", CLOTHES_TOPS, 26, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 27, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket (Geschlossen)", CLOTHES_TOPS, 28, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Jacket", CLOTHES_TOPS, 29, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "" (Geschlossen)", CLOTHES_TOPS, 30, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 31, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 32, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grau, weißes Shirt", CLOTHES_TOPS, 33, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Shirt", CLOTHES_TOPS, 34, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", CLOTHES_TOPS, 35, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiß, grau, blaues Tanktop", CLOTHES_TOPS, 36, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 37, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarz, graue Pulli", CLOTHES_TOPS, 38, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rotes Shirt", CLOTHES_TOPS, 39, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Weste", CLOTHES_TOPS, 40, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot kariertes Hemd", CLOTHES_TOPS, 41, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd mit Hosenträger (Geschlossen)", CLOTHES_TOPS, 42, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Hemd mit Hosenträger", CLOTHES_TOPS, 43, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grünes Shirt", CLOTHES_TOPS, 44, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 45, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 46, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Tshirt", CLOTHES_TOPS, 47, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 48, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 49, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 50, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 51, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 52, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 53, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 54, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 55, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Graues Shirt", CLOTHES_TOPS, 56, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Hoodie", CLOTHES_TOPS, 57, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 58, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Jacket", CLOTHES_TOPS, 59, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Jacket (Geschlossen)", CLOTHES_TOPS, 60, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Jacke", CLOTHES_TOPS, 61, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 62, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", CLOTHES_TOPS, 63, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke (Geschlossen)", CLOTHES_TOPS, 64, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke", CLOTHES_TOPS, 65, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke ohne Ärmel", CLOTHES_TOPS, 66, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 67, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke (Geschlossen)", CLOTHES_TOPS, 68, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke", CLOTHES_TOPS, 69, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Brauner Mantel mit Pelz", CLOTHES_TOPS, 70, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiges Shirt", CLOTHES_TOPS, 71, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellbrauner Mantel", CLOTHES_TOPS, 72, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braunes Shirt mit motiven", CLOTHES_TOPS, 73, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven", CLOTHES_TOPS, 74, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven (Geschlossen)", CLOTHES_TOPS, 75, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiger Mantel (Geschlossen)", CLOTHES_TOPS, 76, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", CLOTHES_TOPS, 77, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Gemusterter Pulli", CLOTHES_TOPS, 78, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, weiße Football Jacke", CLOTHES_TOPS, 79, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Shirt", CLOTHES_TOPS, 80, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Shirt", CLOTHES_TOPS, 81, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Tshirt", CLOTHES_TOPS, 82, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt", CLOTHES_TOPS, 83, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Corkeers Pulli", CLOTHES_TOPS, 84, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaue Hemden", CLOTHES_TOPS, 85, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 86, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Football Jacke (Geschlossen)", CLOTHES_TOPS, 87, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Football Jacke", CLOTHES_TOPS, 88, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Pulli", CLOTHES_TOPS, 89, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiße Football Jacke", CLOTHES_TOPS, 90, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 91, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", CLOTHES_TOPS, 92, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Andreas Tshirt (Außen)", CLOTHES_TOPS, 93, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Andreas Tshirt (Innen)", CLOTHES_TOPS, 94, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Jeans Hemd", CLOTHES_TOPS, 95, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellblauer Hoodie", CLOTHES_TOPS, 96, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellbraunes Tshirt", CLOTHES_TOPS, 97, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 98, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket", CLOTHES_TOPS, 99, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket (Geschlossen)", CLOTHES_TOPS, 100, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Violetes Jacket", CLOTHES_TOPS, 101, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Violetes Jacket (Geschlossen)", CLOTHES_TOPS, 102, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braun gemustertes Jacket", CLOTHES_TOPS, 103, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braun gemustertes Jacket (Geschlossen)", CLOTHES_TOPS, 104, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiß gemustertes Hemd", CLOTHES_TOPS, 105, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaue Jacke", CLOTHES_TOPS, 106, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiße Asiatische Jacke", CLOTHES_TOPS, 107, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, schwarzes Jacket", CLOTHES_TOPS, 108, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißer Pullunder", CLOTHES_TOPS, 109, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 110, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 111, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Beiges Jacket (Geschlossen)", CLOTHES_TOPS, 112, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, schwarze Joggingjacke", CLOTHES_TOPS, 113, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Oberteil", CLOTHES_TOPS, 114, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", CLOTHES_TOPS, 115, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 116, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot kariertes Hemd", CLOTHES_TOPS, 117, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 118, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaues Jacket", CLOTHES_TOPS, 119, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blaue Weste", CLOTHES_TOPS, 120, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißer Hoodie", CLOTHES_TOPS, 121, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 122, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Hemd", CLOTHES_TOPS, 123, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke", CLOTHES_TOPS, 124, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellbraune Jacke", CLOTHES_TOPS, 125, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Hemd (Geschlossen)", CLOTHES_TOPS, 126, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Hemd", CLOTHES_TOPS, 127, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grünes Shirt", CLOTHES_TOPS, 128, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 129, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 130, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Außen)", CLOTHES_TOPS, 131, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Liberty Shirt (Innen)", CLOTHES_TOPS, 132, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Pinkes Hemd", CLOTHES_TOPS, 133, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Liberty Hoodie", CLOTHES_TOPS, 134, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hemd mit motiven", CLOTHES_TOPS, 135, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Jacke", CLOTHES_TOPS, 136, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Karierter Pullunder", CLOTHES_TOPS, 137, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke (Geschlossen)", CLOTHES_TOPS, 138, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Pulli", CLOTHES_TOPS, 139, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", CLOTHES_TOPS, 140, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blau, weiße Jogging Jacke", CLOTHES_TOPS, 141, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Mantel", CLOTHES_TOPS, 142, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grün, weiße Football Jacke", CLOTHES_TOPS, 143, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellblaues Hemd", CLOTHES_TOPS, 144, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellblauer Mantel", CLOTHES_TOPS, 145, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", CLOTHES_TOPS, 146, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 147, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 148, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 149, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Lilane Football Jacke", CLOTHES_TOPS, 150, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 151, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 152, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Jacke", CLOTHES_TOPS, 153, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit Italien Flagge", CLOTHES_TOPS, 154, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 155, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke (Geschlossen)", CLOTHES_TOPS, 156, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", CLOTHES_TOPS, 157, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 158, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Weste", CLOTHES_TOPS, 159, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", CLOTHES_TOPS, 160, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 161, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", CLOTHES_TOPS, 162, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 163, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt", CLOTHES_TOPS, 164, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blauer Pulli", CLOTHES_TOPS, 165, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 166, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rote Winterjackes", CLOTHES_TOPS, 167, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 168, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke", CLOTHES_TOPS, 169, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke ohne Ärmel", CLOTHES_TOPS, 170, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 171, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit motiven", CLOTHES_TOPS, 172, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Jeans Jacke mit motiven und ohne Ärmel", CLOTHES_TOPS, 173, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven", CLOTHES_TOPS, 174, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke mit motiven und ohne Ärmel", CLOTHES_TOPS, 175, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke mit motiven und ohne Ärmel", CLOTHES_TOPS, 176, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 177, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 178, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 179, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 180, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 181, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 182, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarz, weißes Jacket", CLOTHES_TOPS, 183, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke (Geschlossen)", CLOTHES_TOPS, 184, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke", CLOTHES_TOPS, 185, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 186, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke", CLOTHES_TOPS, 187, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Orangene Regenjacke (Geschlossen)", CLOTHES_TOPS, 188, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Orangene Regenjacke", CLOTHES_TOPS, 189, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Pulli", CLOTHES_TOPS, 190, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Camouflage Jacke", CLOTHES_TOPS, 191, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel", CLOTHES_TOPS, 192, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Güffy Shirt", CLOTHES_TOPS, 193, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 194, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 195, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 196, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 197, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 198, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 199, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Gelber Hoodie", CLOTHES_TOPS, 200, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 201, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel (Geschlossen)", CLOTHES_TOPS, 202, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Gelber Hoodie (Geschlossen)", CLOTHES_TOPS, 203, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Regenjacke (Geschlossen)", CLOTHES_TOPS, 204, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie ohne Ärmel", CLOTHES_TOPS, 205, SEX_MALE, 5900),
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
            new BusinessClothesModel(0, "Graue Regenjacke", CLOTHES_TOPS, 217, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graue Regenjacke (Geschlossen)", CLOTHES_TOPS, 218, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 219, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 220, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 221, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 222, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Schwarze Jacke ohne Ärmel", CLOTHES_TOPS, 223, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 224, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blau, weißer Pulli", CLOTHES_TOPS, 225, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Tshirt", CLOTHES_TOPS, 226, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 227, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 228, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke (Geschlossen)", CLOTHES_TOPS, 229, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grüne Jacke", CLOTHES_TOPS, 230, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 231, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 232, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 233, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzes Hemd", CLOTHES_TOPS, 234, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, weiß, graues Bowlingshirt (Außem)", CLOTHES_TOPS, 235, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Rot, weiß, graues Bowlingshirt (Innen)", CLOTHES_TOPS, 236, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Tanktop", CLOTHES_TOPS, 237, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellgraues Shirt", CLOTHES_TOPS, 238, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 239, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grauer Mantel mit Pelz", CLOTHES_TOPS, 240, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Außen)", CLOTHES_TOPS, 241, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Graues Shirt (Innen)", CLOTHES_TOPS, 242, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 243, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Braune Jacke", CLOTHES_TOPS, 244, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grün gemusteter Pulli", CLOTHES_TOPS, 245, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 246, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 247, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 248, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Blaue Jacke", CLOTHES_TOPS, 249, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blauer Hemd", CLOTHES_TOPS, 250, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Brauner Regenmantel", CLOTHES_TOPS, 251, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 252, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Brauner Regenmantel (Geschlossen)", CLOTHES_TOPS, 253, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 254, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißer Pulli", CLOTHES_TOPS, 255, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Bunte Football Jacke (Geschlossen)", CLOTHES_TOPS, 256, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weiße Jacke", CLOTHES_TOPS, 257, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blau kariertes Hemd", CLOTHES_TOPS, 258, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blauer Pulli", CLOTHES_TOPS, 259, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Buntes Hemd", CLOTHES_TOPS, 260, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Bunte Football Jacke", CLOTHES_TOPS, 261, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie", CLOTHES_TOPS, 262, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarzer Hoodie (Geschlossen)", CLOTHES_TOPS, 263, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Schwarze Jacke", CLOTHES_TOPS, 264, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blau gepunktete Jacke (Geschlossen)", CLOTHES_TOPS, 265, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Blau gepunktete Jacke", CLOTHES_TOPS, 266, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grüner Regenmantel (Geschlossen)", CLOTHES_TOPS, 267, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Grüner Regenmantel", CLOTHES_TOPS, 268, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Bunte Winterjacke", CLOTHES_TOPS, 269, SEX_MALE, 5900),
            //new BusinessClothesModel(0, "", CLOTHES_TOPS, 270, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellblaues Shirt", CLOTHES_TOPS, 271, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Hellblaue Jacke", CLOTHES_TOPS, 272, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Weißes Tshirt", CLOTHES_TOPS, 273, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 274, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 275, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 276, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 277, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 278, SEX_MALE, 5900),*/
            new BusinessClothesModel(0, "Benedict Hoodie", CLOTHES_TOPS, 279, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Benedict Hoodie (Geschlossen)", CLOTHES_TOPS, 280, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Burger Pulli", CLOTHES_TOPS, 281, SEX_MALE, 5900),
            new BusinessClothesModel(0, "Burger Shirt", CLOTHES_TOPS, 282, SEX_MALE, 5900),
            /*new BusinessClothesModel(0, "", CLOTHES_TOPS, 283, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 284, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 285, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 286, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 287, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 288, SEX_MALE, 5900),
            new BusinessClothesModel(0, "", CLOTHES_TOPS, 289, SEX_MALE, 5900),*/
 
                
                
            // Female undershirt








            new BusinessClothesModel(0, "0", CLOTHES_UNDERSHIRT, 0, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "1", CLOTHES_UNDERSHIRT, 1, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "2", CLOTHES_UNDERSHIRT, 2, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "3", CLOTHES_UNDERSHIRT, 3, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "4", CLOTHES_UNDERSHIRT, 4, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "5", CLOTHES_UNDERSHIRT, 5, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "6", CLOTHES_UNDERSHIRT, 6, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "7", CLOTHES_UNDERSHIRT, 7, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "8", CLOTHES_UNDERSHIRT, 8, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "9", CLOTHES_UNDERSHIRT, 9, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "10", CLOTHES_UNDERSHIRT, 10, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "11", CLOTHES_UNDERSHIRT, 11, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "12", CLOTHES_UNDERSHIRT, 12, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "13", CLOTHES_UNDERSHIRT, 13, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "14", CLOTHES_UNDERSHIRT, 14, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "15", CLOTHES_UNDERSHIRT, 15, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "16", CLOTHES_UNDERSHIRT, 16, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "17", CLOTHES_UNDERSHIRT, 17, SEX_FEMALE, 3900),

            new BusinessClothesModel(0, "0", CLOTHES_UNDERSHIRT, 0, SEX_MALE, 3900),
            new BusinessClothesModel(0, "1", CLOTHES_UNDERSHIRT, 1, SEX_MALE, 3900),
            new BusinessClothesModel(0, "2", CLOTHES_UNDERSHIRT, 2, SEX_MALE, 3900),
            new BusinessClothesModel(0, "3", CLOTHES_UNDERSHIRT, 3, SEX_MALE, 3900),
            new BusinessClothesModel(0, "4", CLOTHES_UNDERSHIRT, 4, SEX_MALE, 3900),
            new BusinessClothesModel(0, "5", CLOTHES_UNDERSHIRT, 5, SEX_MALE, 3900),
            new BusinessClothesModel(0, "6", CLOTHES_UNDERSHIRT, 6, SEX_MALE, 3900),
            new BusinessClothesModel(0, "7", CLOTHES_UNDERSHIRT, 7, SEX_MALE, 3900),
            new BusinessClothesModel(0, "8", CLOTHES_UNDERSHIRT, 8, SEX_MALE, 3900),
            new BusinessClothesModel(0, "9", CLOTHES_UNDERSHIRT, 9, SEX_MALE, 3900),
            new BusinessClothesModel(0, "10", CLOTHES_UNDERSHIRT, 10, SEX_MALE, 3900),
            new BusinessClothesModel(0, "11", CLOTHES_UNDERSHIRT, 11, SEX_MALE, 3900),
            new BusinessClothesModel(0, "12", CLOTHES_UNDERSHIRT, 12, SEX_MALE, 3900),
            new BusinessClothesModel(0, "13", CLOTHES_UNDERSHIRT, 13, SEX_MALE, 3900),
            new BusinessClothesModel(0, "14", CLOTHES_UNDERSHIRT, 14, SEX_MALE, 3900),
            new BusinessClothesModel(0, "15", CLOTHES_UNDERSHIRT, 15, SEX_MALE, 3900),
            new BusinessClothesModel(0, "16", CLOTHES_UNDERSHIRT, 16, SEX_MALE, 3900),
            new BusinessClothesModel(0, "17", CLOTHES_UNDERSHIRT, 17, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 18, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 19, SEX_MALE, 3900),
            new BusinessClothesModel(0, "18", CLOTHES_UNDERSHIRT, 20, SEX_MALE, 3900),
            new BusinessClothesModel(0, "19", CLOTHES_UNDERSHIRT, 21, SEX_MALE, 3900),
            new BusinessClothesModel(0, "20", CLOTHES_UNDERSHIRT, 22, SEX_MALE, 3900),
            new BusinessClothesModel(0, "21", CLOTHES_UNDERSHIRT, 23, SEX_MALE, 3900),
            new BusinessClothesModel(0, "22", CLOTHES_UNDERSHIRT, 24, SEX_MALE, 3900),
            new BusinessClothesModel(0, "23", CLOTHES_UNDERSHIRT, 25, SEX_MALE, 3900),
            new BusinessClothesModel(0, "24", CLOTHES_UNDERSHIRT, 26, SEX_MALE, 3900),
            new BusinessClothesModel(0, "25", CLOTHES_UNDERSHIRT, 27, SEX_MALE, 3900),
            new BusinessClothesModel(0, "26", CLOTHES_UNDERSHIRT, 28, SEX_MALE, 3900),
            new BusinessClothesModel(0, "27", CLOTHES_UNDERSHIRT, 29, SEX_MALE, 3900),
            new BusinessClothesModel(0, "28", CLOTHES_UNDERSHIRT, 30, SEX_MALE, 3900),
            new BusinessClothesModel(0, "29", CLOTHES_UNDERSHIRT, 31, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 32, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 33, SEX_MALE, 3900),
            new BusinessClothesModel(0, "30", CLOTHES_UNDERSHIRT, 34, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 35, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 36, SEX_MALE, 3900),
            new BusinessClothesModel(0, "31", CLOTHES_UNDERSHIRT, 37, SEX_MALE, 3900),
            new BusinessClothesModel(0, "32", CLOTHES_UNDERSHIRT, 38, SEX_MALE, 3900),
            new BusinessClothesModel(0, "33", CLOTHES_UNDERSHIRT, 39, SEX_MALE, 3900),
            new BusinessClothesModel(0, "34", CLOTHES_UNDERSHIRT, 40, SEX_MALE, 3900),
            new BusinessClothesModel(0, "35", CLOTHES_UNDERSHIRT, 41, SEX_MALE, 3900),
            new BusinessClothesModel(0, "36", CLOTHES_UNDERSHIRT, 42, SEX_MALE, 3900),
            new BusinessClothesModel(0, "37", CLOTHES_UNDERSHIRT, 43, SEX_MALE, 3900),
            new BusinessClothesModel(0, "38", CLOTHES_UNDERSHIRT, 44, SEX_MALE, 3900),
            new BusinessClothesModel(0, "39", CLOTHES_UNDERSHIRT, 45, SEX_MALE, 3900),
            new BusinessClothesModel(0, "40", CLOTHES_UNDERSHIRT, 46, SEX_MALE, 3900),
            new BusinessClothesModel(0, "41", CLOTHES_UNDERSHIRT, 47, SEX_MALE, 3900),
            new BusinessClothesModel(0, "42", CLOTHES_UNDERSHIRT, 48, SEX_MALE, 3900),
            new BusinessClothesModel(0, "43", CLOTHES_UNDERSHIRT, 49, SEX_MALE, 3900),
            new BusinessClothesModel(0, "44", CLOTHES_UNDERSHIRT, 50, SEX_MALE, 3900),
            new BusinessClothesModel(0, "45", CLOTHES_UNDERSHIRT, 51, SEX_MALE, 3900),
            new BusinessClothesModel(0, "46", CLOTHES_UNDERSHIRT, 52, SEX_MALE, 3900),
            new BusinessClothesModel(0, "47", CLOTHES_UNDERSHIRT, 53, SEX_MALE, 3900),
            new BusinessClothesModel(0, "48", CLOTHES_UNDERSHIRT, 54, SEX_MALE, 3900),
            new BusinessClothesModel(0, "49", CLOTHES_UNDERSHIRT, 55, SEX_MALE, 3900),
            new BusinessClothesModel(0, "50", CLOTHES_UNDERSHIRT, 56, SEX_MALE, 3900),
            new BusinessClothesModel(0, "51", CLOTHES_UNDERSHIRT, 57, SEX_MALE, 3900),
            new BusinessClothesModel(0, "52", CLOTHES_UNDERSHIRT, 58, SEX_MALE, 3900),
            new BusinessClothesModel(0, "53", CLOTHES_UNDERSHIRT, 59, SEX_MALE, 3900),
            new BusinessClothesModel(0, "54", CLOTHES_UNDERSHIRT, 60, SEX_MALE, 3900),
            new BusinessClothesModel(0, "55", CLOTHES_UNDERSHIRT, 61, SEX_MALE, 3900),
            new BusinessClothesModel(0, "56", CLOTHES_UNDERSHIRT, 62, SEX_MALE, 3900),
            new BusinessClothesModel(0, "57", CLOTHES_UNDERSHIRT, 63, SEX_MALE, 3900),
            new BusinessClothesModel(0, "58", CLOTHES_UNDERSHIRT, 64, SEX_MALE, 3900),
            new BusinessClothesModel(0, "59", CLOTHES_UNDERSHIRT, 65, SEX_MALE, 3900),
            new BusinessClothesModel(0, "60", CLOTHES_UNDERSHIRT, 66, SEX_MALE, 3900),
            new BusinessClothesModel(0, "61", CLOTHES_UNDERSHIRT, 67, SEX_MALE, 3900),
            new BusinessClothesModel(0, "62", CLOTHES_UNDERSHIRT, 68, SEX_MALE, 3900),
            new BusinessClothesModel(0, "63", CLOTHES_UNDERSHIRT, 69, SEX_MALE, 3900),
            new BusinessClothesModel(0, "64", CLOTHES_UNDERSHIRT, 70, SEX_MALE, 3900),
            new BusinessClothesModel(0, "65", CLOTHES_UNDERSHIRT, 71, SEX_MALE, 3900),
            new BusinessClothesModel(0, "66", CLOTHES_UNDERSHIRT, 72, SEX_MALE, 3900),
            new BusinessClothesModel(0, "67", CLOTHES_UNDERSHIRT, 73, SEX_MALE, 3900),
            new BusinessClothesModel(0, "68", CLOTHES_UNDERSHIRT, 74, SEX_MALE, 3900),
            new BusinessClothesModel(0, "69", CLOTHES_UNDERSHIRT, 75, SEX_MALE, 3900),
            new BusinessClothesModel(0, "70", CLOTHES_UNDERSHIRT, 76, SEX_MALE, 3900),
            new BusinessClothesModel(0, "71", CLOTHES_UNDERSHIRT, 77, SEX_MALE, 3900),
            new BusinessClothesModel(0, "72", CLOTHES_UNDERSHIRT, 78, SEX_MALE, 3900),
            new BusinessClothesModel(0, "73", CLOTHES_UNDERSHIRT, 79, SEX_MALE, 3900),
            new BusinessClothesModel(0, "74", CLOTHES_UNDERSHIRT, 80, SEX_MALE, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 81, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 82, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 83, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 84, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 85, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "75", CLOTHES_UNDERSHIRT, 86, SEX_MALE, 3900),
            new BusinessClothesModel(0, "76", CLOTHES_UNDERSHIRT, 87, SEX_MALE, 3900),
            new BusinessClothesModel(0, "77", CLOTHES_UNDERSHIRT, 88, SEX_MALE, 3900),
            new BusinessClothesModel(0, "78", CLOTHES_UNDERSHIRT, 89, SEX_MALE, 3900),
            new BusinessClothesModel(0, "79", CLOTHES_UNDERSHIRT, 90, SEX_MALE, 3900),
            new BusinessClothesModel(0, "80", CLOTHES_UNDERSHIRT, 91, SEX_MALE, 3900),
            new BusinessClothesModel(0, "81", CLOTHES_UNDERSHIRT, 92, SEX_MALE, 3900),
            new BusinessClothesModel(0, "82", CLOTHES_UNDERSHIRT, 93, SEX_MALE, 3900),
            new BusinessClothesModel(0, "83", CLOTHES_UNDERSHIRT, 94, SEX_MALE, 3900),
            new BusinessClothesModel(0, "84", CLOTHES_UNDERSHIRT, 95, SEX_MALE, 3900),
            new BusinessClothesModel(0, "85", CLOTHES_UNDERSHIRT, 96, SEX_MALE, 3900),
            new BusinessClothesModel(0, "86", CLOTHES_UNDERSHIRT, 97, SEX_MALE, 3900),
            new BusinessClothesModel(0, "87", CLOTHES_UNDERSHIRT, 98, SEX_MALE, 3900),
            new BusinessClothesModel(0, "88", CLOTHES_UNDERSHIRT, 99, SEX_MALE, 3900),
            new BusinessClothesModel(0, "89", CLOTHES_UNDERSHIRT, 100, SEX_MALE, 3900),
            new BusinessClothesModel(0, "90", CLOTHES_UNDERSHIRT, 101, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "91", CLOTHES_UNDERSHIRT, 102, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "92", CLOTHES_UNDERSHIRT, 103, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "93", CLOTHES_UNDERSHIRT, 104, SEX_FEMALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 105, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "94", CLOTHES_UNDERSHIRT, 106, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "95", CLOTHES_UNDERSHIRT, 107, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "96", CLOTHES_UNDERSHIRT, 108, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "97", CLOTHES_UNDERSHIRT, 109, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "98", CLOTHES_UNDERSHIRT, 110, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "99", CLOTHES_UNDERSHIRT, 111, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "100", CLOTHES_UNDERSHIRT, 112, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "101", CLOTHES_UNDERSHIRT, 113, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "102", CLOTHES_UNDERSHIRT, 114, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "103", CLOTHES_UNDERSHIRT, 115, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "104", CLOTHES_UNDERSHIRT, 116, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "105", CLOTHES_UNDERSHIRT, 117, SEX_FEMALE, 3900),
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
            new BusinessClothesModel(0, "106", CLOTHES_UNDERSHIRT, 142, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "107", CLOTHES_UNDERSHIRT, 143, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "108", CLOTHES_UNDERSHIRT, 144, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "109", CLOTHES_UNDERSHIRT, 145, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "110", CLOTHES_UNDERSHIRT, 146, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "111", CLOTHES_UNDERSHIRT, 147, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "112", CLOTHES_UNDERSHIRT, 148, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "113", CLOTHES_UNDERSHIRT, 149, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "114", CLOTHES_UNDERSHIRT, 150, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "115", CLOTHES_UNDERSHIRT, 151, SEX_FEMALE, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 152, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 153, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 154, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 155, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 156, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 157, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 158, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 159, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 160, SEX_FEMALE, 3900),*/
            new BusinessClothesModel(0, "116", CLOTHES_UNDERSHIRT, 161, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "117", CLOTHES_UNDERSHIRT, 162, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "118", CLOTHES_UNDERSHIRT, 163, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "119", CLOTHES_UNDERSHIRT, 164, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "120", CLOTHES_UNDERSHIRT, 165, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "121", CLOTHES_UNDERSHIRT, 166, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "122", CLOTHES_UNDERSHIRT, 167, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "123", CLOTHES_UNDERSHIRT, 168, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "124", CLOTHES_UNDERSHIRT, 170, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "125", CLOTHES_UNDERSHIRT, 171, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "126", CLOTHES_UNDERSHIRT, 172, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "127", CLOTHES_UNDERSHIRT, 173, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "128", CLOTHES_UNDERSHIRT, 174, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "129", CLOTHES_UNDERSHIRT, 175, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "130", CLOTHES_UNDERSHIRT, 176, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "131", CLOTHES_UNDERSHIRT, 177, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "132", CLOTHES_UNDERSHIRT, 178, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "133", CLOTHES_UNDERSHIRT, 179, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "134", CLOTHES_UNDERSHIRT, 180, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "135", CLOTHES_UNDERSHIRT, 181, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "136", CLOTHES_UNDERSHIRT, 182, SEX_FEMALE, 3900),
            new BusinessClothesModel(0, "137", CLOTHES_UNDERSHIRT, 183, SEX_FEMALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 184, SEX_FEMALE, 3900),
 
                
                
            // Male undershirt
                
            new BusinessClothesModel(0, "0", CLOTHES_UNDERSHIRT, 0, SEX_MALE, 3900),
            new BusinessClothesModel(0, "1", CLOTHES_UNDERSHIRT, 1, SEX_MALE, 3900),
            new BusinessClothesModel(0, "2", CLOTHES_UNDERSHIRT, 2, SEX_MALE, 3900),
            new BusinessClothesModel(0, "3", CLOTHES_UNDERSHIRT, 3, SEX_MALE, 3900),
            new BusinessClothesModel(0, "4", CLOTHES_UNDERSHIRT, 4, SEX_MALE, 3900),
            new BusinessClothesModel(0, "5", CLOTHES_UNDERSHIRT, 5, SEX_MALE, 3900),
            new BusinessClothesModel(0, "6", CLOTHES_UNDERSHIRT, 6, SEX_MALE, 3900),
            new BusinessClothesModel(0, "7", CLOTHES_UNDERSHIRT, 7, SEX_MALE, 3900),
            new BusinessClothesModel(0, "8", CLOTHES_UNDERSHIRT, 8, SEX_MALE, 3900),
            new BusinessClothesModel(0, "9", CLOTHES_UNDERSHIRT, 9, SEX_MALE, 3900),
            new BusinessClothesModel(0, "10", CLOTHES_UNDERSHIRT, 10, SEX_MALE, 3900),
            new BusinessClothesModel(0, "11", CLOTHES_UNDERSHIRT, 11, SEX_MALE, 3900),
            new BusinessClothesModel(0, "12", CLOTHES_UNDERSHIRT, 12, SEX_MALE, 3900),
            new BusinessClothesModel(0, "13", CLOTHES_UNDERSHIRT, 13, SEX_MALE, 3900),
            new BusinessClothesModel(0, "14", CLOTHES_UNDERSHIRT, 14, SEX_MALE, 3900),
            new BusinessClothesModel(0, "15", CLOTHES_UNDERSHIRT, 15, SEX_MALE, 3900),
            new BusinessClothesModel(0, "16", CLOTHES_UNDERSHIRT, 16, SEX_MALE, 3900),
            new BusinessClothesModel(0, "17", CLOTHES_UNDERSHIRT, 17, SEX_MALE, 3900),
            new BusinessClothesModel(0, "18", CLOTHES_UNDERSHIRT, 18, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 19, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 20, SEX_MALE, 3900),
            new BusinessClothesModel(0, "19", CLOTHES_UNDERSHIRT, 21, SEX_MALE, 3900),
            new BusinessClothesModel(0, "20", CLOTHES_UNDERSHIRT, 22, SEX_MALE, 3900),
            new BusinessClothesModel(0, "21", CLOTHES_UNDERSHIRT, 23, SEX_MALE, 3900),
            new BusinessClothesModel(0, "22", CLOTHES_UNDERSHIRT, 24, SEX_MALE, 3900),
            new BusinessClothesModel(0, "23", CLOTHES_UNDERSHIRT, 25, SEX_MALE, 3900),
            new BusinessClothesModel(0, "24", CLOTHES_UNDERSHIRT, 26, SEX_MALE, 3900),
            new BusinessClothesModel(0, "25", CLOTHES_UNDERSHIRT, 27, SEX_MALE, 3900),
            new BusinessClothesModel(0, "26", CLOTHES_UNDERSHIRT, 28, SEX_MALE, 3900),
            new BusinessClothesModel(0, "27", CLOTHES_UNDERSHIRT, 29, SEX_MALE, 3900),
            new BusinessClothesModel(0, "28", CLOTHES_UNDERSHIRT, 30, SEX_MALE, 3900),
            new BusinessClothesModel(0, "29", CLOTHES_UNDERSHIRT, 31, SEX_MALE, 3900),
            new BusinessClothesModel(0, "30", CLOTHES_UNDERSHIRT, 32, SEX_MALE, 3900),
            new BusinessClothesModel(0, "31", CLOTHES_UNDERSHIRT, 33, SEX_MALE, 3900),
            new BusinessClothesModel(0, "32", CLOTHES_UNDERSHIRT, 34, SEX_MALE, 3900),
            new BusinessClothesModel(0, "33", CLOTHES_UNDERSHIRT, 35, SEX_MALE, 3900),
            new BusinessClothesModel(0, "34", CLOTHES_UNDERSHIRT, 36, SEX_MALE, 3900),
            new BusinessClothesModel(0, "35", CLOTHES_UNDERSHIRT, 37, SEX_MALE, 3900),
            new BusinessClothesModel(0, "36", CLOTHES_UNDERSHIRT, 38, SEX_MALE, 3900),
            new BusinessClothesModel(0, "37", CLOTHES_UNDERSHIRT, 39, SEX_MALE, 3900),
            new BusinessClothesModel(0, "38", CLOTHES_UNDERSHIRT, 40, SEX_MALE, 3900),
            new BusinessClothesModel(0, "39", CLOTHES_UNDERSHIRT, 41, SEX_MALE, 3900),
            new BusinessClothesModel(0, "40", CLOTHES_UNDERSHIRT, 42, SEX_MALE, 3900),
            new BusinessClothesModel(0, "41", CLOTHES_UNDERSHIRT, 43, SEX_MALE, 3900),
            new BusinessClothesModel(0, "42", CLOTHES_UNDERSHIRT, 44, SEX_MALE, 3900),
            new BusinessClothesModel(0, "43", CLOTHES_UNDERSHIRT, 45, SEX_MALE, 3900),
            new BusinessClothesModel(0, "44", CLOTHES_UNDERSHIRT, 46, SEX_MALE, 3900),
            new BusinessClothesModel(0, "45", CLOTHES_UNDERSHIRT, 47, SEX_MALE, 3900),
            new BusinessClothesModel(0, "46", CLOTHES_UNDERSHIRT, 48, SEX_MALE, 3900),
            new BusinessClothesModel(0, "47", CLOTHES_UNDERSHIRT, 49, SEX_MALE, 3900),
            new BusinessClothesModel(0, "48", CLOTHES_UNDERSHIRT, 50, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 51, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 52, SEX_MALE, 3900),
            new BusinessClothesModel(0, "49", CLOTHES_UNDERSHIRT, 53, SEX_MALE, 3900),
            new BusinessClothesModel(0, "50", CLOTHES_UNDERSHIRT, 54, SEX_MALE, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 55, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 56, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 57, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 58, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 59, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "51", CLOTHES_UNDERSHIRT, 60, SEX_MALE, 3900),
            new BusinessClothesModel(0, "52", CLOTHES_UNDERSHIRT, 61, SEX_MALE, 3900),
            new BusinessClothesModel(0, "53", CLOTHES_UNDERSHIRT, 62, SEX_MALE, 3900),
            new BusinessClothesModel(0, "54", CLOTHES_UNDERSHIRT, 63, SEX_MALE, 3900),
            new BusinessClothesModel(0, "55", CLOTHES_UNDERSHIRT, 64, SEX_MALE, 3900),
            new BusinessClothesModel(0, "56", CLOTHES_UNDERSHIRT, 65, SEX_MALE, 3900),
            new BusinessClothesModel(0, "57", CLOTHES_UNDERSHIRT, 66, SEX_MALE, 3900),
            new BusinessClothesModel(0, "58", CLOTHES_UNDERSHIRT, 67, SEX_MALE, 3900),
            new BusinessClothesModel(0, "59", CLOTHES_UNDERSHIRT, 68, SEX_MALE, 3900),
            new BusinessClothesModel(0, "60", CLOTHES_UNDERSHIRT, 69, SEX_MALE, 3900),
            new BusinessClothesModel(0, "61", CLOTHES_UNDERSHIRT, 70, SEX_MALE, 3900),
            new BusinessClothesModel(0, "62", CLOTHES_UNDERSHIRT, 71, SEX_MALE, 3900),
            new BusinessClothesModel(0, "63", CLOTHES_UNDERSHIRT, 72, SEX_MALE, 3900),
            new BusinessClothesModel(0, "64", CLOTHES_UNDERSHIRT, 73, SEX_MALE, 3900),
            new BusinessClothesModel(0, "65", CLOTHES_UNDERSHIRT, 74, SEX_MALE, 3900),
            new BusinessClothesModel(0, "66", CLOTHES_UNDERSHIRT, 75, SEX_MALE, 3900),
            new BusinessClothesModel(0, "67", CLOTHES_UNDERSHIRT, 76, SEX_MALE, 3900),
            new BusinessClothesModel(0, "68", CLOTHES_UNDERSHIRT, 77, SEX_MALE, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 78, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 79, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 80, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "69", CLOTHES_UNDERSHIRT, 81, SEX_MALE, 3900),
            new BusinessClothesModel(0, "70", CLOTHES_UNDERSHIRT, 82, SEX_MALE, 3900),
            new BusinessClothesModel(0, "71", CLOTHES_UNDERSHIRT, 83, SEX_MALE, 3900),
            new BusinessClothesModel(0, "72", CLOTHES_UNDERSHIRT, 84, SEX_MALE, 3900),
            new BusinessClothesModel(0, "73", CLOTHES_UNDERSHIRT, 85, SEX_MALE, 3900),
            new BusinessClothesModel(0, "74", CLOTHES_UNDERSHIRT, 86, SEX_MALE, 3900),
            new BusinessClothesModel(0, "75", CLOTHES_UNDERSHIRT, 87, SEX_MALE, 3900),
            new BusinessClothesModel(0, "76", CLOTHES_UNDERSHIRT, 88, SEX_MALE, 3900),
            new BusinessClothesModel(0, "77", CLOTHES_UNDERSHIRT, 89, SEX_MALE, 3900),
            new BusinessClothesModel(0, "78", CLOTHES_UNDERSHIRT, 90, SEX_MALE, 3900),
            new BusinessClothesModel(0, "79", CLOTHES_UNDERSHIRT, 91, SEX_MALE, 3900),
            new BusinessClothesModel(0, "80", CLOTHES_UNDERSHIRT, 92, SEX_MALE, 3900),
            new BusinessClothesModel(0, "81", CLOTHES_UNDERSHIRT, 93, SEX_MALE, 3900),
            new BusinessClothesModel(0, "82", CLOTHES_UNDERSHIRT, 94, SEX_MALE, 3900),
            new BusinessClothesModel(0, "83", CLOTHES_UNDERSHIRT, 95, SEX_MALE, 3900),
            new BusinessClothesModel(0, "84", CLOTHES_UNDERSHIRT, 96, SEX_MALE, 3900),
            /*new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 97, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 98, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 99, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 100, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 101, SEX_MALE, 3900),
            new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 102, SEX_MALE, 3900),*/
            new BusinessClothesModel(0, "85", CLOTHES_UNDERSHIRT, 103, SEX_MALE, 3900),
            new BusinessClothesModel(0, "86", CLOTHES_UNDERSHIRT, 104, SEX_MALE, 3900),
            new BusinessClothesModel(0, "87", CLOTHES_UNDERSHIRT, 105, SEX_MALE, 3900),
            new BusinessClothesModel(0, "88", CLOTHES_UNDERSHIRT, 106, SEX_MALE, 3900),
            new BusinessClothesModel(0, "89", CLOTHES_UNDERSHIRT, 107, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 108, SEX_MALE, 3900),
            new BusinessClothesModel(0, "90", CLOTHES_UNDERSHIRT, 109, SEX_MALE, 3900),
            new BusinessClothesModel(0, "91", CLOTHES_UNDERSHIRT, 110, SEX_MALE, 3900),
            new BusinessClothesModel(0, "92", CLOTHES_UNDERSHIRT, 111, SEX_MALE, 3900),
            new BusinessClothesModel(0, "93", CLOTHES_UNDERSHIRT, 112, SEX_MALE, 3900),
            new BusinessClothesModel(0, "94", CLOTHES_UNDERSHIRT, 113, SEX_MALE, 3900),
            new BusinessClothesModel(0, "95", CLOTHES_UNDERSHIRT, 114, SEX_MALE, 3900),
            new BusinessClothesModel(0, "96", CLOTHES_UNDERSHIRT, 115, SEX_MALE, 3900),
            new BusinessClothesModel(0, "97", CLOTHES_UNDERSHIRT, 116, SEX_MALE, 3900),
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
            new BusinessClothesModel(0, "98", CLOTHES_UNDERSHIRT, 132, SEX_MALE, 3900),
            new BusinessClothesModel(0, "99", CLOTHES_UNDERSHIRT, 133, SEX_MALE, 3900),
            new BusinessClothesModel(0, "100", CLOTHES_UNDERSHIRT, 134, SEX_MALE, 3900),
            new BusinessClothesModel(0, "101", CLOTHES_UNDERSHIRT, 135, SEX_MALE, 3900),
            new BusinessClothesModel(0, "102", CLOTHES_UNDERSHIRT, 136, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 137, SEX_MALE, 3900),
            new BusinessClothesModel(0, "103", CLOTHES_UNDERSHIRT, 138, SEX_MALE, 3900),
            new BusinessClothesModel(0, "104", CLOTHES_UNDERSHIRT, 139, SEX_MALE, 3900),
            new BusinessClothesModel(0, "105", CLOTHES_UNDERSHIRT, 140, SEX_MALE, 3900),
            new BusinessClothesModel(0, "106", CLOTHES_UNDERSHIRT, 141, SEX_MALE, 3900),
            new BusinessClothesModel(0, "107", CLOTHES_UNDERSHIRT, 142, SEX_MALE, 3900),
            //new BusinessClothesModel(0, "", CLOTHES_UNDERSHIRT, 143, SEX_MALE, 3900),
 
                
                
            // Female hats
                
            //new BusinessClothesModel(1, "Auriculares rojos", ACCESSORY_HATS, 0, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Cono blanco", ACCESSORY_HATS, 1, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Karierte Cowboy Hut", ACCESSORY_HATS, 2, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Achatado cuadros negro y blanco", ACCESSORY_HATS, 3, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Los Santos Basecap", ACCESSORY_HATS, 4, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Mütze", ACCESSORY_HATS, 5, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Gorra negra", ACCESSORY_HATS, 6, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Blaue abgeflachte Mütze", ACCESSORY_HATS, 7, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Karierter Hut", ACCESSORY_HATS, 8, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "iFruit Basecap", ACCESSORY_HATS, 9, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Karierte Basecap", ACCESSORY_HATS, 10, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Karierter Sonnenhut", ACCESSORY_HATS, 11, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Mütze", ACCESSORY_HATS, 12, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Stroh Hut mit schwarzem Band", ACCESSORY_HATS, 13, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Maler Mütze", ACCESSORY_HATS, 14, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Weiße Kopfhörer", ACCESSORY_HATS, 15, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Casco amarillo rojo y negro", ACCESSORY_HATS, 16, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco abierto azul y negro", ACCESSORY_HATS, 17, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro", ACCESSORY_HATS, 18, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Cowboy Hut", ACCESSORY_HATS, 20, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Pinker Sonnenhut", ACCESSORY_HATS, 21, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Strand Hut", ACCESSORY_HATS, 22, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Papa noel", ACCESSORY_HATS, 23, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Duende", ACCESSORY_HATS, 24, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Reno", ACCESSORY_HATS, 25, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Chaplin Hut", ACCESSORY_HATS, 26, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Zylinder", ACCESSORY_HATS, 27, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Brauner Hut mit schwarzem Band", ACCESSORY_HATS, 28, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Lila Mütze", ACCESSORY_HATS, 29, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Hut", ACCESSORY_HATS, 30, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Zylinder", ACCESSORY_HATS, 31, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Choose you tercero", ACCESSORY_HATS, 32, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Wollmütze", ACCESSORY_HATS, 33, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Motiv", ACCESSORY_HATS, 34, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Sterne", ACCESSORY_HATS, 35, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Pißwasser Getränkhalter", ACCESSORY_HATS, 36, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Casco caballo", ACCESSORY_HATS, 38, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Arbol navidad", ACCESSORY_HATS, 39, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Postre", ACCESSORY_HATS, 40, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Navideño", ACCESSORY_HATS, 41, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Mama noel", ACCESSORY_HATS, 42, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra Naughty", ACCESSORY_HATS, 43, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Rote Basecap (Hinten)", ACCESSORY_HATS, 44, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Casco visera negro", ACCESSORY_HATS, 47, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro opaco", ACCESSORY_HATS, 49, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro espejo", ACCESSORY_HATS, 50, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra verde simbolo", ACCESSORY_HATS, 53, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Brauner Sonnenhut", ACCESSORY_HATS, 54, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Broker Basecap", ACCESSORY_HATS, 55, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Lagnetics Basecap", ACCESSORY_HATS, 56, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Gorra marron clarito", ACCESSORY_HATS, 58, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco caballo verde", ACCESSORY_HATS, 59, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Lana verde", ACCESSORY_HATS, 60, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Schwarzer Hut mit grünem Band", ACCESSORY_HATS, 61, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Casco verde", ACCESSORY_HATS, 62, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra verde", ACCESSORY_HATS, 63, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra negra triangulo rojo y blanco", ACCESSORY_HATS, 64, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gorra negra hacia atras", ACCESSORY_HATS, 65, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco oscuro abierta visera", ACCESSORY_HATS, 66, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro abierta visera", ACCESSORY_HATS, 67, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera espejo abierta", ACCESSORY_HATS, 68, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco verde visera abierta", ACCESSORY_HATS, 71, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco verde abierto", ACCESSORY_HATS, 74, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Atomic Basecap", ACCESSORY_HATS, 75, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Blaue Basecao (Hinten)", ACCESSORY_HATS, 76, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Mütze", ACCESSORY_HATS, 82, SEX_FEMALE, 2500),
            /*new BusinessClothesModel(1, "Casco guerra con pinchos", ACCESSORY_HATS, 83, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco guerra negro", ACCESSORY_HATS, 84, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco cresta", ACCESSORY_HATS, 86, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco trinchera", ACCESSORY_HATS, 88, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco trinchera plata", ACCESSORY_HATS, 89, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas", ACCESSORY_HATS, 90, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas visera abierta", ACCESSORY_HATS, 91, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Casco abierto blanco y azul", ACCESSORY_HATS, 92, SEX_FEMALE, 2500),*/
            new BusinessClothesModel(1, "Beiger Sonnenhut", ACCESSORY_HATS, 93, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarzer hut mit weißem Band", ACCESSORY_HATS, 94, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Bigness Basecap", ACCESSORY_HATS, 95, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Cuernos reno punta roja", ACCESSORY_HATS, 100, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Basecap", ACCESSORY_HATS, 101, SEX_FEMALE, 2500),
            //Neu hinzugefügt//
            new BusinessClothesModel(1, "Gemusteter Sonnenhut", ACCESSORY_HATS, 131, SEX_FEMALE, 2500),
 
                
                
            // Male hats
                
            //new BusinessClothesModel(1, "Auriculares rojos", ACCESSORY_HATS, 0, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Cono blanco", ACCESSORY_HATS, 1, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Lana negro", ACCESSORY_HATS, 2, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Karierter Sonnenhut", ACCESSORY_HATS, 3, SEX_MALE, 2500),
            new BusinessClothesModel(1, "LS Basecap", ACCESSORY_HATS, 4, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarze Wollmütze", ACCESSORY_HATS, 5, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra verde", ACCESSORY_HATS, 6, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorrilla blanca", ACCESSORY_HATS, 7, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra hacia atras cuadrados negros y blancos", ACCESSORY_HATS, 9, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Karierte Baseballcap", ACCESSORY_HATS, 10, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Hut", ACCESSORY_HATS, 12, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Cowboy Hut", ACCESSORY_HATS, 13, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Pañuelo blanco motivos negros", ACCESSORY_HATS, 14, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Blau, weiße Kopfhörer", ACCESSORY_HATS, 15, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco amarillo negro y rojo", ACCESSORY_HATS, 16, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco abierto azul y negro", ACCESSORY_HATS, 17, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco negro", ACCESSORY_HATS, 18, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Grüner Sonnenhut", ACCESSORY_HATS, 20, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gelber Sonnenhut", ACCESSORY_HATS, 21, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Papa noel", ACCESSORY_HATS, 22, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Duende navidad", ACCESSORY_HATS, 23, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Reno", ACCESSORY_HATS, 24, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Dunkelblauer Hut", ACCESSORY_HATS, 25, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Chaplin Hut", ACCESSORY_HATS, 26, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Zylinder", ACCESSORY_HATS, 27, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Blaue Wollfmütze", ACCESSORY_HATS, 28, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Graue Mütze", ACCESSORY_HATS, 29, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Roter Hut mit schwarzem Band", ACCESSORY_HATS, 30, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Hut", ACCESSORY_HATS, 31, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Zylinder", ACCESSORY_HATS, 32, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Choose you tercero", ACCESSORY_HATS, 33, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Wollmütze", ACCESSORY_HATS, 34, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Motiv", ACCESSORY_HATS, 35, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Sterne", ACCESSORY_HATS, 36, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Pißwasser Getränkhalter", ACCESSORY_HATS, 37, SEX_MALE, 2500),
            /*new BusinessClothesModel(1, "Negro caballo", ACCESSORY_HATS, 39, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Arbol navidad", ACCESSORY_HATS, 40, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Postre", ACCESSORY_HATS, 41, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Navideño", ACCESSORY_HATS, 42, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Papa noel a cuadros", ACCESSORY_HATS, 43, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gorra roja y blanca con letras", ACCESSORY_HATS, 44, SEX_MALE, 2500),*/
            new BusinessClothesModel(1, "Rote Basecap", ACCESSORY_HATS, 45, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco visera hacia delante negro", ACCESSORY_HATS, 48, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco negro opaco", ACCESSORY_HATS, 50, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco negro visera espejo", ACCESSORY_HATS, 51, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra verde letra", ACCESSORY_HATS, 54, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Broker Basecap", ACCESSORY_HATS, 55, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Lagnetics Basecap", ACCESSORY_HATS, 56, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra maron", ACCESSORY_HATS, 58, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco caballo verde", ACCESSORY_HATS, 59, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra verde", ACCESSORY_HATS, 60, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Hut mit grünem Band", ACCESSORY_HATS, 61, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Casco verde", ACCESSORY_HATS, 62, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Grüne Basecap", ACCESSORY_HATS, 63, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Blauer Hut", ACCESSORY_HATS, 64, SEX_MALE, 2500),
            /*new BusinessClothesModel(1, "Gorra negra triangulo rojo y blanco", ACCESSORY_HATS, 65, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gorra negra hacia atras", ACCESSORY_HATS, 66, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera abierta", ACCESSORY_HATS, 67, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera opaca abierta", ACCESSORY_HATS, 68, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro visera espejo abierta", ACCESSORY_HATS, 69, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco abierto verde", ACCESSORY_HATS, 75, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gorra azul y amarilla con letras", ACCESSORY_HATS, 76, SEX_MALE, 2500),*/
            new BusinessClothesModel(1, "Blaue Basecap", ACCESSORY_HATS, 77, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Kurze schwarze Wollfmütze", ACCESSORY_HATS, 83, SEX_MALE, 2500),
            /*new BusinessClothesModel(1, "Casco guerra pinchos", ACCESSORY_HATS, 84, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra", ACCESSORY_HATS, 85, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra visera", ACCESSORY_HATS, 86, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra cresta", ACCESSORY_HATS, 87, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra negro", ACCESSORY_HATS, 89, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco guerra plata", ACCESSORY_HATS, 90, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas", ACCESSORY_HATS, 91, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco negro rayas amarillas visera abierta", ACCESSORY_HATS, 92, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Casco abierto blanco con diana", ACCESSORY_HATS, 93, SEX_MALE, 2500),*/
            new BusinessClothesModel(1, "Beiger Sonnenhut", ACCESSORY_HATS, 94, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarzer Hut mit beigen Band", ACCESSORY_HATS, 95, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Gorra negra BIGNESS", ACCESSORY_HATS, 96, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Reno puntas rojas", ACCESSORY_HATS, 101, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarze Basecap", ACCESSORY_HATS, 102, SEX_MALE, 2500),
            //Neu hinzugefügt//
            new BusinessClothesModel(1, "Schwarze Wollmütze", ACCESSORY_HATS, 120, SEX_MALE, 2500),
 
                
                
            // Female glasses
                
            new BusinessClothesModel(1, "Braune Sonnenbrille", ACCESSORY_GLASSES, 0, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Große Sonnenbrille", ACCESSORY_GLASSES, 1, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Große schwarze Sonnenbrille", ACCESSORY_GLASSES, 2, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Rectas cristal marron", ACCESSORY_GLASSES, 3, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Leoparden Sonnenbrille", ACCESSORY_GLASSES, 4, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Silberne Sonnenbrille", ACCESSORY_GLASSES, 6, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Helle, silberne Sonnenbrille", ACCESSORY_GLASSES, 7, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze transperente Brille", ACCESSORY_GLASSES, 8, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Grüne Sportbrille", ACCESSORY_GLASSES, 9, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Grün zu blau farbige Brille", ACCESSORY_GLASSES, 10, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Blau, silberne Brille", ACCESSORY_GLASSES, 11, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze transperente Brille", ACCESSORY_GLASSES, 14, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Gold, schwarze Sonnenbrille", ACCESSORY_GLASSES, 16, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Brille", ACCESSORY_GLASSES, 17, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Sportlich graue Brille", ACCESSORY_GLASSES, 18, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Sportlich schwarze Brille", ACCESSORY_GLASSES, 19, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Redondas negras cristal transparente oscuro", ACCESSORY_GLASSES, 20, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze transperente Brille", ACCESSORY_GLASSES, 21, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Sternbrille", ACCESSORY_GLASSES, 22, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Brille", ACCESSORY_GLASSES, 23, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Schwarze Sonnenbrille", ACCESSORY_GLASSES, 24, SEX_FEMALE, 2500),
            new BusinessClothesModel(1, "Sportlich grüne Brille", ACCESSORY_GLASSES, 25, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Piloto", ACCESSORY_GLASSES, 26, SEX_FEMALE, 2500),
            //new BusinessClothesModel(1, "Snow", ACCESSORY_GLASSES, 27, SEX_FEMALE, 2500),
 
                
                
            // Male glasses
                
            new BusinessClothesModel(1, "Feine schwarze und weiße Quadrate", ACCESSORY_GLASSES, 1, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarz umrandete Sonnenbrille", ACCESSORY_GLASSES, 2, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarze Brille", ACCESSORY_GLASSES, 3, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarze halb umrandete Sonnenbrille", ACCESSORY_GLASSES, 4, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Blau, goldene Sonnenbrille", ACCESSORY_GLASSES, 5, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Blau, silberne Sonnenbrille", ACCESSORY_GLASSES, 8, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Sportlich schwarze Brille", ACCESSORY_GLASSES, 9, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Gold, schwarze quadratische Brille", ACCESSORY_GLASSES, 10, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Goldbraune Brille", ACCESSORY_GLASSES, 12, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarze Sonnenbrille", ACCESSORY_GLASSES, 13, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarz, gelbe Schutzbrille", ACCESSORY_GLASSES, 15, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Sportlich schwarze Sonnenbrille", ACCESSORY_GLASSES, 16, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarz, silberne Brille", ACCESSORY_GLASSES, 17, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Goldene Sonnenbrille", ACCESSORY_GLASSES, 18, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Altmodische Sonnenbrille", ACCESSORY_GLASSES, 19, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Schwarz, gelbe transparente Brille", ACCESSORY_GLASSES, 20, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Sternbrille", ACCESSORY_GLASSES, 21, SEX_MALE, 2500),
            new BusinessClothesModel(1, "U.S.A. Brille", ACCESSORY_GLASSES, 22, SEX_MALE, 2500),
            new BusinessClothesModel(1, "Sportlich grüne Sonnenbrille", ACCESSORY_GLASSES, 23, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Piloto", ACCESSORY_GLASSES, 24, SEX_MALE, 2500),
            //new BusinessClothesModel(1, "Snow", ACCESSORY_GLASSES, 25, SEX_MALE, 2500),
 
                
                
            // Female earrings
                
            new BusinessClothesModel(1, "Schwarz, weißes Headset", ACCESSORY_EARS, 0, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Schwarzes Headset", ACCESSORY_EARS, 1, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Schwarzes Headset (Dick)", ACCESSORY_EARS, 2, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Silberner Ohrring (Lang)", ACCESSORY_EARS, 3, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Brauner Ohrring (Lang)", ACCESSORY_EARS, 4, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Silberohrring", ACCESSORY_EARS, 5, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Goldene Raute", ACCESSORY_EARS, 6, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Goldener Ohrring (Lang)", ACCESSORY_EARS, 7, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Goldene Kugel (Lang)", ACCESSORY_EARS, 8, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Goldvorhang", ACCESSORY_EARS, 9, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Grüne hängende Kugel", ACCESSORY_EARS, 10, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Langes gold", ACCESSORY_EARS, 11, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Kleiner Ohrring", ACCESSORY_EARS, 12, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Gold Ring (Waffe)", ACCESSORY_EARS, 13, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Gold Ring (Gemustert)", ACCESSORY_EARS, 14, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Gold Ring (Glatt)", ACCESSORY_EARS, 15, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Gold Ring (Fuck)", ACCESSORY_EARS, 16, SEX_FEMALE, 1500),
            new BusinessClothesModel(1, "Gold Ring (Scream)", ACCESSORY_EARS, 17, SEX_FEMALE, 1500),
 
                
                
            // Male earrings
                
            new BusinessClothesModel(1, "Schwarz, weißes Headset", ACCESSORY_EARS, 0, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Schwarzes Headset", ACCESSORY_EARS, 1, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Goldener Ohrring", ACCESSORY_EARS, 4, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Kleiner Goldener Kreis", ACCESSORY_EARS, 7, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Goldene Pyramide", ACCESSORY_EARS, 10, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Goldenes Quadrat", ACCESSORY_EARS, 13, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Diamant", ACCESSORY_EARS, 16, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Weißdorn", ACCESSORY_EARS, 22, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Silbener Schädel", ACCESSORY_EARS, 25, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Metall Stecker", ACCESSORY_EARS, 28, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Schwarzes Quadrat", ACCESSORY_EARS, 31, SEX_MALE, 1500),
            new BusinessClothesModel(1, "Silbernes Quadrat", ACCESSORY_EARS, 35, SEX_MALE, 1500)


        };

        // Tattoo list
        public static List<BusinessTattooModel> TATTOO_LIST = new List<BusinessTattooModel>
        {
            // Torso
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Refined Hustler", "mpbusiness_overlays", "MP_Buis_M_Stomach_000", string.Empty, 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Rich", "mpbusiness_overlays", "MP_Buis_M_Chest_000", string.Empty, 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "$$$", "mpbusiness_overlays", "MP_Buis_M_Chest_001", string.Empty, 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Makin' Paper", "mpbusiness_overlays", "MP_Buis_M_Back_000", string.Empty, 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "High Roller", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Chest_000", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Makin' Money", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Chest_001", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Love Money", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Chest_002", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Diamond Back", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Stom_000", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Santo Capra Logo", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Stom_001", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Money Bag", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Stom_002", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Respect", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Back_000", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Gold Digger", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Back_001", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Carp Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_005", "MP_Xmas2_F_Tat_005", 230),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Carp Shaded", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_006", "MP_Xmas2_F_Tat_006", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Time To Die", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_009", "MP_Xmas2_F_Tat_009", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Roaring Tiger", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_011", "MP_Xmas2_F_Tat_011", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Lizard", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_013", "MP_Xmas2_F_Tat_013", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Japanese Warrior", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_015", "MP_Xmas2_F_Tat_015", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Loose Lips Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_016", "MP_Xmas2_F_Tat_016", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Loose Lips Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_017", "MP_Xmas2_F_Tat_017", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Royal Dagger Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_018", "MP_Xmas2_F_Tat_018", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Royal Dagger Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_019", "MP_Xmas2_F_Tat_019", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Executioner", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_028", "MP_Xmas2_F_Tat_028", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Bullet Proof", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_000_M", "MP_Gunrunning_Tattoo_000_F", 320),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Crossed Weapons", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_001_M", "MP_Gunrunning_Tattoo_001_F", 320),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Butterfly Knife", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_009_M", "MP_Gunrunning_Tattoo_009_F", 320),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Cash Money", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_010_M", "MP_Gunrunning_Tattoo_010_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dollar Daggers", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_012_M", "MP_Gunrunning_Tattoo_012_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Wolf Insignia", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_013_M", "MP_Gunrunning_Tattoo_013_F", 450),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Backstabber", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_014_M", "MP_Gunrunning_Tattoo_014_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dog Tags", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_017_M", "MP_Gunrunning_Tattoo_017_F", 120),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dual Wield Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_018_M", "MP_Gunrunning_Tattoo_018_F", 270),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Pistol Wings", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_019_M", "MP_Gunrunning_Tattoo_019_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Crowned Weapons", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_020_M", "MP_Gunrunning_Tattoo_020_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Explosive Heart", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_022_M", "MP_Gunrunning_Tattoo_022_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Micro SMG Chain", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_028_M", "MP_Gunrunning_Tattoo_028_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Win Some Lose Some", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_029_M", "MP_Gunrunning_Tattoo_029_F", 280),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Crossed Arrows", "mphipster_overlays", "FM_Hip_M_Tat_000", "FM_Hip_F_Tat_000", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Chemistry", "mphipster_overlays", "FM_Hip_M_Tat_002", "FM_Hip_F_Tat_002", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Feather Birds", "mphipster_overlays", "FM_Hip_M_Tat_006", "FM_Hip_F_Tat_006", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Infinity", "mphipster_overlays", "FM_Hip_M_Tat_011", "FM_Hip_F_Tat_011", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Antlers", "mphipster_overlays", "FM_Hip_M_Tat_012", "FM_Hip_F_Tat_012", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Boombox", "mphipster_overlays", "FM_Hip_M_Tat_013", "FM_Hip_F_Tat_013", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Pyramid", "mphipster_overlays", "FM_Hip_M_Tat_024", "FM_Hip_F_Tat_024", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Watch Your Step", "mphipster_overlays", "FM_Hip_M_Tat_025", "FM_Hip_F_Tat_025", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Sad", "mphipster_overlays", "FM_Hip_M_Tat_029", "FM_Hip_F_Tat_029", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Shark Fin", "mphipster_overlays", "FM_Hip_M_Tat_030", "FM_Hip_F_Tat_030", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Skateboard", "mphipster_overlays", "FM_Hip_M_Tat_031", "FM_Hip_F_Tat_031", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Paper Plane", "mphipster_overlays", "FM_Hip_M_Tat_032", "FM_Hip_F_Tat_032", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Stag", "mphipster_overlays", "FM_Hip_M_Tat_033", "FM_Hip_F_Tat_033", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Sewn Heart", "mphipster_overlays", "FM_Hip_M_Tat_035", "FM_Hip_F_Tat_035", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Tooth", "mphipster_overlays", "FM_Hip_M_Tat_041", "FM_Hip_F_Tat_041", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Triangles", "mphipster_overlays", "FM_Hip_M_Tat_046", "FM_Hip_F_Tat_046", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Cassette", "mphipster_overlays", "FM_Hip_M_Tat_047", "FM_Hip_F_Tat_047", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Block Back", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_000_M", "MP_MP_ImportExport_Tat_000_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Power Plant", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_001_M", "MP_MP_ImportExport_Tat_001_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Tuned to Death", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_002_M", "MP_MP_ImportExport_Tat_002_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Serpents of Destruction", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_009_M", "MP_MP_ImportExport_Tat_009_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Take the Wheel", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_010_M", "MP_MP_ImportExport_Tat_010_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Talk Shit Get Hit", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_011_M", "MP_MP_ImportExport_Tat_011_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "King Fight", "mplowrider_overlays", "MP_LR_Tat_001_M", "MP_LR_Tat_001_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Holy Mary", "mplowrider_overlays", "MP_LR_Tat_002_M", "MP_LR_Tat_002_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Gun Mic", "mplowrider_overlays", "MP_LR_Tat_004_M", "MP_LR_Tat_004_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Amazon", "mplowrider_overlays", "MP_LR_Tat_009_M", "MP_LR_Tat_009_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Bad Angel", "mplowrider_overlays", "MP_LR_Tat_010_M", "MP_LR_Tat_010_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Love Gamble", "mplowrider_overlays", "MP_LR_Tat_013_M", "MP_LR_Tat_013_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Love is Blind", "mplowrider_overlays", "MP_LR_Tat_014_M", "MP_LR_Tat_014_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Sad Angel", "mplowrider_overlays", "MP_LR_Tat_021_M", "MP_LR_Tat_021_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Royal Takeover", "mplowrider_overlays", "MP_LR_Tat_026_M", "MP_LR_Tat_026_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Turbulence", "mpairraces_overlays", "MP_Airraces_Tattoo_000_M", "MP_Airraces_Tattoo_000_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Pilot Skull", "mpairraces_overlays", "MP_Airraces_Tattoo_001_M", "MP_Airraces_Tattoo_001_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Winged Bombshell", "mpairraces_overlays", "MP_Airraces_Tattoo_002_M", "MP_Airraces_Tattoo_002_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Balloon Pioneer", "mpairraces_overlays", "MP_Airraces_Tattoo_004_M", "MP_Airraces_Tattoo_004_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Parachute Belle", "mpairraces_overlays", "MP_Airraces_Tattoo_005_M", "MP_Airraces_Tattoo_005_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Bombs Away", "mpairraces_overlays", "MP_Airraces_Tattoo_006_M", "MP_Airraces_Tattoo_006_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Eagle Eyes", "mpairraces_overlays", "MP_Airraces_Tattoo_007_M", "MP_Airraces_Tattoo_007_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Demon Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_000_M", "MP_MP_Biker_Tat_000_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Both Barrels", "mpbiker_overlays", "MP_MP_Biker_Tat_001_M", "MP_MP_Biker_Tat_001_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Web Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_003_M", "MP_MP_Biker_Tat_003_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Made In America", "mpbiker_overlays", "MP_MP_Biker_Tat_005_M", "MP_MP_Biker_Tat_005_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Chopper Freedom", "mpbiker_overlays", "MP_MP_Biker_Tat_006_M", "MP_MP_Biker_Tat_006_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Freedom Wheels", "mpbiker_overlays", "MP_MP_Biker_Tat_008_M", "MP_MP_Biker_Tat_008_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Skull Of Taurus", "mpbiker_overlays", "MP_MP_Biker_Tat_010_M", "MP_MP_Biker_Tat_010_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "R.I.P. My Brothers", "mpbiker_overlays", "MP_MP_Biker_Tat_011_M", "MP_MP_Biker_Tat_011_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Demon Crossbones", "mpbiker_overlays", "MP_MP_Biker_Tat_013_M", "MP_MP_Biker_Tat_013_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Clawed Beast", "mpbiker_overlays", "MP_MP_Biker_Tat_017_M", "MP_MP_Biker_Tat_017_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Skeletal Chopper", "mpbiker_overlays", "MP_MP_Biker_Tat_018_M", "MP_MP_Biker_Tat_018_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Gruesome Talons", "mpbiker_overlays", "MP_MP_Biker_Tat_019_M", "MP_MP_Biker_Tat_019_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Flaming Reaper", "mpbiker_overlays", "MP_MP_Biker_Tat_021_M", "MP_MP_Biker_Tat_021_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Western MC", "mpbiker_overlays", "MP_MP_Biker_Tat_023_M", "MP_MP_Biker_Tat_023_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "American Dream", "mpbiker_overlays", "MP_MP_Biker_Tat_026_M", "MP_MP_Biker_Tat_026_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Bone Wrench", "mpbiker_overlays", "MP_MP_Biker_Tat_029_M", "MP_MP_Biker_Tat_029_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Brothers For Life", "mpbiker_overlays", "MP_MP_Biker_Tat_030_M", "MP_MP_Biker_Tat_030_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Gear Head", "mpbiker_overlays", "MP_MP_Biker_Tat_031_M", "MP_MP_Biker_Tat_031_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Western Eagle", "mpbiker_overlays", "MP_MP_Biker_Tat_032_M", "MP_MP_Biker_Tat_032_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Brotherhood of Bikes", "mpbiker_overlays", "MP_MP_Biker_Tat_034_M", "MP_MP_Biker_Tat_034_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Gas Guzzler", "mpbiker_overlays", "MP_MP_Biker_Tat_039_M", "MP_MP_Biker_Tat_039_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "No Regrets", "mpbiker_overlays", "MP_MP_Biker_Tat_041_M", "MP_MP_Biker_Tat_041_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Ride Forever", "mpbiker_overlays", "MP_MP_Biker_Tat_043_M", "MP_MP_Biker_Tat_043_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Unforgiven", "mpbiker_overlays", "MP_MP_Biker_Tat_050_M", "MP_MP_Biker_Tat_050_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Biker Mount", "mpbiker_overlays", "MP_MP_Biker_Tat_052_M", "MP_MP_Biker_Tat_052_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Reaper Vulture", "mpbiker_overlays", "MP_MP_Biker_Tat_058_M", "MP_MP_Biker_Tat_058_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Faggio", "mpbiker_overlays", "MP_MP_Biker_Tat_059_M", "MP_MP_Biker_Tat_059_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "We Are The Mods!", "mpbiker_overlays", "MP_MP_Biker_Tat_060_M", "MP_MP_Biker_Tat_060_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "SA Assault", "mplowrider2_overlays", "MP_LR_Tat_000_M", "MP_LR_Tat_000_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Love the Game", "mplowrider2_overlays", "MP_LR_Tat_008_M", "MP_LR_Tat_008_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Lady Liberty", "mplowrider2_overlays", "MP_LR_Tat_011_M", "MP_LR_Tat_011_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Royal Kiss", "mplowrider2_overlays", "MP_LR_Tat_012_M", "MP_LR_Tat_012_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Two Face", "mplowrider2_overlays", "MP_LR_Tat_016_M", "MP_LR_Tat_016_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Death Behind", "mplowrider2_overlays", "MP_LR_Tat_019_M", "MP_LR_Tat_019_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dead Pretty", "mplowrider2_overlays", "MP_LR_Tat_031_M", "MP_LR_Tat_031_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Reign Over", "mplowrider2_overlays", "MP_LR_Tat_032_M", "MP_LR_Tat_032_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Abstract Skull", "mpluxe_overlays", "MP_LUXE_TAT_003_M", "MP_LUXE_TAT_003_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Eye of the Griffin", "mpluxe_overlays", "MP_LUXE_TAT_007_M", "MP_LUXE_TAT_007_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Flying Eye", "mpluxe_overlays", "MP_LUXE_TAT_008_M", "MP_LUXE_TAT_008_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Ancient Queen", "mpluxe_overlays", "MP_LUXE_TAT_014_M", "MP_LUXE_TAT_014_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Smoking Sisters", "mpluxe_overlays", "MP_LUXE_TAT_015_M", "MP_LUXE_TAT_015_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Feather Mural", "mpluxe_overlays", "MP_LUXE_TAT_024_M", "MP_LUXE_TAT_024_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "The Howler", "mpluxe2_overlays", "MP_LUXE_TAT_002_M", "MP_LUXE_TAT_002_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Geometric Galaxy", "mpluxe2_overlays", "MP_LUXE_TAT_012_M", "MP_LUXE_TAT_012_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Cloaked Angel", "mpluxe2_overlays", "MP_LUXE_TAT_022_M", "MP_LUXE_TAT_022_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Reaper Sway", "mpluxe2_overlays", "MP_LUXE_TAT_025_M", "MP_LUXE_TAT_025_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Cobra Dawn", "mpluxe2_overlays", "MP_LUXE_TAT_027_M", "MP_LUXE_TAT_027_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Geometric Design", "mpluxe2_overlays", "MP_LUXE_TAT_029_M", "MP_LUXE_TAT_029_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Bless The Dead", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_000_M", "MP_Smuggler_Tattoo_000_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dead Lies", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_002_M", "MP_Smuggler_Tattoo_002_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Give Nothing Back", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_003_M", "MP_Smuggler_Tattoo_003_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Never Surrender", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_006_M", "MP_Smuggler_Tattoo_006_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "No Honor", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_007_M", "MP_Smuggler_Tattoo_007_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Tall Ship Conflict", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_009_M", "MP_Smuggler_Tattoo_009_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "See You In Hell", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_010_M", "MP_Smuggler_Tattoo_010_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Torn Wings", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_013_M", "MP_Smuggler_Tattoo_013_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Jolly Roger", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_015_M", "MP_Smuggler_Tattoo_015_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Skull Compass", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_016_M", "MP_Smuggler_Tattoo_016_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Framed Tall Ship", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_017_M", "MP_Smuggler_Tattoo_017_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Finders Keepers", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_018_M", "MP_Smuggler_Tattoo_018_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Lost At Sea", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_019_M", "MP_Smuggler_Tattoo_019_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dead Tales", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_021_M", "MP_Smuggler_Tattoo_021_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "X Marks The Spot", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_022_M", "MP_Smuggler_Tattoo_022_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Pirate Captain", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_024_M", "MP_Smuggler_Tattoo_024_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Claimed By The Beast", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_025_M", "MP_Smuggler_Tattoo_025_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Wheels of Death", "mpstunt_overlays", "MP_MP_Stunt_Tat_011_M", "MP_MP_Stunt_Tat_011_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Punk Biker", "mpstunt_overlays", "MP_MP_Stunt_Tat_012_M", "MP_MP_Stunt_Tat_012_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Bat Cat of Spades", "mpstunt_overlays", "MP_MP_Stunt_Tat_014_M", "MP_MP_Stunt_Tat_014_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Vintage Bully", "mpstunt_overlays", "MP_MP_Stunt_Tat_018_M", "MP_MP_Stunt_Tat_018_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Engine Heart", "mpstunt_overlays", "MP_MP_Stunt_Tat_019_M", "MP_MP_Stunt_Tat_019_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Road Kill", "mpstunt_overlays", "MP_MP_Stunt_Tat_024_M", "MP_MP_Stunt_Tat_024_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Winged Wheel", "mpstunt_overlays", "MP_MP_Stunt_Tat_026_M", "MP_MP_Stunt_Tat_026_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Punk Road Hog", "mpstunt_overlays", "MP_MP_Stunt_Tat_027_M", "MP_MP_Stunt_Tat_027_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Majestic Finish", "mpstunt_overlays", "MP_MP_Stunt_Tat_029_M", "MP_MP_Stunt_Tat_029_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Man's Ruin", "mpstunt_overlays", "MP_MP_Stunt_Tat_030_M", "MP_MP_Stunt_Tat_030_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Sugar Skull Trucker", "mpstunt_overlays", "MP_MP_Stunt_Tat_033_M", "MP_MP_Stunt_Tat_033_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Feather Road Kill", "mpstunt_overlays", "MP_MP_Stunt_Tat_034_M", "MP_MP_Stunt_Tat_034_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Big Grills", "mpstunt_overlays", "MP_MP_Stunt_Tat_037_M", "MP_MP_Stunt_Tat_037_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Monkey Chopper", "mpstunt_overlays", "MP_MP_Stunt_Tat_040_M", "MP_MP_Stunt_Tat_040_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Brapp", "mpstunt_overlays", "MP_MP_Stunt_Tat_041_M", "MP_MP_Stunt_Tat_041_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Ram Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_044_M", "MP_MP_Stunt_Tat_044_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Full Throttle", "mpstunt_overlays", "MP_MP_Stunt_Tat_046_M", "MP_MP_Stunt_Tat_046_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Racing Doll", "mpstunt_overlays", "MP_MP_Stunt_Tat_048_M", "MP_MP_Stunt_Tat_048_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Blackjack", "multiplayer_overlays", "FM_Tat_Award_M_003", "FM_Tat_Award_F_003", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Hustler", "multiplayer_overlays", "FM_Tat_Award_M_004", "FM_Tat_Award_F_004", 300),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Angel", "multiplayer_overlays", "FM_Tat_Award_M_005", "FM_Tat_Award_F_005", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Los Santos Customs", "multiplayer_overlays", "FM_Tat_Award_M_008", "FM_Tat_Award_F_008", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Blank Scroll", "multiplayer_overlays", "FM_Tat_Award_M_011", "FM_Tat_Award_F_011", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Embellished Scroll", "multiplayer_overlays", "FM_Tat_Award_M_012", "FM_Tat_Award_F_012", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Seven Deadly Sins", "multiplayer_overlays", "FM_Tat_Award_M_013", "FM_Tat_Award_F_013", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Trust No One", "multiplayer_overlays", "FM_Tat_Award_M_014", "FM_Tat_Award_F_014", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Clown", "multiplayer_overlays", "FM_Tat_Award_M_016", "FM_Tat_Award_F_016", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Clown and Gun", "multiplayer_overlays", "FM_Tat_Award_M_017", "FM_Tat_Award_F_017", 220),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Clown Dual Wield", "multiplayer_overlays", "FM_Tat_Award_M_018", "FM_Tat_Award_F_018", 240),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Clown Dual Wield Dollars", "multiplayer_overlays", "FM_Tat_Award_M_019", "FM_Tat_Award_F_019", 260),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Faith", "multiplayer_overlays", "FM_Tat_M_004", "FM_Tat_F_004", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Skull on the Cross", "multiplayer_overlays", "FM_Tat_M_009", "FM_Tat_F_009", 400),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "LS Flames", "multiplayer_overlays", "FM_Tat_M_010", "FM_Tat_F_010", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "LS IScript", "multiplayer_overlays", "FM_Tat_M_011", "FM_Tat_F_011", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Los Santos Bills", "multiplayer_overlays", "FM_Tat_M_012", "FM_Tat_F_012", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Eagle and Serpent", "multiplayer_overlays", "FM_Tat_M_013", "FM_Tat_F_013", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Evil Clown", "multiplayer_overlays", "FM_Tat_M_016", "FM_Tat_F_016", 450),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "The Wages of Sin", "multiplayer_overlays", "FM_Tat_M_019", "FM_Tat_F_019", 450),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Dragon", "multiplayer_overlays", "FM_Tat_M_020", "FM_Tat_F_020", 420),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Flaming Cross", "multiplayer_overlays", "FM_Tat_M_024", "FM_Tat_F_024", 350),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "LS Bold", "multiplayer_overlays", "FM_Tat_M_025", "FM_Tat_F_025", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Trinity Knot", "multiplayer_overlays", "FM_Tat_M_029", "FM_Tat_F_029", 100),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Lucky Celtic Dogs", "multiplayer_overlays", "FM_Tat_M_030", "FM_Tat_F_030", 200),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Flaming Shamrock", "multiplayer_overlays", "FM_Tat_M_034", "FM_Tat_F_034", 150),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Way of the Gun", "multiplayer_overlays", "FM_Tat_M_036", "FM_Tat_F_036", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Stone Cross", "multiplayer_overlays", "FM_Tat_M_044", "FM_Tat_F_044", 250),
            new BusinessTattooModel(TATTOO_ZONE_TORSO, "Skulls and Rose", "multiplayer_overlays", "FM_Tat_M_045", "FM_Tat_F_045", 400),
            
            // Head
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Cash is King", "mpbusiness_overlays", "MP_Buis_M_Neck_000", string.Empty, 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Bold Dollar Sign", "mpbusiness_overlays", "MP_Buis_M_Neck_001", string.Empty, 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "IScript Dollar Sign", "mpbusiness_overlays", "MP_Buis_M_Neck_002", string.Empty, 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "$100", "mpbusiness_overlays", "MP_Buis_M_Neck_003", string.Empty, 150),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Val-de-Grace Logo", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Neck_000", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Money Rose", "mpbusiness_overlays", string.Empty, "MP_Buis_F_Neck_001", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Los Muertos", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_007", "MP_Xmas2_F_Tat_007", 150),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Snake Head Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_024", "MP_Xmas2_F_Tat_024", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Snake Head Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_025", "MP_Xmas2_F_Tat_025", 150),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Beautiful Death", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_029", "MP_Xmas2_F_Tat_029", 150),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Lock & Load", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_003_M", "MP_Gunrunning_Tattoo_003_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Beautiful Eye", "mphipster_overlays", "FM_Hip_M_Tat_005", "FM_Hip_F_Tat_005", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Geo Fox", "mphipster_overlays", "FM_Hip_M_Tat_021", "FM_Hip_F_Tat_021", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Morbid Arachnid", "mpbiker_overlays", "MP_MP_Biker_Tat_009_M", "MP_MP_Biker_Tat_009_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "FTW", "mpbiker_overlays", "MP_MP_Biker_Tat_038_M", "MP_MP_Biker_Tat_038_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Western Stylized", "mpbiker_overlays", "MP_MP_Biker_Tat_051_M", "MP_MP_Biker_Tat_051_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Sinner", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_011_M", "MP_Smuggler_Tattoo_011_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Thief", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_012_M", "MP_Smuggler_Tattoo_012_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Stunt Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_000_M", "MP_MP_Stunt_Tat_000_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Scorpion", "mpstunt_overlays", "MP_MP_Stunt_Tat_004_M", "MP_MP_Stunt_Tat_004_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Toxic Spider", "mpstunt_overlays", "MP_MP_Stunt_Tat_006_M", "MP_MP_Stunt_Tat_006_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Bat Wheel", "mpstunt_overlays", "MP_MP_Stunt_Tat_017_M", "MP_MP_Stunt_Tat_017_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Flaming Quad", "mpstunt_overlays", "MP_MP_Stunt_Tat_042_M", "MP_MP_Stunt_Tat_042_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_HEAD, "Skull", "multiplayer_overlays", "FM_Tat_Award_M_000", "FM_Tat_Award_F_000", 100),

            // Left arm
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "$100 Bill", "mpbusiness_overlays", "MP_Buis_M_LeftArm_000", string.Empty, 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "All-Seeing Eye", "mpbusiness_overlays", "MP_Buis_M_LeftArm_001", string.Empty, 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Greed is Good", "mpbusiness_overlays", string.Empty, "MP_Buis_F_LArm_000", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Skull Rider", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_000", "MP_Xmas2_F_Tat_000", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Electric Snake", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_010", "MP_Xmas2_F_Tat_010", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "8 Ball Skull", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_012", "MP_Xmas2_F_Tat_012", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Time's Up Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_020", "MP_Xmas2_F_Tat_020", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Time's Up Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_021", "MP_Xmas2_F_Tat_021", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Sidearm", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_004_M", "MP_Gunrunning_Tattoo_004_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Bandolier", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_008_M", "MP_Gunrunning_Tattoo_008_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Spiked Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_015_M", "MP_Gunrunning_Tattoo_015_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Blood Money", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_016_M", "MP_Gunrunning_Tattoo_016_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Praying Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_025_M", "MP_Gunrunning_Tattoo_025_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Serpent Revolver", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_027_M", "MP_Gunrunning_Tattoo_027_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Diamond Sparkle", "mphipster_overlays", "FM_Hip_M_Tat_003", "FM_Hip_F_Tat_003", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Bricks", "mphipster_overlays", "FM_Hip_M_Tat_007", "FM_Hip_F_Tat_007", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Mustache", "mphipster_overlays", "FM_Hip_M_Tat_015", "FM_Hip_F_Tat_015", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Lightning Bolt", "mphipster_overlays", "FM_Hip_M_Tat_016", "FM_Hip_F_Tat_016", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Pizza", "mphipster_overlays", "FM_Hip_M_Tat_026", "FM_Hip_F_Tat_026", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Padlock", "mphipster_overlays", "FM_Hip_M_Tat_027", "FM_Hip_F_Tat_027", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Thorny Rose", "mphipster_overlays", "FM_Hip_M_Tat_028", "FM_Hip_F_Tat_028", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Stop", "mphipster_overlays", "FM_Hip_M_Tat_034", "FM_Hip_F_Tat_034", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Sunrise", "mphipster_overlays", "FM_Hip_M_Tat_037", "FM_Hip_F_Tat_037", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Sleeve", "mphipster_overlays", "FM_Hip_M_Tat_039", "FM_Hip_F_Tat_039", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Triangle White", "mphipster_overlays", "FM_Hip_M_Tat_043", "FM_Hip_F_Tat_043", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Peace", "mphipster_overlays", "FM_Hip_M_Tat_048", "FM_Hip_F_Tat_048", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Piston Sleeve", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_004_M", "MP_MP_ImportExport_Tat_004_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Scarlett", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_008_M", "MP_MP_ImportExport_Tat_008_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "No Evil", "mplowrider_overlays", "MP_LR_Tat_005_M", "MP_LR_Tat_005_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Los Santos Life", "mplowrider_overlays", "MP_LR_Tat_027_M", "MP_LR_Tat_027_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "City Sorrow", "mplowrider_overlays", "MP_LR_Tat_033_M", "MP_LR_Tat_033_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Toxic Trails", "mpairraces_overlays", "MP_Airraces_Tattoo_003_M", "MP_Airraces_Tattoo_003_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Urban Stunter", "mpbiker_overlays", "MP_MP_Biker_Tat_012_M", "MP_MP_Biker_Tat_012_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Macabre Tree", "mpbiker_overlays", "MP_MP_Biker_Tat_016_M", "MP_MP_Biker_Tat_016_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Cranial Rose", "mpbiker_overlays", "MP_MP_Biker_Tat_020_M", "MP_MP_Biker_Tat_020_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Live to Ride", "mpbiker_overlays", "MP_MP_Biker_Tat_024_M", "MP_MP_Biker_Tat_024_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Good Luck", "mpbiker_overlays", "MP_MP_Biker_Tat_025_M", "MP_MP_Biker_Tat_025_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Chain Fist", "mpbiker_overlays", "MP_MP_Biker_Tat_035_M", "MP_MP_Biker_Tat_035_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Ride Hard Die Fast", "mpbiker_overlays", "MP_MP_Biker_Tat_045_M", "MP_MP_Biker_Tat_045_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Muffler Helmet", "mpbiker_overlays", "MP_MP_Biker_Tat_053_M", "MP_MP_Biker_Tat_053_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Poison Scorpion", "mpbiker_overlays", "MP_MP_Biker_Tat_055_M", "MP_MP_Biker_Tat_055_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Love Hustle", "mplowrider2_overlays", "MP_LR_Tat_006_M", "MP_LR_Tat_006_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Skeleton Party", "mplowrider2_overlays", "MP_LR_Tat_018_M", "MP_LR_Tat_018_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "My Crazy Life", "mplowrider2_overlays", "MP_LR_Tat_022_M", "MP_LR_Tat_022_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Archangel & Mary", "mpluxe_overlays", "MP_LUXE_TAT_020_M", "MP_LUXE_TAT_020_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Gabriel", "mpluxe_overlays", "MP_LUXE_TAT_021_M", "MP_LUXE_TAT_021_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Fatal Dagger", "mpluxe2_overlays", "MP_LUXE_TAT_005_M", "MP_LUXE_TAT_005_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Egyptian Mural", "mpluxe2_overlays", "MP_LUXE_TAT_016_M", "MP_LUXE_TAT_016_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Divine Goddess", "mpluxe2_overlays", "MP_LUXE_TAT_018_M", "MP_LUXE_TAT_018_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Python Skull", "mpluxe2_overlays", "MP_LUXE_TAT_028_M", "MP_LUXE_TAT_028_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Geometric Design", "mpluxe2_overlays", "MP_LUXE_TAT_031_M", "MP_LUXE_TAT_031_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Honor", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_004_M", "MP_Smuggler_Tattoo_004_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Horrors Of The Deep", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_008_M", "MP_Smuggler_Tattoo_008_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Mermaid's Curse", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_014_M", "MP_Smuggler_Tattoo_014_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "8 Eyed Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_001_M", "MP_MP_Stunt_Tat_001_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Big Cat", "mpstunt_overlays", "MP_MP_Stunt_Tat_002_M", "MP_MP_Stunt_Tat_002_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Moonlight Ride", "mpstunt_overlays", "MP_MP_Stunt_Tat_008_M", "MP_MP_Stunt_Tat_008_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Piston Head", "mpstunt_overlays", "MP_MP_Stunt_Tat_022_M", "MP_MP_Stunt_Tat_022_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Tanked", "mpstunt_overlays", "MP_MP_Stunt_Tat_023_M", "MP_MP_Stunt_Tat_023_F", 450),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Stuntman's End", "mpstunt_overlays", "MP_MP_Stunt_Tat_035_M", "MP_MP_Stunt_Tat_035_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Kaboom", "mpstunt_overlays", "MP_MP_Stunt_Tat_039_M", "MP_MP_Stunt_Tat_039_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Engine Arm", "mpstunt_overlays", "MP_MP_Stunt_Tat_043_M", "MP_MP_Stunt_Tat_043_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Burning Heart", "multiplayer_overlays", "FM_Tat_Award_M_001", "FM_Tat_Award_F_001", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Racing Blonde", "multiplayer_overlays", "FM_Tat_Award_M_007", "FM_Tat_Award_F_007", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Racing Brunette", "multiplayer_overlays", "FM_Tat_Award_M_015", "FM_Tat_Award_F_015", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Serpents", "multiplayer_overlays", "FM_Tat_M_005", "FM_Tat_F_005", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Oriental Mural", "multiplayer_overlays", "FM_Tat_M_006", "FM_Tat_F_006", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Zodiac Skull", "multiplayer_overlays", "FM_Tat_M_015", "FM_Tat_F_015", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Lady M", "multiplayer_overlays", "FM_Tat_M_031", "FM_Tat_F_031", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_ARM, "Dope Skull", "multiplayer_overlays", "FM_Tat_M_041", "FM_Tat_F_041", 100),

            // Right arm
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Dollar Skull", "mpbusiness_overlays", "MP_Buis_M_RightArm_000", string.Empty, 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Green", "mpbusiness_overlays", "MP_Buis_M_RightArm_001", string.Empty, 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Dollar Sign", "mpbusiness_overlays", string.Empty, "MP_Buis_F_RArm_000", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Snake Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_003", "MP_Xmas2_F_Tat_003", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Snake Shaded", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_004", "MP_Xmas2_F_Tat_004", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Death Before Dishonor", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_008", "MP_Xmas2_F_Tat_008", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "You're Next Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_022", "MP_Xmas2_F_Tat_022", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "You're Next Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_023", "MP_Xmas2_F_Tat_023", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Fuck Luck Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_026", "MP_Xmas2_F_Tat_026", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Fuck Luck Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_027", "MP_Xmas2_F_Tat_027", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Grenade", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_002_M", "MP_Gunrunning_Tattoo_002_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Have a Nice Day", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_021_M", "MP_Gunrunning_Tattoo_021_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Combat Reaper", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_024_M", "MP_Gunrunning_Tattoo_024_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Single Arrow", "mphipster_overlays", "FM_Hip_M_Tat_001", "FM_Hip_F_Tat_001", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Bone", "mphipster_overlays", "FM_Hip_M_Tat_004", "FM_Hip_F_Tat_004", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Cube", "mphipster_overlays", "FM_Hip_M_Tat_008", "FM_Hip_F_Tat_008", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Horseshoe", "mphipster_overlays", "FM_Hip_M_Tat_010", "FM_Hip_F_Tat_010", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Spray Can", "mphipster_overlays", "FM_Hip_M_Tat_014", "FM_Hip_F_Tat_014", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Eye Triangle", "mphipster_overlays", "FM_Hip_M_Tat_017", "FM_Hip_F_Tat_017", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Origami", "mphipster_overlays", "FM_Hip_M_Tat_018", "FM_Hip_F_Tat_018", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Geo Pattern", "mphipster_overlays", "FM_Hip_M_Tat_020", "FM_Hip_F_Tat_020", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Pencil", "mphipster_overlays", "FM_Hip_M_Tat_022", "FM_Hip_F_Tat_022", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Smiley", "mphipster_overlays", "FM_Hip_M_Tat_023", "FM_Hip_F_Tat_023", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Shapes", "mphipster_overlays", "FM_Hip_M_Tat_036", "FM_Hip_F_Tat_036", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Triangle Black", "mphipster_overlays", "FM_Hip_M_Tat_044", "FM_Hip_F_Tat_044", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Mesh Band", "mphipster_overlays", "FM_Hip_M_Tat_045", "FM_Hip_F_Tat_045", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Mechanical Sleeve", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_003_M", "MP_MP_ImportExport_Tat_003_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Dialed In", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_005_M", "MP_MP_ImportExport_Tat_005_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Engulfed Block", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_006_M", "MP_MP_ImportExport_Tat_006_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Drive Forever", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_007_M", "MP_MP_ImportExport_Tat_007_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Seductress", "mplowrider_overlays", "MP_LR_Tat_015_M", "MP_LR_Tat_015_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Swooping Eagle", "mpbiker_overlays", "MP_MP_Biker_Tat_007_M", "MP_MP_Biker_Tat_007_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Lady Mortality", "mpbiker_overlays", "MP_MP_Biker_Tat_014_M", "MP_MP_Biker_Tat_014_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Eagle Emblem", "mpbiker_overlays", "MP_MP_Biker_Tat_033_M", "MP_MP_Biker_Tat_033_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Grim Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_042_M", "MP_MP_Biker_Tat_042_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Skull Chain", "mpbiker_overlays", "MP_MP_Biker_Tat_046_M", "MP_MP_Biker_Tat_046_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Snake Bike", "mpbiker_overlays", "MP_MP_Biker_Tat_047_M", "MP_MP_Biker_Tat_047_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "These Rgbas Don't Run", "mpbiker_overlays", "MP_MP_Biker_Tat_049_M", "MP_MP_Biker_Tat_049_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Mum", "mpbiker_overlays", "MP_MP_Biker_Tat_054_M", "MP_MP_Biker_Tat_054_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Lady Vamp", "mplowrider2_overlays", "MP_LR_Tat_003_M", "MP_LR_Tat_003_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Loving Los Muertos", "mplowrider2_overlays", "MP_LR_Tat_028_M", "MP_LR_Tat_028_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Black Tears", "mplowrider2_overlays", "MP_LR_Tat_035_M", "MP_LR_Tat_035_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Floral Raven", "mpluxe_overlays", "MP_LUXE_TAT_004_M", "MP_LUXE_TAT_004_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Mermaid Harpist", "mpluxe_overlays", "MP_LUXE_TAT_013_M", "MP_LUXE_TAT_013_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Geisha Bloom", "mpluxe_overlays", "MP_LUXE_TAT_019_M", "MP_LUXE_TAT_019_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Intrometric", "mpluxe2_overlays", "MP_LUXE_TAT_010_M", "MP_LUXE_TAT_010_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Heavenly Deity", "mpluxe2_overlays", "MP_LUXE_TAT_017_M", "MP_LUXE_TAT_017_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Floral Print", "mpluxe2_overlays", "MP_LUXE_TAT_026_M", "MP_LUXE_TAT_026_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Geometric Design", "mpluxe2_overlays", "MP_LUXE_TAT_030_M", "MP_LUXE_TAT_030_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Crackshot", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_001_M", "MP_Smuggler_Tattoo_001_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Mutiny", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_005_M", "MP_Smuggler_Tattoo_005_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Stylized Kraken", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_023_M", "MP_Smuggler_Tattoo_023_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Poison Wrench", "mpstunt_overlays", "MP_MP_Stunt_Tat_003_M", "MP_MP_Stunt_Tat_003_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Arachnid of Death", "mpstunt_overlays", "MP_MP_Stunt_Tat_009_M", "MP_MP_Stunt_Tat_009_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Grave Vulture", "mpstunt_overlays", "MP_MP_Stunt_Tat_010_M", "MP_MP_Stunt_Tat_010_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Coffin Racer", "mpstunt_overlays", "MP_MP_Stunt_Tat_016_M", "MP_MP_Stunt_Tat_016_F", 350),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Biker Stallion", "mpstunt_overlays", "MP_MP_Stunt_Tat_036_M", "MP_MP_Stunt_Tat_036_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "One Down Five Up", "mpstunt_overlays", "MP_MP_Stunt_Tat_038_M", "MP_MP_Stunt_Tat_038_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Seductive Mechanic", "mpstunt_overlays", "MP_MP_Stunt_Tat_049_M", "MP_MP_Stunt_Tat_049_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Grim Reaper Smoking Gun", "multiplayer_overlays", "FM_Tat_Award_M_002", "FM_Tat_Award_F_002", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Ride or Die", "multiplayer_overlays", "FM_Tat_Award_M_010", "FM_Tat_Award_F_010", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Brotherhood", "multiplayer_overlays", "FM_Tat_M_000", "FM_Tat_F_000", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Dragons", "multiplayer_overlays", "FM_Tat_M_001", "FM_Tat_F_001", 350),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Dragons and Skull", "multiplayer_overlays", "FM_Tat_M_003", "FM_Tat_F_003", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Flower Mural", "multiplayer_overlays", "FM_Tat_M_014", "FM_Tat_F_014", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Serpent Skull", "multiplayer_overlays", "FM_Tat_M_018", "FM_Tat_F_018", 350),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Virgin Mary", "multiplayer_overlays", "FM_Tat_M_027", "FM_Tat_F_027", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Mermaid", "multiplayer_overlays", "FM_Tat_M_028", "FM_Tat_F_028", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Dagger", "multiplayer_overlays", "FM_Tat_M_038", "FM_Tat_F_038", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_ARM, "Lion", "multiplayer_overlays", "FM_Tat_M_047", "FM_Tat_F_047", 100),

            // Left leg
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Single", "mpbusiness_overlays", string.Empty, "MP_Buis_F_LLeg_000", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Spider Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_001", "MP_Xmas2_F_Tat_001", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Spider Rgba", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_002", "MP_Xmas2_F_Tat_002", 350),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Patriot Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_005_M", "MP_Gunrunning_Tattoo_005_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Stylized Tiger", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_007_M", "MP_Gunrunning_Tattoo_007_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Death Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_011_M", "MP_Gunrunning_Tattoo_011_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Rose Revolver", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_023_M", "MP_Gunrunning_Tattoo_023_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Squares", "mphipster_overlays", "FM_Hip_M_Tat_009", "FM_Hip_F_Tat_009", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Charm", "mphipster_overlays", "FM_Hip_M_Tat_019", "FM_Hip_F_Tat_019", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Black Anchor", "mphipster_overlays", "FM_Hip_M_Tat_040", "FM_Hip_F_Tat_040", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "LS Serpent", "mplowrider_overlays", "MP_LR_Tat_007_M", "MP_LR_Tat_007_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Presidents", "mplowrider_overlays", "MP_LR_Tat_020_M", "MP_LR_Tat_020_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Rose Tribute", "mpbiker_overlays", "MP_MP_Biker_Tat_002_M", "MP_MP_Biker_Tat_002_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Ride or Die", "mpbiker_overlays", "MP_MP_Biker_Tat_015_M", "MP_MP_Biker_Tat_015_F", 100),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Bad Luck", "mpbiker_overlays", "MP_MP_Biker_Tat_027_M", "MP_MP_Biker_Tat_027_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Engulfed Skull", "mpbiker_overlays", "MP_MP_Biker_Tat_036_M", "MP_MP_Biker_Tat_036_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Scorched Soul", "mpbiker_overlays", "MP_MP_Biker_Tat_037_M", "MP_MP_Biker_Tat_037_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Ride Free", "mpbiker_overlays", "MP_MP_Biker_Tat_044_M", "MP_MP_Biker_Tat_044_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Bone Cruiser", "mpbiker_overlays", "MP_MP_Biker_Tat_056_M", "MP_MP_Biker_Tat_056_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Laughing Skull", "mpbiker_overlays", "MP_MP_Biker_Tat_057_M", "MP_MP_Biker_Tat_057_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Death Us Do Part", "mplowrider2_overlays", "MP_LR_Tat_029_M", "MP_LR_Tat_029_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Serpent of Death", "mpluxe_overlays", "MP_LUXE_TAT_000_M", "MP_LUXE_TAT_000_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Cross of Roses", "mpluxe2_overlays", "MP_LUXE_TAT_011_M", "MP_LUXE_TAT_011_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Dagger Devil", "mpstunt_overlays", "MP_MP_Stunt_Tat_007_M", "MP_MP_Stunt_Tat_007_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Dirt Track Hero", "mpstunt_overlays", "MP_MP_Stunt_Tat_013_M", "MP_MP_Stunt_Tat_013_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Golden Cobra", "mpstunt_overlays", "MP_MP_Stunt_Tat_021_M", "MP_MP_Stunt_Tat_021_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Quad Goblin", "mpstunt_overlays", "MP_MP_Stunt_Tat_028_M", "MP_MP_Stunt_Tat_028_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Stunt Jesus", "mpstunt_overlays", "MP_MP_Stunt_Tat_031_M", "MP_MP_Stunt_Tat_031_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Dragon and Dagger", "multiplayer_overlays", "FM_Tat_Award_M_009", "FM_Tat_Award_F_009", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Melting Skull", "multiplayer_overlays", "FM_Tat_M_002", "FM_Tat_F_002", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Dragon Mural", "multiplayer_overlays", "FM_Tat_M_008", "FM_Tat_F_008", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Serpent Skull", "multiplayer_overlays", "FM_Tat_M_021", "FM_Tat_F_021", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Hottie", "multiplayer_overlays", "FM_Tat_M_023", "FM_Tat_F_023", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Smoking Dagger", "multiplayer_overlays", "FM_Tat_M_026", "FM_Tat_F_026", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Faith", "multiplayer_overlays", "FM_Tat_M_032", "FM_Tat_F_032", 200),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Chinese Dragon", "multiplayer_overlays", "FM_Tat_M_033", "FM_Tat_F_033", 300),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Dragon", "multiplayer_overlays", "FM_Tat_M_035", "FM_Tat_F_035", 250),
            new BusinessTattooModel(TATTOO_ZONE_LEFT_LEG, "Grim Reaper", "multiplayer_overlays", "FM_Tat_M_037", "FM_Tat_F_037", 200),
            
            // Right leg
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Diamond Crown", "mpbusiness_overlays", string.Empty, "MP_Buis_F_RLeg_000", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Floral Dagger", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_014", "MP_Xmas2_F_Tat_014", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Combat Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_006_M", "MP_Gunrunning_Tattoo_006_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Restless Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_026_M", "MP_Gunrunning_Tattoo_026_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Pistol Ace", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_030_M", "MP_Gunrunning_Tattoo_030_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Grub", "mphipster_overlays", "FM_Hip_M_Tat_038", "FM_Hip_F_Tat_038", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Sparkplug", "mphipster_overlays", "FM_Hip_M_Tat_042", "FM_Hip_F_Tat_042", 100),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Ink Me", "mplowrider_overlays", "MP_LR_Tat_017_M", "MP_LR_Tat_017_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Dance of Hearts", "mplowrider_overlays", "MP_LR_Tat_023_M", "MP_LR_Tat_023_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Dragon's Fury", "mpbiker_overlays", "MP_MP_Biker_Tat_004_M", "MP_MP_Biker_Tat_004_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Western Insignia", "mpbiker_overlays", "MP_MP_Biker_Tat_022_M", "MP_MP_Biker_Tat_022_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Dusk Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_028_M", "MP_MP_Biker_Tat_028_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "American Made", "mpbiker_overlays", "MP_MP_Biker_Tat_040_M", "MP_MP_Biker_Tat_040_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "STFU", "mpbiker_overlays", "MP_MP_Biker_Tat_048_M", "MP_MP_Biker_Tat_048_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "San Andreas Prayer", "mplowrider2_overlays", "MP_LR_Tat_030_M", "MP_LR_Tat_030_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Elaborate Los Muertos", "mpluxe_overlays", "MP_LUXE_TAT_001_M", "MP_LUXE_TAT_001_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Starmetric", "mpluxe2_overlays", "MP_LUXE_TAT_023_M", "MP_LUXE_TAT_023_F", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Homeward Bound", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_020_M", "MP_Smuggler_Tattoo_020_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Demon Spark Plug", "mpstunt_overlays", "MP_MP_Stunt_Tat_005_M", "MP_MP_Stunt_Tat_005_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Praying Gloves", "mpstunt_overlays", "MP_MP_Stunt_Tat_015_M", "MP_MP_Stunt_Tat_015_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Piston Angel", "mpstunt_overlays", "MP_MP_Stunt_Tat_020_M", "MP_MP_Stunt_Tat_020_F", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Speed Freak", "mpstunt_overlays", "MP_MP_Stunt_Tat_025_M", "MP_MP_Stunt_Tat_025_F", 150),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Wheelie Mouse", "mpstunt_overlays", "MP_MP_Stunt_Tat_032_M", "MP_MP_Stunt_Tat_032_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Severed Hand", "mpstunt_overlays", "MP_MP_Stunt_Tat_045_M", "MP_MP_Stunt_Tat_045_F", 400),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Brake Knife", "mpstunt_overlays", "MP_MP_Stunt_Tat_047_M", "MP_MP_Stunt_Tat_047_F", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Skull and Sword", "multiplayer_overlays", "FM_Tat_Award_M_006", "FM_Tat_Award_F_006", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "The Warrior", "multiplayer_overlays", "FM_Tat_M_007", "FM_Tat_F_007", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Tribal", "multiplayer_overlays", "FM_Tat_M_017", "FM_Tat_F_017", 250),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Fiery Dragon", "multiplayer_overlays", "FM_Tat_M_022", "FM_Tat_F_022", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Broken Skull", "multiplayer_overlays", "FM_Tat_M_039", "FM_Tat_F_039", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Flaming Skull", "multiplayer_overlays", "FM_Tat_M_040", "FM_Tat_F_040", 300),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Flaming Scorpion", "multiplayer_overlays", "FM_Tat_M_042", "FM_Tat_F_042", 200),
            new BusinessTattooModel(TATTOO_ZONE_RIGHT_LEG, "Indian Ram", "multiplayer_overlays", "FM_Tat_M_043", "FM_Tat_F_043", 200)
        };

        // Car dealer's IVehicles
        public static List<CarShopVehicleModel> CARSHOP_VEHICLE_LIST = new List<CarShopVehicleModel>
        {
            // Compacts
            new CarShopVehicleModel("Blista", AltV.Net.Enums.VehicleModel.Blista, 0, VEHICLE_CLASS_COMPACTS, 34750),
            //new CarShopVehicleModel("Brioso", AltV.Net.Enums.VehicleModel.Brioso, 0, VEHICLE_CLASS_COMPACTS, 15000),
            new CarShopVehicleModel("Dilettante", AltV.Net.Enums.VehicleModel.Dilettante, 0, VEHICLE_CLASS_COMPACTS, 21430),
            new CarShopVehicleModel("Issi2", AltV.Net.Enums.VehicleModel.Issi2, 0, VEHICLE_CLASS_COMPACTS, 21750),
            new CarShopVehicleModel("Panto", AltV.Net.Enums.VehicleModel.Panto, 0, VEHICLE_CLASS_COMPACTS, 39810),
            new CarShopVehicleModel("Prairie", AltV.Net.Enums.VehicleModel.Prairie, 0, VEHICLE_CLASS_COMPACTS, 69540),
            new CarShopVehicleModel("Rhapsody", AltV.Net.Enums.VehicleModel.Rhapsody, 0, VEHICLE_CLASS_COMPACTS, 29850),

            // Coupes
            new CarShopVehicleModel("CogCabrio", AltV.Net.Enums.VehicleModel.CogCabrio, 0, VEHICLE_CLASS_COUPES, 78750),
            new CarShopVehicleModel("Exemplar", AltV.Net.Enums.VehicleModel.Exemplar, 0, VEHICLE_CLASS_COUPES, 65000),
            new CarShopVehicleModel("F620", AltV.Net.Enums.VehicleModel.F620, 0, VEHICLE_CLASS_COUPES, 86320),
            new CarShopVehicleModel("Felon", AltV.Net.Enums.VehicleModel.Felon, 0, VEHICLE_CLASS_COUPES, 91540),
            new CarShopVehicleModel("Felon2", AltV.Net.Enums.VehicleModel.Felon2, 0, VEHICLE_CLASS_COUPES, 90140),
            //new CarShopVehicleModel("Jackal", AltV.Net.Enums.VehicleModel.Jackal, 0, VEHICLE_CLASS_COUPES, 43200),
            //new CarShopVehicleModel("Oracle", AltV.Net.Enums.VehicleModel.Oracle, 0, VEHICLE_CLASS_COUPES, 28000),
            new CarShopVehicleModel("Oracle2", AltV.Net.Enums.VehicleModel.Oracle2, 0, VEHICLE_CLASS_COUPES, 85000),
            new CarShopVehicleModel("Sentinel", AltV.Net.Enums.VehicleModel.Sentinel, 0, VEHICLE_CLASS_COUPES, 76550),
            new CarShopVehicleModel("Sentinel2", AltV.Net.Enums.VehicleModel.Sentinel2, 0, VEHICLE_CLASS_COUPES, 83540),
            //new CarShopVehicleModel("Windsor", AltV.Net.Enums.VehicleModel.Windsor, 0, VEHICLE_CLASS_COUPES, 55000),
            //new CarShopVehicleModel("Windsor2", AltV.Net.Enums.VehicleModel.Windsor2, 0, VEHICLE_CLASS_COUPES, 63000),
            new CarShopVehicleModel("Zion", AltV.Net.Enums.VehicleModel.Zion, 0, VEHICLE_CLASS_COUPES, 69550),
            new CarShopVehicleModel("Zion2", AltV.Net.Enums.VehicleModel.Zion2, 0, VEHICLE_CLASS_COUPES, 76540),

            // Muscle
            //new CarShopVehicleModel("Blade", AltV.Net.Enums.VehicleModel.Blade, 0, VEHICLE_CLASS_MUSCLE, 8000),
            new CarShopVehicleModel("Buccaneer", AltV.Net.Enums.VehicleModel.Buccaneer, 0, VEHICLE_CLASS_MUSCLE, 90750),
            new CarShopVehicleModel("Buccaneer2", AltV.Net.Enums.VehicleModel.Buccaneer2, 0, VEHICLE_CLASS_MUSCLE, 110740),
            new CarShopVehicleModel("Chino", AltV.Net.Enums.VehicleModel.Chino, 0, VEHICLE_CLASS_MUSCLE, 135000),
            new CarShopVehicleModel("Chino2", AltV.Net.Enums.VehicleModel.Chino2, 0, VEHICLE_CLASS_MUSCLE, 137500),
            new CarShopVehicleModel("Dominator", AltV.Net.Enums.VehicleModel.Dominator, 0, VEHICLE_CLASS_MUSCLE, 175000),
            new CarShopVehicleModel("Dukes", AltV.Net.Enums.VehicleModel.Dukes, 0, VEHICLE_CLASS_MUSCLE, 145400),
            new CarShopVehicleModel("Faction", AltV.Net.Enums.VehicleModel.Faction, 0, VEHICLE_CLASS_MUSCLE, 55780),
            new CarShopVehicleModel("Faction2", AltV.Net.Enums.VehicleModel.Faction2, 0, VEHICLE_CLASS_MUSCLE, 146950),
            new CarShopVehicleModel("Gauntlet", AltV.Net.Enums.VehicleModel.Gauntlet, 0, VEHICLE_CLASS_MUSCLE, 175000),
            new CarShopVehicleModel("Moonbeam", AltV.Net.Enums.VehicleModel.Moonbeam, 0, VEHICLE_CLASS_MUSCLE, 67950),
            new CarShopVehicleModel("Phoenix", AltV.Net.Enums.VehicleModel.Phoenix, 0, VEHICLE_CLASS_MUSCLE, 20900),
            new CarShopVehicleModel("Picador", AltV.Net.Enums.VehicleModel.Picador, 0, VEHICLE_CLASS_MUSCLE, 23000),
            new CarShopVehicleModel("Ruiner", AltV.Net.Enums.VehicleModel.Ruiner, 0, VEHICLE_CLASS_MUSCLE, 64950),
            new CarShopVehicleModel("SabreGT", AltV.Net.Enums.VehicleModel.SabreGt, 0, VEHICLE_CLASS_MUSCLE, 89620),
            new CarShopVehicleModel("Stalion", AltV.Net.Enums.VehicleModel.Stalion, 0, VEHICLE_CLASS_MUSCLE, 75320),
            new CarShopVehicleModel("Tampa", AltV.Net.Enums.VehicleModel.Tampa, 0, VEHICLE_CLASS_MUSCLE, 75000),
            new CarShopVehicleModel("Vigero", AltV.Net.Enums.VehicleModel.Vigero, 0, VEHICLE_CLASS_MUSCLE, 100600),
            new CarShopVehicleModel("Voodoo", AltV.Net.Enums.VehicleModel.Voodoo, 0, VEHICLE_CLASS_MUSCLE, 49750),
            new CarShopVehicleModel("Voodoo2", AltV.Net.Enums.VehicleModel.Voodoo2, 0, VEHICLE_CLASS_MUSCLE, 45000),

            // Off-Road
            new CarShopVehicleModel("Bifta", AltV.Net.Enums.VehicleModel.Bifta, 0, VEHICLE_CLASS_OFFROAD, 67950),
            //new CarShopVehicleModel("Sandking", AltV.Net.Enums.VehicleModel.Sandking, 0, VEHICLE_CLASS_OFFROAD, 21000),

            // SUVs
            new CarShopVehicleModel("Baller", AltV.Net.Enums.VehicleModel.Baller, 0, VEHICLE_CLASS_SUVS, 45000),
            new CarShopVehicleModel("Baller2", AltV.Net.Enums.VehicleModel.Baller2, 0, VEHICLE_CLASS_SUVS, 49000),
            new CarShopVehicleModel("Baller3", AltV.Net.Enums.VehicleModel.Baller3, 0, VEHICLE_CLASS_SUVS, 41000),
            new CarShopVehicleModel("Cavalcade", AltV.Net.Enums.VehicleModel.Cavalcade, 0, VEHICLE_CLASS_SUVS, 56200),
            new CarShopVehicleModel("Cavalcade2", AltV.Net.Enums.VehicleModel.Cavalcade2, 0, VEHICLE_CLASS_SUVS, 45900),
            new CarShopVehicleModel("Contender", AltV.Net.Enums.VehicleModel.Contender, 0, VEHICLE_CLASS_SUVS, 43200),
            new CarShopVehicleModel("Dubsta", AltV.Net.Enums.VehicleModel.Dubsta, 0, VEHICLE_CLASS_SUVS, 85400),
            new CarShopVehicleModel("Dubsta2", AltV.Net.Enums.VehicleModel.Dubsta2, 0, VEHICLE_CLASS_SUVS, 95400),
            new CarShopVehicleModel("FQ2", AltV.Net.Enums.VehicleModel.Fq2, 0, VEHICLE_CLASS_SUVS, 120000),
            new CarShopVehicleModel("Gresley", AltV.Net.Enums.VehicleModel.Gresley, 0, VEHICLE_CLASS_SUVS, 95000),
            new CarShopVehicleModel("Habanero", AltV.Net.Enums.VehicleModel.Habanero, 0, VEHICLE_CLASS_SUVS, 39000),
            new CarShopVehicleModel("Huntley", AltV.Net.Enums.VehicleModel.Huntley, 0, VEHICLE_CLASS_SUVS, 43100),
            new CarShopVehicleModel("Landstalker", AltV.Net.Enums.VehicleModel.Landstalker, 0, VEHICLE_CLASS_SUVS, 35000),
            new CarShopVehicleModel("Patriot", AltV.Net.Enums.VehicleModel.Patriot, 0, VEHICLE_CLASS_SUVS, 78500),
            new CarShopVehicleModel("Radi", AltV.Net.Enums.VehicleModel.Radi, 0, VEHICLE_CLASS_SUVS, 32000),
            new CarShopVehicleModel("Rocoto", AltV.Net.Enums.VehicleModel.Rocoto, 0, VEHICLE_CLASS_SUVS, 150000),
            new CarShopVehicleModel("Seminole", AltV.Net.Enums.VehicleModel.Seminole, 0, VEHICLE_CLASS_SUVS, 85750),
            new CarShopVehicleModel("Serrano", AltV.Net.Enums.VehicleModel.Serrano, 0, VEHICLE_CLASS_SUVS, 49750),
            new CarShopVehicleModel("XLS", AltV.Net.Enums.VehicleModel.Xls, 0, VEHICLE_CLASS_SUVS, 112650),
           //new CarShopVehicleModel("Rumpo", AltV.Net.Enums.VehicleModel.Rumpo, 0, VEHICLE_CLASS_SUVS, 65000),

            // Sedans
            new CarShopVehicleModel("Asea", AltV.Net.Enums.VehicleModel.Asea, 0, VEHICLE_CLASS_SEDANS, 6750),
            new CarShopVehicleModel("Asterope", AltV.Net.Enums.VehicleModel.Asterope, 0, VEHICLE_CLASS_SEDANS, 7000),
            new CarShopVehicleModel("Emperor", AltV.Net.Enums.VehicleModel.Emperor, 0, VEHICLE_CLASS_SEDANS, 7500),
            new CarShopVehicleModel("Fugitive", AltV.Net.Enums.VehicleModel.Fugitive, 0, VEHICLE_CLASS_SEDANS, 19800),
            new CarShopVehicleModel("Ingot", AltV.Net.Enums.VehicleModel.Ingot, 0, VEHICLE_CLASS_SEDANS, 11500),
            new CarShopVehicleModel("Intruder", AltV.Net.Enums.VehicleModel.Intruder, 0, VEHICLE_CLASS_SEDANS, 14000),
            new CarShopVehicleModel("Premier", AltV.Net.Enums.VehicleModel.Premier, 0, VEHICLE_CLASS_SEDANS, 16500),
            new CarShopVehicleModel("Primo", AltV.Net.Enums.VehicleModel.Primo, 0, VEHICLE_CLASS_SEDANS, 19850),
            new CarShopVehicleModel("Regina", AltV.Net.Enums.VehicleModel.Regina, 0, VEHICLE_CLASS_SEDANS, 18500),
            new CarShopVehicleModel("Stanier", AltV.Net.Enums.VehicleModel.Stanier, 0, VEHICLE_CLASS_SEDANS, 26500),
            new CarShopVehicleModel("Washington", AltV.Net.Enums.VehicleModel.Washington, 0, VEHICLE_CLASS_SEDANS, 25000),
            new CarShopVehicleModel("Stratum", AltV.Net.Enums.VehicleModel.Stratum, 0, VEHICLE_CLASS_SEDANS, 32000),
            //new CarShopVehicleModel("Stretch", AltV.Net.Enums.VehicleModel.Stretch, 0, VEHICLE_CLASS_SEDANS, 1250000),

            // Sports
            new CarShopVehicleModel("Alpha", AltV.Net.Enums.VehicleModel.Alpha, 0, VEHICLE_CLASS_SPORTS, 195000),
            new CarShopVehicleModel("Banshee", AltV.Net.Enums.VehicleModel.Banshee, 0, VEHICLE_CLASS_SPORTS, 305450),
            new CarShopVehicleModel("BestiaGTS", AltV.Net.Enums.VehicleModel.Bestiagts, 0, VEHICLE_CLASS_SPORTS, 270000),
            new CarShopVehicleModel("Buffalo", AltV.Net.Enums.VehicleModel.Buffalo, 0, VEHICLE_CLASS_SPORTS, 340000),
            new CarShopVehicleModel("Blista2", AltV.Net.Enums.VehicleModel.Blista2, 0, VEHICLE_CLASS_SPORTS, 175300),
            new CarShopVehicleModel("Carbonizzare", AltV.Net.Enums.VehicleModel.Carbonizzare, 0, VEHICLE_CLASS_SPORTS, 375500),
            new CarShopVehicleModel("Comet2", AltV.Net.Enums.VehicleModel.Comet2, 0, VEHICLE_CLASS_SPORTS, 325000),
            new CarShopVehicleModel("Elegy", AltV.Net.Enums.VehicleModel.Elegy, 0, VEHICLE_CLASS_SPORTS, 310000),
            new CarShopVehicleModel("Elegy2", AltV.Net.Enums.VehicleModel.Elegy2, 0, VEHICLE_CLASS_SPORTS, 365000),
            new CarShopVehicleModel("Feltzer2", AltV.Net.Enums.VehicleModel.Feltzer2, 0, VEHICLE_CLASS_SPORTS, 395000),
            new CarShopVehicleModel("Furoregt", AltV.Net.Enums.VehicleModel.Furoregt, 0, VEHICLE_CLASS_SPORTS, 485000),
            new CarShopVehicleModel("Fusilade", AltV.Net.Enums.VehicleModel.Fusilade, 0, VEHICLE_CLASS_SPORTS, 300000),
            new CarShopVehicleModel("Jester", AltV.Net.Enums.VehicleModel.Jester, 0, VEHICLE_CLASS_SPORTS, 365000),
            new CarShopVehicleModel("Khamelion", AltV.Net.Enums.VehicleModel.Khamelion, 0, VEHICLE_CLASS_SPORTS, 330000),
            new CarShopVehicleModel("Kuruma", AltV.Net.Enums.VehicleModel.Kuruma, 0, VEHICLE_CLASS_SPORTS, 575000),
            new CarShopVehicleModel("Lynx", AltV.Net.Enums.VehicleModel.Lynx, 0, VEHICLE_CLASS_SPORTS, 395000),
            new CarShopVehicleModel("Massacro", AltV.Net.Enums.VehicleModel.Massacro, 0, VEHICLE_CLASS_SPORTS, 535000),
            new CarShopVehicleModel("Ninef2", AltV.Net.Enums.VehicleModel.Ninef2, 0, VEHICLE_CLASS_SPORTS, 450000),
            new CarShopVehicleModel("Penumbra", AltV.Net.Enums.VehicleModel.Penumbra, 0, VEHICLE_CLASS_SPORTS, 475000),
            new CarShopVehicleModel("RapidGT2", AltV.Net.Enums.VehicleModel.RapidGt2, 0, VEHICLE_CLASS_SPORTS, 465000),
            new CarShopVehicleModel("Schafter2", AltV.Net.Enums.VehicleModel.Schafter2, 0, VEHICLE_CLASS_SPORTS, 120000),
            new CarShopVehicleModel("Schafter3", AltV.Net.Enums.VehicleModel.Schafter3, 0, VEHICLE_CLASS_SPORTS, 265000),
            new CarShopVehicleModel("Schwarzer", AltV.Net.Enums.VehicleModel.Schwarzer, 0, VEHICLE_CLASS_SPORTS, 265000),
            new CarShopVehicleModel("Seven70", AltV.Net.Enums.VehicleModel.Seven70, 0, VEHICLE_CLASS_SPORTS, 450000),
            new CarShopVehicleModel("Sultan", AltV.Net.Enums.VehicleModel.Sultan, 0, VEHICLE_CLASS_SPORTS, 220000),
            new CarShopVehicleModel("Surano", AltV.Net.Enums.VehicleModel.Surano, 0, VEHICLE_CLASS_SPORTS, 465000),
            new CarShopVehicleModel("SultanRS", AltV.Net.Enums.VehicleModel.SultanRs, 0, VEHICLE_CLASS_SPORTS, 195000),
            
            // Classic sports
            new CarShopVehicleModel("Infernus", AltV.Net.Enums.VehicleModel.Infernus, 0, VEHICLE_CLASS_SPORTS, 390000)

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
            new CarShopVehicleModel("EntityXF", AltV.Net.Enums.VehicleModel.EntityXF, 0, VEHICLE_CLASS_SPORTS, 325000),
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
        public const int DRIVER_FRONT_DOOR = 0;
        public const int PASSENGER_FRONT_DOOR = 1;
        public const int DRIVER_REAR_DOOR = 2;
        public const int PASSENGER_REAR_DOOR = 3;
        public const int VEHICLE_HOOD = 4;
        public const int VEHICLE_TRUNK = 5;

        public static List<Position> CARSHOP_SPAWNS = new List<Position>()
        {
            new Position(-47.8021f, -1116.419f, 26.43427f),
            new Position(-50.66175f, -1116.753f, 26.4342f),
            new Position(-53.51776f, -1116.721f, 26.43449f),
            new Position(-56.41209f, -1116.901f, 26.43442f)
        };

        public static List<Position> BIKESHOP_SPAWNS = new List<Position>()
{
            new Position(265.2711f, -1149.21f, 29.29169f),
            new Position(262.4801f, -1149.25f, 29.29169f),
            new Position(259.3696f, -1149.42f, 29.29169f),
            new Position(256.2483f, -1149.431f, 29.29169f),
            new Position(250.0457f, -1149.472f, 29.28539f)
        };

        public static List<Position> SHIP_SPAWNS = new List<Position>()
        {
            new Position(-727.1069f, -1327.44f, -0.4730833f),
            new Position(-731.7827f, -1334.567f, -0.4733995f),
            new Position(-737.4061f, -1340.965f, -0.4733122f),
            new Position(-743.5413f, -1347.753f, -0.473477f)
        };

        public static List<TunningPriceModel> TUNNING_PRICE_LIST = new List<TunningPriceModel>()
        {
            new TunningPriceModel(VEHICLE_MOD_SPOILER, 250),
            new TunningPriceModel(VEHICLE_MOD_FRONT_BUMPER, 250),
            new TunningPriceModel(VEHICLE_MOD_REAR_BUMPER, 250),
            new TunningPriceModel(VEHICLE_MOD_SIDE_SKIRT, 250),
            new TunningPriceModel(VEHICLE_MOD_EXHAUST, 100),
            new TunningPriceModel(VEHICLE_MOD_FRAME, 500),
            new TunningPriceModel(VEHICLE_MOD_GRILLE, 200),
            new TunningPriceModel(VEHICLE_MOD_HOOD, 300),
            new TunningPriceModel(VEHICLE_MOD_FENDER, 100),
            new TunningPriceModel(VEHICLE_MOD_RIGHT_FENDER, 100),
            new TunningPriceModel(VEHICLE_MOD_ROOF, 400),
            new TunningPriceModel(VEHICLE_MOD_HORN, 100),
            new TunningPriceModel(VEHICLE_MOD_SUSPENSION, 900),
            new TunningPriceModel(VEHICLE_MOD_XENON, 150),
            new TunningPriceModel(VEHICLE_MOD_FRONT_WHEELS, 100),
            new TunningPriceModel(VEHICLE_MOD_BACK_WHEELS, 100),
            new TunningPriceModel(VEHICLE_MOD_PLATE_HOLDERS, 100),
            new TunningPriceModel(VEHICLE_MOD_TRIM_DESIGN, 800),
            new TunningPriceModel(VEHICLE_MOD_ORNAMIENTS, 150),
            new TunningPriceModel(VEHICLE_MOD_STEERING_WHEEL, 100),
            new TunningPriceModel(VEHICLE_MOD_SHIFTER_LEAVERS, 100),
            new TunningPriceModel(VEHICLE_MOD_HYDRAULICS, 1200),
            new TunningPriceModel(VEHICLE_MOD_ENGINE, 5000),
        };

        // ATMs
        public static List<Position> ATM_LIST = new List<Position>()
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
        public static List<Position> AUTO_ZAPF_LIST = new List<Position>()
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
        public static List<Position> AUTO_ZAPF_LIST_BLIPS = new List<Position>()
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
