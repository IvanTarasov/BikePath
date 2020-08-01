using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BikePath
{
    public class DBWorker
    {
        private BikePathContext DataBase;
        private DBLogger Logger;

        public DBWorker()
        {
            DataBase = new BikePathContext();
            Logger = new DBLogger();
        }

        #region Extraction operations
        public List<Route> GetUserRoutes(User user)
        {
            try
            {
                var routes = DataBase.Routes.Include(r => r.User).ToList();
                List<Route> userRoutes = new List<Route>();

                foreach (var route in routes)
                    if (route.User == user)
                        userRoutes.Add(route);

                return userRoutes;
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new List<Route>();
            }
        }

        // search and return the existing user
        public User GetExistingUser(string email, string password)
        {
            try
            {
                foreach (var user in DataBase.Users)
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
                Logger.AddLog(e.Message);
                return null;
            }
        }

        // create, save and return new user
        public User GetAndSaveNewUser(string name, string email, string password)
        {
            try
            {
                User newUser = new User { Name = name, Email = email, Password = password, Distance = 0 };
                DataBase.Users.Add(newUser);
                DataBase.SaveChanges();

                return newUser;
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return null;
            }
        }
        #endregion

        #region Change operations
        // clear all user routes of DB
        public OperationStatusMessage ClearRoutes(User user)
        {
            try
            {
                var routes = GetUserRoutes(user);
                DataBase.Routes.RemoveRange(routes);
                DataBase.SaveChanges();
                return new OperationStatusMessage("Routes cleared", "SUCCESS");
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new OperationStatusMessage("Routes not cleared! \nEXCEPTION:" + e.Message, "ERROR");
            }
        }

        // clear user distanse
        public OperationStatusMessage ClearDistance(ref User user)
        {
            try
            {
                user.Distance = 0;
                DataBase.Users.Update(user);
                DataBase.SaveChanges();
                return new OperationStatusMessage("Distance cleared", "SUCCESS");
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new OperationStatusMessage("Distance not cleared! \nEXCEPTION:" + e.Message, "ERROR");
            }
        }

        // add new route in DB
        public OperationStatusMessage AddRoute(string routeTitle, double routeLength, ref User user)
        {
            try
            {
                Route route = new Route { Title = routeTitle, Length = routeLength, User = user };
                DataBase.Routes.Add(route);
                DataBase.SaveChanges();
                return new OperationStatusMessage("Route added", "SUCCESS");
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new OperationStatusMessage("Route not added! \nEXCEPTION:" + e.Message, "ERROR");
            }
        }

        // remove route through title
        public OperationStatusMessage RemoveRoute(User user, string routeTitle)
        {
            try
            {
                var routes = GetUserRoutes(user);
                OperationStatusMessage message = new OperationStatusMessage("there is no such route", "ERROR");
                foreach (var route in routes)
                {
                    if (routeTitle == route.Title)
                    {
                        DataBase.Routes.Remove(route);
                        message = new OperationStatusMessage("route removed", "SUCCESS");
                    }
                }
                DataBase.SaveChanges();
                return message;

            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new OperationStatusMessage("EXCEPTION: " + e.Message , "ERROR");
            }
        }

        // increases user distance
        public OperationStatusMessage UpdateDistance(ref User user, double length)
        {
            try
            {
                user.Distance += length;
                DataBase.Users.Update(user);
                DataBase.SaveChanges();

                return new OperationStatusMessage("distance updated", "SUCCESS");
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new OperationStatusMessage("distance not updated! \nEXCEPTION:" + e.Message, "ERROR");
            }

        }

        // increases user distance through route length
        public OperationStatusMessage UpdateDistanceWithRoute(ref User user, string routeTitle)
        {
            try
            {
                OperationStatusMessage message = new OperationStatusMessage("there is no such route", "ERROR");
                var routes = GetUserRoutes(user);
                foreach (var route in routes)
                {
                    if (routeTitle == route.Title)
                    {
                        user.Distance += route.Length;
                        DataBase.Users.Update(user);
                        message = new OperationStatusMessage("distance updated", "SUCCESS");
                        break;
                    }
                }

                DataBase.SaveChanges();
                return message;
            }
            catch (System.Exception e)
            {
                Logger.AddLog(e.Message);
                return new OperationStatusMessage("EXCEPTION:" + e.Message, "ERROR");
            }

        }
        #endregion
    }
}
