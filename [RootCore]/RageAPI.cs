using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;

namespace VenoXV.Core
{
    public static class RageAPI
    {
        //RageAPI.CreateColShapeSphere(new Position(732.712f, -1088.656f, 21.77967f), 2);
        public static List<ColShapeModel> GetAllColShapes()
        {
            try { return Sync.ColShapeList; }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<ColShapeModel>(); }
        }
        public static ColShapeModel CreateColShapeSphere(Vector3 Position, float Radius, int Dimension = Globals.Main.REALLIFE_DIMENSION)
        {
            try
            {
                ColShapeModel Entity = (ColShapeModel)Alt.CreateColShapeSphere(Position, Radius);
                Entity.Dimension = Dimension;
                Sync.ColShapeList.Add(Entity);
                return Entity;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }

        public static void RemoveColShape(ColShapeModel ColShape)
        {
            try
            {
                if (Sync.ColShapeList.Contains(ColShape)) { Alt.RemoveColShape(ColShape); Sync.ColShapeList.Remove(ColShape); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static async void SendTranslatedChatMessage(this VnXPlayer element, string msg)
        {
            try
            {
                await Task.Run(async () =>
                {
                    await _Language_.Main.SendTranslatedChatMessage(element, msg);
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void SpawnPlayer(this VnXPlayer element, Vector3 pos, uint DelayInMS = 0)
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
        public static void DespawnPlayer(this VnXPlayer element)
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
        public static void SetPlayerSkin(this VnXPlayer element, uint SkinHash)
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
        public static uint GetPlayerSkin(this VnXPlayer element)
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
                if (element == null) { return default; }
                if (element.GetData(key, out T value)) { return value; }
                return default;
            }
            catch { return default; }
        }
        public static void vnxSetElementData(this IBaseObject element, string key, object value)
        {
            try
            {
                if (element == null) return;
                element.SetData(key, value);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void vnxSetSharedElementData<T>(this IEntity element, string key, T value)
        {
            try
            {
                if (element == null) return;
                element.SetData(key, value);
                element.SetSyncedMetaData(key, value);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void vnxSetStreamSharedElementData<T>(this IEntity element, string key, T value)
        {
            try
            {
                if (element == null) return;
                element.SetData(key, value);
                element.SetStreamSyncedMetaData(key, value);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void Repair(this IVehicle element)
        {
            try
            {
                foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList()) { Alt.Server.TriggerClientEvent(player, "Vehicle:Repair", element); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static T vnxGetSharedData<T>(this IEntity element, string key)
        {
            try
            {
                if (element == null) { return default; }
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
        public static void WarpIntoVehicle(this VnXPlayer player, VehicleModel veh, int seat)
        {
            try
            {
                if (player is null || !player.Exists) return;
                Alt.Server.TriggerClientEvent(player, "Player:WarpIntoVehicle", veh, seat);
            }
            catch { }
        }
        public static void WarpOutOfVehicle(this VnXPlayer player)
        {
            try
            {
                if (player is null || !player.Exists) return;
                Alt.Server.TriggerClientEvent(player, "Player:WarpOutOfVehicle");
            }
            catch { }
        }
        public static VnXPlayer GetPlayerFromName(string name)
        {
            VnXPlayer player = null;
            try
            {
                name = name.ToLower();
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
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
        public static void GivePlayerWeapon(this VnXPlayer player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                Alt.Emit("GlobalSystems:GiveWeapon", player, (uint)weapon, ammo, false);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void RemovePlayerWeapon(this VnXPlayer player, AltV.Net.Enums.WeaponModel weapon)
        {
            try
            {
                Alt.Emit("GlobalSystems:RemovePlayerWeapon", player, (uint)weapon);
            }
            catch { }
        }
        public static void RemoveAllPlayerWeapons(this VnXPlayer player)
        {
            try
            {
                Alt.Emit("GlobalSystems:RemoveAllPlayerWeapons", player);
                //player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }
        public static void SetWeaponAmmo(this VnXPlayer player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                Alt.Emit("GlobalSystems:GiveWeapon", player, (uint)weapon, ammo, false);
            }
            catch { }
        }
        public static async void SendTranslatedChatMessageToAll(string text)
        {
            try
            {
                await Task.Run(async () =>
                {
                    foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                    {
                        await _Language_.Main.SendTranslatedChatMessage(players, text);
                    }
                });
            }
            catch { }
        }

        public static void SetClothes(this VnXPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try
            {
                if (clothesslot < 0 || clothesdrawable < 0) { return; }
                element.Emit("Clothes:Load", clothesslot, clothesdrawable, clothestexture);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void SetProp(this VnXPlayer element, int propID, int drawableID, int textureID)
        {
            try
            {
                if (propID < 0 || textureID < 0) { return; }
                element.Emit("Prop:Load", propID, drawableID, textureID);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void SetAccessories(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try { element.Emit("Accessories:Load", clothesslot, clothesdrawable, clothestexture); }
            catch { }
        }
        public static void SetPlayerVisible(this VnXPlayer element, bool trueOrFalse)
        {
            try { element.Emit("Player:Visible", trueOrFalse); }
            catch { }
        }
        public static void SetPlayerAlpha(this VnXPlayer element, int alpha)
        {
            try { element.Emit("Player:Alpha", alpha); }
            catch { }
        }
        private static int TextLabelCounter = 0;
        public static LabelModel CreateTextLabel(string text, Position pos, float range, float size, int font, int[] color, int dimension = Globals.Main.REALLIFE_DIMENSION, VnXPlayer VisibleOnlyFor = null)
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
                    ColorA = color[3],
                    VisibleOnlyFor = VisibleOnlyFor
                };
                Sync.LabelList.Add(label);
                return label;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new LabelModel(); }
        }
        public static void RemoveTextLabel(LabelModel labelClass)
        {
            try
            {
                if (labelClass == null) { return; }
                if (Sync.LabelList.Contains(labelClass)) { Sync.LabelList.Remove(labelClass); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void RemoveBlip(BlipModel blipClass, VnXPlayer DeleteFor = null)
        {
            try
            {
                if (blipClass == null) { return; }
                if (DeleteFor != null) { DeleteFor.Emit("BlipClass:RemoveBlip", blipClass.Name); }
                else { Alt.EmitAllClients("BlipClass:RemoveBlip", blipClass.Name); }
                if (Sync.BlipList.Contains(blipClass)) { Sync.BlipList.Remove(blipClass); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static BlipModel CreateBlip(string Name, Vector3 coord, int Sprite, int Color, bool ShortRange, VnXPlayer VisibleOnlyFor = null)
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
                    ShortRange = ShortRange,
                    VisibleOnlyFor = VisibleOnlyFor
                };
                Sync.BlipList.Add(blip);
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                {
                    Sync.LoadBlips(players);
                }
                return blip;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new BlipModel(); }
        }
        private static int MarkerCounter = 0;
        public static MarkerModel CreateMarker(int Type, Vector3 Position, Vector3 Scale, int[] Color, VnXPlayer VisibleOnlyFor = null, int Dimension = Globals.Main.REALLIFE_DIMENSION)
        {
            try
            {
                MarkerModel marker = new MarkerModel
                {
                    ID = MarkerCounter++,
                    Type = Type,
                    Position = Position,
                    Scale = Scale,
                    Color = Color,
                    Dimension = Dimension,
                    Visible = true,
                    VisibleOnlyFor = VisibleOnlyFor
                };
                Sync.MarkerList.Add(marker);
                return marker;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new MarkerModel(); }
        }
        public static void RemoveMarker(MarkerModel markerClass)
        {
            try
            {
                if (Sync.MarkerList.Contains(markerClass)) Sync.MarkerList.Remove(markerClass);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        private static int ObjectCounter = 0;
        public static ObjectModel CreateObject(string Parent, string Hash, Vector3 Position, Vector3 Rotation, Quaternion Quaternion, bool HashNeeded = false, int Dimension = Globals.Main.REALLIFE_DIMENSION, VnXPlayer VisibleOnlyFor = null)
        {
            try
            {
                ObjectModel obj = new ObjectModel
                {
                    ID = ObjectCounter++,
                    Parent = Parent,
                    Hash = Hash,
                    Position = Position,
                    Rotation = Rotation,
                    Quaternion = Quaternion,
                    HashNeeded = HashNeeded,
                    Dimension = Dimension,
                    VisibleOnlyFor = VisibleOnlyFor
                };
                Sync.ObjectList.Add(obj);
                return obj;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new ObjectModel(); }
        }

        public static void DeleteVehicleThreadSafe(VehicleModel vehicleClass)
        {
            try
            {
                if (vehicleClass is null) return;
                vehicleClass.Dimension = 99998;
                vehicleClass.EngineOn = false;
                vehicleClass.Locked = true;
                vehicleClass.MarkedForDelete = true;
                if (!Globals.Main.AllVehicles.Contains(vehicleClass)) { Globals.Main.AllVehicles.Add(vehicleClass); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }

        }

        public static NPCModel CreateNPC(string HashName, Vector3 Position, Vector3 Rotation, int Gamemode, VnXPlayer VisibleOnlyFor = null)
        {
            try
            {
                NPCModel NPC = new NPCModel
                {
                    ID = 0,
                    Gamemode = Gamemode,
                    Health = 200,
                    Armor = 100,
                    Name = HashName,
                    Position = Position,
                    Rotation = Rotation
                };
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                {
                    if (players.Playing)
                    {
                        if (players.Gamemode == Gamemode && VisibleOnlyFor == null)
                        {
                            Alt.Server.TriggerClientEvent(players, "NPC:Create", HashName, Position, Rotation.Z);
                        }
                        else if (players.Gamemode == Gamemode && VisibleOnlyFor == players)
                        {
                            Alt.Server.TriggerClientEvent(players, "NPC:Create", HashName, Position, Rotation.Z);
                        }
                    }
                }
                Sync.NPCList.Add(NPC);
                return NPC;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new NPCModel(); }
        }
        public static void UpdateNPCPosition(NPCModel npcClass)
        {

        }
        public static void UpdateNPCPositionById(int npcId)
        {

        }
        public static void RemoveNPC(NPCModel npcClass)
        {
            if (Sync.NPCList.Contains(npcClass)) { Sync.NPCList.Remove(npcClass); }
        }
        public static void RemoveNPCById(int npcId)
        {

        }
        public static float ToRadians(float val)
        {
            return (float)(System.Math.PI / 180) * val;
        }
        public static float ToDegrees(float val)
        {
            return (float)(val * (180 / System.Math.PI));
        }
        public static void ShuffleList<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
