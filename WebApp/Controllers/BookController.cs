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
        private readonly IServiceCollection _bll;

        public BookController(IServiceCollection bll)
        {
            _bll = bll;
        }

        [HttpGet("{searchString}")]
        public async Task<IEnumerable<Book>> GetBooks(string searchString)
        {
            return await _bll.Books.FindAsync(searchString);
        }

        [HttpGet("Elastic/{searchString}")]
        public async Task<IEnumerable<Book>> GetBooksFromElasticIndex(string searchString)
        {
            return await _bll.Books.ElasticFindAsync(searchString);
        }

        [HttpGet("Elastic/{searchString}")]
        public async Task GetElasticIndexResult(string searchString)
        {
            await _bll.Books.ElasticIndexResultAsync(searchString);
        }
        
        [HttpGet("IndexDataFromSierraToElasticsearch")]
        public async Task GetIndexDataFromSierraToElasticsearch()
        {
            await _bll.Books.IndexDataFromSierraToElasticsearch();
        }
        
        [HttpGet("Solr/{searchString}")]
        public async Task<IEnumerable<Book>> GetBooksSolr(string searchString)
        {
            return await _bll.Books.SolrFindAsync(searchString);
        }
        
        [HttpGet("Solr/SearchAndIndex/{searchString}")]
        public async Task GetSolrSearchAndIndex(string searchString)
        {
            await _bll.Books.SolrIndexResultAsync(searchString);
        }
        
        [HttpGet("Solr/IndexAll")]
        public async Task GetSolrIndexAll()
        {
            await _bll.Books.SolrIndexAllAsync();
        }
        
        [HttpGet("AzureCognitiveSearch/CreateIndex")]
        public async Task GetAzureSearchCreateIndex()
        {
            await _bll.Books.AzureSearchCreateIndexAsync();
        }
        
        [HttpGet("AzureCognitiveSearch/IndexAll")]
        public async Task GetAzureSearchIndexAll()
        {
            await _bll.Books.AzureSearchIndexAllAsync();
        }
        
        [HttpGet("AzureCognitiveSearch/{searchString}")]
        public async Task<IEnumerable<Book>> GetBooksAzureSearch(string searchString)
        {
            return await _bll.Books.AzureSearchFindAsync(searchString);
        }
        
        [HttpGet("Lucene/IndexAll")]
        public async Task GetLuceneIndexAll()
        {
            await _bll.Books.LuceneIndexAllAsync();
        }
        
        [HttpGet("Lucene/{searchString}")]
        public IEnumerable<Book> GetBooksLucene(string searchString)
        {
            return _bll.Books.LuceneSearchAsync(searchString);
        }
    }
}