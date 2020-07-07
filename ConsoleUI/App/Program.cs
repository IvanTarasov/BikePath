using ConsoleUI.App;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool tested = true;
            Config.SetConfig(tested);

            Shell shell = new Shell();
            shell.Start();
        }
    }
}
