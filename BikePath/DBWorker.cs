using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath
{
    public static class DBWorker
    {
        public static void RemoveRoutes()
        {
            BikePathContext db = new BikePathContext();
            var routes = db.Routes.Include(r => r.User).ToList();
            foreach (var route in routes)
            {
                db.Routes.Remove(route);
            }
            db.SaveChanges();
        }

        public static void ClearDistance(ref User user)
        {
            BikePathContext db = new BikePathContext();
            user.Distance = 0;
            db.Users.Update(user);
            db.SaveChanges();
        }


    }
}
