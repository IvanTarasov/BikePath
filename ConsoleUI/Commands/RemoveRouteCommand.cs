using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string response = string.Empty;

            BikePathContext db = new BikePathContext();
            Console.WriteLine("           ROUTES" + "\n");
            Console.WriteLine("  Title     " + "|" + "     Length  " + "\n");
            var routes = db.Routes.Include(r => r.User).ToList();
            foreach (var route in routes)
            {
                Console.WriteLine(route.Title + " | " + route.Length + "\n");
            }

            Console.Write("Select route: ");
            string selectRoute = Console.ReadLine();

            foreach (var route in routes)
            {
                if (selectRoute == route.Title)
                {
                    db.Routes.Remove(route);
                    db.SaveChanges();

                    return "Success!";
                }
            }

            return "Unknown route!";
        }
    }
}
