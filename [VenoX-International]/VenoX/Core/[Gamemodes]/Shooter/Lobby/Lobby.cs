using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Enums;
using VenoXV._Gamemodes_.Shooter.Models;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Models;
using VehicleModel = VenoXV.Models.VehicleModel;

namespace VenoXV._Gamemodes_.Shooter.Lobby
{
    public class Lobby
    {
        // Settings
        public static int ShooterRoundWillEnd = 5;                  // Round will end after ... seconds.

        // Variables.
        public static DateTime RoundWillEnd = DateTime.Now;
        public static List<SpawnModel> Spawnmap = new List<SpawnModel>
        {
            new SpawnModel  {   Coord = new Vector3( -4633.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4623.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4613.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4603.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4593.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4583.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4573.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4563.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4553.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4543.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4533.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4523.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4513.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4503.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4493.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4483.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4473.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4463.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4453.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4443.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4433.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4423.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4413.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            new SpawnModel  {   Coord = new Vector3( -4403.899f, 1257.2836f, 863.4636f),  Rotation = new Vector3(0,0,3.109375f),  },
            // other side.
            new SpawnModel  {   Coord = new Vector3( -4625.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4615.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4605.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4595.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4585.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4575.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4565.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4555.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4545.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4535.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4525.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4515.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4505.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4495.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4485.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4475.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4465.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4455.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4445.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4435.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4425.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4415.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
            new SpawnModel  {   Coord = new Vector3( -4405.552f, 965.9209f, 863.4636f),  Rotation = new Vector3(0,0,0),  },
        };

        public static void TakePlayerFromRound(VnXPlayer player)
        {
            if (player.IsInVehicle) player.WarpOutOfVehicle();
            player.Shooter.IsAlive = false;
            player.Freeze = true;
            player.Position = new Vector3(player.Position.X, player.Position.Y, player.Position.Z + 50f);
            player.RemoveAllPlayerWeapons();
        }
        public static void PutPlayerInRound(VnXPlayer player)
        {
            SpawnModel spawn = Spawnmap.FirstOrDefault(x => !x.IsBeingUsed);
            if (spawn is null) return;
            player.Dimension = Main.ShooterDimension;
            player.Position = spawn.Coord;
            player.Rotation = spawn.Rotation;
            spawn.IsBeingUsed = true;
            player.GivePlayerWeapon(WeaponModel.RPG, 20);
            VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Zentorno, spawn.Coord, spawn.Rotation);
            vehicle.EngineOn = true;
            vehicle.Frozen = false;
            vehicle.Godmode = false;
            vehicle.Dimension = Main.ShooterDimension;
        }
        public static void OnPlayerDeath(VnXPlayer player)
        {
            TakePlayerFromRound(player);
            int counter = 0;
            foreach (VnXPlayer players in Main.ShooterPlayers.ToList())
            {
                if (players.Shooter.IsAlive)
                    counter++;
            }
            if (counter <= 1)
            {
                string winnerName = String.Empty;
                VnXPlayer winner = Main.ShooterPlayers.ToList().FirstOrDefault(x => x.Shooter.IsAlive);
                if (winner is not null) winnerName = player.Username;
                ShowWinner(winnerName);
                EndRound();
            }
        }
        public static void PlayerLeaveVehicle(VnXPlayer player)
        {
            TakePlayerFromRound(player);
        }
        public static void OnPlayerConnect(VnXPlayer player)
        {
            PutPlayerInRound(player);
        }
        private static void ShowWinner(string winnerName)
        {
            try
            {
                foreach (VnXPlayer player in Main.ShooterPlayers.ToList())
                {
                    VenoX.TriggerClientEvent(player, "Shooter:ShowWinner", winnerName);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        private static async void EndRound()
        {
            try
            {
                await Task.Delay(3000);
                foreach (VnXPlayer player in Main.ShooterPlayers.ToList())
                {
                    PutPlayerInRound(player);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void OnUpdate()
        {
            if (RoundWillEnd <= DateTime.Now)
            {
                string winner = String.Empty;
                ShowWinner("Niemand");
            }
        }
    }
}
