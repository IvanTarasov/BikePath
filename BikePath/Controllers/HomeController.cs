using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BikePath.Models;
using Microsoft.EntityFrameworkCore;
using BikePath;

namespace BikePath.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
