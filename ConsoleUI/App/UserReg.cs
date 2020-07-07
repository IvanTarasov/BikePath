using BikePath.Models;
using ConsoleUI.GlobalData;

namespace ConsoleUI
{
    static class UserReg
    {
        public static User EnterToAccount(string email, string password)
        {
            foreach (var user in ApplicationContext.Context.Users)
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
