using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.KI
{
    public class Spawner : IScript
    {
        public static List<ZombieModel> CurrentZombies = new List<ZombieModel>();
        private static int CurrentZombieCounter = 0;
        private static int PositionCounter = 0;
        private static int DIST_ZOMBIES = 12;
        private static int MAX_ZOMBIES = 25;

        //
        private static void CreateNewRandomZombie(VnXPlayer player)
        {
            try
            {
                Vector3 Position = new Vector3();
                switch (PositionCounter)
                {
                    case 0:
                        Position = new Vector3(player.Position.X + DIST_ZOMBIES, player.Position.Y + DIST_ZOMBIES, player.Position.Z - 0.5f);
                        break;
                    case 1:
                        Position = new Vector3(player.Position.X - DIST_ZOMBIES, player.Position.Y + DIST_ZOMBIES, player.Position.Z - 0.5f);
                        break;
                    case 2:
                        Position = new Vector3(player.Position.X + DIST_ZOMBIES, player.Position.Y - DIST_ZOMBIES, player.Position.Z - 0.5f);
                        break;
                    case 3:
                        Position = new Vector3(player.Position.X + DIST_ZOMBIES, player.Position.Y - DIST_ZOMBIES, player.Position.Z - 0.5f);
                        PositionCounter = 0;
                        break;
                }
                Random random = new Random();
                int RandomSkin = random.Next(0, _Preload_.Character_Creator.Main.CharacterSkins.ToList().Count);
                PositionCounter++;
                ZombieModel zombieClass = new ZombieModel
                {
                    ID = CurrentZombieCounter++,
                    SkinName = "mp_m_freemode_01",
                    RandomSkinUID = _Preload_.Character_Creator.Main.CharacterSkins.ToList()[RandomSkin].UID,
                    Sex = 0,
                    Armor = 100,
                    Health = 100,
                    IsDead = false,
                    Position = Position,
                    TargetEntity = player
                };
                player.Zombies.NearbyZombies.Add(zombieClass);
                CurrentZombies.Add(zombieClass);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void AddNearbyZombiesIntoList(VnXPlayer player)
        {
            try
            {
                if (player.Zombies.IsSyncer && player.Zombies.NearbyZombies.Count < MAX_ZOMBIES)
                {
                    CreateNewRandomZombie(player);
                    foreach (VnXPlayer nearbyPlayer in player.NearbyPlayers.ToList()) CreateNewRandomZombie(nearbyPlayer);
                }
                //else if (player.Zombies.IsSyncer)
                //Core.Debug.OutputDebugString("[Zombies] : " + player.Username + " hat das Limit von " + MAX_ZOMBIES + " Zombies erreicht.");
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void SpawnZombiesArroundPlayers(VnXPlayer player)
        {
            try
            {
                foreach (ZombieModel zombieClass in CurrentZombies.ToList())
                {
                    if (player.Position.Distance(zombieClass.Position) < Zombie.World.Main.MAX_ZOMBIE_RANGE)
                    {
                        VenoX.TriggerClientEvent(player, "Zombies:SpawnKI", zombieClass.ID, zombieClass.RandomSkinUID, zombieClass.SkinName, zombieClass.Position, zombieClass.TargetEntity);
                        //player?.EmitLocked("Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                        //VenoX.TriggerClientEvent(player, "Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                        zombieClass.Armor = 200;
                        zombieClass.Health = 200;
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void SpawnZombiesForEveryPlayer()
        {
            try
            {
                foreach (VnXPlayer player in Globals.Main.ZombiePlayers.ToList())
                {
                    if (player is null || !player.Exists) continue;
                    AddNearbyZombiesIntoList(player);
                    SpawnZombiesArroundPlayers(player);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


    }
}
