using ConsoleUI.GlobalData;
using System;

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
            foreach (var command in CommandList.Commands)
            {
                Console.WriteLine(command.GetInfo());
            }

            return "command list received";
        }
    }
}
