using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poc.Data;
using poc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase {
        private readonly DataContext dc;

        public CityController(DataContext dc) {
            this.dc = dc;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = dc.Cities.ToList();

            return Ok(cities);
            
        }

        [HttpPost("ADD/{cityname}")]
        public async Task<IActionResult> AddCity(string cityname)
        {
            City city = new();
            city.Name = cityname;
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();
            return Ok(city);

            
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (id > 1)
            {
                return "value";
            }
            return "no value";
        }
        }

}


