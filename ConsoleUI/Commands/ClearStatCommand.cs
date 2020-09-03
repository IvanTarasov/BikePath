using BikePath;
using ConsoleUI.App;

namespace ConsoleUI.Commands
{
    class ClearStatCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ClearStatCommand()
        {
            Name = "clear stat";
            Description = "clear you statistic (routes and distance)";
        }

        public void Execute()
        { 
            DBWorker.ClearRoutes(Shell.CurrentUser);
            DBWorker.ClearDistance(ref Shell.CurrentUser);
        }
    }
}
