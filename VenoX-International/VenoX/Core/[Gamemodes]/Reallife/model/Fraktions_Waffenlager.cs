using AltV.Net.Enums;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class Weapon
    {
        public WeaponModel Hash { get; set; }
        public int Amount { get; set; }
        public Weapon(WeaponModel weaponHash, int amount = 0)
        {
            Hash = weaponHash;
            Amount = amount;
        }
    }
    public class WaffenlagerModel
    {
        public int Faction { get; set; }
        public Weapon WeaponKnuckle = new Weapon(WeaponModel.BrassKnuckles);
        //public int weapon_knuckle { get; set; }
        public Weapon WeaponBaseball = new Weapon(WeaponModel.BaseballBat);
        public Weapon WeaponNightstick = new Weapon(WeaponModel.Nightstick);
        public Weapon WeaponTazer = new Weapon(WeaponModel.StunGun);
        public Weapon WeaponPistol = new Weapon(WeaponModel.Pistol);
        public Weapon WeaponPistol50 = new Weapon(WeaponModel.Pistol50);
        public Weapon WeaponRevolver = new Weapon(WeaponModel.HeavyRevolver);
        public Weapon WeaponPumpshotgun = new Weapon(WeaponModel.PumpShotgun);
        public Weapon WeaponMp5 = new Weapon(WeaponModel.SMG);
        public Weapon WeaponCombatpdw = new Weapon(WeaponModel.CombatPDW);
        public Weapon WeaponAssaultrifle = new Weapon(WeaponModel.AssaultRifle);
        public Weapon WeaponCarbinerifle = new Weapon(WeaponModel.CarbineRifle);
        public Weapon WeaponAdvancedrifle = new Weapon(WeaponModel.AdvancedRifle);
        public Weapon WeaponGusenberg = new Weapon(WeaponModel.GusenbergSweeper);
        public Weapon WeaponRifle = new Weapon(WeaponModel.Musket);
        public Weapon WeaponSniperrifle = new Weapon(WeaponModel.SniperRifle);
        public Weapon WeaponRpg = new Weapon(WeaponModel.RPG);
        public Weapon WeaponBzgas = new Weapon(WeaponModel.BZGas);
        public Weapon WeaponMolotov = new Weapon(WeaponModel.MolotovCocktail);
        public Weapon WeaponSmokegrenade = new Weapon(WeaponModel.TearGas);
        public Weapon WeaponPistolAmmo = new Weapon(WeaponModel.Pistol);
        public Weapon WeaponPistol50Ammo = new Weapon(WeaponModel.Pistol50);
        public Weapon WeaponRevolverAmmo = new Weapon(WeaponModel.HeavyRevolver);
        public Weapon WeaponPumpshotgunAmmo = new Weapon(WeaponModel.PumpShotgun);
        public Weapon WeaponMp5Ammo = new Weapon(WeaponModel.SMG);
        public Weapon WeaponCombatpdwAmmo = new Weapon(WeaponModel.CombatPDW);
        public Weapon WeaponAssaultrifleAmmo = new Weapon(WeaponModel.AssaultRifle);
        public Weapon WeaponCarbinerifleAmmo = new Weapon(WeaponModel.CarbineRifle);
        public Weapon WeaponAdvancedrifleAmmo = new Weapon(WeaponModel.AdvancedRifle);
        public Weapon WeaponGusenbergAmmo = new Weapon(WeaponModel.GusenbergSweeper);
        public Weapon WeaponRifleAmmo = new Weapon(WeaponModel.Musket);
        public Weapon WeaponSniperrifleAmmo = new Weapon(WeaponModel.SniperRifle);
        public Weapon WeaponRpgAmmo = new Weapon(WeaponModel.RPG);
    }
}
