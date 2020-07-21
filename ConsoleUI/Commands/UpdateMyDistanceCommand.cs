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

        public string Execute()
        {
            double length;

            while (true)
            {
                string len = Shell.GetData("distance");

                if (double.TryParse(len, out length))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect length!");
                }
            }

            Shell.DBWorker.UpdateDistance(ref Shell.CurrentUser, length);
            return "distance updated";
        }
    }
}
