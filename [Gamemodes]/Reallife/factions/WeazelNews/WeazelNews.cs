using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions.WeazelNews
{
    public class WeazelNews : IScript
    {
        [Command("requestlive")]
        public void SendIPlayerLiveOffer(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Reallife.Faction == Constants.FACTION_NEWS)
                {
                    /*if(target.Reallife.Faction == Constants.FACTION_NEWS)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keinen Arbeitskollegen Interviewn.");
                        return;
                    }*/
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Du hast " + target.Username + " eine Anfrage geschickt!");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat dir eine Live Anfrage gesendet!");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + "Nutze /acceptlive " + player.Username + " um Live zu gehen");
                    target.vnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", player.Username);
                    player.vnxSetElementData("LIVE_ANFrAGE_GESENDET_AN", target.Username);
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Reporter!");
                }
            }
            catch
            {
            }
        }

        [Command("acceptlive")]
        public void AcceptLiveOffcer(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON") == target.Username)
                {
                    player.vnxSetStreamSharedElementData("settings_reporter", "ja");
                    target.vnxSetStreamSharedElementData("settings_reporter", "ja");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + "Du bist nun Live mit " + target.Username + "!");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + "Nutze /live [Text] um das Interview durchzuführen!");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + player.Username + " hat deine Live Anfrage Bestätigt! Ihr seid nun Live! Nutze /live [Text] um ein Interview durchzuführen!");
                    player.vnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                    target.vnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keine Live Anfrage von " + target.Username + " erhalten!");
                }
            }
            catch
            {
            }
        }

        [Command("live", true)]
        public void SendLiveMessage(Client player, string text)
        {
            try
            {
                if (player.vnxGetElementData<bool>("PLAYER_IS_LIVE") == true)
                {
                    foreach (Client targetsingame in Alt.GetAllPlayers())
                    {
                        if (targetsingame.vnxGetElementData<int>("settings_reporter") == 1)
                        {
                            targetsingame.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                        }
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

        [Command("endlive")]
        public void EndLiveReporter(Client player)
        {
            try
            {

                if (player.vnxGetElementData<bool>("PLAYER_IS_LIVE") == true)
                {
                    string targetName = player.vnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON");
                    //RageAPI.SendTranslatedChatMessageToAll("Live Anfrage ist von : " + player.vnxGetElementData("LIVE_ANFRAGE_ERHALTEN_VON"));
                    Client target = RageAPI.GetPlayerFromName(targetName);
                    player.vnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    target.vnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    foreach (Client targetsingame in Alt.GetAllPlayers())
                    {
                        if (targetsingame.vnxGetElementData<int>("settings_reporter") == 1)
                        {
                            targetsingame.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat das Live interview beendet.");
                        }
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

    }
}
