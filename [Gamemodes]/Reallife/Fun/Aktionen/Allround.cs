using AltV.Net;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun
{
    public class Allround : IScript
    {
        public static bool AKTION_AM_LAUFEN = false;
        public static DateTime AktionsTimer = DateTime.Now;
        public static DateTime AktionGestartet = DateTime.Now;
        public static bool AktionAmLaufen(Client player)
        {
            try
            {
                if (AKTION_AM_LAUFEN)
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Es Läuft bereits eine Aktion!");
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public static void ChangeAktionsState(bool aktionamlaufen)
        {
            AKTION_AM_LAUFEN = aktionamlaufen;
        }

        public static bool isAktionPossible(Client player)
        {
            try
            {
                if (AktionsTimer > DateTime.Now)
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "Es lief bereits eine Aktion vor kurzem! Nächste Aktion möglich : " + AktionsTimer);
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
            catch { }
        }

        public static void OnResourceStart()
        {
            Kokaintruck.OnResourceStart();
            Aktionen.Kokain.KokainSell.OnResourceStart();
            Aktionen.Shoprob.Shoprob.OnResourceStart();
        }
    }
}
