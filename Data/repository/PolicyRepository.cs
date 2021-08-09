using System.Collections.Generic;
using System.Linq;
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

        public async Task<Policy> FindPolicy(int Id)
        {
            return await dc.Policies.FindAsync(Id);
        }

        public IEnumerable<Policy> GetMyPoliciesAsync(int id)
        {
            IQueryable<Policy> q=dc.Policies.FromSqlRaw($"SELECT * FROM Policies WHERE userId LIKE '%{id}%'");
             List<Policy> l = q.ToList();
             return l;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            return await dc.Policies.ToListAsync();
        }

        
        public IEnumerable<Policy> GetPoliciesoftermAsync(string s)
        {
             IQueryable<Policy> q=dc.Policies.FromSqlRaw($"SELECT * FROM Policies WHERE coverName LIKE '%{s}%'");
             List<Policy> l = q.ToList();
             return l;
        }
    }
}