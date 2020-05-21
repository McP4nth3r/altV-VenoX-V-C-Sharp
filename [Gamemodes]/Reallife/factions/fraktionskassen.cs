using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._RootCore_.Database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions
{
    public class fraktionskassen : IScript
    {
        public static void OnResourceStart()
        {
            /*
            IColShape fkassencolLSPD = Alt.CreateColShapeSphere(new Position(452.5833f, -982.6306f, 30.68959f), 1);
            fkassencolLSPD.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_POLICE);
            //////////////////////////////      
            IColShape fkassencolLCN = Alt.CreateColShapeSphere(new Position(259.6794f, -1004.043f, 1, 0.3f, Constants.FACTION_COSANOSTRA));
            fkassencolLCN.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_COSANOSTRA);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(259.6794f, -1004.043f, -99f), 20.0f, 0.75f, 4, new Rgba(40, 40, 40), true, fkassencolLCN.Dimension);
            //////////////////////////////      
            ///
            /// //////////////////////////////      
            IColShape fkassencolYAKUZA = Alt.CreateColShapeSphere(new Position(345.3037f, -995.8774f, 1, 0.3f, Constants.FACTION_YAKUZA));
            fkassencolYAKUZA.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_YAKUZA);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(345.3037f, -995.8774f, -99.19618f), 20.0f, 0.75f, 4, new Rgba(200, 0, 0), true, fkassencolYAKUZA.Dimension);
            //////////////////////////////
            ///

            IColShape fkassencolBallas = Alt.CreateColShapeSphere(new Position(259.6794f, -1004.043f, 1, 0.3f, Constants.FACTION_BALLAS));
            fkassencolBallas.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_BALLAS);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(259.6794f, -1004.043f, -99f), 20.0f, 0.75f, 4, new Rgba(138, 43, 226), true, fkassencolBallas.Dimension);
            //////////////////////////////
            IColShape fkassencolCompton = Alt.CreateColShapeSphere(new Position(259.6794f, -1004.043f, 1, 0.3f, Constants.FACTION_GROVE));
            fkassencolCompton.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_GROVE);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(259.6794f, -1004.043f, -99f), 20.0f, 0.75f, 4, new Rgba(0, 152, 0), true, fkassencolCompton.Dimension);
            //////////////////////////////      
            ///
            ////////////////////////////////
            IColShape fkassencolMS13 = Alt.CreateColShapeSphere(new Position(-1287.002f, 456.257f, 1, 0.3f, Constants.FACTION_MS13));
            fkassencolMS13.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_MS13);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(-1287.002f, 456.257f, 90.29469f), 20.0f, 0.75f, 4, new Rgba(175, 175, 0), true, fkassencolMS13.Dimension);
            //////////////////////////////            
            /////////////////////////////////// 
            IColShape fkassencolSAMCRO = Alt.CreateColShapeSphere(new Position(971.9218f, -98.68291f, 1, 0.3f, Constants.FACTION_SAMCRO));
            fkassencolSAMCRO.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_SAMCRO);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(971.9218f, -98.68291f, 74.84641f), 20.0f, 0.75f, 4, new Rgba(175, 175, 0), true, fkassencolSAMCRO.Dimension);
            //////////////////////////////     */


            ///////////////////////////////////
            IColShape fkassencolNEWS = Alt.CreateColShapeSphere(new Position(-537.0566f, -886.5463f, 25.20651f), 2);
            fkassencolNEWS.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_NEWS);
            Core.RageAPI.CreateTextLabel("News - Kasse", new Position(-537.0566f, -886.5463f, 25.20651f), 20.0f, 0.75f, 4, new int[] { 200, 200, 0, 255 });
            //////////////////////////////      
            //////////////////////////////////////
            IColShape fskincolNEWS = Alt.CreateColShapeSphere(new Position(-575.1335f, -939.9796f, 23.8616f), 2);
            fskincolNEWS.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_NEWS);
            fskincolNEWS.vnxSetElementData("NEUTRALMARKER", true);
            RageAPI.CreateTextLabel("Fraktion - Skin", new Position(-575.1335f, -939.9796f, 23.8616f), 20.0f, 0.75f, 4, new int[] { 200, 200, 0, 255 }, fskincolNEWS.Dimension);
            //////////////////////////////               
            /////////////////////////////////////////
            IColShape fskincolMEDIC = Alt.CreateColShapeSphere(new Position(326.3686f, -559.8064f, 28.74379f), 2);
            fskincolMEDIC.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_EMERGENCY);
            fskincolMEDIC.vnxSetElementData("NEUTRALMARKER", true);
            RageAPI.CreateTextLabel("Fraktion - Skin", new Position(326.3686f, -559.8064f, 28.74379f), 20.0f, 0.75f, 4, new int[] { 200, 0, 0, 255 }, fskincolMEDIC.Dimension);
            //////////////////////////////            






            //////////////////////////////      
            IColShape fskincolLCN = Alt.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolLCN.Dimension = Constants.FACTION_COSANOSTRA;
            fskincolLCN.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_COSANOSTRA);
            fskincolLCN.vnxSetElementData("GANGSKINMARKER", true);
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 40, 40, 40, 255 }, Constants.FACTION_COSANOSTRA);

            //////////////////////////////       
            /*
            /// //////////////////////////////      
            IColShape fskincolYAKUZA = Alt.CreateColShapeSphere(new Position(344.0552f, -1003.21f, 1, 0.3f, Constants.FACTION_YAKUZA));
            fskincolYAKUZA.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_YAKUZA);
            fskincolYAKUZA.vnxSetElementData("GANGSKINMARKER", true);
            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Skin", new Position(344.0552f, -1003.21f, -99.19618f), 20.0f, 0.75f, 4, new Rgba(200, 0, 0), true, fskincolYAKUZA.Dimension);
           
            */

            IColShape fskincolBallas = Alt.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolBallas.Dimension = Constants.FACTION_BALLAS;
            fskincolBallas.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_BALLAS);
            fskincolBallas.vnxSetElementData("GANGSKINMARKER", true);
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 138, 43, 226, 255 }, Constants.FACTION_BALLAS);

            IColShape fskincolCompton = Alt.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolCompton.Dimension = Constants.FACTION_GROVE;
            fskincolCompton.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_GROVE);
            fskincolCompton.vnxSetElementData("GANGSKINMARKER", true);
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 0, 152, 0, 255 }, Constants.FACTION_GROVE);

            IColShape fskincolMS13 = Alt.CreateColShapeSphere(new Position(-1285.856f, 446.7924f, 97.89468f), 0.3f);
            fskincolMS13.Dimension = Constants.FACTION_MS13;
            fskincolMS13.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_MS13);
            fskincolMS13.vnxSetElementData("GANGSKINMARKER", true);
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 175, 175, 0, 255 }, Constants.FACTION_MS13);

            IColShape fskincolSAMCRO = Alt.CreateColShapeSphere(new Position(983.1344f, -98.7942f, 74.84556f), 0.3f);
            fskincolSAMCRO.Dimension = Constants.FACTION_SAMCRO;
            fskincolSAMCRO.vnxSetElementData(EntityData.PLAYER_FACTION, Constants.FACTION_SAMCRO);
            fskincolSAMCRO.vnxSetElementData("GANGSKINMARKER", true);
            RageAPI.CreateTextLabel("Gang - Skin", new Position(983.1344f, -98.7942f, 74.84556f), 20f, 0.75f, 4, new int[] { 175, 175, 0, 255 }, Constants.FACTION_SAMCRO);
        }



        [Command("fstate")]
        //GetFactionStats
        public void Fstatefunc(Client player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == 0)
                {
                    player.SendTranslatedChatMessage("Du bist in keiner Fraktion!");
                }
                else
                {
                    player.SendTranslatedChatMessage("Fraktions ID : " + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    Fraktions_Kassen fkasse = Database.GetFactionStats((int)player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    player.SendTranslatedChatMessage("Fraktions Koks : " + fkasse.koks);
                    player.SendTranslatedChatMessage("Fraktions Mats : " + fkasse.mats);
                    player.SendTranslatedChatMessage("Fraktions Money : " + fkasse.money);
                    player.SendTranslatedChatMessage("Fraktions Weed : " + fkasse.weed);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION Fstatefunc] " + ex.Message);
                Console.WriteLine("[EXCEPTION Fstatefunc] " + ex.StackTrace);
            }
        }

        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == player.vnxGetElementData<int>(EntityData.PLAYER_FACTION))
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == 0)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Nicht befugt!");
                        Console.WriteLine("ColShape Player hit : " + player.Username);
                        Console.WriteLine("FID" + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                        Console.WriteLine("FID COL " + shape.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    }
                    else
                    {
                        if (shape.vnxGetElementData<bool>("GANGSKINMARKER") == true)
                        {
                            player.Emit("show_duty_window_bad");
                            return;
                        }
                        else if (shape.vnxGetElementData<bool>("NEUTRALMARKER") == true)
                        {
                            player.Emit("show_duty_window_bad", true);
                            return;
                        }
                        Fraktions_Kassen fkasse = Database.GetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                        string completeword = string.Empty;
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == 1)
                        {
                            completeword = "Das Fraktions Lager des ";
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == 2)
                        {
                            completeword = "Das Fraktions Lager der ";
                        }
                        player.Emit("showFactionStuff", completeword + Faction.GetPlayerFactionName(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION)), fkasse.koks, fkasse.mats, fkasse.money, fkasse.weed);
                    }
                }
            }
            catch
            {
            }
        }



        //[AltV.Net.ClientEvent("StoreFactionDatasServer")]
        public void StoreFactionDatas(Client player, int money, int mats, int koks, int weed, string state)
        {
            try
            {
                if (money < 0 || mats < 0 || koks < 0 || weed < 0)
                {
                    return;
                }
                if (state == "StoreDatas")
                {
                    Fraktions_Kassen fkasse = Database.GetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    int finalwertweed = fkasse.weed;
                    int finalwertkoks = fkasse.koks;
                    int finalwertmats = fkasse.mats;
                    int finalwertmoney = fkasse.money;
                    int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                    ItemModel KOKS = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_KOKS);
                    ItemModel WEED = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_WEED);
                    ItemModel MATS = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MATS);
                    if (weed > 0)
                    {
                        if (WEED != null)
                        {
                            if (weed > WEED.amount)
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Weed!");
                                return;
                            }
                            else
                            {
                                finalwertweed = fkasse.weed + weed;
                                WEED.amount -= weed;
                                // Update the amount into the database
                                Database.UpdateItem(WEED);

                                if (WEED.amount == 0)
                                {
                                    // Remove the item from the database
                                    Database.RemoveItem(WEED.id);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(WEED);
                                }
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Weed!");
                            return;
                        }
                    }

                    if (koks > 0)
                    {
                        if (KOKS != null)
                        {
                            if (koks > KOKS.amount)
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Kokain!");
                                return;
                            }
                            else
                            {
                                KOKS.amount -= koks;
                                finalwertkoks = fkasse.koks + koks;
                                // Update the amount into the database
                                Database.UpdateItem(KOKS);

                                if (KOKS.amount == 0)
                                {
                                    // Remove the item from the database
                                    Database.RemoveItem(KOKS.id);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(KOKS);
                                }
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Kokain!");
                            return;
                        }
                    }
                    if (mats > 0)
                    {
                        if (MATS != null)
                        {
                            if (mats > MATS.amount)
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Mats!");
                                return;
                            }
                            else
                            {
                                MATS.amount -= mats;
                                finalwertmats = fkasse.mats + mats;
                                // Update the amount into the database
                                Database.UpdateItem(MATS);
                                if (MATS.amount == 0)
                                {
                                    // Remove the item from the database
                                    Database.RemoveItem(MATS.id);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(MATS);
                                }
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Mats!");
                            return;
                        }
                    }
                    else if (money > 0)
                    {
                        if (money > player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY))
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            return;
                        }
                        else
                        {
                            finalwertmoney = fkasse.money + money;
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - money);
                        }
                    }
                    Faction.CreateFactionInformation(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), player.Username + " hat " + RageAPI.GetHexColorcode(0, 200, 255) + " " + money + " " + RageAPI.GetHexColorcode(255, 255, 255) + "$, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + weed + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Weed, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + koks + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Kokain, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + mats + RageAPI.GetHexColorcode(255, 255, 255) + " Stk. Mats ins Depot gelegt!");
                    vnx_stored_files.logfile.WriteLogs("fkasse", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat " + money + " $, " + weed + " G Weed, " + koks + " G Kokain, " + mats + " Stk. Mats ins Depot gelegt!");
                    player.Emit("destroyFkassenWindow");
                    Database.SetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), finalwertmoney, finalwertweed, finalwertkoks, finalwertmats);

                }
                else if (state == "TakeDatas")
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_RANK) < 4)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht Befugt!");
                        return;
                    }
                    Fraktions_Kassen fkasse = Database.GetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                    if (fkasse.weed < weed)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Weed in der Kasse!");
                        return;
                    }
                    if (fkasse.koks < koks)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Kokain in der Kasse!");
                        return;
                    }
                    if (fkasse.mats < mats)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Mats in der Kasse!");
                        return;
                    }
                    if (fkasse.money < money)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Geld in der Kasse!");
                        return;
                    }
                    int finalwertmoney = fkasse.money - money;
                    int finalwertweed = fkasse.weed - weed;
                    int finalwertkoks = fkasse.koks - koks;
                    int finalwertmats = fkasse.mats - mats;
                    player.Emit("destroyFkassenWindow");
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + money);
                    Database.SetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), finalwertmoney, finalwertweed, finalwertkoks, finalwertmats);
                    Faction.CreateFactionInformation(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), player.Username + " hat " + RageAPI.GetHexColorcode(0, 200, 255) + " " + money + " " + RageAPI.GetHexColorcode(255, 255, 255) + "$, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + weed + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Weed, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + koks + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Kokain, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + mats + RageAPI.GetHexColorcode(255, 255, 255) + " Stk. Mats aus dem Depot genommen!");
                    vnx_stored_files.logfile.WriteLogs("fkasse", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat " + money + " $, " + weed + " G Weed, " + koks + " G Kokain, " + mats + " Stk. Mats aus dem Depot genommen!");


                    //Dem Spieler die  Items geben die er verdient hat nahui
                    if (weed > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_WEED, Constants.ITEM_ART_DROGEN, weed, true);
                    }
                    if (koks > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_KOKS, Constants.ITEM_ART_DROGEN, koks, true);
                    }
                    if (mats > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_MATS, Constants.ITEM_ART_DROGEN, mats, true);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
