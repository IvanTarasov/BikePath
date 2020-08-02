using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath
{
    class DBLogger
    {
        private const string FILE = "logs.txt";

        public async void AddLog(string message)
        {
            string time = "[" + DateTime.Now + "]";
            string log = time + ": " + message + "\n \n";

            using (StreamWriter sw = new StreamWriter(FILE, false, System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync(log);
            }
        }
    }
}
