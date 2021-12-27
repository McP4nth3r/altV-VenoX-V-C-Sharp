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

        public static readonly List<string> LanguagePaths = new()
        {
            Alt.Server.Resource.Path + "/Languages/language-fr.json",
            Alt.Server.Resource.Path + "/Languages/language-pl.json",
            Alt.Server.Resource.Path + "/Languages/language-es.json",
            Alt.Server.Resource.Path + "/Languages/language-tr.json",
            Alt.Server.Resource.Path + "/Languages/language-ru.json",
            Alt.Server.Resource.Path + "/Languages/language-sv.json",
            Alt.Server.Resource.Path + "/Languages/language-sr.json",
            Alt.Server.Resource.Path + "/Languages/language-zh-cn.json",
            Alt.Server.Resource.Path + "/Languages/language-fa.json",
            Alt.Server.Resource.Path + "/Languages/language-it.json"
        };
        
        

        //string jsonString_EN = File.ReadAllText(Alt.Server.Resource.Path + Alt.Server.Resource.Path + "/Languages/language-en.json");
                                   
        private static readonly Dictionary<string, LanguageModel> LanguagePackFr = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackPl = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackEs = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackTr = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackRu = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackSv = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackSr = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackCn = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackFa = new();
        private static readonly Dictionary<string, LanguageModel> LanguagePackIt = new();
        
            
        public static void OnResourceStart()
        {
            try
            {
                foreach (string path in LanguagePaths)
                {
                    Debug.OutputDebugString(path);
                    List<LanguageModel> languageList = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(path));
                    if (languageList is null)
                    {
                        Debug.OutputDebugStringColored("[ERROR @ READING LIST '"+ path+"' - IS NULL!]", ConsoleColor.Red);
                        return;
                    }

                    Languages listLanguage = GetLanguageByPair(languageList[0].Pair);
                    Dictionary<string, LanguageModel> cache = GetLanguageCache(listLanguage);
                    foreach (var languageClass in languageList.Where(languageClass => languageClass?.Text != null && languageClass.Text.Length >= 1 && !cache.ContainsKey(languageClass.Text)))
                        cache.Add(languageClass.Text, languageClass);
                }

                Debug.OutputDebugStringColored("[Language-List-FR " + LanguagePackFr.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-PL " + LanguagePackPl.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-ES " + LanguagePackEs.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-TR " + LanguagePackTr.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-RU " + LanguagePackRu.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-SV " + LanguagePackSv.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-SR " + LanguagePackSr.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-CN " + LanguagePackCn.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-FA " + LanguagePackFa.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                Debug.OutputDebugStringColored("[Language-List-IT " + LanguagePackIt.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static string GetClientLanguagePair(Languages language)
        {
            try
            {
                return language switch
                {
                    Languages.German => "de",
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
                    _ => Languages.English,
                };
            }
            catch { return Languages.German; }
        }
        static readonly HttpClient WebClient = new HttpClient();

        private static async Task<string> TranslateText(string text, string fromPair, string toPair)
        {
            try
            {
                Debug.OutputDebugString("Called Translation API : " + fromPair + " | " + toPair + " | " + text);
                //return word;
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromPair}&tl={toPair}&dt=t&q={HttpUtility.UrlEncode(text)}";
                HttpResponseMessage response = await WebClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                result = result[4..result.IndexOf("\"", 4, StringComparison.Ordinal)];
                return result;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return "Error"; }
        }

        private static Dictionary<string, LanguageModel> GetLanguageCache(Languages language)
        {
            try
            {
                return language switch
                {
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
                    _ => new Dictionary<string, LanguageModel>()
                };
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new Dictionary<string, LanguageModel>(); }
        }
        
        public static async Task<string> GetTranslatedTextAsync(Languages language, string text)
        {
            try
            {
                if (language == Languages.English) return text;
                Dictionary<string, LanguageModel> cache = GetLanguageCache(language);
                
                if (cache.ContainsKey(text))
                    return cache[text].TranslatedText;
                
                else
                {
                    // Translate the Text & Get the result from Google API's.
                    string translatedText = await TranslateText(text, "en", GetClientLanguagePair(language));
                    using StringReader readStream = new StringReader(translatedText);
                    LanguageModel languageClass;
                    await AltAsync.Do(() =>
                    {
                        if (translatedText == "Error" || cache.ContainsKey(text)) return;
                        
                        languageClass = new LanguageModel { Pair = GetClientLanguagePair(language), Text = text, TranslatedText = translatedText };
                        string json = JsonConvert.SerializeObject(languageClass);
                        Debug.WriteJsonString("language-" + GetClientLanguagePair(language), json);
                        cache.Add(text, languageClass);
                    });
                    return await readStream.ReadLineAsync();
                }
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
