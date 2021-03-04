using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using DTOs.PublicApi;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private readonly IBookService _service;

        public BookController(IBookService bookService)
        {
            _service = bookService;
        }

        [HttpGet("{searchString}")]
        public async Task<IEnumerable<Book>> GetBooks(string searchString)
        {
            return await _service.FindAsync(searchString);
        }
    }
}