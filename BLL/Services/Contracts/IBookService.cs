using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.PublicApi;

namespace BLL.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> FindAsync(string searchString);
    }
}