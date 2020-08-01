using BikePath.Models;
using ConsoleUI.App;
using System;
using System.Collections.Generic;

namespace ConsoleUI.Commands
{
    class UpdateMyDistanceWithRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateMyDistanceWithRouteCommand()
        {
            Name = "use route";
            Description = "updates your distance using an existing route";
        }

        public void Execute()
        {
            List<Route> routes = Shell.DBWorker.GetUserRoutes(Shell.CurrentUser);
            if (routes != null)
            {
                Console.WriteLine("Routes:");
                foreach (var route in Shell.DBWorker.GetUserRoutes(Shell.CurrentUser))
                {
                    Console.WriteLine("  " + route.Title + ": " + route.Length);
                }
            }

            string routeTitle = Shell.GetData("route");

            ConsoleDrawer.DrawMessage(Shell.DBWorker.UpdateDistanceWithRoute(ref Shell.CurrentUser, routeTitle));
        }
    }
}
