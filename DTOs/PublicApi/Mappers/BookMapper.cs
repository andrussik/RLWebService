using System.Collections.Generic;
using DTOs.DAL.Sierra;

namespace DTOs.PublicApi.Mappers
{
    public static class BookMapper
    {
        public static BookDTO Map(Bib bib)
        {
            var book = new BookDTO
            {
                Id = bib.Id,
                Title = bib.Title,
                Author = bib.Author,
                PublishYear = bib.PublishYear
            };

            return book;
        }

        public static IEnumerable<BookDTO> Map(IEnumerable<Bib> bibs)
        {
            var books = new List<BookDTO>();
            
            foreach (var bib in bibs)
            {
                var book = Map(bib);
                
                books.Add(book);
            }

            return books;
        }
    }
}