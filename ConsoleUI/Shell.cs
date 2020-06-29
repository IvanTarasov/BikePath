using BikePath.Models;
using ConsoleUI.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Shell
    {
        private List<ICommand> Commands;

        public void Start()
        {
            GlobalData.ShellIsWork = true;

            Registration();
            InitCommands();
            PrintInitialInfo();
            StartGettingCommands();
        }

        private void InitCommands()
        {
            Commands = new List<ICommand>();

            Commands.Add(new HelpCommand());
            Commands.Add(new NewRouteCommand());
            Commands.Add(new OutCommand());
            Commands.Add(new PrintMyStatCommand());
            Commands.Add(new UpdateMyDistanceCommand());
            Commands.Add(new UpdateMyDistanceWithRouteCommand());
            Commands.Add(new TestCommand());
            Commands.Add(new ClearStatCommand());
            Commands.Add(new RemoveRouteCommand());

            GlobalData.Commands = Commands;
        }

        private void PrintInitialInfo()
        {
            Console.WriteLine("Bike Path console UI");
            Console.WriteLine("Author - Ivan Tarasov");
            Console.WriteLine("=====================================");
            Console.WriteLine("Type 'help' to get a list of commands");
            Console.WriteLine("/ / / / / / / / / / / / / / / / / / /");
        }

        private void StartGettingCommands()
        {
            while (GlobalData.ShellIsWork)
            {
                string commandStr = GetCommandOfConsole();
                bool commandIsFound = false;

                foreach (var command in Commands)
                {
                    if (commandStr == command.Name)
                    {
                        commandIsFound = true;
                        Console.WriteLine(command.Execute());
                    }
                }

                if (!commandIsFound)
                {
                    Console.WriteLine("COMMAND NOT FOUND");
                }
            }
        }

        private string GetCommandOfConsole()
        {
            Console.Write(">>> ");
            string command = Console.ReadLine();

            return command;
        }

        private void Registration()
        {
            while (true)
            {
                string email = GetEmail();
                string pass = GetPassword();

                User user = UserReg.EnterToAccount(email, pass);
                if (user != null)
                {
                    GlobalData.User = user;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect email or password, pleace try again");
                }
            }
        }

        private string GetEmail()
        {
            Console.Write("EMAIL: ");
            string email = Console.ReadLine();

            return email;
        }

        private string GetPassword()
        {
            Console.Write("PASSWORD: ");
            string pass = Console.ReadLine();

            return pass;
        }
    }
}
