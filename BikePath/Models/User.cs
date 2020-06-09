using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Distance { get; set; } // kilometers
        public List<Route> Routes { get; set; }
    }
}
