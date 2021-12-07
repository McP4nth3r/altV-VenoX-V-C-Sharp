using System;
using System.Text.RegularExpressions;

namespace VenoX.Debug
{
    public class ConsoleHandling
    {
        public class Debug
        {
            public static void OutputDebugString(string textt)
            {
                try
                {
                    if (!Settings.DebugModeEnabled) return;
                    Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + textt);
                }
                catch (Exception ex)
                {
                    ExceptionHandling.CatchExceptions(ex);
                }
            }

            public static void OutputDebugStringColored(string message, ConsoleColor color)
            {
                try
                {
                    if (!Settings.DebugModeEnabled) return;
                    Console.ResetColor();
                    string[] text =
                    {
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", 
                        "|" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "| " + message
                    };
                    var pieces = Regex.Split(text[1], @"(\[[^\]]*\])");
                    foreach (var t in pieces)
                    {
                        string piece = t;
                        if (piece.StartsWith("[") && piece.EndsWith("]"))
                        {
                            //Console.ForegroundColor = color;
                            piece = piece[1..^1];
                        }
                        Console.Write(piece);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    ExceptionHandling.CatchExceptions(ex);
                }
            }
        }
    }
}