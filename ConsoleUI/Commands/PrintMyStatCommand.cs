using BikePath.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI.Commands
{
    class PrintMyStatCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public PrintMyStatCommand()
        {
            Name = "stat";
            Description = "displays your statistics";
        }

        public void Execute()
        {
            Console.WriteLine("User: " + Shell.CurrentUser.Name);
            Console.WriteLine("Email: " + Shell.CurrentUser.Email);
            Console.WriteLine("Distance: " + Shell.CurrentUser.Distance);
            Console.WriteLine("Routes:");

            List<Route> routes = Shell.DBWorker.GetUserRoutes(Shell.CurrentUser);
            if (routes != null)
            {
                foreach (var route in routes)
                {
                    Console.WriteLine("  " + route.Title + ": " + route.Length);
                }
            }
        }
    }
}
