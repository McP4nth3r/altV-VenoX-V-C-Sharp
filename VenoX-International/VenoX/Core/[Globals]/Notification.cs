using System;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Globals_
{
    public class Notification
    {
        //Notification
        public enum Types
        {
            Info = 0,
            Warning = 1,
            Error = 2
        }
        public static void DrawNotification(VnXPlayer player, Types type, string message)
        {
            try
            {
                _RootCore_.VenoX.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, message);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public static async void DrawTranslatedNotification(VnXPlayer player, Types type, string message)
        {
            try
            {
                string translatedMessage = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, message);
                _RootCore_.VenoX.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, translatedMessage);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
