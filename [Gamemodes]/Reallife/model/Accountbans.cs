using System;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class Accountbans
    {
        public int BanUid { get; set; }
        public DateTime Banzeit { get; set; }
        public string Banreason { get; set; }
        public DateTime Banerstelltam { get; set; }
        public string AdminBanned { get; set; }
        public string Bantype { get; set; }



        public Accountbans() { }
        public Accountbans(int banUid, DateTime banzeit, string banreason , DateTime banerstelltam, string adminBanned, string bantype)
        {
            this.BanUid = banUid;
            this.Banzeit = banzeit;
            this.Banreason = banreason;
            this.Banerstelltam = banerstelltam;
            this.AdminBanned = adminBanned;
            this.Bantype = bantype;
        }
    }
}
