using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using BikePath;

namespace BikePath.Controllers
{
    public class HomeController : Controller
    {
        BikePathContext db;
        public HomeController(BikePathContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(new User());
        }
    }
}
