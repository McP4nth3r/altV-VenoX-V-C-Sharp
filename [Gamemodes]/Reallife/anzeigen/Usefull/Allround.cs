using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.anzeigen.Usefull
{
    public class VnX : IScript
    {
        public static void RemoveAllWeapons(Client player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                foreach (ItemModel waffen in anzeigen.Inventar.Main.CurrentOnlineItemList.ToList())
                {
                    if (waffen.ITEM_ART == Constants.ITEM_ART_WAFFE && waffen.ownerIdentifier == playerId)
                    {
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(waffen);
                    }
                }
                Database.RemoveAllItemsByArt(playerId, Constants.ITEM_ART_WAFFE);
                Database.RemoveAllItemsByArt(playerId, Constants.ITEM_ART_MAGAZIN);
            }
            catch
            {
            }
        }

        public static void RemoveAllBadGWWeapons(Client player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();

                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);

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

        public static void onWantedChange(Client player)
        {
            Alt.Server.TriggerClientEvent(player, "UpdateStars", (int)player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"));
        }
        public static void OnFactionChange(Client player)
        {
            Alt.Server.TriggerClientEvent(player, "UpdateFaction", Faction.GetFactionNameById((int)player.Reallife.Faction), Faction.GetPlayerFactionRank(player), (int)player.Reallife.Faction);
        }

        public static void CreateCarGhostMode(Client player, int playeralpha, int IVehiclealpha, int timervalue)
        {
            Alt.Server.TriggerClientEvent(player, "VnX_CreateGhostModeTimer", playeralpha, IVehiclealpha, timervalue);
        }

        public const int QUEST_VENOXRENTALS = 0;
        public const int QUEST_STADTHALLE = 1;
        public const int QUEST_PERSO = 2;
        public const int QUEST_AUTOSCHEIN = 3;
        public const int QUEST_ATM_EINZAHLEN = 4;
        public const int QUEST_GAS_SNACK = 5;
        public const int QUEST_AUTOKAUFEN = 6;
        public const int QUEST_GET100K = 7;
        public const int QUEST_GETWEAPONLICENSE = 8;
        public const int QUEST_GETADVANCEDRIFLE = 9;
        public const int QUEST_START_SHOPROB = 10;
        public const int QUEST_GET225 = 11;
        public static string GetQuestContainerText(Client player)
        {
            if (player.Reallife.Quests == QUEST_VENOXRENTALS)
            {
                return "Willkommen auf VenoX - V,<br>begib dich zu VenoX Rentals um<br>deine Erste Belohnung zu bekommen!";
            }
            else if (player.Reallife.Quests == QUEST_STADTHALLE)
            {
                return "Asylant? Kein Problem!<br>Begib dich zur Stadthalle!<br>Drücke E um die Stadthalle zu betreten.";
            }
            else if (player.Reallife.Quests == QUEST_PERSO)
            {
                return "Kauf dir einen Personalausweis!";
            }
            else if (player.Reallife.Quests == QUEST_AUTOSCHEIN)
            {
                return "Nie wieder Bus Fahren!<br>Bestehe die Führerschein Prüfung!";
            }
            else if (player.Reallife.Quests == QUEST_ATM_EINZAHLEN)
            {
                return "Sparkasse is on the Way!<br>Zahle 1000$ beim ATM ein!<br>Drücke E um einen Bankautomaten zu nutzen.";
            }
            else if (player.Reallife.Quests == QUEST_ATM_EINZAHLEN)
            {
                return "Sparkasse is on the Way!<br>Zahle 1000$ beim ATM ein!<br>Drücke E um einen Bankautomaten zu nutzen.";
            }
            else if (player.Reallife.Quests == QUEST_GAS_SNACK)
            {
                return "Du bist hungrig!<br>Kaufe dir einen Snack bei der Tankstelle!";
            }
            else if (player.Reallife.Quests == QUEST_AUTOKAUFEN)
            {
                return "One Car One Dream!<br>Kaufe dir dein erstes Auto!";
            }
            else if (player.Reallife.Quests == QUEST_GET100K)
            {
                return "Kauf dir einen Benzinkannister.";
            }
            else if (player.Reallife.Quests == QUEST_GETWEAPONLICENSE)
            {
                return "Waffen sind wichtig.....!!!<br>Besorge dir einen Waffenschein ( ab 3 H Verfügbar ).";
            }
            else if (player.Reallife.Quests == QUEST_GETADVANCEDRIFLE)
            {
                return "Ein Kampfgewehr? Not Bad...<br>Besorge dir eine Advanced Rifle.";
            }
            else if (player.Reallife.Quests == QUEST_START_SHOPROB)
            {
                return "Es wird Zeit etwas Geld zu verdienen...<br>Raube einen 24/7 Shop aus!";
            }
            else if (player.Reallife.Quests == QUEST_GET225)
            {
                return "Kauf einen Schneeball auf dem Weihnachtsmarkt!";
            }
            return "Es sind keine weiteren Quests derzeit vorhanden!";
        }

        public const int QUEST_MONEY_VENOXRENTALS = 1350;
        public const int QUEST_MONEY_STADTHALLE = 3500;
        public const int QUEST_MONEY_PERSO = 6535;
        public const int QUEST_MONEY_AUTOSCHEIN = 5000;
        public const int QUEST_MONEY_ATM_EINZAHLEN = 4000;
        public const int QUEST_MONEY_GAS_SNACK = 1000;
        public const int QUEST_MONEY_AUTOKAUFEN = 10000;
        public const int QUEST_MONEY_GET100K = 25000; //125K event Iggno
        public const int QUEST_MONEY_GETWEAPONLICENSE = 20000;
        public const int QUEST_MONEY_GETADVANCEDRIFLE = 15000;
        public const int QUEST_MONEY_START_SHOPROB = 4500;
        public const int QUEST_MONEY_GET225 = 10000; //125K event Iggno
        public static string GetQuestWinText(Client player)
        {
            if (player.Reallife.Quests == QUEST_VENOXRENTALS)
            {
                return "Belohnung : " + QUEST_MONEY_VENOXRENTALS + "$";
            }
            else if (player.Reallife.Quests == QUEST_STADTHALLE)
            {
                return "Belohnung : " + QUEST_MONEY_STADTHALLE + "$";
            }
            else if (player.Reallife.Quests == QUEST_PERSO)
            {
                return "Belohnung : " + QUEST_MONEY_PERSO + "$";
            }
            else if (player.Reallife.Quests == QUEST_AUTOSCHEIN)
            {
                return "Belohnung : " + QUEST_MONEY_AUTOSCHEIN + "$";
            }
            else if (player.Reallife.Quests == QUEST_ATM_EINZAHLEN)
            {
                return "<br>Belohnung : " + QUEST_MONEY_ATM_EINZAHLEN + "$";
            }
            else if (player.Reallife.Quests == QUEST_GAS_SNACK)
            {
                return "Belohnung : " + QUEST_MONEY_GAS_SNACK + "$";
            }
            else if (player.Reallife.Quests == QUEST_AUTOKAUFEN)
            {
                return "Belohnung : " + QUEST_MONEY_AUTOKAUFEN + "$";
            }
            else if (player.Reallife.Quests == QUEST_GET100K)
            {
                return "Belohnung : " + QUEST_MONEY_GET100K + "$";
            }
            else if (player.Reallife.Quests == QUEST_GETWEAPONLICENSE)
            {
                return "Belohnung : " + QUEST_MONEY_GETWEAPONLICENSE + "$";
            }
            else if (player.Reallife.Quests == QUEST_GETADVANCEDRIFLE)
            {
                return "Belohnung : " + QUEST_MONEY_GETADVANCEDRIFLE + "$";
            }
            else if (player.Reallife.Quests == QUEST_START_SHOPROB)
            {
                return "Belohnung : " + QUEST_MONEY_START_SHOPROB + "$";
            }
            else if (player.Reallife.Quests == QUEST_GET225)
            {
                return "Belohnung : " + QUEST_MONEY_GET225 + "$";
            }
            return "";
        }


        public static void UpdateQuestLVL(Client player, int QUESTDONE)
        {
            try
            {
                int playerquest = player.Reallife.Quests;
                if (playerquest < QUESTDONE) { return; }


                if (QUESTDONE == QUEST_VENOXRENTALS)
                {
                    if (playerquest == QUEST_VENOXRENTALS)
                    {
                        int playerMoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney + QUEST_MONEY_VENOXRENTALS);
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, 1);
                    }
                }
                else if (QUESTDONE == QUEST_STADTHALLE)
                {
                    if (playerquest == QUEST_STADTHALLE)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_STADTHALLE);
                    }
                }

                else if (QUESTDONE == QUEST_PERSO)
                {
                    if (playerquest == QUEST_PERSO)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_PERSO);
                    }
                }
                else if (QUESTDONE == QUEST_AUTOSCHEIN)
                {
                    if (playerquest == QUEST_AUTOSCHEIN)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_AUTOSCHEIN);
                    }
                }
                else if (QUESTDONE == QUEST_ATM_EINZAHLEN)
                {
                    if (playerquest == QUEST_ATM_EINZAHLEN)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_ATM_EINZAHLEN);
                    }
                }
                else if (QUESTDONE == QUEST_GAS_SNACK)
                {
                    if (playerquest == QUEST_GAS_SNACK)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GAS_SNACK);
                    }
                }
                else if (QUESTDONE == QUEST_AUTOKAUFEN)
                {
                    if (playerquest == QUEST_AUTOKAUFEN)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_AUTOKAUFEN);
                    }
                }
                else if (QUESTDONE == QUEST_GET100K)
                {
                    if (playerquest == QUEST_GET100K)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GET100K);
                    }
                }
                else if (QUESTDONE == QUEST_GETWEAPONLICENSE)
                {
                    if (playerquest == QUEST_GETWEAPONLICENSE)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GETWEAPONLICENSE);
                    }
                }
                else if (QUESTDONE == QUEST_GETADVANCEDRIFLE)
                {
                    if (playerquest == QUEST_GETADVANCEDRIFLE)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GETADVANCEDRIFLE);
                    }
                }
                else if (QUESTDONE == QUEST_START_SHOPROB)
                {
                    if (playerquest == QUEST_START_SHOPROB)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_START_SHOPROB);
                    }
                }
                else if (QUESTDONE == QUEST_GET225)
                {
                    if (playerquest == QUEST_GET225)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.Reallife.Quests + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GET225);
                    }
                }
            }
            catch { }
        }


        [Command("resethud")]
        public static void ResetHUD(Client player)
        {
            player.vnxSetStreamSharedElementData("HideHUD", 0);
        }


        //[AltV.Net.ClientEvent("onIPlayerClicked")]
        /*public static void onIPlayerClicked(PlayerModel player, Entity objekt)
        {
            player.SendTranslatedChatMessage("Du hast auf ein : " + objekt + " geklickt! ");
        }

    */
        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            int cevent = random.Next(min, max);
            return cevent;
        }


        [Command("me")]
        public static void SendMessageNearPlayers(Client player, string text)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.ReallifePlayers.ToList())
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

        public static void SpectatePlayer(Client player, string target_name, int einsfürfalse)
        {
            // Alt.Server.TriggerClientEvent(player,"VnX_Start_S", Target, einsfürfalse);
        }

        //[AltV.Net.ClientEvent("CreateTypingEffect")]
        public static void CreateTypingEffect(Client player, bool state)
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

        public static void ResetDiscordData(Client player)
        {
            if (Allround.isStateFaction(player))
            {
                if (player.Reallife.Faction == Constants.FACTION_LSPD)
                {
                    Alt.Server.TriggerClientEvent(player, "discord_update", "Auf Streife [L.S.P.D]", "VenoX - Reallife");
                }
                else if (player.Reallife.Faction == Constants.FACTION_FBI)
                {
                    Alt.Server.TriggerClientEvent(player, "discord_update", "Auf Streife [F.I.B]", "VenoX - Reallife");
                }
            }
            else
            {
                Alt.Server.TriggerClientEvent(player, "discord_update", "Unterwegs auf VenoX...", "VenoX - Reallife");
            }
        }


        //[AltV.Net.ClientEvent("VnX_PutPlayerInRandomDim")]
        public static void PutPlayerInRandomDim(Client player)
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


        public static void SavePlayerDatas(Client player)
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
                        if (Vehicle.Testing != true && Vehicle.Faction == 0 && Vehicle.NotSave != false && Vehicle.Dimension == 0)
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
