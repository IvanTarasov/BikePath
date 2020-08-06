using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath
{
    public class DBLogger
    {
        public static string LastLog { get; private set; }
        private const string FILE = "C:/Users/ivant/source/repos/IvanTarasov/BikePath/logs.txt";

        public async void AddLog(string message)
        {
            string time = "[" + DateTime.Now + "]";
            string log = time + ": " + message + "\n \n";

            LastLog = log;

            using (StreamWriter sw = new StreamWriter(FILE, false, System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync(log);
            }
        }

        public static void ClearLastLog()
        {
            LastLog = string.Empty;
        }
    }
}
