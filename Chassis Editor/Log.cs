using System;
using System.IO;
using System.Diagnostics;

namespace Chassis_Editor
{
    public static class Log
    {
        public enum LogType { EXCEPTION, INITIALIZE, CLICK, SHOW, HIDE, MODELUPDATE, FILELOAD, FILEWRITE, UNROLL, HARDPOINT, LOOPS};

        // This running log will be updated throughout runtime and then written to the current directory at the end of the Main function
        static string logText = "";

        // This enables logging at all. If it is disabled, then no logs are recorded or output
        static bool enableLogging = true;

        // This enables writing to a file. If true, log text will be stored in a string and the WriteLog function is enabled
        static bool creatingFile = false;

        // These are all types of exceptions that are related to the LogType enum. Calls to updateLog check the related bool before adding to the logText variable
        static bool enableExceptionLogging = true;
        static bool enableInitializeLogging = true;
        static bool enableClickLogging = true;
        static bool enableShowLogging = true;
        static bool enableHideLogging = true;
        static bool enableModelUpdateLogging = true;
        static bool enableFileLoadLogging = true;
        static bool enableFileWriteLogging = true;
        static bool enableHardpointLogging = true;
        static bool enableLoopsLogging = true;

        // Unroll logging means that the contents of files loaded will be logged
        static bool enableUnrollLogging = true;

        public static void WriteLog(string path)
        {
            if (creatingFile)
            {
                File.WriteAllText(path, logText);
            }
        }

        public static bool LoggingEnabled()
        {
            return enableLogging;
        }

        public static void SetEnableLogging(bool newVal)
        {
            enableLogging = newVal;
        }

        // add a line to the logText with defined format
        public static void updateLog(LogType logType, string log)
        {
            if (!enableLogging)
                return;

            if (LogThis(logType))
            {

                if (creatingFile)
                {
                    string timestamp = DateTime.Now.ToString("hh:mm:ss:tt");
                    string delimiter = "- ";
                    logText += timestamp + delimiter + log + "\n";
                }
                else
                    Debug.WriteLine(log);
            }
        }

        private static bool LogThis(LogType logType)
        {
            switch (logType)
            {
                case LogType.CLICK:
                    return enableClickLogging;
                case LogType.EXCEPTION:
                    return enableExceptionLogging;
                case LogType.FILELOAD:
                    return enableFileLoadLogging;
                case LogType.FILEWRITE:
                    return enableFileWriteLogging;
                case LogType.HIDE:
                    return enableHideLogging;
                case LogType.INITIALIZE:
                    return enableInitializeLogging;
                case LogType.MODELUPDATE:
                    return enableModelUpdateLogging;
                case LogType.SHOW:
                    return enableShowLogging;
                case LogType.UNROLL:
                    return enableUnrollLogging;
                case LogType.HARDPOINT:
                    return enableHardpointLogging;
                case LogType.LOOPS:
                    return enableLoopsLogging;
                default:
                    return true;
            }
        }
    }
}
