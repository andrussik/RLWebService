using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs.PublicApi;

namespace DAL.Sierra.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> FindAsync(string searchString);
    }
}