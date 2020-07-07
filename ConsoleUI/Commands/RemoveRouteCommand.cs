using BikePath;
using ConsoleUI.GlobalData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public string Execute()
        {
            var routes = ApplicationContext.Context.Routes.Include(r => r.User).ToList();
            Console.WriteLine("Routes:");
            foreach (var route in routes)
            {
                Console.WriteLine("  " + route.Title + ": " + route.Length);
            }

            Console.Write("Select route: ");
            string routeTitle = Console.ReadLine();

            return DBWorker.RemoveRoute(ref ApplicationContext.Context, routeTitle);
        }
    }
}
