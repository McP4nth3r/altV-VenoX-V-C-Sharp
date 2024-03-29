﻿using System;
using Discord;
using Discord.Webhook;
using VenoX.Debug;

namespace VenoX.Core._Discord_.Modules
{
    public class Notify
    {

        public static string AdminLog = "https://discordapp.com/api/webhooks/798343739918647319/Ps2ztB47kTAZ8ENdayQc5XAfEv5HxRW7LRCuagWRVxN_RR_6UYrnn5KOdiTlRoehst-q";
        public static string UpdateLog = "https://discordapp.com/api/webhooks/798360693312454696/eSzjrHtsG_EQXqoL9zrRI3PM7sDpWWg4Cg-UBTiMcDsTMCLjzJGJJhJC0U0EW7i5_s2a";

        public static async void SendNotify(string url, string title, string content, Color color, string optionalText)
        {
            try
            {
                ConsoleHandling.OutputDebugString("Sended Text : " + title + " | Content : " + content + " | Color : " + color + " | optionalText : " + optionalText);
                //Core.Debug.OutputDebugString("|" + URL + "|");
                DiscordWebhookClient client = new DiscordWebhookClient(url);
                EmbedBuilder builder = new EmbedBuilder
                {
                    Color = color
                };
                if (title != null)
                {
                    EmbedAuthorBuilder authorBuilder = new EmbedAuthorBuilder();
                    authorBuilder.Name = title;
                    authorBuilder.IconUrl = "https://cdn.discordapp.com/attachments/754712202891755611/798012891684929596/logo_blue.png";
                    builder.Author = authorBuilder;
                    builder.ThumbnailUrl = "https://cdn.discordapp.com/attachments/754712202891755611/798012891684929596/logo_blue.png";
                }
                EmbedFooterBuilder embedFooter = new EmbedFooterBuilder
                {
                    Text = DateTime.Now.ToString("dd'.'MM'.'yyyy hh':'mm")
                };
                builder.Footer = embedFooter;
                builder.Description = content;
                await client.SendMessageAsync(embeds: new[] { builder.Build() }, text: "@everyone");
                ConsoleHandling.OutputDebugString("Sended Text : " + title + " | Content : " + content + " | Color : " + color + " | optionalText : " + optionalText);
            }
            catch (Exception e)
            {
                ExceptionHandling.CatchExceptions(e);
            }
        }

        public static void SendUpdateLog(string title, string subtitle, Color color, string optionalText)
        {
            SendNotify(UpdateLog, title, subtitle, color, optionalText);
        }
    }
}
