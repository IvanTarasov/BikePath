using BikePath;
using BikePath.Models;
using ConsoleUI.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    static class Shell
    {
        public static List<ICommand> Commands { get; private set; }
        public static string WorkStatus { get; set; }
        public static DBWorker DBWorker { get; private set; }
        public static User CurrentUser;

        public const string ACTIVE = "ACTIVE";
        public const string DISABLE = "DISABLE";

        public static void Start()
        {
            WorkStatus = ACTIVE;
            DBWorker = new DBWorker();

            GetCurrentUser();
            InitCommands();
            PrintInitialInfo();
            StartGettingCommands();
        }

        private static void InitCommands()
        {
            Commands = new List<ICommand>();

            Commands.Add(new HelpCommand());
            Commands.Add(new NewRouteCommand());
            Commands.Add(new OutCommand());
            Commands.Add(new PrintMyStatCommand());
            Commands.Add(new UpdateMyDistanceCommand());
            Commands.Add(new UpdateMyDistanceWithRouteCommand());
            Commands.Add(new ClearStatCommand());
            Commands.Add(new RemoveRouteCommand());

            // add new commands here
        }

        private static void PrintInitialInfo()
        {
            Console.WriteLine("Bike Path console UI");
            Console.WriteLine("Author - Ivan Tarasov");
            Console.WriteLine("=====================================");
            Console.WriteLine("Type 'help' to get a list of commands");
            Console.WriteLine("/ / / / / / / / / / / / / / / / / / /");
        }

        private static void StartGettingCommands()
        {
            while (WorkStatus == ACTIVE)
            {
                string commandStr = GetCommandOfConsole();
                bool commandIsFound = false;

                foreach (var command in Commands)
                {
                    if (commandStr == command.Name)
                    {
                        commandIsFound = true;
                        string messageOfCommand = command.Execute();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("message: {0}", messageOfCommand);
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }

                if (!commandIsFound)
                {
                    Console.WriteLine("COMMAND NOT FOUND");
                }
            }
        }

        private static string GetCommandOfConsole()
        {
            Console.Write(">>> ");
            string command = Console.ReadLine();

            return command;
        }

        private static void GetCurrentUser()
        {
            Console.WriteLine("login or register?");
            while (true)
            {
                string method = GetCommandOfConsole();

                if (method == "login")
                {
                    Login();
                    break;
                }
                else if (method == "register")
                {
                    Register();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect data!");
                }
            }
        }

        private static void Login()
        {
            while (true)
            {
                string email = GetData("email");
                string pass = GetData("password");

                User user = DBWorker.GetExistingUser(email, pass);
                if (user != null)
                {
                    CurrentUser = user;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect email or password, pleace try again");
                }
            }
        }

        private static void Register()
        {
            string name = GetData("name");
            string email = GetData("email");
            string password = GetData("password");

            CurrentUser = DBWorker.GetAndSaveNewUser(name, email, password);
        }

        public static string GetData(string dataType)
        {
            Console.Write(dataType.ToUpper() + ": ");
            string data = Console.ReadLine();

            return data;
        }
    }
}
