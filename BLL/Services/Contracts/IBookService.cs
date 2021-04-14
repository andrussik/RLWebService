using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.PublicApi;

namespace BLL.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> FindAsync(string searchString);
        Task<IEnumerable<Book>> ElasticFindAsync(string searchString);
        Task ElasticIndexResultAsync(string searchString);
        Task IndexDataFromSierraToElasticsearch();
        Task SolrIndexResultAsync(string searchString);
        Task SolrIndexAllAsync();
        Task<IEnumerable<Book>> SolrFindAsync(string searchString);
        Task AzureSearchCreateIndexAsync();
        Task AzureSearchIndexAllAsync();
        Task<IEnumerable<Book>> AzureSearchFindAsync(string searchString);
        Task LuceneIndexAllAsync();
        IEnumerable<Book> LuceneSearchAsync(string searchTerm);
    }
}