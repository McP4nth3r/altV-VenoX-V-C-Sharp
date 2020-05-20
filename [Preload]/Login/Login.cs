using AltV.Net;
using VenoXV._Preload_.Register;

namespace VenoXV._Preload_.Login
{
    public class Login : IScript
    {
        public static bool LoginAccount(string Nickname, string Password)
        {
            foreach (AccountModel accClass in Register.Register.AccountList)
            {
                if (accClass.Name.ToLower() == Nickname.ToLower() && accClass.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }
        [ClientEvent("LoginAccount")]
        public static void LoginAccountEvent(string Nickname, string Password)
        {
            if (!LoginAccount(Nickname, Password)) { }
        }
    }
}
