using System.Threading.Tasks;

namespace healtinsapi.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository {get;}
         IPolicyRepository PolicyRepository{get;}

         IPurchaseRepository PurchaseRepository{get;}
         
         Task<bool> SaveAsync();
    }
}