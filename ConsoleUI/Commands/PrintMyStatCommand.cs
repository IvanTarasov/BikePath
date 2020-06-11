using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class PrintMyStatCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public PrintMyStatCommand()
        {
            Name = "printMyStat";
            Description = "displays your statistics";
        }

        public string Execute()
        {
            return "null";
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }
}
