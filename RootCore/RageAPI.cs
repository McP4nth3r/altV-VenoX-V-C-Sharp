using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using VenoXV.Reallife.model;

namespace VenoXV.Core
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
            catch { return default; }
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
            catch { return default; }
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
                name = name.ToLower();
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.GetVnXName<bool>().ToLower() == name)
                    {
                        player = players;
                    }
                }
                return player;
            }
            catch { return player; }
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
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    players.SendChatMessage(text);
                }
            }
            catch { }
        }

        public static void SetClothes(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            if (clothesslot < 0 || clothesdrawable < 0) { return; }
            Core.Debug.OutputDebugString("Stuff : " + clothesslot + " | " + clothesdrawable + " | " + clothestexture);
            try { element.Emit("Clothes:Load", clothesslot, clothesdrawable, clothestexture); }
            catch (Exception ex) { Core.Debug.CatchExceptions("SetClothes", ex); }
        }
        public static void SetCustomization(IPlayer element, SkinModel model)
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

        public static void SetPlayerVisible(IPlayer element, bool trueOrFalse)
        {
            try { element.Emit("Player:Visible", trueOrFalse); }
            catch { }
        }


        public static void CreateTextLabel(string text, Position pos, float range, float size, int font, int[] color, int dimension = 0)
        {
            try
            {
                LabelModel label = new LabelModel
                {
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
                if (Reallife.Globals.Main.LabelList.Count < 50) { Reallife.Globals.Main.LabelList.Add(label); }
                else if (Reallife.Globals.Main.LabelList1.Count < 50) { Reallife.Globals.Main.LabelList1.Add(label); }
                else if (Reallife.Globals.Main.LabelList2.Count < 50) { Reallife.Globals.Main.LabelList2.Add(label); }
                else if (Reallife.Globals.Main.LabelList3.Count < 50) { Reallife.Globals.Main.LabelList3.Add(label); }
                else if (Reallife.Globals.Main.LabelList4.Count < 50) { Reallife.Globals.Main.LabelList4.Add(label); }
                else if (Reallife.Globals.Main.LabelList5.Count < 50) { Reallife.Globals.Main.LabelList5.Add(label); }
                else if (Reallife.Globals.Main.LabelList6.Count < 50) { Reallife.Globals.Main.LabelList6.Add(label); }
                else if (Reallife.Globals.Main.LabelList7.Count < 50) { Reallife.Globals.Main.LabelList7.Add(label); }
                else if (Reallife.Globals.Main.LabelList8.Count < 50) { Reallife.Globals.Main.LabelList8.Add(label); }
                else if (Reallife.Globals.Main.LabelList9.Count < 50) { Reallife.Globals.Main.LabelList9.Add(label); }
                //DynamicTextLabel textLabel = TextLabelStreamer.CreateDynamicTextLabel("Some Text", new Vector3(-879.655f, -853.499f, 19.566f), 0, true, new Rgba(255, 255, 255, 255));
                //TextLabelStreamer.CreateDynamicTextLabel(text, new Vector3(pos.X, pos.Y, pos.Z), dimension, true, new Rgba(255, 255, 255, 255));
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateTextLabel", ex); }
        }


        [Command("getlabels")]
        public static void GetAllLabelss(IPlayer player)
        {
            Core.Debug.OutputDebugString("Started");
            /*foreach(DynamicTextLabel label in TextLabelStreamer.GetAllDynamicTextLabels())
            {
                Debug.OutputDebugString("________________________");
                Debug.OutputDebugString("Name : " + label.Text);
                Debug.OutputDebugString("Position : " + label.Position);
                Debug.OutputDebugString("________________________");
            }*/
            Core.Debug.OutputDebugString("Stopped");
        }
    }
}
