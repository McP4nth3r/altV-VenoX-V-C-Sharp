using AltV.Net;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
namespace VenoXV._Preload_.Loading
{
    public class Main : IScript
    {
        public const int LoadingTimer = 45000; //LoadingTimer In MS
        public static void LoadReallifeMaps(VnXPlayer player)
        {
            _Maps_.Main.LoadMap(player, _Maps_.Main.LSPD_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.BUSSTATION_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.NOOBSPAWN_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.STADTHALLE_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.WUERFELPARK_MAP);
        }
        public static void UnloadReallifeMaps(VnXPlayer player)
        {
            _Maps_.Main.UnloadMap(player, _Maps_.Main.LSPD_MAP);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.BUSSTATION_MAP);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.NOOBSPAWN_MAP);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.STADTHALLE_MAP);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.WUERFELPARK_MAP);
        }
        public static void ShowLoadingScreen(VnXPlayer player)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "LoadingScreen:Show", LoadingTimer);
                player.Gamemode = (int)Preload.Gamemodes.Reallife;
                _Gamemodes_.Reallife.register_login.Login.CreateNewLogin_Cam(player, 0, 0);
            }
            catch { }
        }
        [ClientEvent("Loading:OnClientFinished")]
        public static void OnClientFinished(VnXPlayer player)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "showLoginWindow", "Willkommen auf VenoX", _Gamemodes_.Reallife.register_login.Login.GetCurrentChangelogs());
            }
            catch { }
        }
    }
}
