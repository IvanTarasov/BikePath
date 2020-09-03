using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikePath.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikePath.Controllers
{
    public class UsersController : Controller
    {
        private BikePathContext _db;
        public UsersController(BikePathContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("/user")]
        public IActionResult Get(User user)
        {
            User newUser = _db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            return Ok(newUser);
        }

        [HttpPut]
        [Route("/user")]
        public IActionResult Put(int userId, string length)
        {
            double len = double.Parse(length.Replace('.', ','));

            User putUser = _db.Users.FirstOrDefault(u => u.Id == userId);
            putUser.Distance += len;
            _db.Users.Update(putUser);
            _db.SaveChanges();

            return Ok(putUser.Distance);
        }
    }
}
