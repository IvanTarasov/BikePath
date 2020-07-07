using BikePath.Models;
using ConsoleUI.GlobalData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            User user = ActualUser.User;
            var routes = ApplicationContext.Context.Routes.Include(r => r.User).ToList();

            Console.WriteLine("User: " + user.Name);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Distance: " + user.Distance);
            Console.WriteLine("Routes:");
            foreach (var route in routes)
            {
                Console.WriteLine("  " + route.Title + ": " + route.Length);
            }

            return "statistics printed";
        }
    }
}
