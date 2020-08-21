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
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXLiteNotify", (int)type, message);
        }
    }
}
