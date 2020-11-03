using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Chat
{
    public static class ReallifeChat
    {
        public static void SendReallifeMessage(this VnXPlayer player, string text)
        {
            try
            {
                player.SendChatMessage(text);
            }
            catch { }
        }
        public static void SendReallifeMessageToAll(string text)
        {
            try
            {
                foreach (VnXPlayer player in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    player.SendChatMessage(text);
                }
            }
            catch { }
        }
    }
    public class Chat : IScript
    {
        [CommandEvent(CommandEventType.CommandNotFound)]
        public static void OnPlayerCommandNotFoundHandler(VnXPlayer player, string Command)
        {
            try
            {
                player.SendChatMessage("[VenoX-Command-System] : " + RageAPI.GetHexColorcode(0, 200, 255) + "/" + Command + RageAPI.GetHexColorcode(255, 255, 255) + " not found...");
            }
            catch { }
        }
        public static void SendMessageToNearbyPlayers(VnXPlayer player, string message, int type, float range, bool excludePlayer = false)
        {
            try
            {
                //VenoX.TriggerClientEvent(player,"ScoreBoard_Allow");
                string secondMessage = string.Empty;
                float distanceGap = range / Constants.CHAT_RANGES;

                if (message.Length > Constants.CHAT_LENGTH)
                {
                    secondMessage = message.Substring(Constants.CHAT_LENGTH, message.Length - Constants.CHAT_LENGTH);
                    message = message.Remove(Constants.CHAT_LENGTH, secondMessage.Length);
                }

                foreach (VnXPlayer target in VenoX.GetAllPlayers().ToList())
                {
                    if (target.Playing && player.Dimension == target.Dimension)
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
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.Username + " sagt : " + message + "..." : chatMessageRgba + player.Username + " sagt : " + message);
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage);
                                        }
                                        break;
                                    case Constants.MESSAGE_YELL:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.Username + " schreit : " + message + "..." : chatMessageRgba + player.Username + " schreit : " + message + "!!!");
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage + "!!!");
                                        }
                                        break;
                                    case Constants.MESSAGE_WHISPER:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.Username + " flüstert : " + message + "..." : chatMessageRgba + player.Username + " flüstert : " + message);
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
        [ClientEvent("chat:message")]
        public void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                if (message[0].ToString() == "/") { return; }
                else { Core.Debug.OutputDebugString(message[0].ToString()); }
                if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Tactics)
                {
                    Tactics.chat.Chat.OnChatMessage(player, message);
                }
                else if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.SevenTowers)
                {
                    SevenTowers.globals.Chat.OnChatMessage(player, message);
                }
                else if (player.Playing == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else if (player.Dead != 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_TALK, player.Dimension > 0 ? 7.5f : 10.0f);
                    Console.WriteLine("[ID:" + player.Id + "]" + player.Username + "say" + message);
                    logfile.WriteLogs("chat", "[ " + player.Username + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("say", true)]
        public void DecirCommand(VnXPlayer player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_TALK, player.Dimension > 0 ? 7.5f : 10.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("s", true)]
        public void GritarCommand(VnXPlayer player, string message)
        {
            try
            {
                if (player.IsDead)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_YELL, 45.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] schreit : " + message + " !!!");
                }
            }
            catch { }
        }

        [Command("l", true)]
        public void SusurrarCommand(VnXPlayer player, string message)
        {
            try
            {
                if (player.IsDead)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_WHISPER, 3.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] flüstert : " + message + " ...");
                }
            }
            catch { }
        }
    }
}
