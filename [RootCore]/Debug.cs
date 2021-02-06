using AltV.Net;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace VenoXV.Core
{
    public class Debug : IScript
    {
        public static bool DEBUG_MODE_ENABLED = true;
        public static bool DEBUG_MODE_LOG = false;
        public static void OutputDebugString(string textt)
        {
            try
            {
                if (!DEBUG_MODE_ENABLED) return;
                Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + textt);
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
        public static void OutputDebugStringColored(string message, ConsoleColor color)
        {
            try
            {
                if (!DEBUG_MODE_ENABLED) return;
                string[] text = new string[] { "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", "|" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "| " + message };
                var pieces = Regex.Split(text[1], @"(\[[^\]]*\])");
                for (int i = 0; i < pieces.Length; i++)
                {
                    string piece = pieces[i];
                    if (piece.StartsWith("[") && piece.EndsWith("]"))
                    {
                        Console.ForegroundColor = color;
                        piece = piece[1..^1];
                    }
                    Console.Write(piece);
                    Console.ResetColor();
                }
                Console.WriteLine();
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

        public static void WriteAllText(string logname, string strLog)
        {
            {
                try
                {
                    string logFilePath = Alt.Server.Resource.Path + "/Languages/";
                    logFilePath = logFilePath + logname + "." + "json";
                    File.WriteAllText(logFilePath, strLog);
                }
                catch (Exception ex) { Debug.CatchExceptions(ex); }
            }
        }
    }
}
