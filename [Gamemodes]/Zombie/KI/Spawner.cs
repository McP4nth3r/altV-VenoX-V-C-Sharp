using AltV.Net;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;
using VenoXV.Globals;

namespace VenoXV.Zombie.KI
{
    public class Spawner : IScript
    {
        private static List<ZombieModel> CurrentZombies = new List<ZombieModel>();
        private static int CurrentZombieCounter = 0;
        private static void AddNearbyZombiesIntoList()
        {
            foreach (Client player in Main.ZombiePlayers)
            {
                ZombieModel zombieClass = new ZombieModel
                {
                    ID = CurrentZombieCounter++,
                    SkinName = "u_m_y_zombie_01",
                    IsDead = false,
                    Position = new Vector3(player.Position.X + 3, player.Position.Y + 3, player.Position.Z),
                    TargetEntity = null
                };
                CurrentZombies.Add(zombieClass);
            }
        }
        private static void SpawnZombiesArroundPlayers()
        {
            foreach (Client player in Main.ZombiePlayers)
            {
                foreach (ZombieModel zombieClass in CurrentZombies)
                {
                    if (player.Position.Distance(zombieClass.Position) <= 50 && zombieClass.TargetEntity == null)
                    {
                        zombieClass.TargetEntity = player;
                        player.Emit("Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.Position, player);
                    }
                }
            }
        }
        private static void CheckTargetEntityForZombies()
        {
            foreach (ZombieModel zombieClass in CurrentZombies)
            {
                if (zombieClass.TargetEntity == null)
                {
                    CurrentZombies.Remove(zombieClass);
                }
            }
        }
        public static void SpawnZombiesForEveryPlayer()
        {
            AddNearbyZombiesIntoList();
            SpawnZombiesArroundPlayers();
        }

        public static void DestroyZombieById(int Id)
        {
            foreach (ZombieModel zombies in CurrentZombies.ToList())
            {
                if (zombies.ID == Id)
                {
                    foreach (Client players in Main.ZombiePlayers)
                    {
                        players.Emit("Zombies:DeleteZombieById", Id);
                    }
                    CurrentZombies.Remove(zombies);
                    CurrentZombieCounter--;
                }
            }
        }

    }
}
