﻿using System;
using System.Threading.Tasks;
using VenoXV._RootCore_.Models;
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
        };
        public static void DrawNotification(VnXPlayer player, Types type, string message)
        {
            try
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, message);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static async void DrawTranslatedNotification(VnXPlayer player, Types type, string message)
        {
            try
            {
                await Task.Run(async () =>
                {
                    string TranslatedMessage = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, message);
                    AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, TranslatedMessage);
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
