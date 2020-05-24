﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;

namespace VenoXV.Core
{
    public static class RageAPI
    {
        public static void SendTranslatedChatMessage(this Client element, string msg)
        {
            try
            {
                _Language_.Main.SendTranslatedChatMessage(element, msg);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("SendTranslatedChatMessage", ex); }
        }
        public static void SpawnPlayer(this Client element, Vector3 pos, uint DelayInMS = 0)
        {
            try
            {
                if (element.vnxGetElementData<bool>("RAGEAPI:SpawnedPlayer") != true)
                {
                    element.vnxSetElementData("RAGEAPI:SpawnedPlayer", true);
                    element.SetPosition = pos;
                    element.Spawn(pos, DelayInMS);
                    element.Emit("Player:Spawn");
                }
                else
                {
                    element.SetPosition = pos;
                }
            }
            catch { }
        }
        public static void DespawnPlayer(this Client element)
        {
            try
            {
                if (element.vnxGetElementData<bool>("RAGEAPI:SpawnedPlayer") == true)
                {
                    element.vnxSetStreamSharedElementData("RAGEAPI:SpawnedPlayer", false);
                    element.Despawn();
                }
            }
            catch { }
        }
        public static void SetPlayerSkin(this Client element, uint SkinHash)
        {
            try
            {
                if (element.vnxGetElementData<bool>("RAGEAPI:SpawnedPlayer") == true)
                {
                    if (element.vnxGetElementData<uint>("RAGEAPI:PlayerSkin") != SkinHash)
                    {
                        element.vnxSetStreamSharedElementData("RAGEAPI:PlayerSkin", SkinHash);
                        element.Model = SkinHash;
                    }
                }
            }
            catch { }
        }
        public static uint GetPlayerSkin(this Client element)
        {
            try
            {
                if (element.vnxGetElementData<bool>("RAGEAPI:SpawnedPlayer") == true)
                {
                    return element.Model;
                }
                return (uint)AltV.Net.Enums.PedModel.Natalia;
            }
            catch { return (uint)AltV.Net.Enums.PedModel.Natalia; }
        }
        public static T vnxGetElementData<T>(this IBaseObject element, string key)
        {
            try
            {
                if (element.GetData(key, out T value)) { return value; }
                return default;
            }
            catch { return default; }
        }
        public static void vnxSetElementData(this IBaseObject element, string key, object value)
        {
            try { element.SetData(key, value); }
            catch (Exception ex) { Core.Debug.CatchExceptions("vnxSetElementData", ex); }
        }
        public static void vnxSetSharedElementData<T>(this IEntity element, string key, T value)
        {
            try
            {
                element.SetData(key, value);
                element.SetSyncedMetaData(key, value);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("vnxSetSharedElementData", ex); }
        }
        public static void vnxSetStreamSharedElementData<T>(this IEntity element, string key, T value)
        {
            try
            {
                element.SetData(key, value);
                element.SetStreamSyncedMetaData(key, value);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("vnxSetStreamSharedElementData", ex); }
        }
        public static void Repair(this IVehicle element)
        {
            try
            {
                foreach (Client player in Alt.GetAllPlayers()) { player.Emit("Vehicle:Repair", element); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Repair", ex); }
        }
        public static T vnxGetSharedData<T>(this IEntity element, string key)
        {
            try
            {
                if (element.GetSyncedMetaData(key, out T value))
                {
                    return value;
                }
                return default;
            }
            catch { return default; }
        }
        public static string GetHexColorcode(int r, int g, int b)
        {
            Color myColor = Color.FromArgb(r, g, b);
            return "{" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2") + "}";
        }
        public static void WarpIntoVehicle<T>(this Client player, IVehicle veh, int seat)
        {
            player.Emit("Player:WarpIntoVehicle", veh, seat);
        }
        public static void WarpOutOfVehicle<T>(this Client player)
        {
            player.Emit("Player:WarpOutOfVehicle");
        }
        public static Client GetPlayerFromName(string name)
        {
            Client player = null;
            try
            {
                name = name.ToLower();
                foreach (Client players in Alt.GetAllPlayers())
                {
                    if (players.Username.ToLower() == name)
                    {
                        player = players;
                    }
                }
                return player;
            }
            catch { return player; }
        }
        public static void GivePlayerWeapon(this Client player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                Alt.Emit("GlobalSystems:GiveWeapon", player, (uint)weapon, ammo, false);
                player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }
        public static void RemovePlayerWeapon(this Client player, AltV.Net.Enums.WeaponModel weapon)
        {
            try
            {
                Alt.Emit("GlobalSystems:RemovePlayerWeapon", player, (uint)weapon);
            }
            catch { }
        }
        public static void RemoveAllPlayerWeapons(this Client player)
        {
            try
            {
                Alt.Emit("GlobalSystems:RemoveAllPlayerWeapons", player);
                //player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }
        public static void SetWeaponAmmo(this Client player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                player.SetWeaponAmmo(weapon, (byte)ammo);
            }
            catch { }
        }
        public static void SendTranslatedChatMessageToAll(string text)
        {
            try
            {
                foreach (Client players in Alt.GetAllPlayers())
                {
                    players.SendChatMessage(text);
                }
            }
            catch { }
        }
        public static void SetClothes(this Client element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            if (clothesslot < 0 || clothesdrawable < 0) { return; }
            try { element.Emit("Clothes:Load", clothesslot, clothesdrawable, clothestexture); }
            catch (Exception ex) { Core.Debug.CatchExceptions("SetClothes", ex); }
        }
        public static void SetProp(this Client element, int propID, int drawableID, int textureID)
        {
            if (propID < 0 || textureID < 0) { return; }
            try { element.Emit("Prop:Load", propID, drawableID, textureID); }
            catch (Exception ex) { Core.Debug.CatchExceptions("SetProp", ex); }
        }
        public static void SetCustomization(this Client element, SkinModel model)
        {
            List<SkinModel> modellist = new List<SkinModel>
            {
                model
            };
            try { element.Emit("HeadShape:Load", JsonConvert.SerializeObject(modellist)); }
            catch (Exception ex) { Core.Debug.CatchExceptions("SetCustomization", ex); }
        }
        public static void SetAccessories(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try { element.Emit("Accessories:Load", clothesslot, clothesdrawable, clothestexture); }
            catch { }
        }
        public static void SetPlayerVisible(this Client element, bool trueOrFalse)
        {
            try { element.Emit("Player:Visible", trueOrFalse); }
            catch { }
        }
        public static void SetPlayerAlpha(this Client element, int alpha)
        {
            try { element.Emit("Player:Alpha", alpha); }
            catch { }
        }
        private static int TextLabelCounter = 0;
        public static LabelModel CreateTextLabel(string text, Position pos, float range, float size, int font, int[] color, int dimension = 0)
        {
            try
            {
                LabelModel label = new LabelModel
                {
                    ID = TextLabelCounter++,
                    Text = text,
                    PosX = pos.X,
                    PosY = pos.Y,
                    PosZ = pos.Z,
                    Range = range,
                    Size = size,
                    Font = font,
                    Dimension = dimension,
                    ColorR = color[0],
                    ColorG = color[1],
                    ColorB = color[2],
                    ColorA = color[3]
                };
                Sync.LabelList.Add(label);
                return label;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateTextLabel", ex); return new LabelModel(); }
        }
        public static BlipModel CreateBlip(string Name, Vector3 coord, int Sprite, int Color, bool ShortRange)
        {
            try
            {
                BlipModel blip = new BlipModel
                {
                    Name = Name,
                    posX = coord.X,
                    posY = coord.Y,
                    posZ = coord.Z,
                    Sprite = Sprite,
                    Color = Color,
                    ShortRange = ShortRange
                };
                Sync.BlipList.Add(blip);
                return blip;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateBlip", ex); return new BlipModel(); }
        }
        private static int MarkerCounter = 0;
        public static MarkerModel CreateMarker(int Type, Vector3 Position, Vector3 Scale, int[] Color)
        {
            try
            {
                MarkerModel marker = new MarkerModel
                {
                    ID = MarkerCounter++,
                    Type = Type,
                    Position = Position,
                    Scale = Scale,
                    Color = Color
                };
                Sync.MarkerList.Add(marker);
                return marker;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateMarker", ex); return new MarkerModel(); }
        }

        public static float ToRadians(float val)
        {
            return (float)(System.Math.PI / 180) * val;
        }
        public static float ToDegrees(float val)
        {
            return (float)(val * (180 / System.Math.PI));
        }
    }
}
