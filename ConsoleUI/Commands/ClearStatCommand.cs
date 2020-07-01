using BikePath;
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
            void RemoveRoutes()
            {
                BikePathContext db = new BikePathContext();
                var routes = db.Routes.Include(r => r.User).ToList();
                foreach (var route in routes)
                {
                    db.Routes.Remove(route);
                }
                db.SaveChanges();
            }

            void ClearDistance()
            {
                BikePathContext db = new BikePathContext();
                GlobalData.User.Distance = 0;
                db.Users.Update(GlobalData.User);
                db.SaveChanges();
            }

            RemoveRoutes();
            ClearDistance();

            return "statistics successfully cleared";
        }
    }
}
