using System.Collections.Generic;
using System.Linq;
using DTOs.PublicApi;

namespace BLL.App
{
    public class BookBLL
    {
        public static IEnumerable<BookDTO> CalculateBookOutput(IEnumerable<BookDTO> books)
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