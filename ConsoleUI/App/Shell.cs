﻿using BikePath;
using BikePath.Models;
using ConsoleUI.App;
using ConsoleUI.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    static class Shell
    {
        public static List<ICommand> Commands { get; private set; }
        public static DBWorker DBWorker { get; private set; }
        public static string WorkStatus { get; set; }
        public static User CurrentUser;

        public const string ACTIVE = "ACTIVE";
        public const string DISABLE = "DISABLE";

        public static void Start()
        {
            WorkStatus = ACTIVE;
            DBWorker = new DBWorker();

            GetCurrentUser();
            InitCommands();

            ConsoleDrawer.PrintInitialInfo();
            StartGettingCommands();
        }

        private static void GetCurrentUser()
        {
            while (true)
            {
                string method = GetData("login or register?");

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
                    ConsoleDrawer.DrawMessage(new DBMessage("INCORRECT DATA!", "ERROR"));
                }
            }
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

        private static void StartGettingCommands()
        {
            while (WorkStatus == ACTIVE)
            {
                string commandStr = GetCommand();
                bool commandIsFound = false;

                foreach (var command in Commands)
                    if (commandStr == command.Name)
                    {
                        command.Execute();
                        commandIsFound = true;
                    }

                if (!commandIsFound)
                    ConsoleDrawer.DrawMessage(new DBMessage("COMMAND NOT FOUND!", "ERROR"));
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
                    ConsoleDrawer.DrawMessage(new DBMessage("INCORRECT EMAIL OR PASSWORD!", "ERROR"));
                }
            }
        }

        private static void Register()
        {
            string name = GetData("name");
            string email = GetVerifiedEmail();
            string password = GetData("password");

            CurrentUser = DBWorker.GetAndSaveNewUser(name, email, password);
        }

        private static string GetVerifiedEmail()
        {
            string email;
            while (true)
            {
                email = GetData("email");
                EmailSender emailSender = new EmailSender();

                emailSender.SendVerifyCode(email);
                string userCode = GetData("code");

                if (userCode == emailSender.VERIFY_CODE)
                {
                    return email;
                }
                else
                {
                    ConsoleDrawer.DrawMessage(new DBMessage("INCORRECT EMAIL!", "ERROR"));
                }
            }
        }

        private static string GetCommand()
        {
            Console.Write(">>> ");
            string command = Console.ReadLine();

            return command;
        }

        public static string GetData(string dataType)
        {
            Console.Write(dataType.ToUpper() + ": ");
            string data = Console.ReadLine();

            return data;
        }
    }
}
