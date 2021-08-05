using System.Collections.Generic;
using System.Threading.Tasks;
using healtinsapi.Dtos;
using poc.Models;

namespace healtinsapi.Interfaces
{
    public interface IPurchaseRepository
    {
         Task<IEnumerable<Purchase>> GetPurchasesAsync();

        void AddPurchase(Purchase purchase);
        void DeletePurchase(int Id);
         IEnumerable<Policy> GetMyPolicies(int id);
        

        
        
    }
}