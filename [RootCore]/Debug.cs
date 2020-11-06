using AltV.Net;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace VenoXV.Core
{
    public class Debug : IScript
    {
        public static bool DEBUG_MODE_ENABLED = true;
        public static bool DEBUG_MODE_LOG = true;
        public static void OutputDebugString(string textt)
        {
            try
            {
                if (!DEBUG_MODE_ENABLED) return;
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | : " + textt);
                string[] text = new string[] { "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", textt };
                if (DEBUG_MODE_LOG)
                {
                    _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("DebugStrings", text[0]);
                    _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("DebugStrings", text[1]);
                    _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("DebugStrings", text[0]);
                }
            }
            catch { }
        }
        public static void CatchExceptions(Exception ex, [CallerMemberName] string FunctionName = "")
        {
            if (!DEBUG_MODE_ENABLED) return;
            string[] text = new string[] { "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", "[EXCEPTION " + FunctionName + "] " + ex.Message, "[EXCEPTION " + FunctionName + "] " + ex.StackTrace };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text[0]);
            Console.WriteLine(text[1]);
            Console.WriteLine(text[2]);
            Console.WriteLine(text[0]);
            Console.ResetColor();
            if (DEBUG_MODE_LOG)
            {
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("Exceptions", text[0]);
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("Exceptions", text[1]);
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("Exceptions", text[2]);
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("Exceptions", text[0]);
            }
        }

        public static void WriteJsonString(string logname, string strLog)
        {
            try
            {
                string logFilePath = Alt.Server.Resource.Path + "/Languages/";
                logFilePath = logFilePath + logname + "." + "json";
                string content = File.ReadAllText(logFilePath);
                content = content.Remove(content.Length - 1) + "," + strLog + "]";
                File.WriteAllText(logFilePath, content);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
