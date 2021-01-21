using Discord;
using Discord.Webhook;
using System;

namespace VenoXV._Discord_.Modules
{
    public class Notify
    {

        public static string AdminLog = "https://discordapp.com/api/webhooks/798343739918647319/Ps2ztB47kTAZ8ENdayQc5XAfEv5HxRW7LRCuagWRVxN_RR_6UYrnn5KOdiTlRoehst-q";
        public static string UpdateLog = "https://discordapp.com/api/webhooks/798360693312454696/eSzjrHtsG_EQXqoL9zrRI3PM7sDpWWg4Cg-UBTiMcDsTMCLjzJGJJhJC0U0EW7i5_s2a";

        public static async void SendNotify(string URL, string title, string content, Color color, string optionalText)
        {
            try
            {
                Core.Debug.OutputDebugString("Sended Text : " + title + " | Content : " + content + " | Color : " + color + " | optionalText : " + optionalText);
                //Core.Debug.OutputDebugString("|" + URL + "|");
                var client = new DiscordWebhookClient(URL);
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
                var embedFooter = new EmbedFooterBuilder();
                embedFooter.Text = DateTime.Now.ToString("dd'.'MM'.'yyyy hh':'mm");
                builder.Footer = embedFooter;
                builder.Description = content;
                await client.SendMessageAsync(embeds: new[] { builder.Build() }, text: "@everyone");
                Core.Debug.OutputDebugString("Sended Text : " + title + " | Content : " + content + " | Color : " + color + " | optionalText : " + optionalText);
            }
            catch (Exception e)
            {
                Core.Debug.CatchExceptions(e);
            }
        }

        public static void SendUpdateLog(string Title, string Subtitle, Color color, string optionalText)
        {
            SendNotify(UpdateLog, Title, Subtitle, color, optionalText);
        }
    }
}
