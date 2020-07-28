using AltV.Net.Resources.Chat.Api;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VenoXV._Preload_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Language_
{
    public class Main
    {
        public enum Languages
        {
            German = 1,
            English = 2,
            France = 3
        };

        public static string GetClientLanguagePair(Client player)
        {
            try
            {
                return player.Language switch
                {
                    (int)Languages.German => "de",
                    (int)Languages.English => "en",
                    (int)Languages.France => "fr",
                    _ => "de",
                };
            }
            catch { return "en"; }
        }

        static readonly HttpClient webClient = new HttpClient();
        public static async Task<string> TranslateText(string word, string fromPair, string toPair)
        {
            try
            {
                string fromLanguage = fromPair;
                string toLanguage = toPair;
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
                HttpResponseMessage response = await webClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                result = result[4..result.IndexOf("\"", 4, StringComparison.Ordinal)];
                return result;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("TranslateText", ex); return "Error"; }
        }

        public static async Task SendTranslatedChatMessage(Client playerClass, string text)
        {
            try
            {
                switch (playerClass.Language)
                {
                    case (int)Languages.English:
                        playerClass.SendChatMessage(await TranslateText(text, "de", "en"));
                        break;
                    case (int)Languages.German:
                        if (playerClass.Gamemode == (int)Preload.Gamemodes.Reallife) { playerClass.SendChatMessage(text); return; }
                        playerClass.SendChatMessage(await TranslateText(text, "de", GetClientLanguagePair(playerClass)));
                        break;
                    default:
                        playerClass.SendChatMessage("ERROR " + text);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("SendTranslatedChatMessage", ex); }
        }
    }
}
