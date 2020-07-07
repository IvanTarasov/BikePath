using BikePath;
using BikePath.Models;
using ConsoleUI.GlobalData;
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
            Console.WriteLine("NEW ROUTE:");
            Console.Write(" TITLE: ");
            string title = Console.ReadLine();
            double length;

            while (true)
            {
                Console.Write(" LENGTH: ");
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

            Route route = new Route { Title = title, Length = length, User = ActualUser.User };
            DBWorker.AddRoute(ref ApplicationContext.Context, route);

            return "route added successfully";
        }
    }
}
