using BikePath.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI.Commands
{
    class ClearStatCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ClearStatCommand()
        {
            Name = "clear stat";
            Description = "clear you statistic (routes and distance)";
        }

        public string Execute()
        {
            string response = string.Empty;

            BikePathContext db = new BikePathContext();
            var routes = db.Routes.Include(r => r.User).ToList();
            foreach (var route in routes)
            {
                db.Routes.Remove(route);
            }
            db.SaveChanges();

            BikePathContext bd = new BikePathContext();
            GlobalData.User.Distance = 0;
            bd.Users.Update(GlobalData.User);
            bd.SaveChanges();

            response = "Success!";

            return response;
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }
}
