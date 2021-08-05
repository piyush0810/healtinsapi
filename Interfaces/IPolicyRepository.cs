using System.Collections.Generic;
using System.Threading.Tasks;
using poc.Models;

namespace healtinsapi.Interfaces
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetPoliciesAsync();
         IEnumerable<Policy> GetPoliciesoftermAsync(string s);


        void AddPolicy(Policy policy);
        void DeletePolicy(int Id);



        

        
    }
}