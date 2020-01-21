using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.anzeigen.Usefull
{
    public class VnX : IScript
    {
        public static void RemoveAllWeapons(IPlayer player)
        {
            try
            {
                player.RemoveAllWeapons();
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                foreach(ItemModel waffen in Main.itemList.ToList())
                {
                    if(waffen.ITEM_ART == Constants.ITEM_ART_WAFFE && waffen.ownerIdentifier == playerId)
                    {
                        Main.itemList.Remove(waffen);
                    }
                }
                Database.RemoveAllItemsByArt(playerId, Constants.ITEM_ART_WAFFE);
                Database.RemoveAllItemsByArt(playerId, Constants.ITEM_ART_MAGAZIN);
            }
            catch
            {
            }
        }

        public static void RemoveAllBadGWWeapons(IPlayer player)
        {
            try
            {
                player.RemoveAllWeapons();

                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);

                ItemModel Switchblade = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SWITCHBLADE);
                ItemModel Nightstick = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_NIGHTSTICK);
                ItemModel Baseball = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_BASEBALL);
                ItemModel Tazer = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_TAZER);

                ItemModel Shotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);

                ItemModel Sniperrifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNIPERRIFLE);

                if (Switchblade != null)
                {
                    Database.RemoveItem(Switchblade.id);
                    Main.itemList.Remove(Switchblade);
                }

                if (Baseball != null)
                {
                    Database.RemoveItem(Baseball.id);
                    Main.itemList.Remove(Baseball);
                }

                if (Nightstick != null)
                {
                    Database.RemoveItem(Nightstick.id);
                    Main.itemList.Remove(Nightstick);
                }

                if (Tazer != null)
                {
                    Database.RemoveItem(Tazer.id);
                    Main.itemList.Remove(Tazer);
                }

                if (Shotgun != null)
                {
                    Database.RemoveItem(Shotgun.id);
                    Main.itemList.Remove(Shotgun);
                }

                if (Sniperrifle != null)
                {
                    Database.RemoveItem(Sniperrifle.id);
                    Main.itemList.Remove(Sniperrifle);
                }

                weapons.Weapons.GivePlayerWeaponItems(player);
            }
            catch
            {
            }
        }

        public static void onWantedChange(IPlayer player)
        {
            player.Emit("UpdateStars", (int)player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"));
        }
        public static void OnFactionChange(IPlayer player)
        {
            player.Emit("UpdateFaction", Faction.GetPlayerFactionName((int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION)), Faction.GetPlayerFactionRank(player), (int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
        }

        public static void CreateCarGhostMode(IPlayer player, int playeralpha, int IVehiclealpha, int timervalue)
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
        public static string GetQuestContainerText(IPlayer player)
        {
            if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_VENOXRENTALS)
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
            else if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET100K)
            {
                return "Kauf dir einen Benzinkannister.";
            }
            else if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GETWEAPONLICENSE)
            {
                return "Waffen sind wichtig.....!!!<br>Besorge dir einen Waffenschein ( ab 3 H Verfügbar ).";
            }
            else if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GETADVANCEDRIFLE)
            {
                return "Ein Kampfgewehr? Not Bad...<br>Besorge dir eine Advanced Rifle.";
            }            
            else if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_START_SHOPROB)
            {
                return "Es wird Zeit etwas Geld zu verdienen...<br>Raube einen 24/7 Shop aus!";
            }            
            else if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET225)
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
        public static string GetQuestWinText(IPlayer player)
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
                return "Belohnung : "+ QUEST_MONEY_AUTOSCHEIN + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_ATM_EINZAHLEN)
            {
                return "<br>Belohnung : "+ QUEST_MONEY_ATM_EINZAHLEN + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GAS_SNACK)
            {
                return "Belohnung : "+ QUEST_MONEY_GAS_SNACK + "$";
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_AUTOKAUFEN)
            {
                return "Belohnung : "+ QUEST_MONEY_AUTOKAUFEN + "$";
            }
            else if(player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) == QUEST_GET100K)
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


        public static void UpdateQuestLVL(IPlayer player,  int QUESTDONE)
        {
            try
            {
                int playerquest = player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS);
                if(playerquest < QUESTDONE) { return; }


                if (QUESTDONE == QUEST_VENOXRENTALS)
                {
                    if (playerquest == QUEST_VENOXRENTALS)
                    {
                        int playerMoney = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, playerMoney + QUEST_MONEY_VENOXRENTALS);
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, 1);
                    }
                }
                else if (QUESTDONE == QUEST_STADTHALLE)
                {
                    if (playerquest == QUEST_STADTHALLE)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_STADTHALLE);
                    }
                }

                else if (QUESTDONE == QUEST_PERSO)
                {
                    if (playerquest == QUEST_PERSO)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_PERSO);
                    }
                }
                else if (QUESTDONE == QUEST_AUTOSCHEIN)
                {
                    if (playerquest == QUEST_AUTOSCHEIN)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_AUTOSCHEIN);
                    }
                }
                else if (QUESTDONE == QUEST_ATM_EINZAHLEN)
                {
                    if (playerquest == QUEST_ATM_EINZAHLEN)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_ATM_EINZAHLEN);
                    }
                }
                else if (QUESTDONE == QUEST_GAS_SNACK)
                {
                    if (playerquest == QUEST_GAS_SNACK)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_GAS_SNACK);
                    }
                }
                else if (QUESTDONE == QUEST_AUTOKAUFEN)
                {
                    if (playerquest == QUEST_AUTOKAUFEN)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_AUTOKAUFEN);
                    }
                }
                else if (QUESTDONE == QUEST_GET100K)
                {
                    if (playerquest == QUEST_GET100K)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_GET100K);
                    }
                }
                else if (QUESTDONE == QUEST_GETWEAPONLICENSE)
                {
                    if (playerquest == QUEST_GETWEAPONLICENSE)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_GETWEAPONLICENSE);
                    }
                }
                else if (QUESTDONE == QUEST_GETADVANCEDRIFLE)
                {
                    if (playerquest == QUEST_GETADVANCEDRIFLE)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_GETADVANCEDRIFLE);
                    }
                }                
                else if (QUESTDONE == QUEST_START_SHOPROB)
                {
                    if (playerquest == QUEST_START_SHOPROB)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_START_SHOPROB);
                    }
                }                
                else if (QUESTDONE == QUEST_GET225)
                {
                    if (playerquest == QUEST_GET225)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS) + 1);
                        Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + QUEST_MONEY_GET225);
                    }
                }
            }
            catch { }
        }

        [Command("updatehud")]
        public static void UpdateHUD(IPlayer player)
        {
            try {
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
                    name = "[VnX]" +player.Name;
                }
                else
                {
                    name =player.Name;
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD) == 0)
                {
                    player.Emit("UpdateHealth", player.Armor, player.Health);
                }
                else
                {
                    Alt.Log("HUD : " + player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD));
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
                {
                    player.Emit("UpdateHUD", name, "Zivilist", player.vnxGetElementData<string>(EntityData.PLAYER_STATUS), player.vnxGetElementData<int>(EntityData.PLAYER_MONEY).ToString("#,##0") + " $ ", player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"), Constants.FACTION_NONE, player.vnxGetElementData<string>("settings_quest"), oldquest, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS), GetQuestContainerText(player), GetQuestWinText(player));
                    return;
                }
                player.Emit("UpdateHUD", name, Faction.GetPlayerFactionName((int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION)), Faction.GetPlayerFactionRank(player), player.vnxGetElementData<int>(EntityData.PLAYER_MONEY).ToString("#,##0") + " $ ", player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS), player.vnxGetSharedData<int>("HideHUD"), player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), player.vnxGetElementData<string>("settings_quest"), oldquest, player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS), GetQuestContainerText(player), GetQuestWinText(player));
                
            }
            catch { }
        }




        [Command("resethud")]
        public static void ResetHUD(IPlayer player)
        {
            Core.VnX.vnxSetSharedData(player, "HideHUD", 0);
            UpdateHUD(player);
        }


        //[AltV.Net.ClientEvent("onIPlayerClicked")]
        public static void onIPlayerClicked(IPlayer player, Entity objekt)
        {
            player.SendChatMessage("Du hast auf ein : " + objekt + " geklickt! ");
        }


        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            int cevent = random.Next(min, max);
            return cevent;
        }


        [Command("me")]
        public static void SendMessageNearPlayers(IPlayer player, string text)
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (player.Position.Distance(players.Position) < 5)
                    {
                        players.SendChatMessage( "!{150,0,150}" +player.Name + " : " + text);
                    }
                }
                //player.SendChatMessage( "!{150,0,150}" +player.Name + " : " + text);
                vnx_stored_files.logfile.WriteLogs("chat", "[ME][" +player.Name + "] : " + text);
            }
            catch { }
        }

        public static void SpectatePlayer(IPlayer player, IPlayer Target, int einsfürfalse)
        {
            player.Emit("VnX_Start_S", Target, einsfürfalse);
        }

        //[AltV.Net.ClientEvent("CreateTypingEffect")]
        public  static void CreateTypingEffect(IPlayer player, bool state)
        {
            if (state == true)
            {
                player.SetSyncedMetaData("SocialState_NAMETAG", "Schreibt...");
            }
            else
            {
                player.SetSyncedMetaData("SocialState_NAMETAG", player.vnxGetSharedData<string>(EntityData.PLAYER_STATUS));
            }
        }

        public static void ResetDiscordData(IPlayer player)
        {
            if(Allround.isStateFaction(player))
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
        public static void PutPlayerInRandomDim(IPlayer player)
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


        public static void SavePlayerDatas(IPlayer player)
        {
            try
            {
                PlayerModel character = new PlayerModel();

                character.position = player.Position;
                character.rotation = player.Rotation;
                character.health = player.Health;
                character.armor = player.Armor;
                character.id = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                character.phone = player.vnxGetElementData<int>(EntityData.PLAYER_PHONE);

                character.killed = player.vnxGetElementData<int>(EntityData.PLAYER_KILLED);
                character.faction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                character.zivizeit = player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT);
                character.job = player.vnxGetElementData<string>(EntityData.PLAYER_JOB);
                character.LIEFERJOB_LEVEL = player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL);
                character.AIRPORTJOB_LEVEL = player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL);
                character.BUSJOB_LEVEL = player.vnxGetElementData<int>(EntityData.PLAYER_BUSJOB_LEVEL);
                character.rank = player.vnxGetElementData<int>(EntityData.PLAYER_RANK);
                character.houseRent = player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE);
                character.houseEntered = player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED);
                character.businessEntered = player.vnxGetElementData<int>(EntityData.PLAYER_BUSINESS_ENTERED);


                character.Personalausweis = player.vnxGetElementData<int>(EntityData.PLAYER_PERSONALAUSWEIS);
                character.Autofuehrerschein = player.vnxGetElementData<int>(EntityData.PLAYER_FÜHRERSCHEIN);
                character.Motorradfuehrerschein = player.vnxGetElementData<int>(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN);
                character.LKWfuehrerschein = player.vnxGetElementData<int>(EntityData.PLAYER_LKW_FÜHRERSCHEIN);
                character.Helikopterfuehrerschein = player.vnxGetElementData<int>(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN);
                character.FlugscheinKlasseA = player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN);
                character.FlugscheinKlasseB = player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN);
                character.Motorbootschein = player.vnxGetElementData<int>(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN);
                character.Angelschein = player.vnxGetElementData<int>(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN);
                character.Waffenschein = player.vnxGetElementData<int>(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN);
                character.adventskalender = player.vnxGetElementData<int>(EntityData.PLAYER_ADVENTSKALENEDER);

                character.played = player.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                character.spawn = player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT);
                character.money = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);
                character.bank = player.vnxGetElementData<int>(EntityData.PLAYER_BANK);
                character.quests = player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS);
                character.wanteds = player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS);
                character.knastzeit = player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT);
                character.kaution = player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION);
                character.REALLIFE_HUD = player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD);
                character.atm = player.vnxGetElementData<string>("settings_atm");
                character.haus = player.vnxGetElementData<string>("settings_haus");
                character.tacho = player.vnxGetElementData<string>("settings_tacho");
                character.quest_anzeigen = player.vnxGetElementData<string>("settings_quest");
                character.reporter = player.vnxGetElementData<string>("settings_reporter");
                character.globalchat = player.vnxGetElementData<string>("settings_globalchat");
                character.SocialState = player.vnxGetElementData<string>(EntityData.PLAYER_STATUS);
                // Tactics 
                character.tactic_kills = player.vnxGetElementData<int>(EntityData.PLAYER_TACTIC_KILLS);
                character.tactic_tode = player.vnxGetElementData<int>(EntityData.PLAYER_TACTIC_TODE);

                // Zombie
                character.zombie_tode = player.vnxGetElementData<int>(EntityData.PLAYER_ZOMBIE_TODE);
                character.zombie_kills = player.vnxGetElementData<int>(EntityData.PLAYER_ZOMBIE_KILLS);
                character.zombie_player_kills = player.vnxGetElementData<int>(EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED);


                Database.SaveCharacterInformation(character);
                if (player.vnxGetElementData<int>(EntityData.PLAYER_PRISON_TIME) > 0)
                {
                    player.SetData(EntityData.PLAYER_PRISON_TIME, player.vnxGetElementData<int>(EntityData.PLAYER_PRISON_TIME) - 1);

                    int UID = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                    int PRISON_TIME = player.vnxGetElementData<int>(EntityData.PLAYER_PRISON_TIME);
                    string PRISON_STRING = player.vnxGetElementData<string>(EntityData.PLAYER_PRISON_GRUND);
                    string PRISON_REASON = Database.GetCharakterPrisonReason(player.Name);
                    string PRISON_FROMADMIN = Database.GetCharakterPrisonAdminBy(player.Name);

                    DateTime PRISON_DATETIME = Database.GetCharakterPrisonErstelltAm(player.Name);

                    Database.UpdatePlayerPrisonTime(UID, PRISON_TIME, PRISON_REASON, PRISON_FROMADMIN, PRISON_DATETIME);

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_PRISON_TIME) == 0)
                    {
                        player.SendChatMessage( "!{200,0,0}Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
                        Spawn.spawnplayer_on_spawnpoint(player);
                        Database.RemoveOldPrison(player.Name);
                    }
                }
            }
            catch{}
        }

        public static void SaveIVehicleDatas()
        {
            try
            {
                List<VehicleModel> IVehicleList = new List<VehicleModel>();

                foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                {
                    if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) != null)
                    {
                        if (Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_TESTING) != true && Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION) == 0 && Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_NOT_SAVED) != true && Vehicle.Dimension == 0)
                        {
                            VehicleModel VehicleModel = new VehicleModel();
                            VehicleModel.id = Convert.ToInt32(Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                            VehicleModel.model = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_MODEL);
                            VehicleModel.position = Vehicle.vnxGetElementData<Position>(EntityData.VEHICLE_OWNER);
                            VehicleModel.rotation = Vehicle.vnxGetElementData<Rotation>(EntityData.VEHICLE_ROTATION);
                            VehicleModel.dimension = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_DIMENSION);
                            VehicleModel.RgbaType = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_Rgba_TYPE);
                            VehicleModel.firstRgba = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_FIRST_Rgba);
                            VehicleModel.secondRgba = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_SECOND_Rgba);
                            VehicleModel.pearlescent = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_PEARLESCENT_Rgba);
                            VehicleModel.faction = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION);
                            VehicleModel.plate = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_PLATE);
                            VehicleModel.owner = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER);
                            VehicleModel.price = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_PRICE);
                            VehicleModel.parking = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_PARKING);
                            VehicleModel.parked = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_PARKED);
                            VehicleModel.gas = Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_GAS);
                            VehicleModel.kms = Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_KMS);

                            // Add IVehicle into the list
                            IVehicleList.Add(VehicleModel);
                        }
                    }
                }
                Database.SaveAllIVehicles(IVehicleList);
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION SaveIVehicleDatas] " + ex.Message);
                Alt.Log("[EXCEPTION SaveIVehicleDatas] " + ex.StackTrace);
            }
        }



        /// <param name="player">The Owner of the IVehicle.</param>
        /// <param name="vehName">IVehicle Hash ( See GTA Network Wiki )</param>
        /// <param name="coord">Position Where the Car should spawn</param>
        /// <param name="rot">Simple Float of Rotation</param>
        /// <param name="primaryC">Primary Rgba of the IVehicle</param>
        /// <param name="secondC">Secondary Rgba of the IVehicle</param>
        /// <param name="WarpPlayerIntoVeh">Should the Owner warped into the IVehicle?</param>
        /// <param name="isRentedIVehicle">Is it a Rented IVehicle?</param>
        /// <param name="Job">IVehicle Job?</param>
        /// <param name="NumberplateText">Numberlpate of the IVehicle</param>
        public static void CreateRandomIVehicle(IPlayer player, AltV.Net.Enums.VehicleModel vehName, Position coord, float rot, Rgba primaryC, Rgba secondC, bool WarpPlayerIntoVeh, bool isRentedIVehicle, string Job, string NumberplateText)
        {
            try
            {
                
                IVehicle CreatedVehicle = Alt.CreateVehicle((uint)vehName.GetHashCode(), coord, new Rotation(0, 0, (float)rot));
                if (WarpPlayerIntoVeh == true) 
                { 
                    //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, CreatedIVehicle, -1); 
                }

                CreatedVehicle.PrimaryColorRgb = new Rgba(primaryC.R, primaryC.G, primaryC.B, 255);
                CreatedVehicle.SecondaryColorRgb = new Rgba(secondC.R, secondC.G, secondC.B, 255);
                // EntityData Load & Save
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_ID, 9999);
                Core.VnX.IVehicleSetSharedStringData(CreatedVehicle, EntityData.VEHICLE_MODEL, CreatedVehicle.Model.ToString());
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_FACTION, 0);
                Core.VnX.IVehicleSetSharedStringData(CreatedVehicle, EntityData.VEHICLE_PLATE, "VenoX");
                Core.VnX.IVehicleSetSharedStringData(CreatedVehicle, EntityData.VEHICLE_OWNER,player.Name);
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_Rgba_TYPE, Constants.VEHICLE_Rgba_TYPE_CUSTOM);
                Core.VnX.IVehicleSetSharedStringData(CreatedVehicle, EntityData.VEHICLE_FIRST_Rgba, primaryC.R + "," + primaryC.G + "," + primaryC.B);
                Core.VnX.IVehicleSetSharedStringData(CreatedVehicle, EntityData.VEHICLE_SECOND_Rgba, secondC.R + "," + secondC.G + "," + secondC.B);
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_PEARLESCENT_Rgba, 0);
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_PRICE, 0);
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_PARKING, 0);
                Core.VnX.IVehicleSetSharedINTData(CreatedVehicle, EntityData.VEHICLE_PARKED, 0);
                Core.VnX.IVehicleSetSharedBoolData(CreatedVehicle, EntityData.VEHICLE_RENTED, isRentedIVehicle);
                Core.VnX.IVehicleSetSharedStringData(CreatedVehicle, EntityData.VEHICLE_JOB, Job);
                
                // KM & Gas load and Safe.
                Core.VnX.IVehiclevnxSetSharedData(CreatedVehicle, "kms", 0);
                Core.VnX.IVehiclevnxSetSharedData(CreatedVehicle, "gas", 100);

                Core.VnX.IVehicleSetSharedBoolData(CreatedVehicle, EntityData.VEHICLE_NOT_SAVED, true);
                CreatedVehicle.NumberplateText = NumberplateText;
                CreatedVehicle.EngineOn = true;
            }
            catch { }
        }
    }
}
