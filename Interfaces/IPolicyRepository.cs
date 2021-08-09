using System.Collections.Generic;
using System.Threading.Tasks;
using poc.Models;

namespace healtinsapi.Interfaces
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetPoliciesAsync();
        IEnumerable<Policy> GetMyPoliciesAsync(int id);
         IEnumerable<Policy> GetPoliciesoftermAsync(string s);
         Task<Policy> FindPolicy(int Id);


        void AddPolicy(Policy policy);
        void DeletePolicy(int Id);



        

        
    }
}