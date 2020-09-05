using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Zombie.Globals;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.KI
{
    public class Spawner : IScript
    {
        public static List<ZombieModel> CurrentZombies = new List<ZombieModel>();
        private static int CurrentZombieCounter = 0;
        //
        private static void CreateNewRandomZombie(VnXPlayer player)
        {
            try
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
                    Position = new Vector3(player.Position.X + (player.Zombies.NearbyZombies.Count / 2), player.Position.Y + (player.Zombies.NearbyZombies.Count / 2), player.Position.Z - 0.5f),
                    TargetEntity = player
                };
                player.Zombies.NearbyZombies.Add(zombieClass);
                CurrentZombies.Add(zombieClass);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateNewRandomZombie", ex); }
        }

        private static void AddNearbyZombiesIntoList()
        {
            try
            {
                foreach (VnXPlayer player in Globals.Main.ZombiePlayers.ToList())
                {
                    if (player.Zombies.IsSyncer && player.Zombies.NearbyZombies.Count < 80)
                    {
                        CreateNewRandomZombie(player);
                        //Create Zombies for nearbyPlayers.
                        foreach (VnXPlayer nearbyPlayer in player.Zombies.NearbyPlayers.ToList())
                        {
                            CreateNewRandomZombie(player);
                        }
                    }
                    else if (player.Zombies.IsSyncer) { Core.Debug.OutputDebugString("[Zombies] : " + player.Username + " hat das Limit von 80 Zombies erreicht."); }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("AddNearbyZombiesIntoList", ex); }
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
                            Alt.Server.TriggerClientEvent(player, "Zombies:ClothesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            Alt.Server.TriggerClientEvent(player, "Zombies:AccessoriesLoad", ZombieId, clothes.slot, clothes.drawable, clothes.texture);
                        }
                    }
                }
                Alt.Server.TriggerClientEvent(player, "Zombies:ApplyBloodToZombie", ZombieId);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ApplyZombieClothes", ex); }
        }

        private static void SpawnZombiesArroundPlayers()
        {
            try
            {
                foreach (VnXPlayer player in Globals.Main.ZombiePlayers.ToList())
                {
                    foreach (ZombieModel zombieClass in CurrentZombies.ToList())
                    {
                        Alt.Server.TriggerClientEvent(player, "Zombies:SpawnKI", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                        ApplyZombieClothes(player, zombieClass.RandomSkinUID, zombieClass.ID);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("SpawnZombiesArroundPlayers", ex); }
        }
        public static void SpawnZombiesForEveryPlayer()
        {
            try
            {
                AddNearbyZombiesIntoList();
                SpawnZombiesArroundPlayers();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("SpawnZombiesForEveryPlayer", ex); }
        }
        public static void DestroyZombieById(int Id)
        {
            try
            {
                ZombieModel zombies = CurrentZombies.FirstOrDefault(z => z.ID == Id);
                if (zombies != null)
                {
                    foreach (VnXPlayer players in Globals.Main.ZombiePlayers.ToList())
                    {
                        foreach (ZombieModel zombieClass in players.Zombies.NearbyZombies.ToList())
                            if (zombieClass.ID == Id) players.Zombies.NearbyZombies.Remove(zombieClass);
                        Alt.Server.TriggerClientEvent(players, "Zombies:SetHealth", Id, 0);
                    }
                    Events.KilledZombieIds.Remove(zombies.ID);
                    CurrentZombies.Remove(zombies);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("DestroyZombieById", ex); }
        }

    }
}
