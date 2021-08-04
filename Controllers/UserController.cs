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
    public class UserController : ControllerBase {
        private readonly DataContext dc;

        public UserController(DataContext dc) {
            this.dc = dc;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var users = dc.Users.ToList();

            return Ok(users);
            
        }

        [HttpPost("ADD")]
        public async Task<IActionResult> AddCity(User user)
        {
    
            await dc.Users.AddAsync(user);
            await dc.SaveChangesAsync();
            return Ok(user);

            
        }

        public async Task<User> authenticate(string uemail,string password)
        {
            Console.WriteLine(uemail);
            Console.WriteLine(password);
            Console.WriteLine(dc.Users.FirstOrDefault(x=>x.email==uemail && x.password==password));
            return dc.Users.FirstOrDefault(x=>x.email==uemail && x.password==password);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(string email,string password){
            var user = authenticate(email,password);
            if(user==null)
            {
                return Unauthorized();
            }
            return Ok(user);

        }

}
}


