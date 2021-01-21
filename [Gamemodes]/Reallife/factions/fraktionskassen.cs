using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Fraktionskassen : IScript
    {
        public static void OnResourceStart()
        {

            ColShapeModel fkassencolLSPD = RageAPI.CreateColShapeSphere(new Position(452.5833f, -982.6306f, 30.68959f), 0.3f);
            fkassencolLSPD.Faction = Constants.FACTION_LSPD;
            Core.RageAPI.CreateTextLabel("LSPD - Kasse", new Position(452.5833f, -982.6306f, 30.68959f), 20.0f, 0.75f, 4, new int[] { 0, 0, 200, 255 });
            //////////////////////////////      
            ColShapeModel fkassencolLCN = RageAPI.CreateColShapeSphere(new Position(259.6794f, -1004.043f, -99f), 0.3f, Constants.FACTION_LCN);
            fkassencolLCN.Faction = Constants.FACTION_LCN;
            Core.RageAPI.CreateTextLabel("Gang - Kasse", fkassencolLCN.CurrentPosition, 20.0f, 0.75f, 4, new int[] { 40, 40, 40, 255 }, fkassencolLCN.Dimension);
            //////////////////////////////      

            ColShapeModel fkassencolYAKUZA = RageAPI.CreateColShapeSphere(new Position(345.3037f, -995.8774f, -99f), 0.3f, Constants.FACTION_YAKUZA);
            fkassencolYAKUZA.Faction = Constants.FACTION_YAKUZA;
            Core.RageAPI.CreateTextLabel("Gang - Kasse", fkassencolYAKUZA.CurrentPosition, 20.0f, 0.75f, 4, new int[] { 200, 0, 0, 255 }, fkassencolYAKUZA.Dimension);

            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(345.3037f, -995.8774f, -99.19618f), 20.0f, 0.75f, 4, new Rgba(200, 0, 0), true, fkassencolYAKUZA.Dimension);
            //////////////////////////////
            ///

            //////////////////////////////      
            ColShapeModel fkassencolBallas = RageAPI.CreateColShapeSphere(new Position(259.6794f, -1004.043f, -99f), 0.3f, Constants.FACTION_BALLAS);
            fkassencolBallas.Faction = Constants.FACTION_BALLAS;
            Core.RageAPI.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new int[] { 138, 43, 226, 255 }, fkassencolBallas.Dimension);
            //////////////////////////////      

            //////////////////////////////      
            ColShapeModel fkassencolCompton = RageAPI.CreateColShapeSphere(new Position(259.6794f, -1004.043f, -99f), 0.3f, Constants.FACTION_COMPTON);
            fkassencolCompton.Faction = Constants.FACTION_COMPTON;
            Core.RageAPI.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new int[] { 0, 152, 0, 255 }, fkassencolCompton.Dimension);
            //////////////////////////////      


            //////////////////////////////      
            ColShapeModel fkassencolMS13 = RageAPI.CreateColShapeSphere(new Position(-1287.002f, 456.257f, 90.29469f), 0.3f, Constants.FACTION_NARCOS);
            fkassencolMS13.Faction = Constants.FACTION_NARCOS;
            Core.RageAPI.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new int[] { 220, 220, 220, 255 }, fkassencolMS13.Dimension);
            //////////////////////////////      

            //////////////////////////////      
            ColShapeModel fkassencolSAMCRO = RageAPI.CreateColShapeSphere(new Position(971.9218f, -98.68291f, 74.84641f), 0.3f, Constants.FACTION_SAMCRO);
            fkassencolSAMCRO.Faction = Constants.FACTION_SAMCRO;
            Core.RageAPI.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new int[] { 175, 175, 0, 255 }, fkassencolSAMCRO.Dimension);
            //////////////////////////////      


            ///////////////////////////////////
            ColShapeModel fkassencolNEWS = RageAPI.CreateColShapeSphere(new Position(-537.0566f, -886.5463f, 25.20651f), 2);
            fkassencolNEWS.Faction = Constants.FACTION_NEWS;
            Core.RageAPI.CreateTextLabel("News - Kasse", new Position(-537.0566f, -886.5463f, 25.20651f), 20.0f, 0.75f, 4, new int[] { 200, 200, 0, 255 });
            //////////////////////////////      
            //////////////////////////////////////
            ColShapeModel fskincolNEWS = RageAPI.CreateColShapeSphere(new Position(-575.1335f, -939.9796f, 23.8616f), 2);
            fskincolNEWS.Faction = Constants.FACTION_NEWS;
            fskincolNEWS.NeutralSkinCol = true;
            RageAPI.CreateTextLabel("Fraktion - Skin", new Position(-575.1335f, -939.9796f, 23.8616f), 20.0f, 0.75f, 4, new int[] { 200, 200, 0, 255 }, fskincolNEWS.Dimension);
            //////////////////////////////               
            //////////////////////////////////////
            ColShapeModel fskincolMechanik = RageAPI.CreateColShapeSphere(new Position(472.56262f, -1309.5428f, 29.229248f), 2);
            fskincolMechanik.Faction = Constants.FACTION_MECHANIK;
            fskincolMechanik.NeutralSkinCol = true;
            RageAPI.CreateTextLabel("Fraktion - Skin", new Position(472.56262f, -1309.5428f, 29.229248f), 20.0f, 0.75f, 4, new int[] { 200, 200, 200, 255 });
            //////////////////////////////               
            /////////////////////////////////////////
            ColShapeModel fskincolMEDIC = RageAPI.CreateColShapeSphere(new Position(326.3686f, -559.8064f, 28.74379f), 2);
            fskincolMEDIC.Faction = Constants.FACTION_EMERGENCY;
            fskincolMEDIC.NeutralSkinCol = true;
            RageAPI.CreateTextLabel("Fraktion - Skin", new Position(326.3686f, -559.8064f, 28.74379f), 20.0f, 0.75f, 4, new int[] { 200, 0, 0, 255 }, fskincolMEDIC.Dimension);
            //////////////////////////////            

            //////////////////////////////      
            ColShapeModel fskincolLCN = RageAPI.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f, Constants.FACTION_LCN);
            fskincolLCN.Faction = Constants.FACTION_LCN;
            fskincolLCN.GangSkinCol = true;
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 40, 40, 40, 255 }, Constants.FACTION_LCN);

            //////////////////////////////       

            /// //////////////////////////////      
            ColShapeModel fskincolYAKUZA = RageAPI.CreateColShapeSphere(new Vector3(344.0552f, -1003.21f, -99f), 0.3f, Constants.FACTION_YAKUZA);
            fskincolYAKUZA.Faction = Constants.FACTION_YAKUZA;
            fskincolYAKUZA.GangSkinCol = true;
            RageAPI.CreateTextLabel("Gang - Skin", fskincolYAKUZA.CurrentPosition, 20f, 0.75f, 4, new int[] { 200, 0, 0, 255 }, fskincolYAKUZA.Dimension);
            /// //////////////////////////////      


            ColShapeModel fskincolBallas = RageAPI.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolBallas.Dimension = Constants.FACTION_BALLAS;
            fskincolBallas.Faction = Constants.FACTION_BALLAS;
            fskincolBallas.GangSkinCol = true;
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 138, 43, 226, 255 }, Constants.FACTION_BALLAS);

            ColShapeModel fskincolCompton = RageAPI.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolCompton.Dimension = Constants.FACTION_COMPTON;
            fskincolCompton.Faction = Constants.FACTION_COMPTON;
            fskincolCompton.GangSkinCol = true;
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 0, 152, 0, 255 }, Constants.FACTION_COMPTON);

            ColShapeModel fskincolMS13 = RageAPI.CreateColShapeSphere(new Position(-1285.856f, 446.7924f, 97.89468f), 0.3f);
            fskincolMS13.Dimension = Constants.FACTION_NARCOS;
            fskincolMS13.Faction = Constants.FACTION_NARCOS;
            fskincolMS13.GangSkinCol = true;
            RageAPI.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new int[] { 175, 175, 0, 255 }, Constants.FACTION_NARCOS);

            ColShapeModel fskincolSAMCRO = RageAPI.CreateColShapeSphere(new Position(983.1344f, -98.7942f, 74.84556f), 0.3f);
            fskincolSAMCRO.Faction = Constants.FACTION_SAMCRO;
            fskincolSAMCRO.GangSkinCol = true;
            RageAPI.CreateTextLabel("Gang - Skin", new Position(983.1344f, -98.7942f, 74.84556f), 20f, 0.75f, 4, new int[] { 175, 175, 0, 255 }, Constants.FACTION_SAMCRO);
        }



        [Command("fstate")]
        //GetFactionStats
        public void Fstatefunc(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Faction == 0)
                {
                    player.SendTranslatedChatMessage("Du bist in keiner Fraktion!");
                }
                else
                {
                    player.SendTranslatedChatMessage("Fraktions ID : " + player.Reallife.Faction);
                    Fraktions_Kassen fkasse = Database.GetFactionStats(player.Reallife.Faction);
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

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape.Faction == Constants.FACTION_NONE || shape.Faction != player.Reallife.Faction) return false;
                if (shape.Faction > Constants.FACTION_NONE && shape.Faction == player.Reallife.Faction)
                {
                    if (shape.GangSkinCol == true)
                    {
                        VenoX.TriggerClientEvent(player, "show_duty_window_bad", player.Username);
                        return true;
                    }
                    else if (shape.NeutralSkinCol == true)
                    {
                        VenoX.TriggerClientEvent(player, "show_duty_window_bad", player.Username, true);
                        return true;
                    }
                    Fraktions_Kassen fkasse = Database.GetFactionStats(player.Reallife.Faction);
                    string completeword = string.Empty;
                    if (player.Reallife.Faction == 1)
                    {
                        completeword = "Das Fraktions Lager des ";
                    }
                    else if (player.Reallife.Faction == 2)
                    {
                        completeword = "Das Fraktions Lager der ";
                    }
                    VenoX.TriggerClientEvent(player, "showFactionStuff", completeword + Faction.GetFactionNameById(player.Reallife.Faction), fkasse.koks, fkasse.mats, fkasse.money, fkasse.weed);

                    return true;
                }
                return false;
            }
            catch { return false; }
        }



        [ClientEvent("StoreFactionDatasServer")]
        public void StoreFactionDatas(VnXPlayer player, int money, int mats, int koks, int weed, string state)
        {
            try
            {
                if (money < 0 || mats < 0 || koks < 0 || weed < 0)
                {
                    return;
                }
                if (state == "StoreDatas")
                {
                    Fraktions_Kassen fkasse = Database.GetFactionStats(player.Reallife.Faction);
                    int finalwertweed = fkasse.weed;
                    int finalwertkoks = fkasse.koks;
                    int finalwertmats = fkasse.mats;
                    int finalwertmoney = fkasse.money;
                    int playerId = player.UID;
                    ItemModel KOKS = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_KOKS);
                    ItemModel WEED = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_WEED);
                    ItemModel MATS = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_MATS);
                    if (weed > 0)
                    {
                        if (WEED != null)
                        {
                            if (weed > WEED.Amount)
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Weed!");
                                return;
                            }
                            else
                            {
                                finalwertweed = fkasse.weed + weed;
                                WEED.Amount -= weed;
                                // Update the amount into the database
                                Database.UpdateItem(WEED);

                                if (WEED.Amount == 0)
                                {
                                    // Remove the item from the database
                                    Database.RemoveItem(WEED.Id);
                                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(WEED);
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
                            if (koks > KOKS.Amount)
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Kokain!");
                                return;
                            }
                            else
                            {
                                KOKS.Amount -= koks;
                                finalwertkoks = fkasse.koks + koks;
                                // Update the amount into the database
                                Database.UpdateItem(KOKS);

                                if (KOKS.Amount == 0)
                                {
                                    // Remove the item from the database
                                    Database.RemoveItem(KOKS.Id);
                                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(KOKS);
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
                            if (mats > MATS.Amount)
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Mats!");
                                return;
                            }
                            else
                            {
                                MATS.Amount -= mats;
                                finalwertmats = fkasse.mats + mats;
                                // Update the amount into the database
                                Database.UpdateItem(MATS);
                                if (MATS.Amount == 0)
                                {
                                    // Remove the item from the database
                                    Database.RemoveItem(MATS.Id);
                                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(MATS);
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
                        if (money > player.Reallife.Money)
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            return;
                        }
                        else
                        {
                            finalwertmoney = fkasse.money + money;
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - money);
                        }
                    }
                    Faction.CreateFactionInformation(player.Reallife.Faction, player.Username + " hat " + RageAPI.GetHexColorcode(0, 200, 255) + " " + money + " " + RageAPI.GetHexColorcode(255, 255, 255) + "$, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + weed + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Weed, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + koks + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Kokain, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + mats + RageAPI.GetHexColorcode(255, 255, 255) + " Stk. Mats ins Depot gelegt!");
                    vnx_stored_files.logfile.WriteLogs("fkasse", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat " + money + " $, " + weed + " G Weed, " + koks + " G Kokain, " + mats + " Stk. Mats ins Depot gelegt!");
                    VenoX.TriggerClientEvent(player, "destroyFkassenWindow");
                    Database.SetFactionStats(player.Reallife.Faction, finalwertmoney, finalwertweed, finalwertkoks, finalwertmats);

                }
                else if (state == "TakeDatas")
                {
                    if (player.Reallife.FactionRank < 4)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht Befugt!");
                        return;
                    }
                    Fraktions_Kassen fkasse = Database.GetFactionStats(player.Reallife.Faction);
                    int playerId = player.UID;
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
                    VenoX.TriggerClientEvent(player, "destroyFkassenWindow");
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + money);
                    Database.SetFactionStats(player.Reallife.Faction, finalwertmoney, finalwertweed, finalwertkoks, finalwertmats);
                    Faction.CreateFactionInformation(player.Reallife.Faction, player.Username + " hat " + RageAPI.GetHexColorcode(0, 200, 255) + " " + money + " " + RageAPI.GetHexColorcode(255, 255, 255) + "$, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + weed + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Weed, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + koks + " " + RageAPI.GetHexColorcode(255, 255, 255) + "G Kokain, " + RageAPI.GetHexColorcode(0, 200, 255) + " " + mats + RageAPI.GetHexColorcode(255, 255, 255) + " Stk. Mats aus dem Depot genommen!");
                    vnx_stored_files.logfile.WriteLogs("fkasse", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat " + money + " $, " + weed + " G Weed, " + koks + " G Kokain, " + mats + " Stk. Mats aus dem Depot genommen!");

                    //Dem Spieler die  Items geben die er verdient hat nahui
                    if (weed > 0)
                    {
                        player.Inventory.GiveItem(Constants.ITEM_HASH_WEED, ItemType.Drugs, weed, true);
                    }
                    if (koks > 0)
                    {
                        player.Inventory.GiveItem(Constants.ITEM_HASH_KOKS, ItemType.Drugs, koks, true);
                    }
                    if (mats > 0)
                    {
                        player.Inventory.GiveItem(Constants.ITEM_HASH_MATS, ItemType.Drugs, mats, true);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
