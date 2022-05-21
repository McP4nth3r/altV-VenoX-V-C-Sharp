using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VenoX.Debug;

namespace VenoX.Core._Language_
{
    public class Service
    {
        private static readonly HttpClient WebClient = new();

        public static async Task<string> TranslateText(string text, string fromPair, string toPair)
        {
            try
            {
                ConsoleHandling.OutputDebugString("Called Translation API : " + fromPair + " | " + toPair + " | " + text);
                //return word;
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromPair}&tl={toPair}&dt=t&q={HttpUtility.UrlEncode(text)}";
                HttpResponseMessage response = await WebClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                result = result[4..result.IndexOf("\"", 4, StringComparison.Ordinal)];
                return result;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return "Error"; }
        }
    }
}