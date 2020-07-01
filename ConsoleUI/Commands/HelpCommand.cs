using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class HelpCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public HelpCommand()
        {
            Name = "help";
            Description = "lists available commands";
        }

        public string Execute()
        {
            string commandList = string.Empty;
            foreach (var command in GlobalData.Commands)
            {
                commandList += command.GetInfo() + "\n";
            }

            return commandList;
        }
    }
}
