using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Notifications_
{
    public class Main
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
                VenoX.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, message);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static async void DrawTranslatedNotification(VnXPlayer player, Types type, string message)
        {
            try
            {
                string translatedMessage = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, message);
                VenoX.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, translatedMessage);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
