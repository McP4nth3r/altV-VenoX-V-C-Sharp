using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Globals_;
using VenoX.Core._Preload_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Gamemodes_.Reallife.advertise
{
    public class Werbung : IScript
    {
        private static DateTime WerbungCooldown;
        private static readonly int WerbungMinutesCooldown = 1;
        private static readonly bool AdsActivated = true;
        private static readonly int MinimumPlayTime = 30;
        private static readonly int AdCosts = 5;

        [Command("ad", true)]
        public static void CreateAd(VnXPlayer player, string text)
        {
            if (player.PlayTime >= MinimumPlayTime)
            {
                if (AdsActivated)
                {
                    if (WerbungCooldown <= DateTime.Now)
                    {
                        int finalAdCosts = text.Length * AdCosts;
                        if (player.Reallife.Money > finalAdCosts)
                        {

                            foreach (VnXPlayer players in from players in _RootCore_.VenoX.GetAllPlayers() where players.Gamemode == (int)Preload.Gamemodes.Reallife where players.Gamemode == player.Gamemode where players.Language != player.Language select players)
                            {
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " __________________________________________");
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Advertisement] : " + RageApi.GetHexColorcode(255, 255, 255) + text);
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " From : " + RageApi.GetHexColorcode(255, 255, 255) + player.CharacterUsername + " | " + RageApi.GetHexColorcode(0, 200, 255) + " Phone : " + RageApi.GetHexColorcode(255, 255, 255) + player.Phone.Number);
                                players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " __________________________________________");
                            }
                            WerbungCooldown = DateTime.Now.AddMinutes(WerbungMinutesCooldown);
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - finalAdCosts);
                            Notification.DrawNotification(player, Notification.Types.Info, "Du hast " + finalAdCosts + " $ für deine Werbung Gezahlt!");
                        }
                        else { Notification.DrawNotification(player, Notification.Types.Info, "Du hast nicht genug Geld!"); }
                    }
                    else { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Nächste AD Möglich : " + WerbungCooldown); }
                }
                else { Notification.DrawNotification(player, Notification.Types.Error, "Das AD-System wurde von einem Moderator deaktiviert!"); }
            }
            else { Notification.DrawNotification(player, Notification.Types.Error, "Du brauchst mindestens 30 Spielstunden!"); }
        }
    }
}
