using System.Collections.Generic;
using DTO.DAL.Sierra;

namespace DTO.PublicApi.Mappers
{
    public static class BookMapper
    {
        public static Book Map(Bib bib)
        {
            var book = new Book
            {
                Id = bib.Id,
                Title = bib.Title,
                Author = bib.Author,
                PublishYear = bib.PublishYear
            };

            return book;
        }

        public static IEnumerable<Book> Map(IEnumerable<Bib> bibs)
        {
            var books = new List<Book>();
            
            foreach (var bib in bibs)
            {
                var book = Map(bib);
                
                books.Add(book);
            }

            return books;
        }
    }
}