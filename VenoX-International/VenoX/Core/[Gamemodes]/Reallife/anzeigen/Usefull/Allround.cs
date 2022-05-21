using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.factions;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;
using EntityData = VenoX.Core._Globals_.EntityData;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;
using Weapons = VenoX.Core._Gamemodes_.Reallife.weapons.Weapons;

namespace VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull
{
    public class VnX : IScript
    {
        public static void RemoveAllWeapons(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();
                int playerId = player.CharacterId;
                foreach (ItemModel waffen in Inventory.DatabaseItems.ToList().Where(waffen => waffen.Type == ItemType.Gun && waffen.Uid == playerId))
                {
                    Inventory.DatabaseItems.Remove(waffen);
                    player.Inventory.Items.Remove(waffen);
                }
                Database.RemoveAllItemsByType(playerId, ItemType.Gun);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static void RemoveAllBadGwWeapons(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();

                int playerId = player.CharacterId;

                ItemModel switchblade = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashSwitchblade);
                ItemModel nightstick = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashNightstick);
                ItemModel baseball = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashBaseball);
                ItemModel tazer = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashTazer);

                ItemModel shotgun = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashShotgun);

                ItemModel sniperrifle = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashSniperrifle);

                if (switchblade != null)
                {
                    Database.RemoveItem(switchblade.Id);
                    Inventory.DatabaseItems.Remove(switchblade);
                }

                if (baseball != null)
                {
                    Database.RemoveItem(baseball.Id);
                    Inventory.DatabaseItems.Remove(baseball);
                }

                if (nightstick != null)
                {
                    Database.RemoveItem(nightstick.Id);
                    Inventory.DatabaseItems.Remove(nightstick);
                }

                if (tazer != null)
                {
                    Database.RemoveItem(tazer.Id);
                    Inventory.DatabaseItems.Remove(tazer);
                }

                if (shotgun != null)
                {
                    Database.RemoveItem(shotgun.Id);
                    Inventory.DatabaseItems.Remove(shotgun);
                }

                if (sniperrifle != null)
                {
                    Database.RemoveItem(sniperrifle.Id);
                    Inventory.DatabaseItems.Remove(sniperrifle);
                }

                Weapons.GivePlayerWeaponItems(player);
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
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.ReallifePlayers))
                {
                    if (player.Position.Distance(players.Position) < 5)
                    {
                        players.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 150) + player.CharacterUsername + " : " + text);
                    }
                }
                //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150,0,150) +player.Username + " : " + text);
                Logfile.WriteLogs("chat", "[ME][" + player.CharacterUsername + "] : " + text);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static void SpectatePlayer(VnXPlayer player, string targetName, int einsfürfalse)
        {
            // VenoX.TriggerClientEvent(player,"VnX_Start_S", Target, einsfürfalse);
        }

        //[AltV.Net.ClientEvent("CreateTypingEffect")]
        public static void CreateTypingEffect(VnXPlayer player, bool state)
        {
            if (state)
            {
                player.SetStreamSyncedMetaData("SocialState_NAMETAG", "Schreibt...");
            }
            else
            {
                player.SetStreamSyncedMetaData("SocialState_NAMETAG", player.VnxGetSharedData<string>(EntityData.PlayerStatus));
            }
        }

        public static void ResetDiscordData(VnXPlayer player)
        {
            if (Allround.IsStateFaction(player))
            {
                switch (player.Reallife.Faction)
                {
                    case Constants.FactionLspd:
                        _RootCore_.VenoX.TriggerClientEvent(player, "discord_update", "Auf Streife [L.S.P.D]", "VenoX - Reallife");
                        break;
                    case Constants.FactionFbi:
                        _RootCore_.VenoX.TriggerClientEvent(player, "discord_update", "Auf Streife [F.I.B]", "VenoX - Reallife");
                        break;
                }
            }
            else
            {
                _RootCore_.VenoX.TriggerClientEvent(player, "discord_update", "Unterwegs auf VenoX...", "VenoX - Reallife");
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
