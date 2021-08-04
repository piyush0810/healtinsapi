using System.Collections.Generic;
using System.Threading.Tasks;
using healtinsapi.Dtos;
using Microsoft.AspNetCore.Mvc;
using poc.Models;

namespace healtinsapi.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        void AddUser(User user);
        void DeleteUser(int Id);

        

        Task<User> authenticate(string uemail, string password);
        Task<User> login(UserLoginDto user);

        
            
        
    }
}