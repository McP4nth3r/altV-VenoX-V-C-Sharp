using AltV.Net.Enums;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class Weapon
    {
        public WeaponModel Hash { get; set; }
        public int Amount { get; set; }
        public Weapon(WeaponModel weaponHash, int amount = 0)
        {
            this.Hash = weaponHash;
            this.Amount = amount;
        }
    }
    public class WaffenlagerModel
    {
        public int Faction { get; set; }
        public Weapon weapon_knuckle = new Weapon(WeaponModel.BrassKnuckles);
        //public int weapon_knuckle { get; set; }
        public Weapon weapon_baseball = new Weapon(WeaponModel.BaseballBat);
        public Weapon weapon_nightstick = new Weapon(WeaponModel.Nightstick);
        public Weapon weapon_tazer = new Weapon(WeaponModel.StunGun);
        public Weapon weapon_pistol = new Weapon(WeaponModel.Pistol);
        public Weapon weapon_pistol50 = new Weapon(WeaponModel.Pistol50);
        public Weapon weapon_revolver = new Weapon(WeaponModel.HeavyRevolver);
        public Weapon weapon_pumpshotgun = new Weapon(WeaponModel.PumpShotgun);
        public Weapon weapon_mp5 = new Weapon(WeaponModel.SMG);
        public Weapon weapon_combatpdw = new Weapon(WeaponModel.CombatPDW);
        public Weapon weapon_assaultrifle = new Weapon(WeaponModel.AssaultRifle);
        public Weapon weapon_carbinerifle = new Weapon(WeaponModel.CarbineRifle);
        public Weapon weapon_advancedrifle = new Weapon(WeaponModel.AdvancedRifle);
        public Weapon weapon_gusenberg = new Weapon(WeaponModel.GusenbergSweeper);
        public Weapon weapon_rifle = new Weapon(WeaponModel.Musket);
        public Weapon weapon_sniperrifle = new Weapon(WeaponModel.SniperRifle);
        public Weapon weapon_rpg = new Weapon(WeaponModel.RPG);
        public Weapon weapon_bzgas = new Weapon(WeaponModel.BZGas);
        public Weapon weapon_molotov = new Weapon(WeaponModel.MolotovCocktail);
        public Weapon weapon_smokegrenade = new Weapon(WeaponModel.TearGas);
        public Weapon weapon_pistol_ammo = new Weapon(WeaponModel.Pistol);
        public Weapon weapon_pistol50_ammo = new Weapon(WeaponModel.Pistol50);
        public Weapon weapon_revolver_ammo = new Weapon(WeaponModel.HeavyRevolver);
        public Weapon weapon_pumpshotgun_ammo = new Weapon(WeaponModel.PumpShotgun);
        public Weapon weapon_mp5_ammo = new Weapon(WeaponModel.SMG);
        public Weapon weapon_combatpdw_ammo = new Weapon(WeaponModel.CombatPDW);
        public Weapon weapon_assaultrifle_ammo = new Weapon(WeaponModel.AssaultRifle);
        public Weapon weapon_carbinerifle_ammo = new Weapon(WeaponModel.CarbineRifle);
        public Weapon weapon_advancedrifle_ammo = new Weapon(WeaponModel.AdvancedRifle);
        public Weapon weapon_gusenberg_ammo = new Weapon(WeaponModel.GusenbergSweeper);
        public Weapon weapon_rifle_ammo = new Weapon(WeaponModel.Musket);
        public Weapon weapon_sniperrifle_ammo = new Weapon(WeaponModel.SniperRifle);
        public Weapon weapon_rpg_ammo = new Weapon(WeaponModel.RPG);
    }
}
