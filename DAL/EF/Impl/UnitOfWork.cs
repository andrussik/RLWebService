using System.Threading.Tasks;
using DAL.EF.Interfaces;

namespace DAL.EF.Impl
{
    public class UnitOfWork : RepositoryCollection, IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}