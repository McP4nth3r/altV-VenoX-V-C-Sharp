using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.factions.WeazelNews
{
    public class WeazelNews : IScript
    {
        [Command("requestlive")]
        public void SendIPlayerLiveOffer(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                {
                    /*if(target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du kannst keinen Arbeitskollegen Interviewn.");
                        return;
                    }*/
                    player.SendChatMessage( RageAPI.GetHexColorcode(0,175,0) + "Du hast " + target.GetVnXName<string>() + " eine Anfrage geschickt!");
                   target.SendChatMessage( RageAPI.GetHexColorcode(175,175,0) + Faction.GetPlayerFactionRank(player) + " | " +player.GetVnXName<string>() + " hat dir eine Live Anfrage gesendet!");
                   target.SendChatMessage( RageAPI.GetHexColorcode(175,175,0) + "Nutze /acceptlive " +player.GetVnXName<string>() + " um Live zu gehen");
                    target.SetData("LIVE_ANFRAGE_ERHALTEN_VON",player.GetVnXName<string>());
                    player.SetData("LIVE_ANFrAGE_GESENDET_AN", target.GetVnXName<string>());
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
        public void AcceptLiveOffcer(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON") == target.GetVnXName<string>())
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_reporter", "ja");
                    Core.VnX.SetSharedSettingsData(target, "settings_reporter", "ja");
                    player.SendChatMessage( RageAPI.GetHexColorcode(175,175,0) + "Du bist nun Live mit " + target.GetVnXName<string>() + "!");
                    player.SendChatMessage( RageAPI.GetHexColorcode(175,175,0)+"Nutze /live [Text] um das Interview durchzuführen!");
                   target.SendChatMessage( RageAPI.GetHexColorcode(175,175,0) + player.GetVnXName<string>() + " hat deine Live Anfrage Bestätigt! Ihr seid nun Live! Nutze /live [Text] um ein Interview durchzuführen!");
                    player.SetData("PLAYER_IS_LIVE", "TRUE");
                    target.SetData("PLAYER_IS_LIVE", "TRUE");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Live Anfrage von " + target.GetVnXName<string>() + " erhalten!");
                }
            }
            catch
            {
            }
        }

        [Command("live",  true)]
        public void SendLiveMessage(IPlayer player, string text)
        {
            try
            {
                if (player.vnxGetElementData<bool>("PLAYER_IS_LIVE") == true)
                {
                    foreach (IPlayer targetsingame in Alt.GetAllPlayers())
                    {
                        if (targetsingame.vnxGetElementData<string>("settings_reporter") == "ja")
                        {
                            targetsingame.SendChatMessage( RageAPI.GetHexColorcode(200,200,0)+ Faction.GetPlayerFactionRank(player) + " | " +player.GetVnXName<string>() + " : " + text);
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
        public void EndLiveReporter(IPlayer player)
        {
            try
            {

                if (player.vnxGetElementData<bool>("PLAYER_IS_LIVE") == true)
                {
                    string targetName = player.vnxGetElementData<string>("LIVE_ANFRAGE_ERHALTEN_VON");
                    //Reallife.Core.RageAPI.SendChatMessageToAll("Live Anfrage ist von : " + player.vnxGetElementData("LIVE_ANFRAGE_ERHALTEN_VON"));
                    IPlayer target = Reallife.Core.RageAPI.GetPlayerFromName(targetName);
                    player.SetData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    target.SetData("LIVE_ANFRAGE_ERHALTEN_VON", "false");
                    foreach (IPlayer targetsingame in Alt.GetAllPlayers())
                    {
                        if (targetsingame.vnxGetElementData<string>("settings_reporter") == "ja")
                        {
                            targetsingame.SendChatMessage( RageAPI.GetHexColorcode(200,200,0) + Faction.GetPlayerFactionRank(player) + " | " +player.GetVnXName<string>() + " hat das Live interview beendet.");
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
