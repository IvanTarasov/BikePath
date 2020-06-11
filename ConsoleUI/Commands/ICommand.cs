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

        // override ToString() for normal work 
    }
}
