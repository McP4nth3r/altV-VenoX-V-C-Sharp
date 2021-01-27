using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
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
                foreach (ItemModel waffen in _Globals_.Inventory.Inventory.DatabaseItems.ToList())
                {
                    if (waffen.Type == ItemType.Gun && waffen.UID == playerId)
                    {

                        _Globals_.Inventory.Inventory.DatabaseItems.Remove(waffen);
                        player.Inventory.Items.Remove(waffen);
                    }
                }
                Database.RemoveAllItemsByType(playerId, ItemType.Gun);
            }
            catch { }
        }

        public static void RemoveAllBadGWWeapons(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();

                int playerId = player.UID;

                ItemModel Switchblade = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SWITCHBLADE);
                ItemModel Nightstick = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_NIGHTSTICK);
                ItemModel Baseball = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_BASEBALL);
                ItemModel Tazer = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_TAZER);

                ItemModel Shotgun = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SHOTGUN);

                ItemModel Sniperrifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SNIPERRIFLE);

                if (Switchblade != null)
                {
                    Database.RemoveItem(Switchblade.Id);
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(Switchblade);
                }

                if (Baseball != null)
                {
                    Database.RemoveItem(Baseball.Id);
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(Baseball);
                }

                if (Nightstick != null)
                {
                    Database.RemoveItem(Nightstick.Id);
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(Nightstick);
                }

                if (Tazer != null)
                {
                    Database.RemoveItem(Tazer.Id);
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(Tazer);
                }

                if (Shotgun != null)
                {
                    Database.RemoveItem(Shotgun.Id);
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(Shotgun);
                }

                if (Sniperrifle != null)
                {
                    Database.RemoveItem(Sniperrifle.Id);
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(Sniperrifle);
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
    }
}
