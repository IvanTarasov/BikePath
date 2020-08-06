using BikePath;
using ConsoleUI.App;
using System;

namespace ConsoleUI.Commands
{
    class UpdateMyDistanceCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateMyDistanceCommand()
        {
            Name = "update distance";
            Description = "updates your distance using distance input";
        }

        public void Execute()
        {
            string length = Shell.GetData("distance");
            DBWorker.UpdateDistance(ref Shell.CurrentUser, length);
        }
    }
}
