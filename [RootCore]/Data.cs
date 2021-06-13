﻿using System;
using AltV.Net;
using VenoXV._Globals_;
using VenoXV.Models;

namespace VenoXV.Core
{

    public class VnX : IScript
    {
        public static object Usefull { get; internal set; }
        public static string PlayerMoney = EntityData.PlayerMoney;
        public static string PlayerBankmoney = EntityData.PlayerBank;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Der Spieler wird Definiert.</param>
        /// <param name="args">[0] = Element Name, [1] = value für die Element Data, [2] Type der Value, [3] = TimeInMS (TimeOut-JS-CS)</param>
        public static void SetDelayedData(VnXPlayer player, object[] args)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "delay_element_data", args[0], args[1], args[2], args[3]);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
