using BikePath;
using BikePath.Models;
using System;

namespace ConsoleUI.Commands
{
    class NewRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public NewRouteCommand()
        {
            Name = "new route";
            Description = "add new route";
        }

        public string Execute()
        {
            Console.WriteLine("[NEW ROUTE]");
            string title = Shell.GetData("title");
            double length;

            while (true)
            {
                string len = Shell.GetData("length");

                if (double.TryParse(len, out length))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect length!");
                }
            }
            Shell.DBWorker.AddRoute(title, length, ref Shell.CurrentUser);

            return "route added successfully";
        }
    }
}
