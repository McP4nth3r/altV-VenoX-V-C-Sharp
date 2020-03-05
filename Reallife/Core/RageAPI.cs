using AltV.Net.Elements.Entities;
using AltV.Net;
using System;
using System.Collections.Generic;
using System.Text;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System.Drawing;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Core
{
    public static class RageAPI
    {
        /*
        public static dynamic vnxGetElementData(this IPlayer player, string key)
        {
            try
            {
                return player.vnxGetElementData(key, out object value) ? value : default(dynamic);
            }
            catch { return null; }
        }*/

        public static T vnxGetElementData<T>(this IBaseObject element, string key)
        {
            try
            {
                //Console.WriteLine("[LOADED vnxGetElementData] : 1");
                if (element.GetData(key, out T value))
                {
                    //Console.WriteLine("[LOADED vnxGetElementData] KEY : " + key + " | " + value);
                    return value;
                }
                return default;
            }
            catch{ return default; }
        }                 
                
        public static T vnxGetSharedData<T>(this IEntity element, string key)
        {
            try
            {
                //Console.WriteLine("[LOADED vnxGetSharedData] : 2");
                if (element.GetSyncedMetaData(key, out T value))
                {
                    //Console.WriteLine("[LOADED vnxGetSharedData] KEY : " + key + " | " + value);
                    return value;
                }
                return default;
            }
            catch{ return default; }
        }      
        
        public static string GetHexColorcode(int r, int g, int b)
        {
            Color myColor = Color.FromArgb(r, g, b);
            return "{" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2") + "}";
        }

        public static void WarpIntoVehicle<T>(this IPlayer player, IVehicle veh, int seat)
        {
            player.Emit("Player:WarpIntoVehicle", veh, seat);
        }                
        public static void WarpOutOfVehicle<T>(this IPlayer player)
        {
            player.Emit("Player:WarpOutOfVehicle");
        }        
        public static void SetVnXName<T>(this IPlayer player, string Name)
        {
            player.SetData(Reallife.Globals.EntityData.PLAYER_NAME, Name);
            player.SetStreamSyncedMetaData(Reallife.Globals.EntityData.PLAYER_NAME, Name);
        }       
        public static string GetVnXName<T>(this IPlayer player)
        {
            return player.vnxGetElementData<string>(Reallife.Globals.EntityData.PLAYER_NAME);
        }

        public static IPlayer GetPlayerFromName(string name)
        {
            IPlayer player = null;
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if(players.Name == name)
                    {
                        player = players;
                    }
                }
                return player;
            }
            catch
            {
                return player;
            }
        }
        public static void GivePlayerWeapon(this IPlayer player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }        
                
        public static void SetWeaponAmmo(this IPlayer player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }        

        public static void SendChatMessageToAll(string text)
        {
            try
            {
                foreach(IPlayer players in Alt.GetAllPlayers())
                {
                    players.SendChatMessage(text);
                }
            }
            catch { }
        }

        public static void SetClothes(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try { element.Emit("Clothes:Load", clothesslot, clothesdrawable, clothestexture); }
            catch { }
        }        
        public static void SetCustomization(IPlayer element, SkinModel model)
        {
            List<SkinModel> modellist = new List<SkinModel>
            {
                model
            };
            try { element.Emit("HeadShape:Load", JsonConvert.SerializeObject(modellist)); }
            catch (Exception ex) { Core.Debug.CatchExceptions("SetCustomization", ex); }
            modellist.Clear();
        }

        public static void SetAccessories(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try { element.Emit("Accessories:Load", clothesslot, clothesdrawable, clothestexture); }
            catch { }
        }

        public static void SetPlayerVisible(IPlayer element, bool trueOrFalse)
        {
            try { element.Emit("Player:Visible", trueOrFalse); }
            catch { }
        }
    }
}
