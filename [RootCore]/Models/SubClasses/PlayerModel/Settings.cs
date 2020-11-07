using AltV.Net.Elements.Entities;
using System;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class Settings
    {
        private Player Player;
        private int _ShowATM { get; set; }
        public int ShowATM { get { return _ShowATM; } set { _ShowATM = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ATM_ANZEIGEN, value); } }
        private int _ShowHouse { get; set; }
        public int ShowHouse { get { return _ShowHouse; } set { _ShowHouse = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HAUS_ANZEIGEN, value); } }
        private int _ShowSpeedo { get; set; }
        public int ShowSpeedo { get { return _ShowSpeedo; } set { _ShowSpeedo = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_TACHO_ANZEIGEN, value); } }
        private int _ShowQuests { get; set; }
        public int ShowQuests
        {
            get { return _ShowQuests; }
            set
            {
                _ShowQuests = value;
                try
                {
                    if (value == 1) VenoX.TriggerClientEvent((VnXPlayer)Player, "Quests:Show", true);
                    else VenoX.TriggerClientEvent((VnXPlayer)Player, "Quests:Show", false);
                    Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_QUEST_ANZEIGEN, value);
                }
                catch { }
            }
        }
        private int _ShowReporter { get; set; }
        public int ShowReporter { get { return _ShowReporter; } set { _ShowReporter = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REPORTER_ANZEIGEN, value); } }
        private int _ShowGlobalChat { get; set; }
        public int ShowGlobalChat { get { return _ShowGlobalChat; } set { _ShowGlobalChat = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_GLOBALCHAT_ANZEIGEN, value); } }

        public Settings(Player player)
        {
            try
            {
                Player = player;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }

}
