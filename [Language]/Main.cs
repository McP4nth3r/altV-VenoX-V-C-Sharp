using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VenoXV._Language_.Models;
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

        public static string GetClientLanguagePair(VnXPlayer player)
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

        public static List<LanguageModel> TranslatedText = new List<LanguageModel>();
        static readonly HttpClient webClient = new HttpClient();
        public static async Task<string> TranslateText(string Text, string fromPair, string toPair)
        {
            try
            {
                foreach (LanguageModel languageClass in TranslatedText.ToList())
                {
                    if (languageClass.Text.ToLower() == Text.ToLower() && languageClass.Pair == toPair)
                    {
                        return languageClass.TranslatedText;
                    }
                }
                //return word;
                string fromLanguage = fromPair;
                string toLanguage = toPair;
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(Text)}";
                HttpResponseMessage response = await webClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                result = result[4..result.IndexOf("\"", 4, StringComparison.Ordinal)];
                LanguageModel newEntry = new LanguageModel()
                {
                    Pair = toPair,
                    Text = Text,
                    TranslatedText = result
                };
                TranslatedText.Add(newEntry);
                return result;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return "Error"; }
        }


        public static async Task SendTranslatedChatMessage(VnXPlayer playerClass, string text)
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
                        playerClass.SendChatMessage(text);
                        break;
                    default:
                        playerClass.SendChatMessage(await TranslateText(text, "de", GetClientLanguagePair(playerClass)));
                        //playerClass.SendChatMessage("ERROR " + text);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
