using AltV.Net.Resources.Chat.Api;
using Google.Cloud.Translation.V2;
using System;
using VenoXV._RootCore_.Models;

namespace VenoXV._Language_
{
    public class Main
    {
        public enum Languages
        {
            German = 1,
            English = 2,
            Turkish = 3,
            French = 4,
            Italian = 5,
            Spanish = 6
        };

        public static void SendTranslatedChatMessage(Client playerClass, string text)
        {
            TranslationClient client = TranslationClient.Create();
            switch (playerClass.Language)
            {
                case (int)Languages.English:
                    playerClass.SendChatMessage(client.TranslateText(text, LanguageCodes.English).TranslatedText);
                    break;
                case (int)Languages.German:
                    playerClass.SendChatMessage(text);
                    break;
                case (int)Languages.French:
                    playerClass.SendChatMessage(client.TranslateText(text, LanguageCodes.French).TranslatedText);
                    break;
                case (int)Languages.Italian:
                    playerClass.SendChatMessage(client.TranslateText(text, LanguageCodes.Italian).TranslatedText);
                    break;
                case (int)Languages.Spanish:
                    playerClass.SendChatMessage(client.TranslateText(text, LanguageCodes.Spanish).TranslatedText);
                    break;
                case (int)Languages.Turkish:
                    playerClass.SendChatMessage(client.TranslateText(text, LanguageCodes.Turkish).TranslatedText);
                    break;
            }
        }
        public static string ReturnTranslatedText(string CountryLanguageCode, string text)
        {
            try
            {
                TranslationClient client = TranslationClient.Create();
                return CountryLanguageCode switch
                {
                    LanguageCodes.English => client.TranslateText(text, LanguageCodes.English).TranslatedText,
                    LanguageCodes.German => client.TranslateText(text, LanguageCodes.German).TranslatedText,
                    LanguageCodes.French => client.TranslateText(text, LanguageCodes.French).TranslatedText,
                    LanguageCodes.Italian => client.TranslateText(text, LanguageCodes.Italian).TranslatedText,
                    LanguageCodes.Spanish => client.TranslateText(text, LanguageCodes.Spanish).TranslatedText,
                    LanguageCodes.Turkish => client.TranslateText(text, LanguageCodes.Turkish).TranslatedText,
                    _ => text,
                };
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ReturnTranslatedText", ex); return ""; }
        }

    }
}
