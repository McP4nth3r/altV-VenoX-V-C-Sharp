using AltV.Net.Enums;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Zombie.KI
{
    public class LevelSystem
    {
        public static Dictionary<int, WeaponModel> LevelWeapons = new Dictionary<int, WeaponModel>
        {
            { 0, WeaponModel.Pistol },
            { 20, WeaponModel.APPistol },
            { 50, WeaponModel.MicroSMG },
            { 75,  WeaponModel.CombatPDW },
            { 120, WeaponModel.PumpShotgun },
            { 200, WeaponModel.BullpupRifle },
            { 300, WeaponModel.CombatMG },
            { 350, WeaponModel.HeavySniper },
            { 400, WeaponModel.FireworkLauncher },
            { 500, WeaponModel.GrenadeLauncher },
            { 525, WeaponModel.MolotovCocktail },
            { 550, WeaponModel.Grenade },
            { 600, WeaponModel.GrenadeLauncher },
            { 800, WeaponModel.RPG },
            { 900, WeaponModel.Railgun },
            { 1000, WeaponModel.Minigun },
            { 20000, WeaponModel.Widowmaker },
        };
        public static void GivePlayerWeaponsByLevel(VnXPlayer player)
        {
            try
            {
                if (player is null) return;
                foreach (KeyValuePair<int, WeaponModel> weapon in LevelWeapons)
                {
                    if (weapon.Key <= player.Zombies.Zombie_kills)
                        player.GivePlayerWeapon(weapon.Value, 9999);
                }
            }
            catch { }
        }
    }
}
