using System.Collections.Generic;
using System.Threading.Tasks;
using healtinsapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using poc.Data;
using poc.Models;

namespace healtinsapi.Data.repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly DataContext dc;
        public PolicyRepository(DataContext dc)
        {
            this.dc = dc;

        }
        public void AddPolicy(Policy policy)
        {
           dc.Policies.AddAsync(policy);
        }

        public void DeletePolicy(int Id)
        {
             var policy=dc.Policies.Find(Id);
            dc.Policies.Remove(policy);
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            return await dc.Policies.ToListAsync();
        }
    }
}