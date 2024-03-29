﻿using System;
using System.IO;
using AltV.Net;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.vnx_stored_files
{
    public class Logfile : IScript
    {

        public static void WriteLogs(string logname, string strLog)
        {
            try
            {
                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                //string logFilePath = "C:\\Users\\Administrator\\Desktop\\vnx_log_files\\";
                string logFilePath = "C:\\inetpub\\vhosts\\cp-venox.com\\httpdocs\\pages\\vnx_log_files\\";
                logFilePath = logFilePath + logname + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + " | " + DateTime.Now.ToString("HH:mm:ss tt") + " | " + strLog);
                log.Close();
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
