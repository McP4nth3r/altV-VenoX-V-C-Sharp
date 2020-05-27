using AltV.Net;
using System.Collections.Generic;

namespace VenoXV._Gamemodes_.Tactics.weapons
{
    public class Combat : IScript
    {
        public static Dictionary<AltV.Net.Enums.WeaponModel, float> DamageValues;

        // WEAPON DAMAGE SYSTEM
        public const float TAZER_DAMAGE = 1;
        public const float PISTOL_DAMAGE = 15;
        public const float PISTOL50_DAMAGE = 25;
        public const float REVOLVER_DAMAGE = 30;
        public const float SHOTGUN_DAMAGE = 4;
        public const float PDW_DAMAGE = 12;
        public const float MP5_DAMAGE = 9;
        public const float AK47_DAMAGE = 14;
        public const float KARABINER_DAMAGE = 11;
        public const float ADVANCEDRIFLE_DAMAGE = 13;
        public const float RIFLE_DAMAGE = 10;
        public const float SNIPER_DAMAGE = 5;
        public const float RPG_DAMAGE = 200;
        public const float MINIGUN_DAMAGE = 5;

        public const float RAY_PISTOL = 30;
        public const float RAY_MINIGUN = 20;



        public static void OnResourceStart()
        {
            DamageValues = new Dictionary<AltV.Net.Enums.WeaponModel, float>
            {
                { AltV.Net.Enums.WeaponModel.StunGun, TAZER_DAMAGE }, // Tazer
                { AltV.Net.Enums.WeaponModel.Pistol, PISTOL_DAMAGE }, // Pistol
                { AltV.Net.Enums.WeaponModel.Pistol50, PISTOL50_DAMAGE }, // Pistol50
                { AltV.Net.Enums.WeaponModel.HeavyRevolver, REVOLVER_DAMAGE }, // Revolver
                { AltV.Net.Enums.WeaponModel.PumpShotgun, SHOTGUN_DAMAGE }, // Shotgun (Ammu & State )
                { AltV.Net.Enums.WeaponModel.CombatPDW, PDW_DAMAGE },  // PDW DAMAGE
                { AltV.Net.Enums.WeaponModel.SMG, MP5_DAMAGE }, // MP5 DAMAGE
                { AltV.Net.Enums.WeaponModel.AssaultRifle, AK47_DAMAGE }, // Ak-47 DAMAGE
                { AltV.Net.Enums.WeaponModel.CarbineRifle, KARABINER_DAMAGE }, // M4A1 - KARABINER DAMAGE
                { AltV.Net.Enums.WeaponModel.AdvancedRifle, ADVANCEDRIFLE_DAMAGE }, // ADVANCEDRIFLE - KAMPFGEWEHR DAMAGE
                { AltV.Net.Enums.WeaponModel.Musket, RIFLE_DAMAGE }, // MUSKET - RIFLE DAMAGE
                { AltV.Net.Enums.WeaponModel.SniperRifle, SNIPER_DAMAGE }, // SNIPERRIFLE - DAMAGE
                { AltV.Net.Enums.WeaponModel.RPG, RPG_DAMAGE }, // SNIPERRIFLE - DAMAGE
                { AltV.Net.Enums.WeaponModel.Minigun, MINIGUN_DAMAGE }, // SNIPERRIFLE - DAMAGE
                {(AltV.Net.Enums.WeaponModel)AltV.Net.Alt.Hash("weapon_raypistol"), RAY_PISTOL },// SNIPERRIFLE - DAMAGE
                {(AltV.Net.Enums.WeaponModel)AltV.Net.Alt.Hash("weapon_rayminigun"), RAY_MINIGUN } // SNIPERRIFLE - DAMAGE
            };
        }
    }
}
