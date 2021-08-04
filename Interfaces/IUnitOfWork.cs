using System.Threading.Tasks;

namespace healtinsapi.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository {get;}

         Task<bool> SaveAsync();
    }
}