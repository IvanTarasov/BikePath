using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BikePath
{
    public class DBWorker
    {
        private BikePathContext db;

        public DBWorker()
        {
            db = new BikePathContext();
        }

        public List<Route> GetUserRoutes()
        {
            return db.Routes.Include(r => r.User).ToList();
        }

        // clear all routes of DB
        public void ClearRoutes()
        {
            var routes = GetUserRoutes();
            db.Routes.RemoveRange(routes);
            db.SaveChanges();
        }

        // clear user distanse
        public void ClearDistance(ref User user)
        {
            user.Distance = 0;
            db.Users.Update(user);
            db.SaveChanges();
        }

        // add new route in DB
        public void AddRoute(string routeTitle, double routeLength, ref User user)
        {
            Route route = new Route { Title = routeTitle, Length = routeLength, User = user};

            db.Routes.Add(route);
            db.SaveChanges();
        }

        // remove route through title
        public string RemoveRoute(string routeTitle)
        {
            string response = "there is no such route";

            var routes = GetUserRoutes();
            foreach (var route in routes)
            {
                if (routeTitle == route.Title)
                {
                    db.Routes.Remove(route);
                    response = "route removed";
                    break;
                }
            }

            db.SaveChanges();
            return response;
        }

        // increases user distance
        public void UpdateDistance(ref User user, double length)
        {
            user.Distance += length;
            db.Users.Update(user);
            db.SaveChanges();
        }

        // increases user distance through route length
        public string UpdateDistanceWithRoute(ref User user, string routeTitle)
        {
            string response = "there is no such route";

            var routes = GetUserRoutes();
            foreach (var route in routes)
            {
                if (routeTitle == route.Title)
                {
                    user.Distance += route.Length;
                    db.Users.Update(user);

                    response =  "distance updated";
                    break;
                }
            }

            db.SaveChanges();
            return response;
        }

        // search and return the existing user
        public User GetExistingUser(string email, string password)
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
        public User GetAndSaveNewUser(string name, string email, string password)
        {
            User newUser = new User { Name = name, Email = email, Password = password, Distance = 0 };
            db.Users.Add(newUser);
            db.SaveChanges();

            return newUser;
        }
    }
}
