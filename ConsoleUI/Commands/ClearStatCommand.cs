
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

        public string Execute()
        {
            Shell.DBWorker.ClearRoutes();
            Shell.DBWorker.ClearDistance(ref Shell.CurrentUser);

            return "statistics successfully cleared";
        }
    }
}
