using AltV.Net;
using VenoXV._RootCore_.Models;
namespace VenoXV._Preload_.Loading
{
    public class Main : IScript
    {
        public const int LoadingTimer = 45000; //LoadingTimer In MS
        private static void LoadReallifeMaps(Client player)
        {
            _Maps_.Main.LoadMap(player, _Maps_.Main.LSPD_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.NOOBSPAWN_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.STADTHALLE_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.WUERFELPARK_MAP);
        }
        public static void ShowLoadingScreen(Client player)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "LoadingScreen:Show", LoadingTimer);
                LoadReallifeMaps(player);
                player.Gamemode = (int)Preload.Gamemodes.Reallife;
                _Gamemodes_.Reallife.register_login.Login.CreateNewLogin_Cam(player, 0, 0);
            }
            catch { }
        }
        [ClientEvent("Loading:OnClientFinished")]
        public static void OnClientFinished(Client player)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "showLoginWindow", "Willkommen auf VenoX", _Gamemodes_.Reallife.register_login.Login.GetCurrentChangelogs());
            }
            catch { }
        }
    }
}
