using BikePath.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands
{
    class UpdateMyDistanceCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateMyDistanceCommand()
        {
            Name = "update distance";
            Description = "updates your distance using distance input";
        }

        public string Execute()
        {
            string response = string.Empty;
            double length;

            while (true)
            {
                Console.Write("Distance traveled: ");
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
            GlobalData.User.Distance += length;
            db.Users.Update(GlobalData.User);
            db.SaveChanges();

            response = "Succesfull!";
            return response;
        }
    }
}
