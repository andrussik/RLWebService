using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Factory;
using BLL.Services.Contracts;
using DTO.PublicApi;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private readonly IServiceCollection _serviceCollection;

        public BookController(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        [HttpGet("{searchString}")]
        public async Task<IEnumerable<Book>> GetBooks(string searchString)
        {
            return await _serviceCollection.Books.FindAsync(searchString);
        }
    }
}