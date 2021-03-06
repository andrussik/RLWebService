using System.Collections.Generic;
using System.Linq;
using DTO.PublicApi;

namespace BLL.BL
{
    public class BookBL
    {
        public static IEnumerable<Book> CalculateBookOutput(IEnumerable<Book> books)
        {
            var calculateBookOutput = books.ToList();
            foreach (var book in calculateBookOutput)
            {
                book.Author += " recalculated";
            }

            return calculateBookOutput;
        } 
    }
}