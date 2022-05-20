using System;
using System.IO;
using AltV.Net;

namespace VenoX.Debug;

public class JsonHandling
{
    public static void WriteJsonString(string logname, string strLog)
    {
        try
        {
            string logFilePath = Alt.Server.Resource.Path + "/Languages/" + logname + "." + "json";
            ConsoleHandling.OutputDebugString(logFilePath);
            string content = File.ReadAllText(logFilePath);
            content = content.Remove(content.Length - 1) + "," + strLog + "]";
            File.WriteAllText(logFilePath, content);
        }
        catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
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
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}