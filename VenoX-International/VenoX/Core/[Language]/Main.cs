using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoX.Core._Language_.Models;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Language_
{
    public class Main
    {
        public static void OnResourceStart()
        {
            try
            {
                foreach (string path in Constants.LanguagePathFolders)
                {
                    foreach (List<LanguageModel> languageList in from languageParent in Constants.LanguageParents select path + languageParent + ".json" into currentPath where File.Exists(currentPath) select JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(currentPath)))
                    {
                        if (languageList is null)
                        {
                            ConsoleHandling.OutputDebugStringColored("[ERROR @ READING LIST '"+ path+"' - IS NULL!]", ConsoleColor.Red);
                            return;
                        }
                        Constants.Languages listLanguage = GetLanguageByPair(languageList[0].Pair);
                        Dictionary<string, LanguageModel> cache = GetLanguageCache(listLanguage);
                        ConsoleHandling.OutputDebugStringColored("[INFO @ READING LIST '"+ listLanguage+"'!]", ConsoleColor.Red);
                        ConsoleHandling.OutputDebugStringColored("[INFO @ READING LIST '"+ cache+"'!]", ConsoleColor.Red);
                        ConsoleHandling.OutputDebugStringColored("[INFO @ READING LIST '"+ cache.Count+"'!]", ConsoleColor.Red);
                        foreach (LanguageModel languageClass in languageList.Where(languageClass => languageClass?.Text != null && languageClass.Text.Length >= 1 && !cache.ContainsKey(languageClass.Text)))
                            cache.Add(languageClass.Text, languageClass);
                    }
                }
                /* foreach (string path in Constants.LanguagePaths)
                 {
                     VenoXV.Core.Debug.OutputDebugString(path);
                     List<LanguageModel> languageList = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(path));
                     if (languageList is null)
                     {
                         VenoXV.Core.Debug.OutputDebugStringColored("[ERROR @ READING LIST '"+ path+"' - IS NULL!]", ConsoleColor.Red);
                         return;
                     }
 
                     Constants.Languages listLanguage = GetLanguageByPair(languageList[0].Pair);
                     Dictionary<string, LanguageModel> cache = GetLanguageCache(listLanguage);
                     foreach (LanguageModel languageClass in languageList.Where(languageClass => languageClass?.Text != null && languageClass.Text.Length >= 1 && !cache.ContainsKey(languageClass.Text)))
                         cache.Add(languageClass.Text, languageClass);
                 }
                 */
                
                ConsoleHandling.OutputDebugStringColored("[Language-List-FR " + Constants.LanguagePackFr.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-DE " + Constants.LanguagePackDe.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-PL " + Constants.LanguagePackPl.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-ES " + Constants.LanguagePackEs.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-TR " + Constants.LanguagePackTr.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-RU " + Constants.LanguagePackRu.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-SV " + Constants.LanguagePackSv.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-SR " + Constants.LanguagePackSr.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-CN " + Constants.LanguagePackCn.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-FA " + Constants.LanguagePackFa.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
                ConsoleHandling.OutputDebugStringColored("[Language-List-IT " + Constants.LanguagePackIt.Count + " translated Text's loaded...]", ConsoleColor.Cyan);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static string GetClientLanguagePair(Constants.Languages language)
        {
            try
            {
                return language switch
                {
                    Constants.Languages.German => "de",
                    Constants.Languages.French => "fr",
                    Constants.Languages.Polish => "pl",
                    Constants.Languages.Spanish => "es",
                    Constants.Languages.Turkish => "tr",
                    Constants.Languages.Russian => "ru",
                    Constants.Languages.Swedish => "sv",
                    Constants.Languages.Serbian => "sr",
                    Constants.Languages.Chinese => "zh-cn",
                    Constants.Languages.Farsi => "fa",
                    Constants.Languages.Italian => "it",
                    _ => "de",
                };
            }
            catch { return "en"; }
        }
        public static Constants.Languages GetLanguageByPair(string pair)
        {
            try
            {
                return pair switch
                {
                    "de" => Constants.Languages.German,
                    "fr" => Constants.Languages.French,
                    "pl" => Constants.Languages.Polish,
                    "es" => Constants.Languages.Spanish,
                    "tr" => Constants.Languages.Turkish,
                    "ru" => Constants.Languages.Russian,
                    "sv" => Constants.Languages.Swedish,
                    "sr" => Constants.Languages.Serbian,
                    "zh-cn" => Constants.Languages.Chinese,
                    "fa" => Constants.Languages.Farsi,
                    "it" => Constants.Languages.Italian,
                    _ => Constants.Languages.English,
                };
            }
            catch { return Constants.Languages.German; }
        }


        private static Dictionary<string, LanguageModel> GetLanguageCache(Constants.Languages language)
        {
            try
            {
                return language switch
                {
                    Constants.Languages.French => Constants.LanguagePackFr,
                    Constants.Languages.Polish => Constants.LanguagePackPl,
                    Constants.Languages.Spanish => Constants.LanguagePackEs,
                    Constants.Languages.Turkish => Constants.LanguagePackTr,
                    Constants.Languages.Russian => Constants.LanguagePackRu,
                    Constants.Languages.Swedish => Constants.LanguagePackSv,
                    Constants.Languages.Serbian => Constants.LanguagePackSr,
                    Constants.Languages.Chinese => Constants.LanguagePackCn,
                    Constants.Languages.Farsi => Constants.LanguagePackFa,
                    Constants.Languages.Italian => Constants.LanguagePackIt,
                    Constants.Languages.German => Constants.LanguagePackDe,
                    _ => new Dictionary<string, LanguageModel>()
                };
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new Dictionary<string, LanguageModel>(); }
        }
        
        public static async Task<string> GetTranslatedTextAsync(Constants.Languages language, string text, string parent = _Language_.Constants.LanguageParents_Unknown)
        {
            try
            {
                if (language == Constants.Languages.English) return text;
                Dictionary<string, LanguageModel> cache = GetLanguageCache(language);
                
                ConsoleHandling.OutputDebugString("Cache Count : " + cache.Count + " | " + language);
                
                if (cache.ContainsKey(text))
                    return cache[text].TranslatedText;

                // Translate the Text & Get the result from Google API's. - Current gamemode language = fromPair parameter.
                string translatedText = await Service.TranslateText(text, "en", GetClientLanguagePair(language));
                using StringReader readStream = new StringReader(translatedText);
                LanguageModel languageClass;
                await AltAsync.Do(() =>
                {
                    if (translatedText == "Error" || cache.ContainsKey(text)) return;
                    languageClass = new LanguageModel { Pair = GetClientLanguagePair(language), Text = text, TranslatedText = translatedText };
                    string json = JsonConvert.SerializeObject(languageClass);
                    global::VenoX.Debug.JsonHandling.WriteJsonString("language-" +  GetClientLanguagePair(language) + "/" + parent, json);
                    cache.Add(text, languageClass);
                });
                return await readStream.ReadLineAsync();
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return text; }
        }

        public static async Task SendTranslatedChatMessage(VnXPlayer playerClass, string text)
        {
            try
            {
                playerClass?.SendChatMessage(await GetTranslatedTextAsync((Constants.Languages)playerClass.Language, text));
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        
    }
}
