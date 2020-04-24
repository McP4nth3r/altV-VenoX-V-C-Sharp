using AltV.Net.Elements.Entities;
using System.IO;
using System.Text;
using VenoXV._Gamemodes_.Reallife.Globals;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;
using AltV.Net;

namespace VenoXV._Gamemodes_.Reallife.vnx_stored_files
{
    public class logfile : IScript
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
            catch { }
        }


        public static void WriteAntiCheatLogs(string logname, string strLog)
        {
            try
            {
                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

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
            catch { }
        }
    }
}
