using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Language_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.Environment.Gzone
{
    public class Zone : IScript
    {
        public static Position LspdColPos = new Position(399.868f, -998.4932f, 29.45414f);
        public static ColShapeModel LspdCol = RageApi.CreateColShapeSphere(LspdColPos, 50);
        public static void CreateGreenzone(VnXPlayer player)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "Greenzone:Create", "LSPD_COL", LspdColPos.X, LspdColPos.Y, LspdColPos.Z, 50, 3, 0);
            }
            catch { }
        }
        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            if (shape != LspdCol) return false;
            AltAsync.Do(async () =>
            {
                string text1 = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Du hast eine NO-DM Zone betreten!");
                string text2 = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Jegliches Deathmatch ist verboten!");
                string text3 = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Ausnahme : Staatsfraktionen.");
                string textcomplete = text1 + "\n" + text2 + "\n" + text3;
                VenoX.TriggerClientEvent(player, "Greenzone:ChangeStatus", true, textcomplete);
                if (player.Settings.ShowQuests == 1)
                {
                    player.Settings.ShowQuests = 0;
                    player.VnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", true);
                }
            });
            return true;
        }

        public static void OnPlayerExitColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == LspdCol)
                {
                    if (player.VnxGetElementData<bool>("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT"))
                    {
                        player.Settings.ShowQuests = 1;
                        player.VnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", false);
                    }
                    VenoX.TriggerClientEvent(player, "Greenzone:ChangeStatus", false, "");
                }
            }
            catch { }
        }
    }
}
