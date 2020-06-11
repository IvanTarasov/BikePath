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
            string commandList = "{\n";
            foreach (var command in GlobalData.Commands)
            {
                commandList += command.ToString() + "\n";
            }
            commandList += "}";

            return commandList;
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }
}
