using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.advertise
{
    public class Werbung : IScript
    {
        public static DateTime WERBUNG_COOLDOWN;
        public static int WERBUNG_MINUTES_COOLDOWN = 1;
        public static bool ADS_ACTIVATED = true;
        public static int MINDEST_SPIELZEIT_ = 30;
        public static int AD_COSTS = 5;

        [Command("ad", true)]
        public static void CreateAD(Client player, string text)
        {
            if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) >= MINDEST_SPIELZEIT_)
            {
                if (ADS_ACTIVATED)
                {
                    if (WERBUNG_COOLDOWN <= DateTime.Now)
                    {
                        int FINAL_AD_COSTS = text.Length * AD_COSTS;
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) > FINAL_AD_COSTS)
                        {
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 200, 255) + " __________________________________________");
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 200, 255) + " [Werbung] : " + RageAPI.GetHexColorcode(255, 255, 255) + text);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 200, 255) + " Von : " + RageAPI.GetHexColorcode(255, 255, 255) + player.GetVnXName() + " | " + RageAPI.GetHexColorcode(0, 200, 255) + " Handy : " + RageAPI.GetHexColorcode(255, 255, 255) + "V.2.0.0 INCOMING");
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 200, 255) + " __________________________________________");
                            WERBUNG_COOLDOWN = DateTime.Now.AddMinutes(WERBUNG_MINUTES_COOLDOWN);

                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - FINAL_AD_COSTS);
                            dxLibary.VnX.DrawNotification(player, "info", "Du hast " + FINAL_AD_COSTS + " $ für deine Werbung Gezahlt!");
                        }
                        else { dxLibary.VnX.DrawNotification(player, "info", "Du hast nicht genug Geld!"); }
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Nächste AD Möglich : " + WERBUNG_COOLDOWN); }
                }
                else { dxLibary.VnX.DrawNotification(player, "error", "Das AD-System wurde von einem Moderator deaktiviert!"); }
            }
            else { dxLibary.VnX.DrawNotification(player, "error", "Du brauchst mindestens 30 Spielstunden!"); }
        }

        [Command("werbung", true)]
        public static void CreateWerbung(Client player, string text)
        {
            CreateAD(player, text);
        }
    }
}
