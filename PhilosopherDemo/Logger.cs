using System;
using System.IO;

using PhilosopherDemo.Const;

namespace PhilosopherDemo
{
    class Logger
    {
        private static object obj1 = new object();

        public static void Log(DateTime time,  string threadName, string message)
        {
            lock (obj1)
            {
                File.AppendAllText(DefaultSetting.DEFAULT_LOG_FILE_NAME, string.Format("{0}: {1} - {2}{3}", time.ToShortTimeString(), threadName, message, Environment.NewLine));
            }
        }
    }
}
