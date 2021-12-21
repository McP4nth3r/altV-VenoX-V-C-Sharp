using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.advertise
{
    public class Werbung : IScript
    {
        public static DateTime WerbungCooldown;
        public static int WerbungMinutesCooldown = 1;
        public static bool AdsActivated = true;
        public static int MindestSpielzeit = 30;
        public static int AdCosts = 5;

        [Command("ad", true)]
        public static void CreateAd(VnXPlayer player, string text)
        {
            if (player.Played >= MindestSpielzeit)
            {
                if (AdsActivated)
                {
                    if (WerbungCooldown <= DateTime.Now)
                    {
                        int finalAdCosts = text.Length * AdCosts;
                        if (player.Reallife.Money > finalAdCosts)
                        {
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 200, 255) + " __________________________________________");
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 200, 255) + " [Werbung] : " + RageApi.GetHexColorcode(255, 255, 255) + text);
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 200, 255) + " Von : " + RageApi.GetHexColorcode(255, 255, 255) + player.Username + " | " + RageApi.GetHexColorcode(0, 200, 255) + " Handy : " + RageApi.GetHexColorcode(255, 255, 255) + "V.2.0.0 INCOMING");
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 200, 255) + " __________________________________________");
                            WerbungCooldown = DateTime.Now.AddMinutes(WerbungMinutesCooldown);

                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - finalAdCosts);
                            Main.DrawNotification(player, Main.Types.Info, "Du hast " + finalAdCosts + " $ für deine Werbung Gezahlt!");
                        }
                        else { Main.DrawNotification(player, Main.Types.Info, "Du hast nicht genug Geld!"); }
                    }
                    else { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Nächste AD Möglich : " + WerbungCooldown); }
                }
                else { Main.DrawNotification(player, Main.Types.Error, "Das AD-System wurde von einem Moderator deaktiviert!"); }
            }
            else { Main.DrawNotification(player, Main.Types.Error, "Du brauchst mindestens 30 Spielstunden!"); }
        }

        [Command("werbung", true)]
        public static void CreateWerbung(VnXPlayer player, string text)
        {
            CreateAd(player, text);
        }
    }
}
