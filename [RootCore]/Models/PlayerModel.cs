using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Numerics;

namespace VenoXV._RootCore_.Models
{
    public class PlayerModel : Player
    {

        public int id { get; set; }
        public string realName { get; set; }
        public int adminRank { get; set; }

        private Vector3 Pos { get; set; }
        public Position position
        {
            get { return Pos; }
            set { Pos = value; Alt.Emit("GlobalSystems:PlayerPosition", this, value); Core.Debug.OutputDebugString("Called Pos " + value); }
        }
        public int rotation { get; set; }
        public int money { get; set; }
        public int bank { get; set; }
        public string SocialState { get; set; }
        public int health { get; set; }
        public int armor { get; set; }
        public int age { get; set; }
        public int sex { get; set; }
        public int faction { get; set; }
        public int REALLIFE_HUD { get; set; }
        public DateTime zivizeit { get; set; }
        public string job { get; set; }
        public int LIEFERJOB_LEVEL { get; set; }
        public int AIRPORTJOB_LEVEL { get; set; }
        public int BUSJOB_LEVEL { get; set; }
        public int rank { get; set; }
        public int phone { get; set; }
        public int killed { get; set; }
        public int status { get; set; }
        public int played { get; set; }
        public int houseRent { get; set; }
        public int houseEntered { get; set; }
        public int businessEntered { get; set; }

        public int Personalausweis { get; set; }
        public int Autofuehrerschein { get; set; }
        public int Motorradfuehrerschein { get; set; }
        public int LKWfuehrerschein { get; set; }
        public int Helikopterfuehrerschein { get; set; }
        public int FlugscheinKlasseA { get; set; }
        public int FlugscheinKlasseB { get; set; }
        public int Motorbootschein { get; set; }
        public int Angelschein { get; set; }
        public int Waffenschein { get; set; }

        public string spawn { get; set; }
        public int quests { get; set; }

        public int wanteds { get; set; }
        public int knastzeit { get; set; }
        public int kaution { get; set; }
        public int adventskalender { get; set; }
        public string atm { get; set; }
        public string haus { get; set; }
        public string tacho { get; set; }

        public string quest_anzeigen { get; set; }
        public string reporter { get; set; }
        public string globalchat { get; set; }

        public string Vip_Paket { get; set; }
        public DateTime Vip_BisZum { get; set; }
        public DateTime Vip_GekauftAm { get; set; }


        // Tactics : 

        public int tactic_kills { get; set; }
        public int tactic_tode { get; set; }


        // Zombie : 

        public int zombie_kills { get; set; }
        public int zombie_player_kills { get; set; }
        public int zombie_tode { get; set; }

        public PlayerModel(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            try
            {
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }

    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr playerPointer, ushort id)
        {
            try
            {
                return new PlayerModel(playerPointer, id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerFactory:Create", ex); return null; }
        }
    }
}
