using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;

namespace VenoXV.Reallife.Environment.Gzone
{
    public class Zone : IScript
    {
        public static Position LSPD_COL_POS = new Position(399.868f, -998.4932f, 29.45414f);
        public static IColShape LSPD_Col = Alt.CreateColShapeSphere(LSPD_COL_POS, 50);
        public static void CreateGreenzone(IPlayer player)
        {
            try
            {
                player.Emit("Greenzone:Create", "LSPD_COL", LSPD_COL_POS.X, LSPD_COL_POS.Y, LSPD_COL_POS.Z, 50, 2, 0);
            }
            catch { }
        }
        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            if(shape == LSPD_Col)
            {
                player.Emit("Greenzone:ChangeStatus", true);
                if (player.vnxGetElementData<string>("settings_quest") == "ja")
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_quest", "nein");
                    anzeigen.Usefull.VnX.UpdateHUD(player);
                    player.SetData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", true);
                }
            }
        }

        public static void OnPlayerExitIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == LSPD_Col)
                {
                    if(player.vnxGetElementData<bool>("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT") == true)
                    {
                        Core.VnX.SetSharedSettingsData(player, "settings_quest", "ja");
                        anzeigen.Usefull.VnX.UpdateHUD(player);
                        player.SetData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", false);
                    }
                    player.Emit("Greenzone:ChangeStatus", false);
                }
            }
            catch { }
        }
    }
}
