
using healtinsapi.Data;
using healtinsapi.Dtos;
using healtinsapi.Interfaces;
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


    public class UserController : ControllerBase
    {
        
        private readonly IUnitOfWork uow;

        public UserController(IUnitOfWork uow)
        {
            this.uow = uow;
            this.uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var users = await uow.UserRepository.GetUsersAsync();

            return Ok(users);

        }

        [HttpPost("ADD")]
        public async Task<IActionResult> AddUser(User user)
        {

            uow.UserRepository.AddUser(user);
            await uow.SaveAsync();
            return StatusCode(201);


        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            uow.UserRepository.DeleteUser(id);
            await uow.SaveAsync();
            return StatusCode(201);
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> ulogin(UserLoginDto user)
        {
            var TempUser=await uow.UserRepository.login(user);
            if(TempUser==null)
            {
                return Unauthorized();
            }
            return Ok(TempUser);

        }

    }
}


