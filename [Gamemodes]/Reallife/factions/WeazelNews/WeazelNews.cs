using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.Factions.WeazelNews
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
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keinen Arbeitskollegen Interviewn.");
                        return;
                    }*/
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "Du hast " + target.Username + " eine Anfrage geschickt!");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat dir eine Live Anfrage gesendet!");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + "Nutze /acceptlive " + player.Username + " um Live zu gehen");
                    target.VnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", player.Username);
                    player.VnxSetElementData("LIVE_ANFrAGE_GESENDET_AN", target.Username);
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Du bist kein Reporter!");
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
                if (player.VnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON") == target.Username)
                {
                    player.VnxSetStreamSharedElementData("settings_reporter", "ja");
                    target.VnxSetStreamSharedElementData("settings_reporter", "ja");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + "Du bist nun Live mit " + target.Username + "!");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + "Nutze /live [Text] um das Interview durchzuführen!");
                    target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 175, 0) + player.Username + " hat deine Live Anfrage Bestätigt! Ihr seid nun Live! Nutze /live [Text] um ein Interview durchzuführen!");
                    player.VnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                    target.VnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Du hast keine Live Anfrage von " + target.Username + " erhalten!");
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
                    foreach (VnXPlayer targetsingame in _Globals_.Main.ReallifePlayers.ToList())
                    {
                        if (targetsingame.VnxGetElementData<int>("settings_reporter") == 1)
                        {
                            targetsingame.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                        }
                    }
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Du bist in keinem Interview!");
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
                    foreach (VnXPlayer targetsingame in _Globals_.Main.ReallifePlayers.ToList())
                    {
                        if (targetsingame.VnxGetElementData<int>("settings_reporter") == 1)
                        {
                            targetsingame.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat das Live interview beendet.");
                        }
                    }
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

    }
}
