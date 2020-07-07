using System.Collections.Generic;

namespace ConsoleUI.GlobalData
{
    static class CommandList
    {
        public static List<ICommand> Commands { get; private set; }

        public static void SetCommands(List<ICommand> commands)
        {
            Commands = commands;
        }
    }
}
