using BikePath.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    static class GlobalData
    {
        public static List<ICommand> Commands { get; private set; }
        public static User User;
        public static bool ShellIsWork;
        public static bool AppTest = true;

        public static void SetCommads(List<ICommand> commands)
        {
            Commands = commands;
        }
    }
}
