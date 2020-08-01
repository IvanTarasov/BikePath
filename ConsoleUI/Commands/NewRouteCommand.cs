using BikePath;
using ConsoleUI.App;
using System;

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

        public void Execute()
        {
            Console.WriteLine("[NEW ROUTE]");
            string title = Shell.GetData("title");
            double length;

            while (true)
            {
                string len = Shell.GetData("length");

                if (double.TryParse(len, out length))
                {
                    break;
                }
                else
                {
                    ConsoleDrawer.DrawMessage(new OperationStatusMessage("Incorrect length!", "ERROR"));
                }
            }
            ConsoleDrawer.DrawMessage(Shell.DBWorker.AddRoute(title, length, ref Shell.CurrentUser));
        }
    }
}
