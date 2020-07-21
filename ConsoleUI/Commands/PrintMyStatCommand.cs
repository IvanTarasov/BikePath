using System;

namespace ConsoleUI.Commands
{
    class PrintMyStatCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public PrintMyStatCommand()
        {
            Name = "stat";
            Description = "displays your statistics";
        }

        public string Execute()
        {
            Console.WriteLine("User: " + Shell.CurrentUser.Name);
            Console.WriteLine("Email: " + Shell.CurrentUser.Email);
            Console.WriteLine("Distance: " + Shell.CurrentUser.Distance);
            Console.WriteLine("Routes:");
            foreach (var route in Shell.DBWorker.GetUserRoutes())
            {
                Console.WriteLine("  " + route.Title + ": " + route.Length);
            }

            return "statistics printed";
        }
    }
}
