using BikePath.Models;

namespace ConsoleUI.GlobalData
{
    static class ActualUser
    {
        public static User User;

        public static void SetUser(User user)
        {
            User = user;
        }
    }
}
