using BikePath.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    static class UserReg
    {
        public static User EnterToAccount(string email, string password)
        {
            BikePathContext db = new BikePathContext();

            foreach (var user in db.Users)
            {
                if (email == user.Email && password == user.Password)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
