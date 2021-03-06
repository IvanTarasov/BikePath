﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Length { get; set; } // kilometers

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
