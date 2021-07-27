using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoXV._Language_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Language_
{
    public class Main
    {
        public enum Languages
        {
            German = 0,
            English = 1,
            French = 2,
            Polish = 3,
            Spanish = 4,
            Turkish = 5,
            Russian = 6,
            Swedish = 7,
            Serbian = 8,
            Chinese = 9,
            Farsi = 10,
            Italian = 11
        }

        //string jsonString_EN = File.ReadAllText(Alt.Server.Resource.Path + Alt.Server.Resource.Path + "/Languages/language-en.json");
        public static List<LanguageModel> LanguagePackEn = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-en.json"));
        public static List<LanguageModel> LanguagePackFr = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fr.json"));
        public static List<LanguageModel> LanguagePackPl = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-pl.json"));
        public static List<LanguageModel> LanguagePackEs = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-es.json"));
        public static List<LanguageModel> LanguagePackTr = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-tr.json"));
        public static List<LanguageModel> LanguagePackRu = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-ru.json"));
        public static List<LanguageModel> LanguagePackSv = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sv.json"));
        public static List<LanguageModel> LanguagePackSr = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sr.json"));
        public static List<LanguageModel> LanguagePackCn = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-zh-cn.json"));
        public static List<LanguageModel> LanguagePackFa = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fa.json"));
        public static List<LanguageModel> LanguagePackIt = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-it.json"));


        public static void ReloadLanguageCacheLists()
        {
            try
            {
                LanguagePackEn = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-en.json"));
                LanguagePackFr = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fr.json"));
                LanguagePackPl = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-pl.json"));
                LanguagePackEs = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-es.json"));
                LanguagePackTr = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-tr.json"));
                LanguagePackRu = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-ru.json"));
                LanguagePackSv = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sv.json"));
                LanguagePackSr = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-sr.json"));
                LanguagePackCn = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-zh-cn.json"));
                LanguagePackFa = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-fa.json"));
                LanguagePackIt = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-it.json"));
                Debug.OutputDebugString("Language-List-EN " + LanguagePackEn.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-FR " + LanguagePackFr.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-PL " + LanguagePackPl.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-ES " + LanguagePackEs.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-TR " + LanguagePackTr.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-RU " + LanguagePackRu.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-SV " + LanguagePackSv.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-SR " + LanguagePackSr.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-CN " + LanguagePackCn.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-FA " + LanguagePackFa.Count + " translated Text's loaded...");
                Debug.OutputDebugString("Language-List-IT " + LanguagePackIt.Count + " translated Text's loaded...");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void CleanCacheFiles()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Debug.OutputDebugString("Cleaning all Cache - Files");
            Console.ForegroundColor = ConsoleColor.Cyan;

            // English : 
            List<LanguageModel> enCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackEn.Where(languageClass => enCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                enCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-EN ] : Before [" + LanguagePackEn.Count + "] - Now [" + enCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.English), JsonConvert.SerializeObject(enCache));


            // French : 
            List<LanguageModel> frCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackFr.Where(languageClass => frCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                frCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-FR ] : Before [" + LanguagePackFr.Count + "] - Now [" + frCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.French), JsonConvert.SerializeObject(frCache));


            // Polish : 
            List<LanguageModel> plCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackPl.Where(languageClass => plCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                plCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-PL ] : Before [" + LanguagePackPl.Count + "] - Now [" + plCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Polish), JsonConvert.SerializeObject(plCache));

            // Spanish : 
            List<LanguageModel> esCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackEs.Where(languageClass => esCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                esCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-ES ] : Before [" + LanguagePackEs.Count + "] - Now [" + esCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Spanish), JsonConvert.SerializeObject(esCache));


            // Turkish : 
            List<LanguageModel> trCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackTr.Where(languageClass => trCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                trCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-TR ] : Before [" + LanguagePackTr.Count + "] - Now [" + trCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Turkish), JsonConvert.SerializeObject(trCache));


            // Russian : 
            List<LanguageModel> ruCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackRu.Where(languageClass => ruCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                ruCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-RU ] : Before [" + LanguagePackRu.Count + "] - Now [" + ruCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Russian), JsonConvert.SerializeObject(ruCache));

            // Swedish : 
            List<LanguageModel> svCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackSv.Where(languageClass => svCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                svCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-SV ] : Before [" + LanguagePackSv.Count + "] - Now [" + svCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Swedish), JsonConvert.SerializeObject(svCache));

            // Serbian : 
            List<LanguageModel> srCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackSr.Where(languageClass => srCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                srCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-SR ] : Before [" + LanguagePackSr.Count + "] - Now [" + srCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Serbian), JsonConvert.SerializeObject(srCache));

            // Chinese : 
            List<LanguageModel> cnCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackCn.Where(languageClass => cnCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                cnCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-CN-ZH ] : Before [" + LanguagePackCn.Count + "] - Now [" + cnCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Chinese), JsonConvert.SerializeObject(cnCache));

            // Farsi : 
            List<LanguageModel> faCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackFa.Where(languageClass => faCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                faCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-FA ] : Before [" + LanguagePackFa.Count + "] - Now [" + faCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Farsi), JsonConvert.SerializeObject(faCache));

            // Italian : 
            List<LanguageModel> itCache = new List<LanguageModel>();
            foreach (var languageClass in LanguagePackIt.Where(languageClass => itCache.FirstOrDefault(x => x.Text == languageClass.Text) is null))
                itCache.Add(languageClass);
            Debug.OutputDebugString("[Clean-Up | Language-List-IT ] : Before [" + LanguagePackIt.Count + "] - Now [" + itCache.Count + "]");
            Debug.WriteAllText("language-" + GetClientLanguagePair(Languages.Italian), JsonConvert.SerializeObject(itCache));

            Console.ForegroundColor = ConsoleColor.Green;
            Debug.OutputDebugString("[Clean-Up] : Done!");

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
                    Languages.French => "fr",
                    Languages.Polish => "pl",
                    Languages.Spanish => "es",
                    Languages.Turkish => "tr",
                    Languages.Russian => "ru",
                    Languages.Swedish => "sv",
                    Languages.Serbian => "sr",
                    Languages.Chinese => "zh-cn",
                    Languages.Farsi => "fa",
                    Languages.Italian => "it",
                    _ => "de",
                };
            }
            catch { return "en"; }
        }
        public static Languages GetLanguageByPair(string pair)
        {
            try
            {
                return pair switch
                {
                    "de" => Languages.German,
                    "en" => Languages.English,
                    "fr" => Languages.French,
                    "pl" => Languages.Polish,
                    "es" => Languages.Spanish,
                    "tr" => Languages.Turkish,
                    "ru" => Languages.Russian,
                    "sv" => Languages.Swedish,
                    "sr" => Languages.Serbian,
                    "zh-cn" => Languages.Chinese,
                    "fa" => Languages.Farsi,
                    "it" => Languages.Italian,
                    _ => Languages.German,
                };
            }
            catch { return Languages.German; }
        }
        static readonly HttpClient WebClient = new HttpClient();
        public static async Task<string> TranslateText(string text, string fromPair, string toPair)
        {
            try
            {
                Debug.OutputDebugString("Called Translation API");
                //return word;
                string fromLanguage = fromPair;
                string toLanguage = toPair;
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(text)}";
                HttpResponseMessage response = await WebClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                result = result[4..result.IndexOf("\"", 4, StringComparison.Ordinal)];
                return result;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return "Error"; }
        }
        private static List<LanguageModel> GetLanguageCache(Languages language)
        {
            try
            {
                return language switch
                {
                    Languages.English => LanguagePackEn,
                    Languages.French => LanguagePackFr,
                    Languages.Polish => LanguagePackPl,
                    Languages.Spanish => LanguagePackEs,
                    Languages.Turkish => LanguagePackTr,
                    Languages.Russian => LanguagePackRu,
                    Languages.Swedish => LanguagePackSv,
                    Languages.Serbian => LanguagePackSr,
                    Languages.Chinese => LanguagePackCn,
                    Languages.Farsi => LanguagePackFa,
                    Languages.Italian => LanguagePackIt,
                    _ => new List<LanguageModel>(),
                };
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new List<LanguageModel>(); }
        }
        private static bool IsTranslatedTextCached(List<LanguageModel> languageList, string text)
        {
            foreach (LanguageModel languageClass in languageList.ToList())
                if (languageClass.TranslatedText == text) return true;
            return false;
        }
        public static async Task<string> GetTranslatedTextAsync(Languages language, string text)
        {
            try
            {
                // if german main language => return.
                if (language == Languages.German) return text;

                // Simple Check if it's exists in the Async Thread ( so don't need to switch back to the main thread ) 
                List<LanguageModel> cachedLanguage = GetLanguageCache(language);
                LanguageModel languageClass = cachedLanguage.ToList().FirstOrDefault(x => x.Text == text);

                // Return if found.
                if (languageClass is not null) return languageClass.TranslatedText;

                string translatedText = "";
                // Switch to Main-Thread.
                await AltAsync.Do(async () =>
                {
                    // Check if the Language stuff is cached into the list & the file.
                    List<LanguageModel> cachedLanguage = GetLanguageCache(language);
                    LanguageModel languageClass = cachedLanguage.ToList().FirstOrDefault(x => x.Text == text);
                    string languagePair = GetClientLanguagePair(language);
                    if (languageClass is null)
                    {
                        // Switch to a new Thread.. so probably it won't bother the main thread ( improve performance ).
                        await Task.Run(async () =>
                        {
                            // Translate the Text & Get the result from Google API's.
                            string translatedText = await TranslateText(text, "de", languagePair);
                            using StringReader readStream = new StringReader(translatedText);
                            await AltAsync.Do(() =>
                            {
                                // If too many request was send... it returns ,,Error" - Simple false information check ^^.
                                if (translatedText != "Error")
                                {
                                    // Create a new Translated Model.
                                    languageClass = new LanguageModel { Pair = languagePair, Text = text, TranslatedText = translatedText };
                                    // Add it into the Translated Language List.
                                    cachedLanguage.Add(languageClass);
                                    // Convert it into a Json Obj. and put it into the file.
                                    string json = JsonConvert.SerializeObject(languageClass);
                                    Debug.WriteJsonString("language-" + languagePair, json);
                                }
                            });
                            // Return Text even if it's error.. so it will not be a Empty string.
                            return await readStream.ReadLineAsync();
                        });
                    }
                    else translatedText = languageClass.TranslatedText;
                });
                return translatedText;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return text; }
        }

        public static async Task SendTranslatedChatMessage(VnXPlayer playerClass, string text)
        {
            try
            {
                playerClass?.SendChatMessage(await GetTranslatedTextAsync((Languages)playerClass.Language, text));
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
