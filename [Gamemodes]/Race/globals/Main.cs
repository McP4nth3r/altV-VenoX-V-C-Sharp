namespace VenoXV._Gamemodes_.Race.Globals
{
    class Main
    {
        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Main.RacePlayers.Count <= 0) { return; }
                Lobby.Main.OnUpdate();
            }
            catch { }
        }
    }
}