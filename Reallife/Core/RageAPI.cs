using AltV.Net.Elements.Entities;
using AltV.Net;
using System;
using System.Collections.Generic;
using System.Text;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System.Drawing;

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
    }
}
