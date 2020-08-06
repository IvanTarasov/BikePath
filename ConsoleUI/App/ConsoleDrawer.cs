using BikePath;
using System;

namespace ConsoleUI.App
{
    static class ConsoleDrawer
    {
        public static void DrawMessage(OperationStatusMessage message)
        {
            switch (message.Type.ToUpper())
            {
                case "SUCCESS":
                    DrawSuccessMessage(message.Text);
                    break;
                case "ERROR":
                    DrawErrorMessage(message.Text);
                    break;
            }
        }

        public static void PrintInitialInfo()
        {
            Console.WriteLine("Bike Path console UI");
            Console.WriteLine("Author - Ivan Tarasov");
            Console.WriteLine("=====================================");
            Console.WriteLine("Type 'help' to get a list of commands");
            Console.WriteLine("/ / / / / / / / / / / / / / / / / / /");
        }

        public static void PrintLastLog()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(DBLogger.LastLog);
            Console.ResetColor();

            DBLogger.ClearLastLog();
        }

        private static void DrawSuccessMessage(string message)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + message.ToUpper() + "\n");
            Console.ResetColor();
        }

        private static void DrawErrorMessage(string message)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message.ToUpper() + "\n");
            Console.ResetColor();
        }
    }
}
