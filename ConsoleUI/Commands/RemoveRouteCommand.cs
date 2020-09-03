using BikePath;
using BikePath.Models;
using ConsoleUI.App;
using System;
using System.Collections.Generic;

namespace ConsoleUI.Commands
{
    class RemoveRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public RemoveRouteCommand()
        {
            Name = "remove route";
            Description = "remove changed route";
        }

        public void Execute()
        {
            List<Route> routes = DBWorker.GetUserRoutes(Shell.CurrentUser);
            if (routes != null)
            {
                Console.WriteLine("Routes:");
                foreach (var route in DBWorker.GetUserRoutes(Shell.CurrentUser))
                {
                    Console.WriteLine("  " + route.Title + ": " + route.Length);
                }

                string routeTitle = Shell.GetData("route");
                DBWorker.RemoveRoute(Shell.CurrentUser, routeTitle);
            }
        }
    }
}
