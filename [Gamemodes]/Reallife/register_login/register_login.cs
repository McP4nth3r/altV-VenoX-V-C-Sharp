using AltV.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.register_login
{
    public class Main : IScript
    {
        public static string GetCurrentChangelogs()
        {
            return "" +
           "10.12.2019 <br>---------------------------------<br>"
           + " - Version 1.1.1 ist nun Online.<br>"
           + " - EVENT MODE wurde entfernt.<br>"
           + " - 225.000$ wurde entfernt.<br>"
           + " - More Infos Cooming Soon...<br>"
           ;
        }

        [ClientEvent("Register:First")]
        public static void OnFirstStepRegister(Client player, string username, string email, string password, string password_retype, int GenderSelected)
        {
            //int Sex = int.Parse(GenderSelected);
            Core.Debug.OutputDebugString("Register : " + username + " | " + email + " | " + password + " | " + password_retype + " | " + GenderSelected);
            Core.Debug.OutputDebugString("Register called");
            player.Emit("DestroyLoginWindow");
            player.Emit("CharCreator:Start");
        }
    }
}
