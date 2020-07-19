using BikePath;
using BikePath.Models;
using ConsoleUI.App;
using ConsoleUI.Commands;
using ConsoleUI.GlobalData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleUI
{
    class Shell
    {
        private List<ICommand> Commands;

        public void Start()
        {
            ShellStatus.IsWork = true;
            ApplicationContext.Context = new BikePathContext();

            GettingAnAccount();
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
            Commands.Add(new ClearStatCommand());
            Commands.Add(new RemoveRouteCommand());

            // add new commands here

            CommandList.SetCommands(Commands);
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
            while (ShellStatus.IsWork)
            {
                string commandStr = GetCommandOfConsole();
                bool commandIsFound = false;

                foreach (var command in Commands)
                {
                    if (commandStr == command.Name)
                    {
                        commandIsFound = true;
                        string messageOfCommand = command.Execute();
                        Console.WriteLine("message: {0}", messageOfCommand);
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

        private void GettingAnAccount()
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

        private void Login()
        {
            if (Config.Tested)
            {
                ActualUser.SetUser(DBWorker.GetExistingUser(ref ApplicationContext.Context, "ivan.tarasov12345@gmail.com", "1234509876_Asdivannew"));
            }
            else
            {
                while (true)
                {
                    string email = GetEmail();
                    string pass = GetPassword();

                    User user = DBWorker.GetExistingUser(ref ApplicationContext.Context, email, pass);
                    if (user != null)
                    {
                        ActualUser.SetUser(user);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect email or password, pleace try again");
                    }
                }
            }
        }

        private void Register()
        {
            string name = GetName();
            string email = GetEmail();
            string password = GetPassword();

            User user = DBWorker.GetAndSaveNewUser(ref ApplicationContext.Context, name, email, password);
            ActualUser.SetUser(user);
        }

        private string GetName()
        {
            Console.Write("NAME: ");
            string name = Console.ReadLine();

            return name;
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
