using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class NewRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public NewRouteCommand()
        {
            Name = "newRoute";
            Description = "add new route";
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
