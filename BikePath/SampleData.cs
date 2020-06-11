using BikePath.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikePath
{
    public static class SampleData
    {
        public static void InitDB(BikePathContext context)
        {
            if (!context.Users.Any())
            {
                User U1 = GetNewUser("Ivan Tarasov", "ivan.tarasov12345@gmail.com", "1234509876_Asdivannew", 0);
                context.Users.Add(U1);
                context.SaveChanges();

                Route R1 = new Route { Title = "РОДНИК-ЁЛОЧКИ", Length = 16, User = U1};
                Route R2 = new Route { Title = "ПРУД-БЛИЖНИЕ_ЁЛОЧКИ", Length = 12, User = U1 };
                Route R3 = new Route { Title = "ЗА СТРЕТИНКОЙ", Length = 13, User = U1 };
                context.Routes.AddRange(R1, R2, R3);
                context.SaveChanges();
            }
        }

        private static User GetNewUser(string name, string email, string password, double distance)
        {
            User user = new User { Name = name, Email = email, Password = password, Distance = distance};
            return user;
        }
    }
}
