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
        public static IColShape LSPD_Col = Alt.CreateColShapeSphere(LSPD_COL_POS, 50);
        public static void CreateGreenzone(Client player)
        {
            try
            {
                player.Emit("Greenzone:Create", "LSPD_COL", LSPD_COL_POS.X, LSPD_COL_POS.Y, LSPD_COL_POS.Z, 50, 2, 0);
            }
            catch { }
        }
        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            if (shape == LSPD_Col)
            {
                player.Emit("Greenzone:ChangeStatus", true);
                if (player.vnxGetElementData<int>("settings_quest") == 1)
                {
                    player.vnxSetStreamSharedElementData("settings_quest", "nein");
                    player.vnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", true);
                }
            }
        }

        public static void OnPlayerExitIColShape(IColShape shape, Client player)
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
                    player.Emit("Greenzone:ChangeStatus", false);
                }
            }
            catch { }
        }
    }
}
