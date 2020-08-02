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

        public void Execute()
        {
            foreach (var command in Shell.Commands)
            {
                Console.WriteLine(command.GetInfo());
            }
        }
    }
}
