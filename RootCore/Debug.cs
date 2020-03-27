using AltV.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV.Core
{
    public class Debug : IScript
    {
        public static bool DEBUG_MODE_ENABLED = true;
        public static void OutputDebugString(string text)
        {
            try
            {
                if (!DEBUG_MODE_ENABLED) { return; }
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | : " + text);
            }
            catch { }
        }

        public static void CatchExceptions(string FunctionName, Exception ex)
        {
            if (!DEBUG_MODE_ENABLED) { return; }
            Console.WriteLine("[EXCEPTION "+ FunctionName+ "] " + ex.Message);
            Console.WriteLine("[EXCEPTION "+ FunctionName+ "] " + ex.StackTrace);
        }
    }
}
