using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    interface ICommand
    {
        string Name { get; }

        string Description { get; }

        string Execute();

        string GetInfo() {
            return Name + ": " + Description;
        } 
    }
}
