using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BikePath
{
    public class DBWorker
    {
        private BikePathContext db;
        private DBLogger logger;

        public DBWorker()
        {
            db = new BikePathContext();
            logger = new DBLogger();
        }

        #region Extraction operations
        public List<Route> GetUserRoutes()
        {
            try
            {
                return db.Routes.Include(r => r.User).ToList();
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new List<Route>();
            }
        }

        // search and return the existing user
        public User GetExistingUser(string email, string password)
        {
            try
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
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return null;
            }
        }

        // create, save and return new user
        public User GetAndSaveNewUser(string name, string email, string password)
        {
            try
            {
                User newUser = new User { Name = name, Email = email, Password = password, Distance = 0 };
                db.Users.Add(newUser);
                db.SaveChanges();

                return newUser;
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return null;
            }
        }
        #endregion

        #region Change operations
        // clear all user routes of DB
        public DBMessage ClearRoutes()
        {
            try
            {
                var routes = GetUserRoutes();
                db.Routes.RemoveRange(routes);
                db.SaveChanges();
                return new DBMessage("Routes cleared", "SUCCESS");
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new DBMessage("Routes not cleared! \nEXCEPTION:" + e.Message, "ERROR");
            }
        }

        // clear user distanse
        public DBMessage ClearDistance(ref User user)
        {
            try
            {
                user.Distance = 0;
                db.Users.Update(user);
                db.SaveChanges();
                return new DBMessage("Distance cleared", "SUCCESS");
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new DBMessage("Distance not cleared! \nEXCEPTION:" + e.Message, "ERROR");
            }
        }

        // add new route in DB
        public DBMessage AddRoute(string routeTitle, double routeLength, ref User user)
        {
            try
            {
                Route route = new Route { Title = routeTitle, Length = routeLength, User = user };
                db.Routes.Add(route);
                db.SaveChanges();
                return new DBMessage("Route added", "SUCCESS");
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new DBMessage("Route not added! \nEXCEPTION:" + e.Message, "ERROR");
            }
        }

        // remove route through title
        public DBMessage RemoveRoute(string routeTitle)
        {
            try
            {
                var routes = GetUserRoutes();
                DBMessage message = new DBMessage("there is no such route", "ERROR");
                foreach (var route in routes)
                {
                    if (routeTitle == route.Title)
                    {
                        db.Routes.Remove(route);
                        message = new DBMessage("route removed", "SUCCESS");
                    }
                }
                db.SaveChanges();
                return message;

            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new DBMessage("EXCEPTION: " + e.Message , "ERROR");
            }
        }

        // increases user distance
        public DBMessage UpdateDistance(ref User user, double length)
        {
            try
            {
                user.Distance += length;
                db.Users.Update(user);
                db.SaveChanges();

                return new DBMessage("distance updated", "SUCCESS");
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new DBMessage("distance not updated! \nEXCEPTION:" + e.Message, "ERROR");
            }

        }

        // increases user distance through route length
        public DBMessage UpdateDistanceWithRoute(ref User user, string routeTitle)
        {
            try
            {
                DBMessage message = new DBMessage("there is no such route", "ERROR");
                var routes = GetUserRoutes();
                foreach (var route in routes)
                {
                    if (routeTitle == route.Title)
                    {
                        user.Distance += route.Length;
                        db.Users.Update(user);
                        message = new DBMessage("distance updated", "SUCCESS");
                        break;
                    }
                }

                db.SaveChanges();
                return message;
            }
            catch (System.Exception e)
            {
                logger.AddLog(e.Message);
                return new DBMessage("EXCEPTION:" + e.Message, "ERROR");
            }

        }
        #endregion
    }
}
