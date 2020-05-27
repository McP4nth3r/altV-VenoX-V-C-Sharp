using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;
using VenoXV.Globals;

namespace VenoXV._Gamemodes_.KI
{
    public class Spawner : IScript
    {
        public static List<ZombieModel> CurrentZombies = new List<ZombieModel>();
        private static int CurrentZombieCounter = 0;
        private static void AddNearbyZombiesIntoList()
        {
            foreach (Client player in Main.ZombiePlayers)
            {
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
                    IsDead = false,
                    Position = new Vector3(player.Position.X + 5, player.Position.Y + 5, player.Position.Z),
                    TargetEntity = player
                };
                CurrentZombies.Add(zombieClass);
            }
        }

        private static void ApplyZombieClothes(Client player, int RandomSkinUID, int ZombieId)
        {
            try
            {
                foreach (ClothesModel clothes in _Gamemodes_.Reallife.Globals.Main.clothesList)
                {
                    if (clothes.player == RandomSkinUID && clothes.dressed)
                    {
                        if (clothes.type == 0)
                        {
                            player.Emit("Clothes:Load", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            player.Emit("Zombies:AccessoriesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                        }
                    }
                }
                player.Emit("Zombies:ApplyBloodToZombie", ZombieId);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ApplyZombieClothes", ex); }
        }

        private static void SpawnZombiesArroundPlayers()
        {
            foreach (Client player in Main.ZombiePlayers)
            {
                foreach (ZombieModel zombieClass in CurrentZombies)
                {
                    player.Emit("Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                    ApplyZombieClothes(player, zombieClass.RandomSkinUID, zombieClass.ID);
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
                    /*
                    foreach (Client players in Main.ZombiePlayers)
                    {
                        players.Emit("Zombies:DeleteZombieById", Id);
                    }*/
                    CurrentZombies.Remove(zombies);
                }
            }
        }

    }
}
