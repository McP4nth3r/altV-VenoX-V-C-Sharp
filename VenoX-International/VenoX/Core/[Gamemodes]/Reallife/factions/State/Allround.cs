using System;
using System.Numerics;
using System.Threading.Tasks;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using Main = VenoX.Core._Language_.Main;

namespace VenoX.Core._Gamemodes_.Reallife.factions.State
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
                ConsoleHandling.OutputDebugString("Called OnColShapeHit for " + player.CharacterUsername);
                if (!factions.Allround.IsStateFaction(player) || colShape != LspdDuty || colShape != FbiDuty || colShape != ArmyDuty) return false;
                string translatedText1 = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Wilkommen Officer");
                string translatedText2Asset = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Hier kannst du dich für den Dienst melden, bei speziellen Einsätzen aber");
                string translatedText2Asset2 = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "auch in den SWAT gehen.Du kannst dich aber auch wieder abmelden.");

                string translatedText2 = "<br><br><br>" + translatedText2Asset + "<br><br><br>" + translatedText2Asset2;
                string translatedTextResult = translatedText1 + " " + player.CharacterUsername + "!" + translatedText2;
                
                if (colShape == LspdDuty) { _RootCore_.VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FactionPoliceName, translatedTextResult); return true; }
                if (colShape == FbiDuty) { _RootCore_.VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FactionFbiName, translatedTextResult); return true; }
                if (colShape == ArmyDuty || colShape == Army2Duty) { _RootCore_.VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FactionUsarmyName, translatedTextResult); return true; }
    
                return false;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return false; }
        }
    }
}
