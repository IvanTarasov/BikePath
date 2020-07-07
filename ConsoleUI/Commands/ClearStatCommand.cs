using BikePath;
using ConsoleUI.GlobalData;

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
            DBWorker.ClearRoutes(ref ApplicationContext.Context);
            DBWorker.ClearDistance(ref ApplicationContext.Context, ref ActualUser.User);

            return "statistics successfully cleared";
        }
    }
}
