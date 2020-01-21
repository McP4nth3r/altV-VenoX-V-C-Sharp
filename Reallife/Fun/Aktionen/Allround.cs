using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV.Reallife.Fun
{
    public class Allround : IScript
    {
        public static bool AktionAmLaufen_Server = false;
        public static DateTime AktionsTimer = DateTime.Now;
        public static DateTime AktionGestartet = DateTime.Now;
        public static bool AktionAmLaufen(IPlayer player)
        {
            try
            {
                if (AktionAmLaufen_Server)
                {
                    player.SendChatMessage( "!{175,0,0}Es Läuft bereits eine Aktion!");
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public static bool AktionAmLaufen_Server_(IPlayer player)
        {
            try
            {
                if (AktionAmLaufen_Server)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public static void ChangeAktionsState(bool aktionamlaufen)
        {
            AktionAmLaufen_Server = aktionamlaufen;
        }

        public static bool isAktionPossible(IPlayer player)
        {
            try
            {
                if (AktionsTimer > DateTime.Now)
                {
                    player.SendChatMessage( "!{125,0,0}Es lief bereits eine Aktion vor kurzem! Nächste Aktion möglich : " + AktionsTimer);
                    return false;
                }
                return true;
            }
            catch { return false; }
        }

        public static void ChangeAktionsTimer(DateTime datetime)
        {
            try
            {
                AktionsTimer = datetime;
            }
            catch {}
        }

        public static void OnResourceStart()
        {
            Kokaintruck.OnResourceStart();
            Aktionen.Kokain.KokainSell.OnResourceStart();
            Aktionen.Shoprob.Shoprob.OnResourceStart();
        }
    }
}
