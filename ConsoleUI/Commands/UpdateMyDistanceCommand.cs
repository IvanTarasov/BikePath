using BikePath;
using ConsoleUI.GlobalData;
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
                Console.Write("Distance traveled: ");
                string len = Console.ReadLine();

                if (double.TryParse(len, out length))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect length!");
                }
            }

            DBWorker.UpdateDistance(ref ApplicationContext.Context, ref ActualUser.User, length);
            return "distance updated";
        }
    }
}
