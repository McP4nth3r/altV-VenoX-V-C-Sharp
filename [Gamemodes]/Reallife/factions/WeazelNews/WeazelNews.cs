using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions.WeazelNews
{
    public class WeazelNews : IScript
    {
        [Command("requestlive")]
        public void SendIPlayerLiveOffer(PlayerModel player, string target_name)
        {
            try
            {
                PlayerModel target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                {
                    /*if(target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du kannst keinen Arbeitskollegen Interviewn.");
                        return;
                    }*/
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Du hast " + target.GetVnXName() + " eine Anfrage geschickt!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName() + " hat dir eine Live Anfrage gesendet!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + "Nutze /acceptlive " + player.GetVnXName() + " um Live zu gehen");
                    target.vnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", player.GetVnXName());
                    player.vnxSetElementData("LIVE_ANFrAGE_GESENDET_AN", target.GetVnXName());
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Reporter!");
                }
            }
            catch
            {
            }
        }

        [Command("acceptlive")]
        public void AcceptLiveOffcer(PlayerModel player, string target_name)
        {
            try
            {
                PlayerModel target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON") == target.GetVnXName())
                {
                    player.vnxSetStreamSharedElementData("settings_reporter", "ja");
                    target.vnxSetStreamSharedElementData("settings_reporter", "ja");
                    player.SendChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + "Du bist nun Live mit " + target.GetVnXName() + "!");
                    player.SendChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + "Nutze /live [Text] um das Interview durchzuführen!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(175, 175, 0) + player.GetVnXName() + " hat deine Live Anfrage Bestätigt! Ihr seid nun Live! Nutze /live [Text] um ein Interview durchzuführen!");
                    player.vnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                    target.vnxSetElementData("PLAYER_IS_LIVE", "TRUE");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Live Anfrage von " + target.GetVnXName() + " erhalten!");
                }
            }
            catch
            {
            }
        }

        [Command("live", true)]
        public void SendLiveMessage(PlayerModel player, string text)
        {
            try
            {
                if (player.vnxGetElementData<bool>("PLAYER_IS_LIVE") == true)
                {
                    foreach (IPlayer targetsingame in Alt.GetAllPlayers())
                    {
                        if (targetsingame.vnxGetElementData<string>("settings_reporter") == "ja")
                        {
                            targetsingame.SendChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName() + " : " + text);
                        }
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

        [Command("endlive")]
        public void EndLiveReporter(PlayerModel player)
        {
            try
            {

                if (player.vnxGetElementData<bool>("PLAYER_IS_LIVE") == true)
                {
                    string targetName = player.vnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON");
                    //RageAPI.SendChatMessageToAll("Live Anfrage ist von : " + player.vnxGetElementData("LIVE_ANFRAGE_ERHALTEN_VON"));
                    PlayerModel target = RageAPI.GetPlayerFromName(targetName);
                    player.vnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    target.vnxSetElementData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    foreach (IPlayer targetsingame in Alt.GetAllPlayers())
                    {
                        if (targetsingame.vnxGetElementData<string>("settings_reporter") == "ja")
                        {
                            targetsingame.SendChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName() + " hat das Live interview beendet.");
                        }
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Interview!");
                }
            }
            catch
            {
            }
        }

    }
}
