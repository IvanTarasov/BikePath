using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikePath
{
    public static class DBWorker
    {
        private static BikePathContext DataBase = new BikePathContext();
        private static DBLogger Logger = new DBLogger();

        #region Extraction operations
        public static List<Route> GetUserRoutes(User user)
        {
            try
            {
                var routes = DataBase.Routes.Where(r => r.UserId == user.Id).ToList();
                return routes;
            }
            catch (Exception e)
            {
                Logger.AddLog(e.Message);
                return null;
            }
        }

        // search and return the existing user
        public static User GetExistingUser(string email, string password)
        {
            try
            {
                User user = DataBase.Users.FirstOrDefault(u => (u.Email == email) & (u.Password == password)); 
                return user;
            }
            catch (Exception e)
            {
                Logger.AddLog(e.Message);
                return null;
            }
        }

        // create, save and return new user
        public static User GetAndSaveNewUser(string name, string email, string password)
        {
            try
            {
                User newUser = new User { Name = name, Email = email, Password = password, Distance = 0 };
                DataBase.Users.Add(newUser);
                DataBase.SaveChanges();

                return newUser;
            }
            catch (Exception e)
            {
                Logger.AddLog(e.Message);
                return null;
            }
        }
        #endregion

        #region Change operations
        // clear all user routes of DB
        public static void ClearRoutes(User user)
        {
            string log;
            try
            {
                var routes = GetUserRoutes(user);
                DataBase.Routes.RemoveRange(routes);
                DataBase.SaveChanges();
                log = "Routes cleared";
            }
            catch (Exception e)
            {
                log = "Routes not cleared! \nEXCEPTION:" + e.Message;
            }
            Logger.AddLog(log);
        }

        // clear user distanse
        public static void ClearDistance(ref User user)
        {
            string log;
            try
            {
                user.Distance = 0;
                DataBase.Users.Update(user);
                DataBase.SaveChanges();
                log = "Distance cleared";
            }
            catch (Exception e)
            {
                Logger.AddLog(e.Message);
                log = "Distance not cleared! \nEXCEPTION:" + e.Message;
            }
            Logger.AddLog(log);
        }

        // add new route in DB
        public static void AddRoute(string routeTitle, string routeLength, ref User user)
        {
            string log;
            try
            {
                double length = double.Parse(routeLength);
                Route route = new Route { Title = routeTitle, Length = length, User = user };
                DataBase.Routes.Add(route);
                DataBase.SaveChanges();
                log = "Route added";
            }
            catch (Exception e)
            {
                log = "Route not added! \nEXCEPTION:" + e.Message;
            }
            Logger.AddLog(log);
        }

        // remove route through title
        public static void RemoveRoute(User user, string routeTitle)
        {
            string log;
            try
            {
                var routes = GetUserRoutes(user);
                log = "there is no such route";
                foreach (var route in routes)
                {
                    if (routeTitle == route.Title)
                    {
                        DataBase.Routes.Remove(route);
                        log = "route removed";
                    }
                }
                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                log = "EXCEPTION: " + e.Message;
            }
            Logger.AddLog(log);
        }

        // increases user distance
        public static void UpdateDistance(ref User user, string length)
        {
            string log;
            try
            {
                user.Distance += double.Parse(length);
                DataBase.Users.Update(user);
                DataBase.SaveChanges();

                log = "distance updated";
            }
            catch (Exception e)
            {
                log = "distance not updated! \nEXCEPTION:" + e.Message;
            }
            Logger.AddLog(log);
        }

        // increases user distance through route length
        public static void UpdateDistanceWithRoute(ref User user, string routeTitle)
        {
            string log;
            try
            {
                log = "there is no such route";
                var routes = GetUserRoutes(user);
                foreach (var route in routes)
                {
                    if (routeTitle == route.Title)
                    {
                        user.Distance += route.Length;
                        DataBase.Users.Update(user);
                        log = "distance updated";
                        break;
                    }
                }

                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                log = "EXCEPTION:" + e.Message;
            }
            Logger.AddLog(log);
        }
        #endregion
    }
}
