using BikePath;
using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI.Commands
{
    class TestCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public TestCommand()
        {
            Name = "test";
            Description = "test DB";
        }

        public string Execute()
        {
            string response = "";
            BikePathContext context = new BikePathContext();
            SampleData.InitDB(context);

            var users = context.Users.Include(u => u.Routes).ToList();
            foreach (var user in users)
            {
                foreach (var route in user.Routes)
                {
                    response += route.Title + " " + route.Length + "\n";
                }
            }
            return response;
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }
}
