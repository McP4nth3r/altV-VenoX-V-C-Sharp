using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            German = 0,
            English = 1,
            France = 2,
            Poland = 3,
            Spanish = 4,
            Turkish = 5
        };

        //string jsonString_EN = File.ReadAllText(Alt.Server.Resource.Path + Alt.Server.Resource.Path + "/Languages/language-en.json");
        public static List<LanguageModel> LANGUAGE_PACK_EN = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-en.json"));
        public static List<LanguageModel> LANGUAGE_PACK_FR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fr.json"));
        public static List<LanguageModel> LANGUAGE_PACK_PL = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-pl.json"));
        public static List<LanguageModel> LANGUAGE_PACK_ES = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-es.json"));
        public static List<LanguageModel> LANGUAGE_PACK_TR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-tr.json"));
        public static void OnResourceStart()
        {
            Core.Debug.OutputDebugString("Language-List-EN " + LANGUAGE_PACK_EN.Count + " translated Text's loaded...");

            /*
            foreach (LanguageModel languageClassEN in LANGUAGE_PACK_FR)
            {

            }
            foreach (LanguageModel languageClassEN in LANGUAGE_PACK_PL)
            {

            }
            foreach (LanguageModel languageClassEN in LANGUAGE_PACK_ES)
            {

            }
            foreach (LanguageModel languageClassEN in LANGUAGE_PACK_ES)
            {

            }
            */
        }
        public static string GetClientLanguagePair(Languages language)
        {
            try
            {
                return language switch
                {
                    Languages.German => "de",
                    Languages.English => "en",
                    Languages.France => "fr",
                    Languages.Poland => "pl",
                    Languages.Spanish => "es",
                    Languages.Turkish => "tr",
                    _ => "de",
                };
            }
            catch { return "en"; }
        }
        static readonly HttpClient webClient = new HttpClient();
        public static async Task<string> TranslateText(string Text, string fromPair, string toPair)
        {
            try
            {
                //return word;
                string fromLanguage = fromPair;
                string toLanguage = toPair;
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(Text)}";
                HttpResponseMessage response = await webClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                result = result[4..result.IndexOf("\"", 4, StringComparison.Ordinal)];
                return result;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return "Error"; }
        }
        private static List<LanguageModel> GetLanguageCache(Languages language)
        {
            try
            {
                return language switch
                {
                    Languages.English => LANGUAGE_PACK_EN,
                    Languages.France => LANGUAGE_PACK_FR,
                    Languages.Poland => LANGUAGE_PACK_PL,
                    Languages.Spanish => LANGUAGE_PACK_ES,
                    Languages.Turkish => LANGUAGE_PACK_TR,
                    _ => new List<LanguageModel>(),
                };
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<LanguageModel>(); }
        }
        private static bool IsTranslatedTextCached(List<LanguageModel> LanguageList, string Text)
        {
            foreach (LanguageModel languageClass in LanguageList.ToList())
                if (languageClass.TranslatedText == Text) return true;
            return false;
        }
        public static async Task<string> GetTranslatedTextAsync(Languages language, string text)
        {
            try
            {
                if (language == Languages.German) return text;
                List<LanguageModel> CachedLanguage = GetLanguageCache(language);
                LanguageModel languageClass = CachedLanguage.ToList().FirstOrDefault(x => x.Text == text);
                string LanguagePair = GetClientLanguagePair(language);
                if (languageClass is null)
                {
                    string TranslatedText = await TranslateText(text, "de", LanguagePair);
                    using StringReader readStream = new StringReader(TranslatedText);
                    await AltAsync.Do(() =>
                    {
                        if (TranslatedText != "error")
                        {
                            languageClass = new LanguageModel { Pair = LanguagePair, Text = text, TranslatedText = TranslatedText };
                            CachedLanguage.Add(languageClass);
                            string Json = JsonConvert.SerializeObject(languageClass);
                            Core.Debug.WriteJsonString("language-" + LanguagePair, Json);
                        }
                    });
                    return await readStream.ReadLineAsync();
                }
                else return languageClass.TranslatedText;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return text; }
        }

        public static async Task SendTranslatedChatMessage(VnXPlayer playerClass, string text)
        {
            try
            {
                switch (playerClass.Language)
                {
                    case (int)Languages.English:
                        playerClass.SendChatMessage(await GetTranslatedTextAsync((Languages)playerClass.Language, text));
                        break;
                    case (int)Languages.German:
                        if (playerClass.Gamemode == (int)Preload.Gamemodes.Reallife) { playerClass.SendChatMessage(text); return; }
                        playerClass.SendChatMessage(text);
                        break;
                    default:
                        //playerClass.SendChatMessage(await TranslateText(text, "de", GetClientLanguagePair(playerClass)));
                        //playerClass.SendChatMessage("ERROR " + text);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
