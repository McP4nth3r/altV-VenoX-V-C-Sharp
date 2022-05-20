﻿using System;
using AltV.Net.Elements.Entities;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models.SubClasses.PlayerModel
{
    public class Settings
    {
        private readonly Player _client;
        private int _ShowAtm { get; set; }
        public int ShowAtm { get => _ShowAtm;
            set { _ShowAtm = value; _client.VnxSetStreamSharedElementData(EntityData.PlayerAtmAnzeigen, value); } }
        private int _ShowHouse { get; set; }
        public int ShowHouse { get => _ShowHouse;
            set { _ShowHouse = value; _client.VnxSetStreamSharedElementData(EntityData.PlayerHausAnzeigen, value); } }
        
        
        private int _Speedometer { get; set; }
        public int Speedometer
        {
            get => _Speedometer;
            set
            {
                _Speedometer = value;
                VenoX.TriggerClientEvent((VnXPlayer) _client, "Speedometer:Create", value);
            }
        }
        
        private int _ScoreboardBackground { get; set; }
        public int ScoreboardBackground
        {
            get => _ScoreboardBackground;
            set
            {
                _ScoreboardBackground = value;
                VenoX.TriggerClientEvent((VnXPlayer) _client, "Speedometer:Create", value);
            }
        }

        private int _ShowQuests { get; set; }
        public int ShowQuests
        {
            get => _ShowQuests;
            set
            {
                _ShowQuests = value;
                try
                {
                    VenoX.TriggerClientEvent((VnXPlayer) _client, "Quests:Show", value == 1);
                    _client.VnxSetStreamSharedElementData(EntityData.PlayerQuestAnzeigen, value);
                }
                catch
                {
                    // ignored
                }
            }
        }
        private int _ShowReporter { get; set; }
        public int ShowReporter { get => _ShowReporter;
            set { _ShowReporter = value; _client.VnxSetStreamSharedElementData(EntityData.PlayerReporterAnzeigen, value); } }
        private int _ShowGlobalChat { get; set; }
        public int ShowGlobalChat { get => _ShowGlobalChat;
            set { _ShowGlobalChat = value; _client.VnxSetStreamSharedElementData(EntityData.PlayerGlobalchatAnzeigen, value); } }

        private int _ReallifeHud{ get; set; }
        public int ReallifeHud
        {
            get => _ReallifeHud;
            set
            {
                _ReallifeHud = value;
                VenoX.TriggerClientEvent((VnXPlayer)_client, "Reallife:LoadHUD", value);
            }
        }
        
        public Settings(Player player)
        {
            try
            {
                _client = player;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }

}
