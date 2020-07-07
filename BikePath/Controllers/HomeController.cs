﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BikePath.Models;
using Microsoft.EntityFrameworkCore;

namespace MobileStore.Controllers
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
            return View(db.Users.ToList());
        }
    }
}