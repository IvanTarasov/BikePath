using BikePath;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleUI.App
{
    static class ConsoleDrawer
    {
        public static void DrawMessage(DBMessage message)
        {
            switch (message.Type.ToUpper())
            {
                case "SUCCESS":
                    DrawSuccessMessage(message.Text);
                    break;
                case "ERROR":
                    DrawErrorMessage(message.Text);
                    break;
                default:
                    DefaultDraw(message.Text);
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

        private static void DefaultDraw(string message)
        {
            Console.WriteLine(message + "\n");
        }
    }
}
