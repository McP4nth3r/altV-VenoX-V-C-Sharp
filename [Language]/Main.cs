using AltV.Net.Resources.Chat.Api;
using Google.Cloud.Translation.V2;
using System;
using System.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV._Language_
{
    public class Main
    {
        public enum Languages
        {
            German = 1,
            English = 2,
        };

        public static string TranslateText(string input, string languagePair)
        {
            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
            WebClient webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            string result = webClient.DownloadString(url);
            result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
            result = result.Substring(result.IndexOf(">") + 1);
            result = result.Substring(0, result.IndexOf("</span>"));
            return result.Trim();
        }

        public static void SendTranslatedChatMessage(Client playerClass, string text)
        {
            switch (playerClass.Language)
            {
                case (int)Languages.English:
                    playerClass.SendChatMessage(TranslateText(text, LanguageCodes.English));
                    break;
                case (int)Languages.German:
                    playerClass.SendChatMessage(text);
                    break;
                default:
                    playerClass.SendChatMessage("ERROR " + text);
                    break;
            }
        }
        public static string ReturnTranslatedText(string CountryLanguageCode, string text)
        {
            try
            {
                return CountryLanguageCode switch
                {
                    LanguageCodes.English => TranslateText(text, LanguageCodes.English),
                    LanguageCodes.German => TranslateText(text, LanguageCodes.German),
                    _ => text,
                };
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ReturnTranslatedText", ex); return ""; }
        }

    }
}
