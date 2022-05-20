using System;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Race.globals
{
    class Main
    {
        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Initialize.RacePlayers.Count <= 0) return; 
                lobby.Main.OnUpdate();
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}