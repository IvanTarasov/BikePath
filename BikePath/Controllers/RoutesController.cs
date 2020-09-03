using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikePath.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikePath.Controllers
{
    public class RoutesController : Controller
    {
        private BikePathContext _db;
        public RoutesController(BikePathContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("/main")]
        public IActionResult Get()
        {
            User user = DBWorker.GetExistingUser("ivan.tarasov12345@gmail.com", "ivan12345");
            var routes = _db.Routes.Where(r => r.UserId == user.Id).ToList();
            return Ok(routes);
        }

        [HttpPost]
        [Route("/main")]
        public IActionResult Post(int userId, string title, string length)
        {
            double len = double.Parse(length.Replace('.', ','));
            Route route = new Route { UserId = userId, Title = title, Length = len };
            _db.Routes.Add(route);
            _db.SaveChanges();
            return Ok(route);
        }

        [HttpPut]
        [Route("/main")]
        public IActionResult Put(Route model)
        {
            return Ok(model);
        }

        [HttpDelete]
        [Route("/main")]
        public IActionResult Delete(Route route)
        {
            _db.Routes.Remove(route);
            _db.SaveChanges();
            return Ok();
        }
    }
}
