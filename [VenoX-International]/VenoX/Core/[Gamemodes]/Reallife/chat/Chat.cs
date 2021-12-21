using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Preload_;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;

namespace VenoXV.Reallife.chat
{
    public static class ReallifeChat
    {
        public static void SendReallifeMessage(this VnXPlayer player, string text)
        {
            try
            {
                player.SendChatMessage(text);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SendReallifeMessageToAll(string text)
        {
            try
            {
                foreach (VnXPlayer player in Main.ReallifePlayers.ToList())
                {
                    player.SendChatMessage(text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
    public class Chat : IScript
    {
        [CommandEvent(CommandEventType.CommandNotFound)]
        public static void OnPlayerCommandNotFoundHandler(VnXPlayer player, string command)
        {
            try
            {
                player.SendChatMessage("[VenoX-Command-System] : " + RageApi.GetHexColorcode(0, 200, 255) + "/" + command + RageApi.GetHexColorcode(255, 255, 255) + " not found...");
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        private static async void SendMessageToNearbyPlayers(VnXPlayer player, string message, int type, float range, bool excludePlayer = false)
        {
            try
            {
                //VenoX.TriggerClientEvent(player,"ScoreBoard_Allow");
                string secondMessage = string.Empty;
                float distanceGap = range / Constants.ChatRanges;

                if (message.Length > Constants.ChatLength)
                {
                    secondMessage = message.Substring(Constants.ChatLength, message.Length - Constants.ChatLength);
                    message = message.Remove(Constants.ChatLength, secondMessage.Length);
                }

                string messageSendDateString = "[" + DateTime.Now.ToString("hh:mm:ss") + "] ";

                foreach (VnXPlayer target in VenoX.GetAllPlayers().ToList())
                {
                    if (!target.Playing || player.Dimension != target.Dimension) continue;
                    if (player == target && (player != target || excludePlayer)) continue;
                    float distance = player.Position.Distance(target.Position);
                    if (distance <= range)
                    {
                        string chatMessageRgba = GetChatMessageRgba(distance, distanceGap);

                        switch (type)
                        {
                            case Constants.MessageTalk:
                                string sayingString = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) target.Language, "sagt :");
                                target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba +  player.Username + " " + sayingString + " " +  message + "..." : chatMessageRgba + messageSendDateString + player.Username + " " + sayingString + " " + message);
                                if (secondMessage.Length > 0)
                                {
                                    target.SendChatMessage(chatMessageRgba + secondMessage);
                                }
                                break;
                            case Constants.MessageYell:
                                string yellingString = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) target.Language, "schreit :");
                                target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba +  player.Username  + " " + yellingString + " " + message + "..." : chatMessageRgba + messageSendDateString + player.Username  + " " + yellingString + " " + message + "!!!");
                                if (secondMessage.Length > 0)
                                {
                                    target.SendChatMessage(chatMessageRgba + secondMessage + "!!!");
                                }
                                break;
                            case Constants.MessageWhisper:
                                string whisperString = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) target.Language, "flüstert :");
                                target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.Username + " " + whisperString + " " + message + "..." : chatMessageRgba + messageSendDateString + player.Username + " " + whisperString + " " + message);
                                if (secondMessage.Length > 0)
                                {
                                    target.SendChatMessage(chatMessageRgba + secondMessage);
                                }
                                break;
                        }
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        private static string GetChatMessageRgba(float distance, float distanceGap)
        {
            string rgba = null;
            if (distance < distanceGap)
            {
                rgba = Constants.RgbaChatClose;
            }
            else if (distance < distanceGap * 2)
            {
                rgba = Constants.RgbaChatNear;
            }
            else if (distance < distanceGap * 3)
            {
                rgba = Constants.RgbaChatMedium;
            }
            else if (distance < distanceGap * 4)
            {
                rgba = Constants.RgbaChatFar;
            }
            else
            {
                rgba = Constants.RgbaChatLimit;
            }
            return rgba;
        }


        //[ServerEvent(Event.ChatMessage)]
        [VenoXRemoteEvent("chat:message")]
        public void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                if (message[0].ToString() == "/") return;
                switch (player.Gamemode)
                {
                    //else { Core.Debug.OutputDebugString(message[0].ToString()); }
                    case (int)Preload.Gamemodes.Tactics:
                        _Gamemodes_.Tactics.chat.Chat.OnChatMessage(player, message);
                        break;
                    case (int)Preload.Gamemodes.SevenTowers:
                        _Gamemodes_.SevenTowers.globals.Chat.OnChatMessage(player, message);
                        break;
                    default:
                    {
                        if (player.Playing == false)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                        }
                        else if (player.Dead != 0)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                        }
                        else
                        {
                            SendMessageToNearbyPlayers(player, message, Constants.MessageTalk, player.Dimension > 0 ? 7.5f : 10.0f);
                            //Console.WriteLine("[ID:" + player.Id + "]" + player.Username + "say" + message);
                            Logfile.WriteLogs("chat", "[ " + player.Username + " ] sagt : " + message);
                        }

                        break;
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("say", true)]
        public void DecirCommand(VnXPlayer player, string message)
        {
            try
            {
                if (player.VnxGetElementData<int>(EntityData.PlayerKilled) != 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                }
                else
                {
                    SendMessageToNearbyPlayers(player, message, Constants.MessageTalk, player.Dimension > 0 ? 7.5f : 10.0f);
                    Logfile.WriteLogs("chat", "[ " + player.SocialClubId + " ]" + "[ " + player.Username + " ] sagt : " + message);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
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
                    SendMessageToNearbyPlayers(player, message, Constants.MessageYell, 45.0f);
                    Logfile.WriteLogs("chat", "[ " + player.SocialClubId + " ]" + "[ " + player.Username + " ] schreit : " + message + " !!!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
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
                    SendMessageToNearbyPlayers(player, message, Constants.MessageWhisper, 3.0f);
                    Logfile.WriteLogs("chat", "[ " + player.SocialClubId + " ]" + "[ " + player.Username + " ] flüstert : " + message + " ...");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
