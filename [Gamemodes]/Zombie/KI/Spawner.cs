using AltV.Net;
using AltV.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.KI
{
    public class Spawner : IScript
    {
        public static List<ZombieModel> CurrentZombies = new List<ZombieModel>();
        private static int CurrentZombieCounter = 0;
        private static int PositionCounter = 0;
        private static int DIST_ZOMBIES = 10;
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
                PositionCounter++;
                Random randomSkin = new Random();
                int randomSkinPicked = randomSkin.Next(0, _Preload_.Character_Creator.Main.CharacterSkins.Count);
                ZombieModel zombieClass = new ZombieModel
                {
                    ID = CurrentZombieCounter++,
                    SkinName = "mp_m_freemode_01",
                    RandomSkinUID = randomSkinPicked,
                    FaceFeatures = _Preload_.Character_Creator.Main.CharacterSkins[randomSkinPicked].FaceFeatures,
                    HeadBlendData = _Preload_.Character_Creator.Main.CharacterSkins[randomSkinPicked].HeadBlendData,
                    HeadOverlays = _Preload_.Character_Creator.Main.CharacterSkins[randomSkinPicked].HeadOverlays,
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

        private static void AddNearbyZombiesIntoList()
        {
            try
            {
                foreach (VnXPlayer player in Globals.Main.ZombiePlayers.ToList())
                {
                    if (player != null)
                    {
                        if (player.Zombies.IsSyncer && player.Zombies.NearbyZombies.Count < MAX_ZOMBIES)
                        {
                            CreateNewRandomZombie(player);
                            foreach (VnXPlayer nearbyPlayer in player.Zombies.NearbyPlayers.ToList())
                                CreateNewRandomZombie(nearbyPlayer);
                        }
                        else if (player.Zombies.IsSyncer) { Core.Debug.OutputDebugString("[Zombies] : " + player.Username + " hat das Limit von 80 Zombies erreicht."); }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void ApplyZombieClothes(VnXPlayer player, int RandomSkinUID, int ZombieId)
        {
            try
            {
                foreach (ClothesModel clothes in Reallife.Globals.Main.clothesList)
                {
                    if (clothes.player == RandomSkinUID && clothes.dressed)
                    {
                        if (clothes.type == 0)
                        {
                            //Alt.Server.TriggerClientEvent(player, "Zombies:ClothesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                            player?.EmitLocked("Zombies:ClothesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            //Alt.Server.TriggerClientEvent(player, "Zombies:AccessoriesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                            player?.EmitLocked("Zombies:AccessoriesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                        }
                    }
                }
                //Alt.Server.TriggerClientEvent(player, "Zombies:ApplyBloodToZombie", ZombieId);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void SpawnZombiesArroundPlayers()
        {
            try
            {
                foreach (VnXPlayer player in Globals.Main.ZombiePlayers.ToList())
                {
                    foreach (ZombieModel zombieClass in CurrentZombies.ToList())
                    {
                        if (player.Position.Distance(zombieClass.Position) < Zombie.World.Main.MAX_ZOMBIE_RANGE)
                        {
                            player?.EmitLocked("Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                            //Alt.Server.TriggerClientEvent(player, "Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                            zombieClass.Armor = 200;
                            zombieClass.Health = 200;
                            ApplyZombieClothes(player, zombieClass.RandomSkinUID, zombieClass.ID);
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void SpawnZombiesForEveryPlayer()
        {
            try
            {
                AddNearbyZombiesIntoList();
                SpawnZombiesArroundPlayers();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


    }
}
