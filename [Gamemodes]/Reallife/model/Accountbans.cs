using System;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class Accountbans
    {
        public int BanUID { get; set; }
        public DateTime banzeit { get; set; }
        public string banreason { get; set; }
        public DateTime banerstelltam { get; set; }
        public string AdminBanned { get; set; }
        public string Bantype { get; set; }



        public Accountbans() { }
        public Accountbans(int BanUID, DateTime banzeit, string banreason , DateTime banerstelltam, string AdminBanned, string Bantype)
        {
            this.BanUID = BanUID;
            this.banzeit = banzeit;
            this.banreason = banreason;
            this.banerstelltam = banerstelltam;
            this.AdminBanned = AdminBanned;
            this.Bantype = Bantype;
        }
    }
}
