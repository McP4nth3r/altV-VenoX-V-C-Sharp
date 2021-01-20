using AltV.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Globals_.Inventory
{
    public class Inventory
    {
        public static List<ItemModel> DatabaseItems = new List<ItemModel>();

        public static WeaponModel GetWeaponModelByItemHash(string hash)
        {
            try
            {
                WeaponHashes.TryGetValue(hash, out WeaponModel value);
                return value;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return WeaponModel.Fist; }
        }

        private static Dictionary<string, string> GetObjectHash = new Dictionary<string, string>
        {
            { ItemHashes.Pistol, "w_pi_pistol" },
            { ItemHashes.Stone_Hatchet, "w_me_hatchet" },
            { ItemHashes.Bat, "w_me_bat" },
            { ItemHashes.Golfclub, "prop_golf_iron_01" },
            { ItemHashes.Carbinerifle, "w_ar_carbinerifle" },
            { ItemHashes.Carbinerifle_Mk2, "w_ar_carbineriflemk2" },
            { ItemHashes.Assaultrifle, "w_ar_assaultrifle" },
            { ItemHashes.Specialcarbine, "w_ar_specialcarbine" },
            { ItemHashes.Bullpuprifle, "w_ar_bullpuprifle" },
            { ItemHashes.Advancedrifle, "w_ar_advancedrifle" },
            { ItemHashes.Microsmg, "w_sb_microsmg" },
            { ItemHashes.Assaultsmg, "w_sb_assaultsmg" },
            { ItemHashes.Smg, "w_sb_smg" },
            { ItemHashes.Smg_Mk2, "w_sb_smgmk2" },
            { ItemHashes.Gusenberg, "w_sb_gusenberg" },
            { ItemHashes.Sniperrifle, "w_sr_sniperrifle" },
            { ItemHashes.Assaultshotgun, "w_sg_assaultshotgun" },
            { ItemHashes.Bullpupshotgun, "w_sg_bullpupshotgun" },
            { ItemHashes.Pumpshotgun, "w_sg_pumpshotgun" },
            { ItemHashes.Musket, "w_ar_musket" },
            { ItemHashes.Heavyshotgun, "w_sg_heavyshotgun" },
            { ItemHashes.Firework, "w_lr_firework" },
        };


        public static void CreateDroppedObject(VnXPlayer player, ItemModel item)
        {
            try
            {
                string Obj = "prop_cs_package_01";
                switch (item.Type)
                {
                    case ItemType.Gun:
                        GetObjectHash.TryGetValue(item.Hash, out string Value);
                        if (Value is not null)
                            Obj = Value;
                        break;
                    case ItemType.Drugs:
                        Obj = "bkr_prop_weed_bigbag_01a";
                        break;
                    default:
                        Core.Debug.OutputDebugString("obj not found : " + item.Hash);
                        break;
                }

                if (item is null) return;

                foreach (VnXPlayer nearby in player.NearbyPlayers.ToList())
                    VenoX.TriggerClientEvent(nearby, "Inventory:DropObj", item.Id, Obj, item.Hash + "[" + item.Id + "]\nPress ~b~'E' ~w~ to pickup.");

                VenoX.TriggerClientEvent(player, "Inventory:DropObj", item.Id, Obj, item.Hash + "[" + item.Id + "]\nPress ~b~'E' ~w~ to pickup.");


                item.UID = -1;
                item.Position = player.Position;
                item.Dropped = DateTime.Now.AddMinutes(30);
                item.Update();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void DeleteDroppedObject(VnXPlayer player, ItemModel item)
        {
            if (player is not null && player.Exists && item is not null)
                VenoX.TriggerClientEvent(player, "Inventory:DeleteObj", item.Id);
        }
        private static Dictionary<string, WeaponModel> WeaponHashes = new Dictionary<string, WeaponModel>
        {
            { ItemHashes.Advancedrifle, WeaponModel.AdvancedRifle },
            { ItemHashes.Appistol, WeaponModel.APPistol },
            { ItemHashes.Assaultrifle, WeaponModel.AssaultRifle },
            { ItemHashes.Assaultrifle_Mk2, WeaponModel.AssaultRifleMkII },
            { ItemHashes.Assaultshotgun, WeaponModel.AssaultShotgun },
            { ItemHashes.Assaultsmg, WeaponModel.AssaultSMG },
            { ItemHashes.Autoshotgun, WeaponModel.BullpupShotgun },
            { ItemHashes.Ball, WeaponModel.Baseball },
            { ItemHashes.Bat, WeaponModel.BaseballBat },
            { ItemHashes.Battleaxe, WeaponModel.BattleAxe },
            { ItemHashes.Bottle, WeaponModel.BrokenBottle },
            { ItemHashes.Bullpuprifle, WeaponModel.BullpupRifle },
            { ItemHashes.Bullpuprifle_Mk2, WeaponModel.BullpupRifleMkII },
            { ItemHashes.Bullpupshotgun, WeaponModel.BullpupShotgun },
            { ItemHashes.Bzgas, WeaponModel.BZGas },
            { ItemHashes.Carbinerifle, WeaponModel.CarbineRifle },
            { ItemHashes.Carbinerifle_Mk2, WeaponModel.CarbineRifleMkII },
            { ItemHashes.Ceramicpistol, WeaponModel.MarksmanPistol },
            { ItemHashes.Combatmg, WeaponModel.CombatMG },
            { ItemHashes.Combatmg_Mk2, WeaponModel.CombatMGMkII },
            { ItemHashes.Combatpdw, WeaponModel.CombatPDW },
            { ItemHashes.Combatpistol, WeaponModel.CombatPistol },
            { ItemHashes.Combatshotgun, WeaponModel.HeavyShotgun },
            { ItemHashes.Compactlauncher, WeaponModel.CompactGrenadeLauncher },
            { ItemHashes.Compactrifle, WeaponModel.CompactRifle },
            { ItemHashes.Crowbar, WeaponModel.Crowbar },
            { ItemHashes.Dagger, WeaponModel.AntiqueCavalryDagger },
            { ItemHashes.Dbshotgun, WeaponModel.PumpShotgun },
            { ItemHashes.Doubleaction, WeaponModel.DoubleActionRevolver },
            { ItemHashes.Fireextinguisher, WeaponModel.FireExtinguisher },
            { ItemHashes.Firework, WeaponModel.FireworkLauncher },
            { ItemHashes.Flare, WeaponModel.FlareGun },
            { ItemHashes.Flashlight, WeaponModel.Flashlight },
            { ItemHashes.Gadgetpistol, WeaponModel.Pistol },
            { ItemHashes.Golfclub, WeaponModel.GolfClub },
            { ItemHashes.Grenade, WeaponModel.Grenade },
            { ItemHashes.Grenadelauncher, WeaponModel.GrenadeLauncher },
            { ItemHashes.Grenadelauncher_Smoke, WeaponModel.GrenadeLauncherSmoke },
            { ItemHashes.Gusenberg, WeaponModel.GusenbergSweeper },
            { ItemHashes.Hammer, WeaponModel.Hammer },
            { ItemHashes.Hatchet, WeaponModel.Hatchet },
            { ItemHashes.Heavypistol, WeaponModel.HeavyPistol },
            { ItemHashes.Heavyshotgun, WeaponModel.HeavyShotgun },
            { ItemHashes.Heavysniper, WeaponModel.HeavySniper },
            { ItemHashes.Heavysniper_Mk2, WeaponModel.HeavySniperMkII },
            { ItemHashes.Hominglauncher, WeaponModel.HomingLauncher },
            { ItemHashes.Knife, WeaponModel.Knife },
            { ItemHashes.Knuckle, WeaponModel.BrassKnuckles },
            { ItemHashes.Machete, WeaponModel.Machete },
            { ItemHashes.Machinepistol, WeaponModel.MachinePistol },
            { ItemHashes.Marksmanpistol, WeaponModel.MarksmanPistol },
            { ItemHashes.Marksmanrifle, WeaponModel.MarksmanRifle },
            { ItemHashes.Marksmanrifle_Mk2, WeaponModel.MarksmanRifleMkII },
            { ItemHashes.Mg, WeaponModel.MG },
            { ItemHashes.Microsmg, WeaponModel.MicroSMG },
            { ItemHashes.Militaryrifle, WeaponModel.BullpupRifle },
            { ItemHashes.Minigun, WeaponModel.Minigun },
            { ItemHashes.Minismg, WeaponModel.MiniSMG },
            { ItemHashes.Molotov, WeaponModel.MolotovCocktail },
            { ItemHashes.Musket, WeaponModel.Musket },
            { ItemHashes.Navyrevolver, WeaponModel.HeavyRevolver },
            { ItemHashes.Nightstick, WeaponModel.Nightstick },
            { ItemHashes.Pipebomb, WeaponModel.PipeBombs },
            { ItemHashes.Pistol, WeaponModel.Pistol },
            { ItemHashes.Pistol_Mk2, WeaponModel.PistolMkII },
            { ItemHashes.Pistol50, WeaponModel.Pistol50 },
            { ItemHashes.Poolcue, WeaponModel.PoolCue },
            { ItemHashes.Proxmine, WeaponModel.ProximityMines },
            { ItemHashes.Pumpshotgun, WeaponModel.PumpShotgun },
            { ItemHashes.Pumpshotgun_Mk2, WeaponModel.PumpShotgunMkII },

            { ItemHashes.Railgun, WeaponModel.Railgun },
            // Dont exists!
            { ItemHashes.Raycarbine, WeaponModel.Railgun },
            { ItemHashes.Rayminigun, WeaponModel.Railgun },
            { ItemHashes.Raypistol, WeaponModel.UpnAtomizer },
            { ItemHashes.Revolver, WeaponModel.HeavyRevolver },
            { ItemHashes.Revolver_Mk2, WeaponModel.HeavyRevolverMkII },
            { ItemHashes.Rpg, WeaponModel.RPG },
            { ItemHashes.Sawnoffshotgun, WeaponModel.SawedOffShotgun },
            { ItemHashes.Smg, WeaponModel.SMG },
            { ItemHashes.Smg_Mk2, WeaponModel.SMGMkII },
            { ItemHashes.Smokegrenade, WeaponModel.TearGas },
            { ItemHashes.Sniperrifle, WeaponModel.SniperRifle },
            { ItemHashes.Snowball, WeaponModel.Snowballs },
            { ItemHashes.Snspistol, WeaponModel.SNSPistol },
            { ItemHashes.Snspistol_Mk2, WeaponModel.SNSPistolMkII },
            { ItemHashes.Specialcarbine, WeaponModel.SpecialCarbine },
            { ItemHashes.Specialcarbine_Mk2, WeaponModel.SpecialCarbineMkII },
            { ItemHashes.Stickybomb, WeaponModel.StickyBomb },
            { ItemHashes.Stone_Hatchet, WeaponModel.StoneHatchet },
            { ItemHashes.Stungun, WeaponModel.StunGun },
            { ItemHashes.Switchblade, WeaponModel.Switchblade },
            { ItemHashes.Vintagepistol, WeaponModel.VintagePistol },
            { ItemHashes.Wrench, WeaponModel.PipeWrench },
        };
    }
}
