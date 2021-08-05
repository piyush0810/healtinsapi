using System.Threading.Tasks;
using healtinsapi.Data.repository;
using healtinsapi.Interfaces;
using poc.Data;

namespace healtinsapi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;

        }
        public IUserRepository UserRepository =>
        new UserRepository(dc);
        public IPurchaseRepository PurchaseRepository =>
        new PurchaseRepository(dc);

        public IPolicyRepository PolicyRepository =>
        new PolicyRepository(dc);
        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}