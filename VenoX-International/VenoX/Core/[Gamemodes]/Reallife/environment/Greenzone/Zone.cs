using System;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoX.Core._Language_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.environment.Greenzone
{
    public class Zone : IScript
    {
        public static Position LspdColPos = new Position(399.868f, -998.4932f, 29.45414f);
        public static ColShapeModel LspdCol = RageApi.CreateColShapeSphere(LspdColPos, 50);
        public static void CreateGreenzone(VnXPlayer player)
        {
            try
            {
                _RootCore_.VenoX.TriggerClientEvent(player, "Greenzone:Create", "LSPD_COL", LspdColPos.X, LspdColPos.Y, LspdColPos.Z, 50, 3, 0);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != LspdCol) return false;
                Task.Run(async () =>
                {
                    string text1 = await Main.GetTranslatedTextAsync((Constants.Languages) player.Language, "You have entered a NO-DM zone!");
                    string text2 = await Main.GetTranslatedTextAsync((Constants.Languages) player.Language, "Any deathmatch is prohibited!");
                    string text3 = await Main.GetTranslatedTextAsync((Constants.Languages) player.Language, "Exception : state factions.");
                    string textcomplete = text1 + "\n" + text2 + "\n" + text3;
                    _RootCore_.VenoX.TriggerClientEvent(player, "Greenzone:ChangeStatus", true, textcomplete);
                });

                if (player.Settings.ShowQuests != 1) return true;
                player.Settings.ShowQuests = 0;
                player.VnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", true);
                return true;
            }
            catch(Exception ex)
            {
                ExceptionHandling.CatchExceptions(ex);
                return false;
            }
        }

        public static void OnPlayerExitColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape != LspdCol) return;
                if (player.VnxGetElementData<bool>("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT"))
                {
                    player.Settings.ShowQuests = 1;
                    player.VnxSetElementData("QUEST_ANZEIGE_DURCH_COL_DEAKTIVIERT", false);
                }
                _RootCore_.VenoX.TriggerClientEvent(player, "Greenzone:ChangeStatus", false, "");
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
