using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.PublicApi;

namespace DAL.Sierra.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> FindAsync(string searchString);
    }
}