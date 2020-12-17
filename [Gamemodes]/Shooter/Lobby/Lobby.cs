using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Shooter.Lobby
{
    public class Lobby
    {
        public static void OnPlayerConnect(VnXPlayer player)
        {
            player.SetPosition = new Vector3(-4637f, 1200f, 872f);
            _Admin_.Admin.CreateAdminVehicle(player, "zentorno", 0, false);
            player.GivePlayerWeapon(AltV.Net.Enums.WeaponModel.RPG, 20);
        }
    }
}
