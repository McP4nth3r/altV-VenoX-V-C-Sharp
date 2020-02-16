using AltV.Net.Elements.Entities;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.factions;
using System.Linq;
using System;
using VenoXV.Reallife.vnx_stored_files;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Core;
using AltV.Net.Resources.Chat.Api;
using AltV.Net;

namespace VenoXV.Reallife.chat
{
    public class Chat : IScript
    {
        public static void SendMessageToNearbyPlayers(IPlayer player, string message, int type, float range, bool excludePlayer = false)
        {
            try
            {
                if(player.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == true)
                {
                    return;
                }
                player.Emit("ScoreBoard_Allow");
                string secondMessage = string.Empty;
                float distanceGap = range / Constants.CHAT_RANGES;

                if (message.Length > Constants.CHAT_LENGTH)
                {
                    secondMessage = message.Substring(Constants.CHAT_LENGTH, message.Length - Constants.CHAT_LENGTH);
                    message = message.Remove(Constants.CHAT_LENGTH, secondMessage.Length);
                }

                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) && player.Dimension == target.Dimension)
                    {
                        if (player != target || (player == target && !excludePlayer))
                        {
                            float distance = player.Position.Distance(target.Position);

                            if (distance <= range)
                            {
                                string chatMessageRgba = GetChatMessageRgba(distance, distanceGap);

                                switch (type)
                                {
                                    case Constants.MESSAGE_TALK:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba +player.GetVnXName<string>() + " sagt : " + message + "..." : chatMessageRgba +player.GetVnXName<string>() + " sagt : " + message);
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage);
                                        }
                                        break;
                                    case Constants.MESSAGE_YELL:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba +player.GetVnXName<string>() + " schreit : " + message + "..." : chatMessageRgba +player.GetVnXName<string>() + " schreit : " + message + "!!!");
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage + "!!!");
                                        }
                                        break;
                                    case Constants.MESSAGE_WHISPER:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba +player.GetVnXName<string>() + " flüstert : " + message + "..." : chatMessageRgba +player.GetVnXName<string>() + " flüstert : " + message);
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        
        private static string GetChatMessageRgba(float distance, float distanceGap)
        {
            string Rgba = null;
            if (distance < distanceGap)
            {
                Rgba = Constants.Rgba_CHAT_CLOSE;
            }
            else if (distance < distanceGap * 2)
            {
                Rgba = Constants.Rgba_CHAT_NEAR;
            }
            else if (distance < distanceGap * 3)
            {
                Rgba = Constants.Rgba_CHAT_MEDIUM;
            }
            else if (distance < distanceGap * 4)
            {
                Rgba = Constants.Rgba_CHAT_FAR;
            }
            else
            {
                Rgba = Constants.Rgba_CHAT_LIMIT;
            }
            return Rgba;
        }
        

        //[ServerEvent(Event.ChatMessage)]
        public void OnChatMessage(IPlayer player, string message)
        {
            try
            {
                if(player.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_GAMEMODE) == globals.EntityData.GAMEMODE_TACTICS)
                {
                    Tactics.chat.Chat.OnChatMessage(player, message);
                }
                else if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == false)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_TALK, player.Dimension > 0 ? 7.5f : 10.0f);
                    Console.WriteLine("[ID:" + player.Id + "]" +player.GetVnXName<string>() + "say" + message);
                    logfile.WriteLogs("chat", "[ " +player.GetVnXName<string>() + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("say",  true)]
        public void DecirCommand(IPlayer player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_TALK, player.Dimension > 0 ? 7.5f : 10.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.GetVnXName<string>() + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("s",  true)]
        public void GritarCommand(IPlayer player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_YELL, 45.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.GetVnXName<string>() + " ] schreit : " + message + " !!!");
                }
            }
            catch { }
        }

        [Command("l",  true)]
        public void SusurrarCommand(IPlayer player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_WHISPER, 3.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.GetVnXName<string>() + " ] flüstert : " + message + " ...");
                }
            }
            catch { }
        }
    }
}
