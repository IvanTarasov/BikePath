using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string Execute()
        {
            string response = string.Empty;
            User user = GlobalData.User;
            BikePathContext db = new BikePathContext();


            response += "User: " + user.Name + "\n"
                      + "Email: " + user.Email + "\n"
                      + "Distance: " + user.Distance + "\n" + "\n";

            response += "           ROUTES" + "\n";
            response += "  Title     " + "|" + "     Length  " + "\n";

            var routes = db.Routes.Include(r => r.User).ToList();
            foreach (var route in routes)
            {
                response += route.Title + " | " + route.Length + "\n";
            }

            return response;
        }
    }
}
