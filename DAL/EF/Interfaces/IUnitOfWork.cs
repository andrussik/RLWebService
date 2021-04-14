using System.Threading.Tasks;

namespace DAL.EF.Interfaces
{
    public interface IUnitOfWork : IRepositoryCollection
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}