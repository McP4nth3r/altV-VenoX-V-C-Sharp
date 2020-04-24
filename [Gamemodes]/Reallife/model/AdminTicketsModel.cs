using System;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class AdminTickets
    {
        public int id { get; set; }
        public int playerSQLID { get; set; }

        public string playerSocialClub { get; set; }

        public string playerName { get; set; }

        public string Betreff { get; set; }

        public string Frage { get; set; }

        public string Status { get; set; }
    }
}
