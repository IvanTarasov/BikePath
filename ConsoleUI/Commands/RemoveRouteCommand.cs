using System;

namespace ConsoleUI.Commands
{
    class RemoveRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public RemoveRouteCommand()
        {
            Name = "remove route";
            Description = "remove changed route";
        }

        public string Execute()
        {
            Console.WriteLine("Routes:");
            foreach (var route in Shell.DBWorker.GetUserRoutes())
            {
                Console.WriteLine("  " + route.Title + ": " + route.Length);
            }

            string routeTitle = Shell.GetData("route");

            return Shell.DBWorker.RemoveRoute(routeTitle);
        }
    }
}
