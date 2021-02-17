using System;
using System.Linq;
using AltV.Net.Data;
using VenoXV._Globals_.Inventory;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public enum ItemType
    {
        Drugs = 0,
        Useable = 1,
        Clothes = 2,
        Gun = 3
    }
    public class ItemHashes
    {
        //Guns
        public const string Advancedrifle = "Advancedrifle";
        public const string Appistol = "Appistol";
        public const string Assaultrifle = "Assaultrifle";
        public const string AssaultrifleMk2 = "Assaultrifle-Mk2";
        public const string Assaultshotgun = "Assaultshotgun";
        public const string Assaultsmg = "Assaultsmg";
        public const string Autoshotgun = "Autoshotgun";
        public const string Ball = "Ball";
        public const string Bat = "Bat";
        public const string Battleaxe = "Battleaxe";
        public const string Bottle = "Bottle";
        public const string Bullpuprifle = "Bullpuprifle";
        public const string BullpuprifleMk2 = "Bullpuprifle-Mk2";
        public const string Bullpupshotgun = "Bullpupshotgun";
        public const string Bzgas = "Bzgas";
        public const string Carbinerifle = "Carbinerifle";
        public const string CarbinerifleMk2 = "Carbinerifle-Mk2";
        public const string Ceramicpistol = "Ceramicpistol";
        public const string Combatmg = "Combatmg";
        public const string CombatmgMk2 = "Combatmg-Mk2";
        public const string Combatpdw = "Combatpdw";
        public const string Combatpistol = "Combatpistol";
        public const string Combatshotgun = "Combatshotgun";
        public const string Compactlauncher = "Compactlauncher";
        public const string Compactrifle = "Compactrifle";

        public const string Crowbar = "Crowbar";
        public const string Dagger = "Dagger";
        public const string Dbshotgun = "Dbshotgun";
        public const string Doubleaction = "Doubleaction";
        public const string Fireextinguisher = "Fireextinguisher";
        public const string Firework = "Firework";
        public const string Flare = "Flaregun";
        public const string Flashlight = "Flashlight";
        public const string Gadgetpistol = "Gadgetpistol";
        public const string Golfclub = "Golfclub";
        public const string Grenade = "Grenade";
        public const string Grenadelauncher = "Grenadelauncher";
        public const string GrenadelauncherSmoke = "Grenadelauncher-Smoke";
        public const string Gusenberg = "Gusenberg";
        public const string Hammer = "Hammer";
        public const string Hatchet = "Hatchet";
        public const string Heavypistol = "Heavypistol";
        public const string Heavyshotgun = "Heavyshotgun";
        public const string Heavysniper = "Heavysniper";
        public const string HeavysniperMk2 = "Heavysniper-Mk2";
        public const string Hominglauncher = "Hominglauncher";
        public const string Knife = "Knife";
        public const string Knuckle = "Knuckle";
        public const string Machete = "Machete";
        public const string Machinepistol = "Machinepistol";
        public const string Marksmanpistol = "Marksmanpistol";
        public const string Marksmanrifle = "Marksmanrifle";
        public const string MarksmanrifleMk2 = "Marksmanrifle-Mk2";
        public const string Mg = "Mg";
        public const string Microsmg = "Microsmg";
        public const string Militaryrifle = "Militaryrifle";
        public const string Minigun = "Minigun";
        public const string Minismg = "Minismg";
        public const string Molotov = "Molotov";
        public const string Musket = "Musket";
        public const string Navyrevolver = "Navyrevolver";
        public const string Nightstick = "Nightstick";
        public const string Pipebomb = "Pipebomb";
        public const string Pistol = "Pistol";
        public const string PistolMk2 = "Pistol-Mk2";
        public const string Pistol50 = "Pistol50";
        public const string Poolcue = "Poolcue";
        public const string Proxmine = "Proxmine";
        public const string Pumpshotgun = "Pumpshotgun";
        public const string PumpshotgunMk2 = "Pumpshotgun-Mk2";
        public const string Railgun = "Railgun";
        public const string Raycarbine = "Raycarbine";
        public const string Rayminigun = "Rayminigun";
        public const string Raypistol = "Raypistol";
        public const string Revolver = "Revolver";
        public const string RevolverMk2 = "Revolver-Mk2";
        public const string Rpg = "Rpg";
        public const string Sawnoffshotgun = "Sawnoffshotgun";
        public const string Smg = "Smg";
        public const string SmgMk2 = "Smg-Mk2";
        public const string Smokegrenade = "Smokegrenade";
        public const string Sniperrifle = "Sniperrifle";
        public const string Snowball = "Snowball";
        public const string Snspistol = "Snspistol";
        public const string SnspistolMk2 = "Snspistol-Mk2";
        public const string Specialcarbine = "Specialcarbine";
        public const string SpecialcarbineMk2 = "Specialcarbine-Mk2";
        public const string Stickybomb = "Stickybomb";
        public const string StoneHatchet = "Stone-Hatchet";
        public const string Stungun = "Stungun";
        public const string Switchblade = "Switchblade";
        public const string Vintagepistol = "Vintagepistol";
        public const string Wrench = "Wrench";

        //Eatable
        public const string Cookie = "Cookie";
        public const string Milk = "Milk";
        public const string Milkshake = "Milkshake";
        public const string Ribs = "Ribs";
        public const string Gingerbread = "Gingerbread";

        // Drugs
        public const string Weed = "Weed";
        public const string WeedSeeds = "Weed-Seeds";

        //Useable 
        public const string Petrolcan = "Petrolcan";


    }
    public class ItemModel
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public int Uid { get; set; }
        public int Amount { get; set; }
        public Position Position { get; set; }
        public DateTime Dropped { get; set; }
        public int Dimension { get; set; }
        public float Weight { get; set; }
        public ItemType Type { get; set; }
        public int ClothesSlot { get; set; }
        public int ClothesDrawable { get; set; }
        public int ClothesTexture { get; set; }
        public bool IsUsing { get; set; }
        public void Update()
        {
            ItemModel offlineItem = Inventory.DatabaseItems.FirstOrDefault(x => x.Id == Id);
            if (offlineItem is not null)
            {
                offlineItem.Amount = Amount;
                offlineItem.Position = Position;
                offlineItem.Dropped = Dropped;
                offlineItem.Dimension = Dimension;
                offlineItem.Weight = Weight;
                offlineItem.Type = Type;
                Debug.OutputDebugString("Updated OfflineItem List!");
            }
        }
    }
}
