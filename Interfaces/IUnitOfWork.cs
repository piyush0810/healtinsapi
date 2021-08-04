using System.Threading.Tasks;

namespace healtinsapi.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository {get;}
         IPolicyRepository PolicyRepository{get;}
         Task<bool> SaveAsync();
    }
}