using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App;
using BLL.Services.Contracts;
using DAL.Sierra.Repositories.Contracts;
using DTOs.PublicApi;

namespace BLL.Services.App
{
    public class BookService : IBookService
    {
        protected readonly IBookRepository _repo;
        
        public BookService(IBookRepository bookRepository)
        {
            _repo = bookRepository;
        }

        public async Task<IEnumerable<Book>> FindAsync(string searchString)
        {
            var books = await _repo.FindAsync(searchString);
            books = BookBLL.CalculateBookOutput(books);
            return books;
        }
    }
}