using System;
using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV.Models;

namespace VenoXV._Preload_.Loading
{
    public class Main : IScript
    {
        public const int LoadingTimer = 45000; //LoadingTimer In MS
        public static void LoadReallifeMaps(VnXPlayer player)
        {
            _Maps_.Main.LoadMap(player, _Maps_.Main.LspdMap);
            _Maps_.Main.LoadMap(player, _Maps_.Main.NoobspawnMap);
            _Maps_.Main.LoadMap(player, _Maps_.Main.StadthalleMap);
            _Maps_.Main.LoadMap(player, _Maps_.Main.WuerfelparkMap);
        }
        public static void UnloadReallifeMaps(VnXPlayer player)
        {
            _Maps_.Main.UnloadMap(player, _Maps_.Main.LspdMap);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.NoobspawnMap);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.StadthalleMap);
            _Maps_.Main.UnloadMap(player, _Maps_.Main.WuerfelparkMap);
        }
        public static void ShowLoadingScreen(VnXPlayer player)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "LoadingScreen:ShowPreload", true);
                player.Gamemode = (int)Preload.Gamemodes.Reallife;
                _Gamemodes_.Reallife.register_login.Login.CreateNewLogin_Cam(player, 0, 0);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
