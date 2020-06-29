using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class NewRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public NewRouteCommand()
        {
            Name = "new route";
            Description = "add new route";
        }

        public string Execute()
        {
            string response = string.Empty;

            Console.WriteLine("NEW ROUTE:");
            Console.Write(" TITLE: ");
            string title = Console.ReadLine();
            double length;

            while (true)
            {
                Console.Write(" LENGTH: ");
                string len = Console.ReadLine();

                if (double.TryParse(len, out length))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect length!");
                }
            }

            BikePathContext db = new BikePathContext();
            db.Routes.Add(new Route { Title = title, Length = length, User = GlobalData.User });

            var entry = db.Entry(GlobalData.User);
            entry.State = EntityState.Unchanged;

            db.SaveChanges();

            response = "Succesfull!";
            return response;
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }
}
