﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.Gzone
{
    public class Zone : IScript
    {
        public static Position LSPD_COL_POS = new Position(399.868f, -998.4932f, 29.45414f);
        public static ColShapeModel LSPD_Col = RageAPI.CreateColShapeSphere(LSPD_COL_POS, 50);
        public static void CreateGreenzone(VnXPlayer player)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "Greenzone:Create", "LSPD_COL", LSPD_COL_POS.X, LSPD_COL_POS.Y, LSPD_COL_POS.Z, 50, 2, 0);
            }
            catch { }
        }
        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            if (shape == LSPD_Col)
            {
                Alt.Server.TriggerClientEvent(player, "Greenzone:ChangeStatus", true);
                if (player.vnxGetElementData<int>("settings_quest") == 1)
                {
                    player.vnxSetStreamSharedElementData("settings_quest", "nein");
                    player.vnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", true);
                }
            }
        }

        public static void OnPlayerExitColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == LSPD_Col)
                {
                    if (player.vnxGetElementData<bool>("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT") == true)
                    {
                        player.vnxSetStreamSharedElementData("settings_quest", "ja");
                        player.vnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", false);
                    }
                    Alt.Server.TriggerClientEvent(player, "Greenzone:ChangeStatus", false);
                }
            }
            catch { }
        }
    }
}
