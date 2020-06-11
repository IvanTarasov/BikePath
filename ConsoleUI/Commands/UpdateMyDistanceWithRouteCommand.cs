using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class UpdateMyDistanceWithRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateMyDistanceWithRouteCommand()
        {
            Name = "updateMyDistanceWithRoute";
            Description = "updates your distance using an existing route";
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
