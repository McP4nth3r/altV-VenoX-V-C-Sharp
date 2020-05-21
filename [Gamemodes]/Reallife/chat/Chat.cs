using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.chat
{
    public class Chat : IScript
    {
        [CommandEvent(CommandEventType.CommandNotFound)]
        public static void OnPlayerCommandNotFoundHandler(Client player, string Command)
        {
            try
            {
                player.SendChatMessage("[VenoX-Command-System] : /" + RageAPI.GetHexColorcode(0, 200, 255) + Command + RageAPI.GetHexColorcode(255, 255, 255) + " not found...");
            }
            catch { }
        }
        public static void SendMessageToNearbyPlayers(Client player, string message, int type, float range, bool excludePlayer = false)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == true) { return; }
                //player.Emit("ScoreBoard_Allow");
                string secondMessage = string.Empty;
                float distanceGap = range / Constants.CHAT_RANGES;

                if (message.Length > Constants.CHAT_LENGTH)
                {
                    secondMessage = message.Substring(Constants.CHAT_LENGTH, message.Length - Constants.CHAT_LENGTH);
                    message = message.Remove(Constants.CHAT_LENGTH, secondMessage.Length);
                }

                foreach (Client target in Alt.GetAllPlayers())
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
                                        target.SendTranslatedChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.GetVnXName() + " sagt : " + message + "..." : chatMessageRgba + player.GetVnXName() + " sagt : " + message);
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendTranslatedChatMessage(chatMessageRgba + secondMessage);
                                        }
                                        break;
                                    case Constants.MESSAGE_YELL:
                                        target.SendTranslatedChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.GetVnXName() + " schreit : " + message + "..." : chatMessageRgba + player.GetVnXName() + " schreit : " + message + "!!!");
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendTranslatedChatMessage(chatMessageRgba + secondMessage + "!!!");
                                        }
                                        break;
                                    case Constants.MESSAGE_WHISPER:
                                        target.SendTranslatedChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.GetVnXName() + " flüstert : " + message + "..." : chatMessageRgba + player.GetVnXName() + " flüstert : " + message);
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendTranslatedChatMessage(chatMessageRgba + secondMessage);
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
        public void OnChatMessage(Client player, string message)
        {
            try
            {
                if (message[0].ToString() == "/") { return; }
                else { Core.Debug.OutputDebugString(message[0].ToString()); }
                if (player.vnxGetElementData<string>(VenoXV.Globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.Globals.EntityData.GAMEMODE_TACTICS)
                {
                    Tactics.chat.Chat.OnChatMessage(player, message);
                }
                else if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_TALK, player.Dimension > 0 ? 7.5f : 10.0f);
                    Console.WriteLine("[ID:" + player.Id + "]" + player.GetVnXName() + "say" + message);
                    logfile.WriteLogs("chat", "[ " + player.GetVnXName() + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("say", true)]
        public void DecirCommand(Client player, string message)
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
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("s", true)]
        public void GritarCommand(Client player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_YELL, 45.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] schreit : " + message + " !!!");
                }
            }
            catch { }
        }

        [Command("l", true)]
        public void SusurrarCommand(Client player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MESSAGE_WHISPER, 3.0f);
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] flüstert : " + message + " ...");
                }
            }
            catch { }
        }
    }
}
