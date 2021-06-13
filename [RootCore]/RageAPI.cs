using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Language_;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;
using VenoXV.Models;
using VehicleModel = VenoXV.Models.VehicleModel;

namespace VenoXV
{
    public static class RageApi
    {
        //RageAPI.CreateColShapeSphere(new Position(732.712f, -1088.656f, 21.77967f), 2);
        public static ColShapeModel CreateColShapeSphere(Vector3 position, float radius, int dimension = Dimension.GlobalDimension)
        {
            try
            {
                ColShapeModel entity = (ColShapeModel)Alt.CreateColShapeSphere(position, radius);
                entity.Dimension = dimension;
                Sync.ColShapeList.Add(entity);
                return entity;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }

        public static void RemoveColShape(ColShapeModel colShape)
        {
            try
            {
                if (!Sync.ColShapeList.Contains(colShape) || colShape == null || !colShape.Exists) return;
                colShape.MarkedForDelete = true;
                colShape.CurrentPosition = new Vector3(0, 0, 0);
                colShape.Position = new Vector3(0, 0, 0);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static async void SendTranslatedChatMessage(this VnXPlayer element, string msg)
        {
            try
            {
                await Main.SendTranslatedChatMessage(element, msg);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void SpawnPlayer(this VnXPlayer element, Vector3 pos, uint delayInMs = 0)
        {
            try
            {
                if (element.Spawned != true)
                {
                    element.Spawned = true;
                    element.SetPosition = pos;
                    element.Spawn(pos, delayInMs);
                    VenoX.TriggerClientEvent(element, "Player:Spawn");
                }
                else
                {
                    element.SetPosition = pos;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void DespawnPlayer(this VnXPlayer element)
        {
            try
            {
                if (!element.Spawned) return;
                element.Spawned = false;
                element.Despawn();
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SetPlayerSkin(this VnXPlayer element, uint skinHash)
        {
            try
            {
                if (!element.Spawned) return;
                if (element.Model == skinHash) return;
                element.Model = skinHash;
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static uint GetPlayerSkin(this VnXPlayer element)
        {
            try
            {
                if (element.Spawned) return element.Model;
                return (uint)PedModel.Natalia;
            }
            catch { return (uint)PedModel.Natalia; }
        }
        public static T VnxGetElementData<T>(this IBaseObject element, string key)
        {
            try
            {
                if (element == null) return default;
                if (element.GetData(key, out T value)) return value;
                return default;
            }
            catch { return default; }
        }
        public static void VnxSetElementData(this IBaseObject element, string key, object value)
        {
            try
            {
                if (element == null) return;
                element.SetData(key, value);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void VnxSetSharedElementData<T>(this IEntity element, string key, T value)
        {
            try
            {
                if (element == null) return;
                element.SetData(key, value);
                element.SetSyncedMetaData(key, value);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void VnxSetStreamSharedElementData<T>(this IEntity element, string key, T value)
        {
            try
            {
                if (element == null) return;
                element.SetData(key, value);
                element.SetStreamSyncedMetaData(key, value);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void Repair(this VehicleModel element)
        {
            try
            {
                element.Repair();
                //foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList()) { VenoX.TriggerClientEvent(player, "Vehicle:Repair", element); }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static T VnxGetSharedData<T>(this IEntity element, string key)
        {
            try
            {
                if (element == null) return default;
                if (element.GetSyncedMetaData(key, out T value)) return value;
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
                VenoX.TriggerClientEvent(player, "Player:WarpIntoVehicle", veh, seat);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void WarpOutOfVehicle(this VnXPlayer player)
        {
            try
            {
                if (player is null || !player.Exists) return;
                VenoX.TriggerClientEvent(player, "Player:WarpOutOfVehicle");
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static VnXPlayer GetPlayerFromName(string name)
        {
            try
            {
                return VenoX.GetAllPlayers().ToList().FirstOrDefault(x => x.Username.ToLower() == name.ToLower());
            }
            catch { return null; }
        }
        public static void GivePlayerWeapon(this VnXPlayer player, WeaponModel weapon, int ammo)
        {
            try
            {
                Alt.Emit("GlobalSystems:GiveWeapon", player, (uint)weapon, ammo, false);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void RemovePlayerWeapon(this VnXPlayer player, WeaponModel weapon)
        {
            try
            {
                Alt.Emit("GlobalSystems:RemovePlayerWeapon", player, (uint)weapon);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void RemoveAllPlayerWeapons(this VnXPlayer player)
        {
            try
            {
                Alt.Emit("GlobalSystems:RemoveAllPlayerWeapons", player);
                //player.GiveWeapon(weapon, ammo, false);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SetWeaponAmmo(this VnXPlayer player, WeaponModel weapon, int ammo)
        {
            try
            {
                Alt.Emit("GlobalSystems:GiveWeapon", player, (uint)weapon, ammo, false);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static async void SendTranslatedChatMessageToAll(string text)
        {
            try
            {
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                {
                    await Main.SendTranslatedChatMessage(players, text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SendChatMessageToAll(string text)
        {
            try
            {
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                {
                    lock (players)
                    {
                        players.SendChatMessage(text);
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void SetClothes(this VnXPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try
            {
                //Debug.OutputDebugString("Clothes : " + clothesslot + " | " + clothesdrawable + " | " + clothestexture);
                //Alt.Emit("GlobalSystems:SetClothes", element, clothesslot, clothesdrawable, clothestexture);
                VenoX.TriggerClientEvent(element, "Clothes:Load", clothesslot, clothesdrawable, clothestexture);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void SetProp(this VnXPlayer element, int propId, int drawableId, int textureId)
        {
            try
            {
                //Debug.OutputDebugString("Prop : " + propID + " | " + drawableID + " | " + textureID);
                Alt.Emit("GlobalSystems:SetProps", element, propId, drawableId, textureId);
                //VenoX.TriggerClientEvent(element, "Prop:Load", propID, drawableID, textureID);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void SetAccessories(this VnXPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try { VenoX.TriggerClientEvent(element, "Accessories:Load", clothesslot, clothesdrawable, clothestexture); }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SetPlayerVisible(this VnXPlayer element, bool trueOrFalse)
        {
            try
            {
                element.Visible = trueOrFalse;
                //VenoX.TriggerClientEvent(element, "Player:Visible", trueOrFalse);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SetPlayerAlpha(this VnXPlayer element, int alpha)
        {
            try { VenoX.TriggerClientEvent(element, "Player:Alpha", alpha); }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        private static int _textLabelCounter;
        public static LabelModel CreateTextLabel(string text, Position pos, float range, float size, int font, int[] color, int dimension = Dimension.GlobalDimension, VnXPlayer visibleOnlyFor = null, bool translate = true, bool isHouseLabel = false, int houseLabelId = 0)
        {
            try
            {
                LabelModel label = new LabelModel
                {
                    Id = _textLabelCounter++,
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
                    VisibleOnlyFor = visibleOnlyFor,
                    Translate = translate,
                    IsHouseLabel = isHouseLabel,
                    HouseLabelId = houseLabelId
                };
                Sync.LabelList.Add(label);
                return label;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new LabelModel(); }
        }
        public static void RemoveTextLabel(LabelModel labelClass)
        {
            try
            {
                if (labelClass == null) return;
                if (Sync.LabelList.Contains(labelClass))
                {
                    VenoX.TriggerEventForAll("Sync:RemoveLabelByID", labelClass.Id);
                    Sync.LabelList.Remove(labelClass);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void RemoveBlip(BlipModel blipClass, VnXPlayer deleteFor = null)
        {
            try
            {
                if (blipClass == null) return;
                if (deleteFor != null) VenoX.TriggerClientEvent(deleteFor, "BlipClass:RemoveBlip", blipClass.Id);
                else VenoX.TriggerEventForAll("BlipClass:RemoveBlip", blipClass.Id);
                if (Sync.BlipList.Contains(blipClass)) Sync.BlipList.Remove(blipClass);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        private static int _blipCounter;
        public static BlipModel CreateBlip(string name, Vector3 coord, int sprite, int color, bool shortRange, VnXPlayer visibleOnlyFor = null)
        {
            try
            {
                BlipModel blip = new BlipModel
                {
                    Id = _blipCounter,
                    Name = name,
                    PosX = coord.X,
                    PosY = coord.Y,
                    PosZ = coord.Z,
                    Sprite = sprite,
                    Color = color,
                    ShortRange = shortRange,
                    VisibleOnlyFor = visibleOnlyFor
                };
                Sync.BlipList.Add(blip);
                _blipCounter++;
                if (visibleOnlyFor is null) VenoX.TriggerEventForAll("BlipClass:CreateBlip", blip.Id, blip.Name, blip.PosX, blip.PosY, blip.PosZ, blip.Sprite, blip.Color, blip.ShortRange);
                else VenoX.TriggerClientEvent(visibleOnlyFor, "BlipClass:CreateBlip", blip.Id, blip.Name, blip.PosX, blip.PosY, blip.PosZ, blip.Sprite, blip.Color, blip.ShortRange);
                /*foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                    Sync.LoadBlips(players);*/
                return blip;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new BlipModel(); }
        }
        private static int _markerCounter;
        public static MarkerModel CreateMarker(int type, Vector3 position, Vector3 scale, int[] color, VnXPlayer visibleOnlyFor = null, int dimension = Dimension.GlobalDimension)
        {
            try
            {
                MarkerModel marker = new MarkerModel
                {
                    Id = _markerCounter++,
                    Type = type,
                    Position = position,
                    Scale = scale,
                    Color = color,
                    Dimension = dimension,
                    Visible = true,
                    VisibleOnlyFor = visibleOnlyFor
                };
                Sync.MarkerList.Add(marker);
                return marker;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new MarkerModel(); }
        }
        public static void RemoveMarker(MarkerModel markerClass)
        {
            try
            {
                if (Sync.MarkerList.Contains(markerClass))
                {
                    VenoX.TriggerEventForAll("Sync:RemoveMarkerByID", markerClass.Id);
                    Sync.MarkerList.Remove(markerClass);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        private static int _objectCounter;
        public static ObjectModel CreateObject(string parent, string hash, Vector3 position, Vector3 rotation, Quaternion quaternion, bool hashNeeded = false, int dimension = Dimension.GlobalDimension, VnXPlayer visibleOnlyFor = null)
        {
            try
            {
                ObjectModel obj = new ObjectModel
                {
                    Id = _objectCounter,
                    Parent = parent,
                    Hash = hash,
                    Position = position,
                    Rotation = rotation,
                    Quaternion = quaternion,
                    HashNeeded = hashNeeded,
                    Dimension = dimension,
                    VisibleOnlyFor = visibleOnlyFor
                };
                Sync.ObjectList.Add(obj);
                _objectCounter++;
                return obj;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new ObjectModel(); }
        }

        public static void DeleteVehicleThreadSafe(VehicleModel vehicleClass)
        {
            try
            {
                if (vehicleClass is null || !vehicleClass.Exists) return;
                vehicleClass.Dimension = 99998;
                vehicleClass.EngineOn = false;
                vehicleClass.Locked = true;
                vehicleClass.MarkedForDelete = true;
                if (!_Globals_.Main.AllVehicles.Contains(vehicleClass)) _Globals_.Main.AllVehicles.Add(vehicleClass);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static NpcModel CreateNpc(string hashName, Vector3 position, Vector3 rotation, int gamemode, VnXPlayer visibleOnlyFor = null)
        {
            try
            {
                NpcModel npc = new NpcModel
                {
                    Id = 0,
                    Gamemode = gamemode,
                    Health = 200,
                    Armor = 100,
                    Name = hashName,
                    Position = position,
                    Rotation = rotation
                };
                foreach (var players in VenoX.GetAllPlayers().ToList().Where(players => players.Playing))
                {
                    if (players.Gamemode == gamemode && visibleOnlyFor == null)
                        VenoX.TriggerClientEvent(players, "NPC:Create", hashName, position, rotation.Z);
                    else if (players.Gamemode == gamemode && visibleOnlyFor == players)
                        VenoX.TriggerClientEvent(players, "NPC:Create", hashName, position, rotation.Z);
                }
                Sync.NpcList.Add(npc);
                return npc;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new NpcModel(); }
        }
        public static void UpdateNpcPosition(NpcModel npcClass)
        {

        }
        public static void UpdateNpcPositionById(int npcId)
        {

        }
        public static void RemoveNpc(NpcModel npcClass)
        {
            if (Sync.NpcList.Contains(npcClass)) { Sync.NpcList.Remove(npcClass); }
        }
        public static void RemoveNpcById(int npcId)
        {

        }
        public static float ToRadians(float val)
        {
            return (float)(Math.PI / 180) * val;
        }
        public static float ToDegrees(float val)
        {
            return (float)(val * (180 / Math.PI));
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
