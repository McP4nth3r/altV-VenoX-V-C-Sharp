using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AltV.Net;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV.Models;

namespace VenoXV.Core
{
    public class Debug : IScript
    {
        public static bool DebugModeEnabled = true;
        public static bool DebugModeLog = false;
        public static void OutputDebugString(string textt)
        {
            try
            {
                if (!DebugModeEnabled) return;
                Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + textt);
                string[] text = { "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", textt };
                if (!DebugModeLog) return;
                Logfile.WriteLogs("DebugStrings", text[0]);
                Logfile.WriteLogs("DebugStrings", text[1]);
                Logfile.WriteLogs("DebugStrings", text[0]);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void OutputDebugStringColored(string message, ConsoleColor color)
        {
            try
            {
                if (!DebugModeEnabled) return;
                string[] text = { "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", "|" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "| " + message };
                var pieces = Regex.Split(text[1], @"(\[[^\]]*\])");
                foreach (var t in pieces)
                {
                    string piece = t;
                    if (piece.StartsWith("[") && piece.EndsWith("]"))
                    {
                        Console.ForegroundColor = color;
                        piece = piece[1..^1];
                    }
                    Console.Write(piece);
                    Console.ResetColor();
                }
                Console.WriteLine();
                if (!DebugModeLog) return;
                Logfile.WriteLogs("DebugStrings", text[0]);
                Logfile.WriteLogs("DebugStrings", text[1]);
                Logfile.WriteLogs("DebugStrings", text[0]);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void CatchExceptions(Exception ex, [CallerMemberName] string functionName = "")
        {
            if (!DebugModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("[EXCEPTION " + functionName + "] " + ex.Message);
            Console.WriteLine("[EXCEPTION " + functionName + "] " + ex.StackTrace);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ResetColor();
            if (DebugModeLog)
            {
                Logfile.WriteLogs("Exceptions", "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Logfile.WriteLogs("Exceptions", ex.Message);
                Logfile.WriteLogs("Exceptions", ex.StackTrace);
                Logfile.WriteLogs("Exceptions", "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        public static void WriteJsonString(string logname, string strLog)
        {
            try
            {
                string logFilePath = Alt.Server.Resource.Path + "/Languages/" + logname + "." + "json";
                string content = File.ReadAllText(logFilePath);
                content = content.Remove(content.Length - 1) + "," + strLog + "]";
                File.WriteAllText(logFilePath, content);
            }
            catch (Exception ex) { CatchExceptions(ex); }
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
                catch (Exception ex) { CatchExceptions(ex); }
            }
        }


        [VenoXRemoteEvent("CEF:Debug")]
        public static void DebugCEFPaths(VnXPlayer player, string name, string path)
        {
            try
            {
                string fixedPath = path.Replace("/", "\\");
                const string clientLogPath = "C:\\Users\\Administrator\\Desktop\\Server\\altV-VenoX-Server - TestServer#2\\resources\\VenoXV_Client\\VenoXV_Client\\";
                
                if(File.Exists(clientLogPath + fixedPath)) 
                    Core.Debug.OutputDebugStringColored("File Exists = [True]", ConsoleColor.Green);
                else 
                    Core.Debug.OutputDebugStringColored("File Exists = [False] - " + name + " | " + clientLogPath + fixedPath, ConsoleColor.Red);
            }
            catch (Exception ex) { CatchExceptions(ex); }
        }
    }
}
