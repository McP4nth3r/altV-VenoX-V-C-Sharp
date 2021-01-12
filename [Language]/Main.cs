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
            Turkish = 5,
            Russian = 6,
            Swedish = 7,
            Serbian = 8,
            Chinese = 9,
            Farsi = 10,
            Italien = 11
        };

        //string jsonString_EN = File.ReadAllText(Alt.Server.Resource.Path + Alt.Server.Resource.Path + "/Languages/language-en.json");
        public static List<LanguageModel> LANGUAGE_PACK_EN = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-en.json"));
        public static List<LanguageModel> LANGUAGE_PACK_FR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fr.json"));
        public static List<LanguageModel> LANGUAGE_PACK_PL = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-pl.json"));
        public static List<LanguageModel> LANGUAGE_PACK_ES = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-es.json"));
        public static List<LanguageModel> LANGUAGE_PACK_TR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-tr.json"));
        public static List<LanguageModel> LANGUAGE_PACK_RU = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-ru.json"));
        public static List<LanguageModel> LANGUAGE_PACK_SV = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sv.json"));
        public static List<LanguageModel> LANGUAGE_PACK_SR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sr.json"));
        public static List<LanguageModel> LANGUAGE_PACK_CN = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-zh-cn.json"));
        public static List<LanguageModel> LANGUAGE_PACK_FA = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fa.json"));
        public static List<LanguageModel> LANGUAGE_PACK_IT = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-it.json"));


        public static void ReloadLanguageCacheLists()
        {
            try
            {
                LANGUAGE_PACK_EN = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-en.json"));
                LANGUAGE_PACK_FR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fr.json"));
                LANGUAGE_PACK_PL = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-pl.json"));
                LANGUAGE_PACK_ES = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-es.json"));
                LANGUAGE_PACK_TR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-tr.json"));
                LANGUAGE_PACK_RU = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-ru.json"));
                LANGUAGE_PACK_SV = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sv.json"));
                LANGUAGE_PACK_SR = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sr.json"));
                LANGUAGE_PACK_CN = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-zh-cn.json"));
                LANGUAGE_PACK_FA = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fa.json"));
                LANGUAGE_PACK_IT = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-it.json"));
                Core.Debug.OutputDebugString("Language-List-EN " + LANGUAGE_PACK_EN.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-FR " + LANGUAGE_PACK_FR.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-PL " + LANGUAGE_PACK_PL.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-ES " + LANGUAGE_PACK_ES.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-TR " + LANGUAGE_PACK_TR.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-RU " + LANGUAGE_PACK_RU.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-SV " + LANGUAGE_PACK_SV.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-SR " + LANGUAGE_PACK_SR.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-CN " + LANGUAGE_PACK_CN.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-FA " + LANGUAGE_PACK_FA.Count + " translated Text's loaded...");
                Core.Debug.OutputDebugString("Language-List-IT " + LANGUAGE_PACK_IT.Count + " translated Text's loaded...");
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void CleanCacheFiles()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Core.Debug.OutputDebugString("Cleaning all Cache - Files");
            Console.ForegroundColor = ConsoleColor.Cyan;

            // English : 
            List<LanguageModel> EN_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_EN)
            {
                if (EN_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    EN_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-EN ] : Before [" + LANGUAGE_PACK_EN.Count + "] - Now [" + EN_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.English), JsonConvert.SerializeObject(EN_Cache));


            // France : 
            List<LanguageModel> FR_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_FR)
            {
                if (FR_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    FR_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-FR ] : Before [" + LANGUAGE_PACK_FR.Count + "] - Now [" + FR_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.France), JsonConvert.SerializeObject(FR_Cache));


            // Poland : 
            List<LanguageModel> PL_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_PL)
            {
                if (PL_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    PL_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-PL ] : Before [" + LANGUAGE_PACK_PL.Count + "] - Now [" + PL_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Poland), JsonConvert.SerializeObject(PL_Cache));

            // Spanish : 
            List<LanguageModel> ES_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_ES)
            {
                if (ES_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    ES_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-ES ] : Before [" + LANGUAGE_PACK_ES.Count + "] - Now [" + ES_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Spanish), JsonConvert.SerializeObject(ES_Cache));


            // Turkish : 
            List<LanguageModel> TR_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_TR)
            {
                if (TR_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    TR_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-TR ] : Before [" + LANGUAGE_PACK_TR.Count + "] - Now [" + TR_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Turkish), JsonConvert.SerializeObject(TR_Cache));


            // Russian : 
            List<LanguageModel> RU_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_RU)
            {
                if (RU_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    RU_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-RU ] : Before [" + LANGUAGE_PACK_RU.Count + "] - Now [" + RU_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Russian), JsonConvert.SerializeObject(RU_Cache));

            // Swedish : 
            List<LanguageModel> SV_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_SV)
            {
                if (SV_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    SV_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-SV ] : Before [" + LANGUAGE_PACK_SV.Count + "] - Now [" + SV_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Swedish), JsonConvert.SerializeObject(SV_Cache));

            // Serbian : 
            List<LanguageModel> SR_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_SR)
            {
                if (SR_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    SR_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-SR ] : Before [" + LANGUAGE_PACK_SR.Count + "] - Now [" + SR_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Serbian), JsonConvert.SerializeObject(SR_Cache));

            // Chinese : 
            List<LanguageModel> CN_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_CN)
            {
                if (CN_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    CN_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-CN-ZH ] : Before [" + LANGUAGE_PACK_CN.Count + "] - Now [" + CN_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Chinese), JsonConvert.SerializeObject(CN_Cache));

            // Farsi : 
            List<LanguageModel> FA_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_FA)
            {
                if (FA_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    FA_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-FA ] : Before [" + LANGUAGE_PACK_FA.Count + "] - Now [" + FA_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Farsi), JsonConvert.SerializeObject(FA_Cache));

            // Italian : 
            List<LanguageModel> IT_Cache = new List<LanguageModel>();
            foreach (LanguageModel languageClass in LANGUAGE_PACK_IT)
            {
                if (IT_Cache.FirstOrDefault(x => x.Text == languageClass.Text) is null)
                    IT_Cache.Add(languageClass);
            }
            Core.Debug.OutputDebugString("[Clean-Up | Language-List-IT ] : Before [" + LANGUAGE_PACK_IT.Count + "] - Now [" + IT_Cache.Count + "]");
            Core.Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Italien), JsonConvert.SerializeObject(IT_Cache));

            Console.ForegroundColor = ConsoleColor.Green;
            Core.Debug.OutputDebugString("[Clean-Up] : Done!");

        }
        public static void OnResourceStart()
        {
            CleanCacheFiles();
            ReloadLanguageCacheLists();
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
                    Languages.Russian => "ru",
                    Languages.Swedish => "sv",
                    Languages.Serbian => "sr",
                    Languages.Chinese => "zh-cn",
                    Languages.Farsi => "fa",
                    Languages.Italien => "it",
                    _ => "de",
                };
            }
            catch { return "en"; }
        }
        public static Languages GetLanguageByPair(string Pair)
        {
            try
            {
                return Pair switch
                {
                    "de" => Languages.German,
                    "en" => Languages.English,
                    "fr" => Languages.France,
                    "pl" => Languages.Poland,
                    "es" => Languages.Spanish,
                    "tr" => Languages.Turkish,
                    "ru" => Languages.Russian,
                    "sv" => Languages.Swedish,
                    "sr" => Languages.Serbian,
                    "zh-cn" => Languages.Chinese,
                    "fa" => Languages.Farsi,
                    "it" => Languages.Italien,
                    _ => Languages.German,
                };
            }
            catch { return Languages.German; }
        }
        static readonly HttpClient webClient = new HttpClient();
        public static async Task<string> TranslateText(string Text, string fromPair, string toPair)
        {
            try
            {
                Core.Debug.OutputDebugString("Called Translation API");
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
                    Languages.Russian => LANGUAGE_PACK_RU,
                    Languages.Swedish => LANGUAGE_PACK_SV,
                    Languages.Serbian => LANGUAGE_PACK_SR,
                    Languages.Chinese => LANGUAGE_PACK_CN,
                    Languages.Farsi => LANGUAGE_PACK_FA,
                    Languages.Italien => LANGUAGE_PACK_IT,
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
                // if german main language => return.
                if (language == Languages.German) return text;

                // Simple Check if it's exits in the Async Thread ( so don't need to switch back to the main thread ) 
                List<LanguageModel> CachedLanguage = GetLanguageCache(language);
                LanguageModel languageClass = CachedLanguage.ToList().FirstOrDefault(x => x.Text == text);

                // Return if found.
                if (languageClass is not null) return languageClass.TranslatedText;

                string TranslatedText = "";
                // Switch to Main-Thread.
                await AltAsync.Do(async () =>
                {
                    // Check if the Language stuff is cached into the list & the file.
                    List<LanguageModel> CachedLanguage = GetLanguageCache(language);
                    LanguageModel languageClass = CachedLanguage.ToList().FirstOrDefault(x => x.Text == text);
                    string LanguagePair = GetClientLanguagePair(language);
                    if (languageClass is null)
                    {
                        // Switch to a new Thread.. so probably it won't bother the main thread ( improve performance ).
                        await Task.Run(async () =>
                        {
                            // Translate the Text & Get the result from Google API's.
                            string TranslatedText = await TranslateText(text, "de", LanguagePair);
                            using StringReader readStream = new StringReader(TranslatedText);
                            await AltAsync.Do(() =>
                            {
                                // If too many request was send... it returns ,,Error" - Simple false information check ^^.
                                if (TranslatedText != "Error")
                                {
                                    // Create a new Translated Model.
                                    languageClass = new LanguageModel { Pair = LanguagePair, Text = text, TranslatedText = TranslatedText };
                                    // Add it into the Translated Language List.
                                    CachedLanguage.Add(languageClass);
                                    // Convert it into a Json Obj. and put it into the file.
                                    string Json = JsonConvert.SerializeObject(languageClass);
                                    Core.Debug.WriteJsonString("language-" + LanguagePair, Json);
                                }
                            });
                            // Return Text even if it's error.. so it will not be a Empty string.
                            return await readStream.ReadLineAsync();
                        });
                    }
                    else TranslatedText = languageClass.TranslatedText;
                });
                return TranslatedText;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return text; }
        }

        public static async Task SendTranslatedChatMessage(VnXPlayer playerClass, string text)
        {
            try
            {
                playerClass?.SendChatMessage(await GetTranslatedTextAsync((Languages)playerClass.Language, text));
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
