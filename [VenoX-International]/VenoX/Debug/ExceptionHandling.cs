using System;
using System.Runtime.CompilerServices;

namespace VenoX.Debug
{
    public class ExceptionHandling
    {
        public static void CatchExceptions(Exception ex, [CallerMemberName] string functionName = "")
        {
            if (!Settings.DebugModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("[EXCEPTION " + functionName + "] " + ex.Message);
            Console.WriteLine("[EXCEPTION " + functionName + "] " + ex.StackTrace);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ResetColor();
        }
    }
}