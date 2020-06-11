using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class OutCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public OutCommand()
        {
            Name = "out";
            Description = "close application";
        }

        public string Execute()
        {
            GlobalData.ShellIsWork = false;
            return "Goodbye!";
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }
}
