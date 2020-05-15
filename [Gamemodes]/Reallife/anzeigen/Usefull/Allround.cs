using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
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
            player.Emit("UpdateStars", (int)player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"));
        }
        public static void OnFactionChange(Client player)
        {
            player.Emit("UpdateFaction", Faction.GetPlayerFactionName((int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION)), Faction.GetPlayerFactionRank(player), (int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
        }

        public static void CreateCarGhostMode(Client player, int playeralpha, int IVehiclealpha, int timervalue)
        {
            player.Emit("VnX_CreateGhostModeTimer", playeralpha, IVehiclealpha, timervalue);
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
            if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_VENOXRENTALS)
            {
                return "Willkommen auf VenoX - V,<br>begib dich zu VenoX Rentals um<br>deine Erste Belohnung zu bekommen!";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_STADTHALLE)
            {
                return "Asylant? Kein Problem!<br>Begib dich zur Stadthalle!<br>Drücke E um die Stadthalle zu betreten.";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_PERSO)
            {
                return "Kauf dir einen Personalausweis!";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_AUTOSCHEIN)
            {
                return "Nie wieder Bus Fahren!<br>Bestehe die Führerschein Prüfung!";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_ATM_EINZAHLEN)
            {
                return "Sparkasse is on the Way!<br>Zahle 1000$ beim ATM ein!<br>Drücke E um einen Bankautomaten zu nutzen.";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_ATM_EINZAHLEN)
            {
                return "Sparkasse is on the Way!<br>Zahle 1000$ beim ATM ein!<br>Drücke E um einen Bankautomaten zu nutzen.";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GAS_SNACK)
            {
                return "Du bist hungrig!<br>Kaufe dir einen Snack bei der Tankstelle!";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_AUTOKAUFEN)
            {
                return "One Car One Dream!<br>Kaufe dir dein erstes Auto!";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET100K)
            {
                return "Kauf dir einen Benzinkannister.";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GETWEAPONLICENSE)
            {
                return "Waffen sind wichtig.....!!!<br>Besorge dir einen Waffenschein ( ab 3 H Verfügbar ).";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GETADVANCEDRIFLE)
            {
                return "Ein Kampfgewehr? Not Bad...<br>Besorge dir eine Advanced Rifle.";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_START_SHOPROB)
            {
                return "Es wird Zeit etwas Geld zu verdienen...<br>Raube einen 24/7 Shop aus!";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET225)
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
            if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_VENOXRENTALS)
            {
                return "Belohnung : " + QUEST_MONEY_VENOXRENTALS + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_STADTHALLE)
            {
                return "Belohnung : " + QUEST_MONEY_STADTHALLE + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_PERSO)
            {
                return "Belohnung : " + QUEST_MONEY_PERSO + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_AUTOSCHEIN)
            {
                return "Belohnung : " + QUEST_MONEY_AUTOSCHEIN + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_ATM_EINZAHLEN)
            {
                return "<br>Belohnung : " + QUEST_MONEY_ATM_EINZAHLEN + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GAS_SNACK)
            {
                return "Belohnung : " + QUEST_MONEY_GAS_SNACK + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_AUTOKAUFEN)
            {
                return "Belohnung : " + QUEST_MONEY_AUTOKAUFEN + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET100K)
            {
                return "Belohnung : " + QUEST_MONEY_GET100K + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GETWEAPONLICENSE)
            {
                return "Belohnung : " + QUEST_MONEY_GETWEAPONLICENSE + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GETADVANCEDRIFLE)
            {
                return "Belohnung : " + QUEST_MONEY_GETADVANCEDRIFLE + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_START_SHOPROB)
            {
                return "Belohnung : " + QUEST_MONEY_START_SHOPROB + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET225)
            {
                return "Belohnung : " + QUEST_MONEY_GET225 + "$";
            }
            return "";
        }


        public static void UpdateQuestLVL(Client player, int QUESTDONE)
        {
            try
            {
                int playerquest = player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS);
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
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_STADTHALLE);
                    }
                }

                else if (QUESTDONE == QUEST_PERSO)
                {
                    if (playerquest == QUEST_PERSO)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_PERSO);
                    }
                }
                else if (QUESTDONE == QUEST_AUTOSCHEIN)
                {
                    if (playerquest == QUEST_AUTOSCHEIN)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_AUTOSCHEIN);
                    }
                }
                else if (QUESTDONE == QUEST_ATM_EINZAHLEN)
                {
                    if (playerquest == QUEST_ATM_EINZAHLEN)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_ATM_EINZAHLEN);
                    }
                }
                else if (QUESTDONE == QUEST_GAS_SNACK)
                {
                    if (playerquest == QUEST_GAS_SNACK)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GAS_SNACK);
                    }
                }
                else if (QUESTDONE == QUEST_AUTOKAUFEN)
                {
                    if (playerquest == QUEST_AUTOKAUFEN)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_AUTOKAUFEN);
                    }
                }
                else if (QUESTDONE == QUEST_GET100K)
                {
                    if (playerquest == QUEST_GET100K)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GET100K);
                    }
                }
                else if (QUESTDONE == QUEST_GETWEAPONLICENSE)
                {
                    if (playerquest == QUEST_GETWEAPONLICENSE)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GETWEAPONLICENSE);
                    }
                }
                else if (QUESTDONE == QUEST_GETADVANCEDRIFLE)
                {
                    if (playerquest == QUEST_GETADVANCEDRIFLE)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GETADVANCEDRIFLE);
                    }
                }
                else if (QUESTDONE == QUEST_START_SHOPROB)
                {
                    if (playerquest == QUEST_START_SHOPROB)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_START_SHOPROB);
                    }
                }
                else if (QUESTDONE == QUEST_GET225)
                {
                    if (playerquest == QUEST_GET225)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + QUEST_MONEY_GET225);
                    }
                }
            }
            catch { }
        }

        [Command("updatehud")]
        public static void UpdateHUD(Client player)
        {
            try
            {
                string name = string.Empty;
                int oldquest = 0;
                if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) - 1 == -1)
                {
                    oldquest = 0;
                }
                else
                {
                    oldquest = player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) - 1;
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
                {
                    name = "[VnX]" + player.GetVnXName();
                }
                else
                {
                    name = player.GetVnXName();
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD) == 0)
                {
                    player.Emit("UpdateHealth", player.Armor, player.Health);
                }
                else
                {
                    Console.WriteLine("HUD : " + player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD));
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
                {
                    player.Emit("UpdateHUD", name, "Zivilist", player.vnxGetElementData<string>(VenoXV.Globals.EntityData.PLAYER_STATUS), player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY).ToString("#,##0") + " $ ", player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"), Constants.FACTION_NONE, player.vnxGetElementData<string>("settings_quest"), oldquest, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS), GetQuestContainerText(player), GetQuestWinText(player));
                    return;
                }
                player.Emit("UpdateHUD", name, Faction.GetPlayerFactionName((int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION)), Faction.GetPlayerFactionRank(player), player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY).ToString("#,##0") + " $ ", player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"), player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), player.vnxGetElementData<string>("settings_quest"), oldquest, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS), GetQuestContainerText(player), GetQuestWinText(player));

            }
            catch { }
        }




        [Command("resethud")]
        public static void ResetHUD(Client player)
        {
            player.vnxSetStreamSharedElementData("HideHUD", 0);
            UpdateHUD(player);
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
                foreach (Client players in Alt.GetAllPlayers())
                {
                    if (player.Position.Distance(players.Position) < 5)
                    {
                        players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 150) + player.GetVnXName() + " : " + text);
                    }
                }
                //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150,0,150) +player.GetVnXName() + " : " + text);
                vnx_stored_files.logfile.WriteLogs("chat", "[ME][" + player.GetVnXName() + "] : " + text);
            }
            catch { }
        }

        public static void SpectatePlayer(Client player, string target_name, int einsfürfalse)
        {
            // player.Emit("VnX_Start_S", Target, einsfürfalse);
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
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_POLICE)
                {
                    player.Emit("discord_update", "Auf Streife [L.S.P.D]", "VenoX - Reallife");
                }
                else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_FBI)
                {
                    player.Emit("discord_update", "Auf Streife [F.I.B]", "VenoX - Reallife");
                }
            }
            else
            {
                player.Emit("discord_update", "Unterwegs auf VenoX...", "VenoX - Reallife");
            }
        }


        //[AltV.Net.ClientEvent("VnX_PutPlayerInRandomDim")]
        public static void PutPlayerInRandomDim(Client player)
        {
            try
            {
                Random random = new Random();
                int cevent = random.Next(1, 9999999);
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
                if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) > 0)
                {
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) - 1);

                    int UID = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                    int PRISON_TIME = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME);
                    string PRISON_STRING = player.vnxGetElementData<string>(VenoXV.Globals.EntityData.PLAYER_PRISON_GRUND);
                    string PRISON_REASON = Database.GetCharakterPrisonReason(player.GetVnXName());
                    string PRISON_FROMADMIN = Database.GetCharakterPrisonAdminBy(player.GetVnXName());

                    DateTime PRISON_DATETIME = Database.GetCharakterPrisonErstelltAm(player.GetVnXName());

                    Database.UpdatePlayerPrisonTime(UID, PRISON_TIME, PRISON_REASON, PRISON_FROMADMIN, PRISON_DATETIME);

                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) == 0)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
                        Spawn.spawnplayer_on_spawnpoint(player);
                        Database.RemoveOldPrison(player.GetVnXName());
                    }
                }
            }
            catch { }
        }

        public static void SaveIVehicleDatas()
        {
            try
            {
                List<VehicleModel> IVehicleList = new List<VehicleModel>();

                foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                {
                    if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) != null)
                    {
                        if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_TESTING) != true && Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION) == 0 && Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED) != true && Vehicle.Dimension == 0)
                        {
                            VehicleModel VehicleModel = new VehicleModel();
                            VehicleModel.id = Convert.ToInt32(Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID));
                            VehicleModel.model = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_MODEL);
                            VehicleModel.position = Vehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                            VehicleModel.rotation = Vehicle.vnxGetElementData<Rotation>(VenoXV.Globals.EntityData.VEHICLE_ROTATION);
                            VehicleModel.dimension = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_DIMENSION);
                            VehicleModel.RgbaType = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_Rgba_TYPE);
                            VehicleModel.firstRgba = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_FIRST_Rgba);
                            VehicleModel.secondRgba = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_SECOND_Rgba);
                            VehicleModel.pearlescent = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_PEARLESCENT_Rgba);
                            VehicleModel.faction = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION);
                            VehicleModel.plate = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_PLATE);
                            VehicleModel.owner = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                            VehicleModel.price = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_PRICE);
                            VehicleModel.parking = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_PARKING);
                            VehicleModel.parked = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_PARKED);
                            VehicleModel.gas = Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                            VehicleModel.kms = Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_KMS);

                            // Add IVehicle into the list
                            IVehicleList.Add(VehicleModel);
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
