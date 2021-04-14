using System;
using System.Collections.Generic;
using System.Linq;
using DTO.PublicApi;

namespace BLL.BL
{
    public static class BookBL
    {
        public static IEnumerable<Book> CalculateBookOutput(IEnumerable<Book> books)
        {
            var calculateBookOutput = books.ToList();
            Console.WriteLine("result calculated");

            return calculateBookOutput;
        } 
    }
}