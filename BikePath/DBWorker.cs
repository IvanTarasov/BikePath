using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BikePath
{
    public static class DBWorker
    {
        public static void ClearRoutes(ref BikePathContext db)
        {
            var routes = db.Routes.Include(r => r.User).ToList();
            foreach (var route in routes)
            {
                db.Routes.Remove(route);
            }
            db.SaveChanges();
        }

        public static void ClearDistance(ref BikePathContext db, ref User user)
        {
            user.Distance = 0;
            db.Users.Update(user);
            db.SaveChanges();
        }

        public static void AddRoute(ref BikePathContext db, Route route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
        }

        public static string RemoveRoute(ref BikePathContext db, string routeTitle)
        {
            string response = "there is no such route";
            foreach (var route in db.Routes)
            {
                if(routeTitle == route.Title)
                {
                    db.Routes.Remove(route);

                    response = "route removed";
                }
            }
            db.SaveChanges();
            return response;
        }

        public static void UpdateDistance(ref BikePathContext db, ref User user, double length)
        {
            user.Distance += length;
            db.Users.Update(user);
            db.SaveChanges();
        }

        public static string UpdateDistanceWithRoute(ref BikePathContext db, ref User user, string routeTitle)
        {
            string response = "there is no such route";
            foreach (var route in db.Routes)
            {
                if (routeTitle == route.Title)
                {
                    user.Distance += route.Length;
                    db.Users.Update(user);

                    response =  "distance updated";
                }
            }

            db.SaveChanges();
            return response;
        }
    }
}
