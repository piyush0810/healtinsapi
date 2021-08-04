using System.Collections.Generic;
using System.Threading.Tasks;
using healtinsapi.Dtos;
using healtinsapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using poc.Data;
using poc.Models;
using Microsoft.AspNetCore.Http;

namespace healtinsapi.Data.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;
        public UserRepository(DataContext dc)
        {
            this.dc=dc;
        }

        

        public void AddUser(User user)
        {
            dc.Users.AddAsync(user);
        }

        

        public void DeleteUser(int Id)
        {
            var user=dc.Users.Find(Id);
            dc.Users.Remove(user);
        }

       

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dc.Users.ToListAsync();
        }

        public Task<User> login(UserLoginDto user)
        {
            
            
            var temp = authenticate(user.email, user.password);
            
            return temp;
        }

        public async Task<User> authenticate(string uemail, string password)
        {
            return await dc.Users.FirstOrDefaultAsync(x => x.email == uemail && x.password == password);
        }

        
    }
}