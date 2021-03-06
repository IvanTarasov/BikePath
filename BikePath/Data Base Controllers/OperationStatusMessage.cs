﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath
{
    public class OperationStatusMessage
    {
        public string Text { get; private set; }
        public string Type { get; private set; } // ERROR or SUCCESS

        public OperationStatusMessage(string text, string type)
        {
            Text = text;
            Type = type;
        }
    }
}
