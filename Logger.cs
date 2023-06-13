using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW5_module2
{
    public class Logger
    {
        private static Logger? _instance;
        private static string[] logs = new string[100];
        private static int maxLogs = 100;
        private static int currentLogIndex = 0;

        private Logger()
        {
        }

        public enum LogLevel
        {
            Error,
            Info,
            Warning
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
            }
        }

        public void Log(string message, LogLevel logLevel)
        {
            string log = $"{DateTime.Now}: {logLevel}: {message}";
            logs[currentLogIndex] = log;
            currentLogIndex = (currentLogIndex + 1) % maxLogs;
            Console.WriteLine(log);
            FileService.WriteToFile(log);
        }

        public string GetLogs()
        {
            return string.Join("\n", logs);
        }
    }
}
