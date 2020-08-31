using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikePath;
using BikePath.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BikePathWeb.Controllers
{
    [Route("api/routes")]
    [ApiController]
    public class MainController : ControllerBase
    {
        BikePathContext DataBase;

        public MainController()
        {
            DataBase = new BikePathContext();
        }
        // GET: api/<MainController>
        [HttpGet]
        public string Get()
        {
            User user = DBWorker.GetExistingUser("ivan.tarasov12345@gmail.com", "ivan12345");
            return JsonConvert.SerializeObject(DataBase.Routes.Where(r => r.UserId == user.Id).ToList());
        }

        // GET api/<MainController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MainController>
        [HttpPost]
        public void Post()
        {
        }

        // PUT api/<MainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
