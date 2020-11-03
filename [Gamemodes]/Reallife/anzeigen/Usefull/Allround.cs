using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.anzeigen.Usefull
{
    public class VnX : IScript
    {
        public static void RemoveAllWeapons(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();
                int playerId = player.UID;
                foreach (ItemModel waffen in Inventar.Main.CurrentOnlineItemList.ToList())
                {
                    if (waffen.ITEM_ART == Constants.ITEM_ART_WAFFE && waffen.ownerIdentifier == playerId)
                    {
                        Inventar.Main.CurrentOnlineItemList.Remove(waffen);
                    }
                }
                Database.RemoveAllItemsByArt(playerId, Constants.ITEM_ART_WAFFE);
                Database.RemoveAllItemsByArt(playerId, Constants.ITEM_ART_MAGAZIN);
            }
            catch { }
        }

        public static void RemoveAllBadGWWeapons(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();

                int playerId = player.UID;

                ItemModel Switchblade = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SWITCHBLADE);
                ItemModel Nightstick = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_NIGHTSTICK);
                ItemModel Baseball = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_BASEBALL);
                ItemModel Tazer = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_TAZER);

                ItemModel Shotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);

                ItemModel Sniperrifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNIPERRIFLE);

                if (Switchblade != null)
                {
                    Database.RemoveItem(Switchblade.id);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Switchblade);
                }

                if (Baseball != null)
                {
                    Database.RemoveItem(Baseball.id);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Baseball);
                }

                if (Nightstick != null)
                {
                    Database.RemoveItem(Nightstick.id);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Nightstick);
                }

                if (Tazer != null)
                {
                    Database.RemoveItem(Tazer.id);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Tazer);
                }

                if (Shotgun != null)
                {
                    Database.RemoveItem(Shotgun.id);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Shotgun);
                }

                if (Sniperrifle != null)
                {
                    Database.RemoveItem(Sniperrifle.id);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Sniperrifle);
                }

                weapons.Weapons.GivePlayerWeaponItems(player);
            }
            catch
            {
            }
        }

        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            int cevent = random.Next(min, max);
            return cevent;
        }


        [Command("me")]
        public static void SendMessageNearPlayers(VnXPlayer player, string text)
        {
            try
            {
                foreach (VnXPlayer players in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (player.Position.Distance(players.Position) < 5)
                    {
                        players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 150) + player.Username + " : " + text);
                    }
                }
                //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150,0,150) +player.Username + " : " + text);
                vnx_stored_files.logfile.WriteLogs("chat", "[ME][" + player.Username + "] : " + text);
            }
            catch { }
        }

        public static void SpectatePlayer(VnXPlayer player, string target_name, int einsfürfalse)
        {
            // VenoX.TriggerClientEvent(player,"VnX_Start_S", Target, einsfürfalse);
        }

        //[AltV.Net.ClientEvent("CreateTypingEffect")]
        public static void CreateTypingEffect(VnXPlayer player, bool state)
        {
            if (state == true)
            {
                player.SetStreamSyncedMetaData("SocialState_NAMETAG", "Schreibt...");
            }
            else
            {
                player.SetStreamSyncedMetaData("SocialState_NAMETAG", player.vnxGetSharedData<string>(VenoXV.Globals.EntityData.PLAYER_STATUS));
            }
        }

        public static void ResetDiscordData(VnXPlayer player)
        {
            if (Allround.isStateFaction(player))
            {
                if (player.Reallife.Faction == Constants.FACTION_LSPD)
                {
                    VenoX.TriggerClientEvent(player, "discord_update", "Auf Streife [L.S.P.D]", "VenoX - Reallife");
                }
                else if (player.Reallife.Faction == Constants.FACTION_FBI)
                {
                    VenoX.TriggerClientEvent(player, "discord_update", "Auf Streife [F.I.B]", "VenoX - Reallife");
                }
            }
            else
            {
                VenoX.TriggerClientEvent(player, "discord_update", "Unterwegs auf VenoX...", "VenoX - Reallife");
            }
        }


        //[AltV.Net.ClientEvent("VnX_PutPlayerInRandomDim")]
        public static void PutPlayerInRandomDim(VnXPlayer player)
        {
            try
            {
                Random random = new Random();
                int cevent = random.Next(1, 9999999);
                if (player.IsInVehicle) { player.Vehicle.Dimension = cevent; }
                player.Dimension = cevent;
            }
            catch
            {
            }
        }


        public static void SavePlayerDatas(VnXPlayer player)
        {
            try
            {
                Database.SaveCharacterInformation(player);
            }
            catch { }
        }

        public static void SaveIVehicleDatas()
        {
            try
            {
                List<VehicleModel> IVehicleList = new List<VehicleModel>();

                foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                {
                    if (Vehicle.Owner != null)
                    {
                        if (Vehicle.IsTestVehicle != true && Vehicle.Faction == 0 && Vehicle.NotSave != false && Vehicle.Dimension == 0)
                        {
                            // Add IVehicle into the list
                            IVehicleList.Add(Vehicle);
                        }
                    }
                }
                Database.SaveAllIVehicles(IVehicleList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SaveIVehicleDatas] " + ex.Message);
                Console.WriteLine("[EXCEPTION SaveIVehicleDatas] " + ex.StackTrace);
            }
        }
    }
}
