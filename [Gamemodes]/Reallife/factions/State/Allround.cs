using AltV.Net.Async;
using System;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions.State
{
    public class Allround
    {
        public static ColShapeModel LSPDDuty = RageAPI.CreateColShapeSphere(new Vector3(459.297f, -990.9312f, 30.6896f), 1.5f, -1);
        public static ColShapeModel FBIDuty = RageAPI.CreateColShapeSphere(new Vector3(121.7512f, -753.7672f, 45.75201f), 1.5f, -1);
        public static ColShapeModel ARMYDuty = RageAPI.CreateColShapeSphere(new Vector3(467.07693f, -3220.4834f, 7.0549316f), 1.5f, -1);
        public static ColShapeModel ARMY2Duty = RageAPI.CreateColShapeSphere(new Vector3(-2172.7913f, 3255.9692f, 32.801514f), 1.5f, -1);
        public static bool OnStateColShapeHit(ColShapeModel colShape, VnXPlayer player)
        {
            try
            {
                if (!Factions.Allround.isStateFaction(player)) return false;
                AltAsync.Do(async () =>
                {
                    string TranslatedText1 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Wilkommen Officer");
                    string TranslatedText2Asset = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Hier kannst du dich für den Dienst melden, bei speziellen Einsätzen aber");
                    string TranslatedText2Asset2 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "auch in den SWAT gehen.Du kannst dich aber auch wieder abmelden.");

                    string TranslatedText2 = "<br><br><br>" + TranslatedText2Asset + "<br><br><br>" + TranslatedText2Asset2;
                    string TranslatedTextResult = TranslatedText1 + " " + player.Username + "!" + TranslatedText2;

                    if (colShape == LSPDDuty) { VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FACTION_POLICE_NAME, TranslatedTextResult); return true; }
                    else if (colShape == FBIDuty) { VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FACTION_FBI_NAME, TranslatedTextResult); return true; }
                    else if (colShape == ARMYDuty || colShape == ARMY2Duty) { VenoX.TriggerClientEvent(player, "DutyWindow:Show", Constants.FACTION_USARMY_NAME, TranslatedTextResult); return true; }
                    else return false;
                });
                return false;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
    }
}
