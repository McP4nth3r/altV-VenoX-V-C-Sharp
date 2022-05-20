using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Gamemodes_.Reallife.factions
{
    public class Fraktionskassen : IScript
    {
        public static void OnResourceStart()
        {

            ColShapeModel fkassencolLspd = RageApi.CreateColShapeSphere(new Position(452.5833f, -982.6306f, 30.68959f), 0.3f);
            fkassencolLspd.Faction = Constants.FactionLspd;
            RageApi.CreateTextLabel("LSPD - Kasse", new Position(452.5833f, -982.6306f, 30.68959f), 20.0f, 0.75f, 4, new[] { 0, 0, 200, 255 });
            //////////////////////////////      
            ColShapeModel fkassencolLcn = RageApi.CreateColShapeSphere(new Position(259.6794f, -1004.043f, -99f), 0.3f, Constants.FactionLcn);
            fkassencolLcn.Faction = Constants.FactionLcn;
            RageApi.CreateTextLabel("Gang - Kasse", fkassencolLcn.CurrentPosition, 20.0f, 0.75f, 4, new[] { 40, 40, 40, 255 }, fkassencolLcn.Dimension);
            //////////////////////////////      

            ColShapeModel fkassencolYakuza = RageApi.CreateColShapeSphere(new Position(345.3037f, -995.8774f, -99f), 0.3f, Constants.FactionYakuza);
            fkassencolYakuza.Faction = Constants.FactionYakuza;
            RageApi.CreateTextLabel("Gang - Kasse", fkassencolYakuza.CurrentPosition, 20.0f, 0.75f, 4, new[] { 200, 0, 0, 255 }, fkassencolYakuza.Dimension);

            //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("Gang - Kasse", new Position(345.3037f, -995.8774f, -99.19618f), 20.0f, 0.75f, 4, new Rgba(200, 0, 0), true, fkassencolYAKUZA.Dimension);
            //////////////////////////////
            ///

            //////////////////////////////      
            ColShapeModel fkassencolBallas = RageApi.CreateColShapeSphere(new Position(259.6794f, -1004.043f, -99f), 0.3f, Constants.FactionBallas);
            fkassencolBallas.Faction = Constants.FactionBallas;
            RageApi.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new[] { 138, 43, 226, 255 }, fkassencolBallas.Dimension);
            //////////////////////////////      

            //////////////////////////////      
            ColShapeModel fkassencolCompton = RageApi.CreateColShapeSphere(new Position(259.6794f, -1004.043f, -99f), 0.3f, Constants.FactionCompton);
            fkassencolCompton.Faction = Constants.FactionCompton;
            RageApi.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new[] { 0, 152, 0, 255 }, fkassencolCompton.Dimension);
            //////////////////////////////      


            //////////////////////////////      
            ColShapeModel fkassencolMs13 = RageApi.CreateColShapeSphere(new Position(-1287.002f, 456.257f, 90.29469f), 0.3f, Constants.FactionNarcos);
            fkassencolMs13.Faction = Constants.FactionNarcos;
            RageApi.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new[] { 220, 220, 220, 255 }, fkassencolMs13.Dimension);
            //////////////////////////////      

            //////////////////////////////      
            ColShapeModel fkassencolSamcro = RageApi.CreateColShapeSphere(new Position(971.9218f, -98.68291f, 74.84641f), 0.3f, Constants.FactionSamcro);
            fkassencolSamcro.Faction = Constants.FactionSamcro;
            RageApi.CreateTextLabel("Gang - Kasse", fkassencolBallas.CurrentPosition, 20.0f, 0.75f, 4, new[] { 175, 175, 0, 255 }, fkassencolSamcro.Dimension);
            //////////////////////////////      


            ///////////////////////////////////
            ColShapeModel fkassencolNews = RageApi.CreateColShapeSphere(new Position(-537.0566f, -886.5463f, 25.20651f), 2);
            fkassencolNews.Faction = Constants.FactionNews;
            RageApi.CreateTextLabel("News - Kasse", new Position(-537.0566f, -886.5463f, 25.20651f), 20.0f, 0.75f, 4, new[] { 200, 200, 0, 255 });
            //////////////////////////////      
            //////////////////////////////////////
            ColShapeModel fskincolNews = RageApi.CreateColShapeSphere(new Position(-575.1335f, -939.9796f, 23.8616f), 2);
            fskincolNews.Faction = Constants.FactionNews;
            fskincolNews.NeutralSkinCol = true;
            RageApi.CreateTextLabel("Fraktion - Skin", new Position(-575.1335f, -939.9796f, 23.8616f), 20.0f, 0.75f, 4, new[] { 200, 200, 0, 255 }, fskincolNews.Dimension);
            //////////////////////////////               
            //////////////////////////////////////
            ColShapeModel fskincolMechanik = RageApi.CreateColShapeSphere(new Position(472.56262f, -1309.5428f, 29.229248f), 2);
            fskincolMechanik.Faction = Constants.FactionMechanik;
            fskincolMechanik.NeutralSkinCol = true;
            RageApi.CreateTextLabel("Fraktion - Skin", new Position(472.56262f, -1309.5428f, 29.229248f), 20.0f, 0.75f, 4, new[] { 200, 200, 200, 255 });
            //////////////////////////////               
            /////////////////////////////////////////
            ColShapeModel fskincolMedic = RageApi.CreateColShapeSphere(new Position(326.3686f, -559.8064f, 28.74379f), 2);
            fskincolMedic.Faction = Constants.FactionEmergency;
            fskincolMedic.NeutralSkinCol = true;
            RageApi.CreateTextLabel("Fraktion - Skin", new Position(326.3686f, -559.8064f, 28.74379f), 20.0f, 0.75f, 4, new[] { 200, 0, 0, 255 }, fskincolMedic.Dimension);
            //////////////////////////////            

            //////////////////////////////      
            ColShapeModel fskincolLcn = RageApi.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f, Constants.FactionLcn);
            fskincolLcn.Faction = Constants.FactionLcn;
            fskincolLcn.GangSkinCol = true;
            RageApi.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new[] { 40, 40, 40, 255 }, Constants.FactionLcn);

            //////////////////////////////       

            /// //////////////////////////////      
            ColShapeModel fskincolYakuza = RageApi.CreateColShapeSphere(new Vector3(344.0552f, -1003.21f, -99f), 0.3f, Constants.FactionYakuza);
            fskincolYakuza.Faction = Constants.FactionYakuza;
            fskincolYakuza.GangSkinCol = true;
            RageApi.CreateTextLabel("Gang - Skin", fskincolYakuza.CurrentPosition, 20f, 0.75f, 4, new[] { 200, 0, 0, 255 }, fskincolYakuza.Dimension);
            /// //////////////////////////////      


            ColShapeModel fskincolBallas = RageApi.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolBallas.Dimension = Constants.FactionBallas;
            fskincolBallas.Faction = Constants.FactionBallas;
            fskincolBallas.GangSkinCol = true;
            RageApi.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new[] { 138, 43, 226, 255 }, Constants.FactionBallas);

            ColShapeModel fskincolCompton = RageApi.CreateColShapeSphere(new Position(265.5594f, -995.382f, -99f), 0.3f);
            fskincolCompton.Dimension = Constants.FactionCompton;
            fskincolCompton.Faction = Constants.FactionCompton;
            fskincolCompton.GangSkinCol = true;
            RageApi.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new[] { 0, 152, 0, 255 }, Constants.FactionCompton);

            ColShapeModel fskincolMs13 = RageApi.CreateColShapeSphere(new Position(-1285.856f, 446.7924f, 97.89468f), 0.3f);
            fskincolMs13.Dimension = Constants.FactionNarcos;
            fskincolMs13.Faction = Constants.FactionNarcos;
            fskincolMs13.GangSkinCol = true;
            RageApi.CreateTextLabel("Gang - Skin", new Position(265.5594f, -995.382f, -99f), 20f, 0.75f, 4, new[] { 175, 175, 0, 255 }, Constants.FactionNarcos);

            ColShapeModel fskincolSamcro = RageApi.CreateColShapeSphere(new Position(983.1344f, -98.7942f, 74.84556f), 0.3f);
            fskincolSamcro.Faction = Constants.FactionSamcro;
            fskincolSamcro.GangSkinCol = true;
            RageApi.CreateTextLabel("Gang - Skin", new Position(983.1344f, -98.7942f, 74.84556f), 20f, 0.75f, 4, new[] { 175, 175, 0, 255 }, Constants.FactionSamcro);
        }



        [Command("fstate")]
        //GetFactionStats
        public static void Fstatefunc(VnXPlayer player)
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
                    FraktionsKassen fkasse = Database.GetFactionStats(player.Reallife.Faction);
                    player.SendTranslatedChatMessage("Fraktions Koks : " + fkasse.Koks);
                    player.SendTranslatedChatMessage("Fraktions Mats : " + fkasse.Mats);
                    player.SendTranslatedChatMessage("Fraktions Money : " + fkasse.Money);
                    player.SendTranslatedChatMessage("Fraktions Weed : " + fkasse.Weed);
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
                if (shape.Faction == Constants.FactionNone || shape.Faction != player.Reallife.Faction) return false;
                if (shape.Faction > Constants.FactionNone && shape.Faction == player.Reallife.Faction)
                {
                    if (shape.GangSkinCol)
                    {
                        _RootCore_.VenoX.TriggerClientEvent(player, "show_duty_window_bad", player.CharacterUsername);
                        return true;
                    }

                    if (shape.NeutralSkinCol)
                    {
                        _RootCore_.VenoX.TriggerClientEvent(player, "show_duty_window_bad", player.CharacterUsername, true);
                        return true;
                    }
                    FraktionsKassen fkasse = Database.GetFactionStats(player.Reallife.Faction);
                    string completeword = string.Empty;
                    switch (player.Reallife.Faction)
                    {
                        case 1:
                            completeword = "Das Fraktions Lager des ";
                            break;
                        case 2:
                            completeword = "Das Fraktions Lager der ";
                            break;
                    }
                    _RootCore_.VenoX.TriggerClientEvent(player, "showFactionStuff", completeword + Faction.GetFactionNameById(player.Reallife.Faction), fkasse.Koks, fkasse.Mats, fkasse.Money, fkasse.Weed);

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
