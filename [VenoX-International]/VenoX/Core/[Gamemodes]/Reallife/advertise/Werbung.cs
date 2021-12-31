using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Globals_;
using VenoXV._Preload_;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.advertise
{
    public class Werbung : IScript
    {
        private static DateTime WerbungCooldown;
        private static int WerbungMinutesCooldown = 1;
        private static bool AdsActivated = true;
        private static int MinimumPlayTime = 30;
        private static int AdCosts = 5;

        [Command("ad", true)]
        public static void CreateAd(VnXPlayer player, string text)
        {
            if (player.Played >= MinimumPlayTime)
            {
                if (AdsActivated)
                {
                    if (WerbungCooldown <= DateTime.Now)
                    {
                        int finalAdCosts = text.Length * AdCosts;
                        if (player.Reallife.Money > finalAdCosts)
                        {

                            foreach (var players in from players in VenoX.GetAllPlayers() where players.Gamemode == (int)Preload.Gamemodes.Reallife where players.Gamemode == player.Gamemode where players.Language != player.Language select players)
                            {
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " __________________________________________");
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Advertisement] : " + RageApi.GetHexColorcode(255, 255, 255) + text);
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " From : " + RageApi.GetHexColorcode(255, 255, 255) + player.Username + " | " + RageApi.GetHexColorcode(0, 200, 255) + " Phone : " + RageApi.GetHexColorcode(255, 255, 255) + player.Phone.Number);
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " __________________________________________");
                            }
                            
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
    }
}
