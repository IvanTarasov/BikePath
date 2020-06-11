using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class UpdateMyDistanceCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateMyDistanceCommand()
        {
            Name = "updateMyDistance";
            Description = "updates your distance using distance input";
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
