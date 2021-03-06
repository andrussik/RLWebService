using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.BL;
using BLL.Services.Contracts;
using DAL.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using DTO.PublicApi;

namespace BLL.Services.App
{
    public class BookService : BaseService, IBookService
    {
        public BookService(
            ISierraRepositoryCollection sierraRepo, 
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo
            ) : base(sierraRepo, riksRepo, urramRepo)
        {
        }

        public async Task<IEnumerable<Book>> FindAsync(string searchString)
        {
            var books = await _sierraRepo.SierraBooks.FindAsync(searchString);
            books = BookBL.CalculateBookOutput(books);
            return books;
        }
    }
}