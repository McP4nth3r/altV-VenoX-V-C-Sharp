﻿using AltV.Net;
using AltV.Net.Elements.Entities;
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
        public static void SendMessageToNearbyPlayers(PlayerModel player, string message, int type, float range, bool excludePlayer = false)
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

                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) && player.Dimension == target.Dimension)
                    {
                        if (player != target || (player == target && !excludePlayer))
                        {
                            float distance = player.position.Distance(target.Position);

                            if (distance <= range)
                            {
                                string chatMessageRgba = GetChatMessageRgba(distance, distanceGap);

                                switch (type)
                                {
                                    case Constants.MESSAGE_TALK:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.GetVnXName() + " sagt : " + message + "..." : chatMessageRgba + player.GetVnXName() + " sagt : " + message);
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage);
                                        }
                                        break;
                                    case Constants.MESSAGE_YELL:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.GetVnXName() + " schreit : " + message + "..." : chatMessageRgba + player.GetVnXName() + " schreit : " + message + "!!!");
                                        if (secondMessage.Length > 0)
                                        {
                                            target.SendChatMessage(chatMessageRgba + secondMessage + "!!!");
                                        }
                                        break;
                                    case Constants.MESSAGE_WHISPER:
                                        target.SendChatMessage(secondMessage.Length > 0 ? chatMessageRgba + player.GetVnXName() + " flüstert : " + message + "..." : chatMessageRgba + player.GetVnXName() + " flüstert : " + message);
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
        public void OnChatMessage(PlayerModel player, string message)
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
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
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
        public void DecirCommand(PlayerModel player, string message)
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
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] sagt : " + message);
                }
            }
            catch { }
        }

        [Command("s", true)]
        public void GritarCommand(PlayerModel player, string message)
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
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] schreit : " + message + " !!!");
                }
            }
            catch { }
        }

        [Command("l", true)]
        public void SusurrarCommand(PlayerModel player, string message)
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
                    logfile.WriteLogs("chat", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] flüstert : " + message + " ...");
                }
            }
            catch { }
        }
    }
}
