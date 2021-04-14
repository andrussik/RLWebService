using System.Net.Http;
using DAL.Elasticsearch.Repositories.Contracts;

namespace DAL.Solr.Repositories.App
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly HttpClient _httpClient;

        public BaseRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("solr");
        }
    }
}