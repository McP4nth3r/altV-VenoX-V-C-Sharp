using System;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Language_.Main;

namespace VenoXV.Reallife.factions.State
{
    public class Allround
    {
        public static ColShapeModel LspdDuty = RageApi.CreateColShapeSphere(new Vector3(459.297f, -990.9312f, 30.6896f), 1.5f);
        public static ColShapeModel FbiDuty = RageApi.CreateColShapeSphere(new Vector3(121.7512f, -753.7672f, 45.75201f), 1.5f);
        public static ColShapeModel ArmyDuty = RageApi.CreateColShapeSphere(new Vector3(467.07693f, -3220.4834f, 7.0549316f), 1.5f);
        public static ColShapeModel Army2Duty = RageApi.CreateColShapeSphere(new Vector3(-2172.7913f, 3255.9692f, 32.801514f), 1.5f);
        public static async Task<bool> OnStateColShapeHit(ColShapeModel colShape, VnXPlayer player)
        {
            try
            {
                Core.Debug.OutputDebugString("Called OnColShapeHit for " + player.Username);
                if (!factions.Allround.IsStateFaction(player) || colShape != LspdDuty || colShape != FbiDuty || colShape != ArmyDuty) return false;
                string translatedText1 = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Wilkommen Officer");
                string translatedText2Asset = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Hier kannst du dich für den Dienst melden, bei speziellen Einsätzen aber");
                string translatedText2Asset2 = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "auch in den SWAT gehen.Du kannst dich aber auch wieder abmelden.");

                string translatedText2 = "<br><br><br>" + translatedText2Asset + "<br><br><br>" + translatedText2Asset2;
                string translatedTextResult = translatedText1 + " " + player.Username + "!" + translatedText2;
                
                if (colShape == LspdDuty) { VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FactionPoliceName, translatedTextResult); return true; }
                if (colShape == FbiDuty) { VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FactionFbiName, translatedTextResult); return true; }
                if (colShape == ArmyDuty || colShape == Army2Duty) { VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FactionUsarmyName, translatedTextResult); return true; }
    
                return false;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
    }
}
