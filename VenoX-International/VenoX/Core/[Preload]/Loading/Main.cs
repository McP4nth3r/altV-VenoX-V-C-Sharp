using System;
using AltV.Net;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Preload_.Loading
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
                _RootCore_.VenoX.TriggerClientEvent(player, "LoadingScreen:ShowPreload", true);
                player.Gamemode = (int)Preload.Gamemodes.Reallife;
                global::VenoX.Core._Gamemodes_.Reallife.register_login.Login.CreateNewLogin_Cam(player, 0, 0);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

    }
}
