using System;

namespace ConsoleUI.Commands
{
    class UpdateMyDistanceWithRouteCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateMyDistanceWithRouteCommand()
        {
            Name = "use route";
            Description = "updates your distance using an existing route";
        }

        public string Execute()
        {
            Console.WriteLine("Routes:");
            foreach (var route in Shell.DBWorker.GetUserRoutes())
            {
                Console.WriteLine("  " + route.Title + ": " + route.Length);
            }

            string routeTitle = Shell.GetData("route");

            return Shell.DBWorker.UpdateDistanceWithRoute(ref Shell.CurrentUser, routeTitle);
        }
    }
}
