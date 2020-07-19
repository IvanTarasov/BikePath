using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BikePath
{
    public static class DBWorker
    {
        // clear all routes of DB
        public static void ClearRoutes(ref BikePathContext db)
        {
            var routes = db.Routes.Include(r => r.User).ToList();
            foreach (var route in routes)
            {
                db.Routes.Remove(route);
            }
            db.SaveChanges();
        }

        // clear user distanse
        public static void ClearDistance(ref BikePathContext db, ref User user)
        {
            user.Distance = 0;
            db.Users.Update(user);
            db.SaveChanges();
        }

        // add new route in DB
        public static void AddRoute(ref BikePathContext db, Route route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
        }

        // remove route through title
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

        // increases user distance
        public static void UpdateDistance(ref BikePathContext db, ref User user, double length)
        {
            user.Distance += length;
            db.Users.Update(user);
            db.SaveChanges();
        }

        // increases user distance through route length
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

        // search and return the existing user
        public static User GetExistingUser(ref BikePathContext db, string email, string password)
        {
            foreach (var user in db.Users)
            {
                if (email == user.Email && password == user.Password)
                {
                    return user;
                }
            }

            return null;
        }

        // create, save and return new user
        public static User GetAndSaveNewUser(ref BikePathContext db, string name, string email, string password)
        {
            User newUser = new User { Name = name, Email = email, Password = password, Distance = 0 };
            db.Users.Add(newUser);
            db.SaveChanges();

            return newUser;
        }
    }
}
