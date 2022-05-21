using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using VenoX.Core._Gamemodes_.Zombie.Models;
using VenoX.Core._Preload_.Character_Creator;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Zombie.KI
{
    public class Spawner : IScript
    {
        public static List<ZombieModel> CurrentZombies = new List<ZombieModel>();
        private static int _currentZombieCounter;
        private static int _positionCounter;
        private static readonly int _distZombies = 12;
        private static readonly int _maxZombies = 15;

        //
        private static void CreateNewRandomZombie(VnXPlayer player)
        {
            try
            {
                Vector3 position = new Vector3();
                switch (_positionCounter)
                {
                    case 0:
                        position = new Vector3(player.Position.X + _distZombies, player.Position.Y + _distZombies, player.Position.Z - 0.5f);
                        break;
                    case 1:
                        position = new Vector3(player.Position.X - _distZombies, player.Position.Y + _distZombies, player.Position.Z - 0.5f);
                        break;
                    case 2:
                        position = new Vector3(player.Position.X + _distZombies, player.Position.Y - _distZombies, player.Position.Z - 0.5f);
                        break;
                    case 3:
                        position = new Vector3(player.Position.X + _distZombies, player.Position.Y - _distZombies, player.Position.Z - 0.5f);
                        _positionCounter = 0;
                        break;
                }
                Random random = new Random();
                int randomSkin = random.Next(0, Main.CharacterSkins.ToList().Count);
                _positionCounter++;
                ZombieModel zombieClass = new ZombieModel
                {
                    Id = _currentZombieCounter++,
                    SkinName = "mp_m_freemode_01",
                    RandomSkinUid = Main.CharacterSkins.ToList()[randomSkin].Uid,
                    Sex = 0,
                    Armor = 100,
                    Health = 100,
                    IsDead = false,
                    Position = position,
                    TargetEntity = player
                };
                player.Zombies.NearbyZombies.Add(zombieClass);
                CurrentZombies.Add(zombieClass);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        private static void AddNearbyZombiesIntoList(VnXPlayer player)
        {
            try
            {
                if (player.Zombies.IsSyncer && player.Zombies.NearbyZombies.Count < _maxZombies)
                {
                    CreateNewRandomZombie(player);
                    foreach (VnXPlayer nearbyPlayer in player.NearbyPlayers.ToList()) CreateNewRandomZombie(nearbyPlayer);
                }
                //else if (player.Zombies.IsSyncer)
                //Core.Debug.OutputDebugString("[Zombies] : " + player.Username + " hat das Limit von " + MAX_ZOMBIES + " Zombies erreicht.");
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        private static void SpawnZombiesArroundPlayers(VnXPlayer player)
        {
            try
            {
                foreach (ZombieModel zombieClass in CurrentZombies.ToList())
                {
                    if (player.Position.Distance(zombieClass.Position) < Zombie.World.Main.MaxZombieRange)
                    {
                        _RootCore_.VenoX.TriggerClientEvent(player, "Zombies:SpawnKI", zombieClass.Id, zombieClass.RandomSkinUid, zombieClass.SkinName, zombieClass.Position, zombieClass.TargetEntity);
                        //player?.EmitLocked("Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                        //VenoX.TriggerClientEvent(player, "Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                        zombieClass.Armor = 200;
                        zombieClass.Health = 200;
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public static void SpawnZombiesForEveryPlayer()
        {
            try
            {
                foreach (VnXPlayer player in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.ZombiePlayers))
                {
                    if (player is null || !player.Exists) continue;
                    AddNearbyZombiesIntoList(player);
                    SpawnZombiesArroundPlayers(player);
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }


    }
}
