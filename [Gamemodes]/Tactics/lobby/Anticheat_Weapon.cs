using AltV.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Tactics.lobby
{
    public class Anticheat_Weapon : IScript
    {

        public static bool WeaponIsAllowed(AltV.Net.Enums.WeaponModel weapon)
        {
            try
            {
                if (weapon == AltV.Net.Enums.WeaponModel.HeavyRevolver) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.SMG) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.CarbineRifle) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.AssaultRifle) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.CombatPDW) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.Musket) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.PumpShotgun) { return true; }
                else if (weapon == AltV.Net.Enums.WeaponModel.SniperRifle) { return true; }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public static void LoadTacticsAnticheat(Client player, AltV.Net.Enums.WeaponModel oldWeapon, AltV.Net.Enums.WeaponModel weapon)
        {
            try
            {
                if (!WeaponIsAllowed(weapon))
                {
                    VenoXV.Anti_Cheat.Anti_Cheat_Weapons.anticheat_permanent_ban(player, oldWeapon.ToString());
                }
            }
            catch { }
        }

    }
}
