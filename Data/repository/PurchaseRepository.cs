using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using healtinsapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using poc.Data;
using poc.Models;

namespace healtinsapi.Data.repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DataContext dc;
        public PurchaseRepository(DataContext dc)
        {
            this.dc = dc;

        }
        public void AddPurchase(Purchase purchase)
        {
            dc.Purchases.AddAsync(purchase);
        }

        public void DeletePurchase(int Id)
        {
            var purchase=dc.Purchases.Find(Id);
            dc.Purchases.Remove(purchase);
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesAsync()
        {
            return await dc.Purchases.ToListAsync();
        }

        public IEnumerable<Policy> GetMyPolicies(int id)
        {
            Console.WriteLine("addsaf");
             IQueryable<Policy> q=dc.Policies.FromSqlRaw($"SELECT p.* FROM Policies p INNER JOIN Purchases A ON P.Id = A.PolicyId Where UId={id};");
             List<Policy> l = q.ToList();
             return l;
        }
    }
}