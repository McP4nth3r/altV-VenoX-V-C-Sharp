using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Gamemodes_.Reallife.factions.WeazelNews
{
    public class WeazelNews : IScript
    {
        [Command("requestlive")]
        public void SendIPlayerLiveOffer(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.Reallife.Faction == Constants.FactionNews)
                {
                    /*if(target.Reallife.Faction == Constants.FACTION_NEWS)
                    {
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du kannst keinen Arbeitskollegen Interviewn.");
                        return;
                    }*/
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "Du hast " + target.CharacterUsername + " eine Anfrage geschickt!");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat dir eine Live Anfrage gesendet!");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + "Nutze /acceptlive " + player.CharacterUsername + " um Live zu gehen");
                    target.VnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", player.CharacterUsername);
                    player.VnxSetElementData("LIVE_ANFrAGE_GESENDET_AN", target.CharacterUsername);
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist kein Reporter!");
                }
            }
            catch
            {
            }
        }

        [Command("acceptlive")]
        public void AcceptLiveOffcer(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.VnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON") == target.CharacterUsername)
                {
                    player.VnxSetStreamSharedElementData("settings_reporter", "ja");
                    target.VnxSetStreamSharedElementData("settings_reporter", "ja");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + "Du bist nun Live mit " + target.CharacterUsername + "!");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + "Nutze /live [Text] um das Interview durchzuführen!");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + player.CharacterUsername + " hat deine Live Anfrage Bestätigt! Ihr seid nun Live! Nutze /live [Text] um ein Interview durchzuführen!");
                    player.VnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                    target.VnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du hast keine Live Anfrage von " + target.CharacterUsername + " erhalten!");
                }
            }
            catch
            {
            }
        }

        [Command("live", true)]
        public void SendLiveMessage(VnXPlayer player, string text)
        {
            try
            {
                if (player.VnxGetElementData<bool>("PLAYER_IS_LIVE"))
                {
                    foreach (VnXPlayer targetsingame in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.ReallifePlayers))
                    {
                        if (targetsingame.VnxGetElementData<int>("settings_reporter") == 1)
                        {
                            targetsingame.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " : " + text);
                        }
                    }
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

        [Command("endlive")]
        public void EndLiveReporter(VnXPlayer player)
        {
            try
            {

                if (player.VnxGetElementData<bool>("PLAYER_IS_LIVE"))
                {
                    string targetName = player.VnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON");
                    //RageAPI.SendTranslatedChatMessageToAll("Live Anfrage ist von : " + player.vnxGetElementData("LIVE_ANFRAGE_ERHALTEN_VON"));
                    VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                    player.VnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    target.VnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    foreach (VnXPlayer targetsingame in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.ReallifePlayers))
                    {
                        if (targetsingame.VnxGetElementData<int>("settings_reporter") == 1)
                        {
                            targetsingame.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat das Live interview beendet.");
                        }
                    }
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

    }
}
