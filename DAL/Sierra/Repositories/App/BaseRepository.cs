using System.Net.Http;
using DAL.Sierra.Repositories.Contracts;

namespace DAL.Sierra.Repositories.App
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly HttpClient _httpClient;

        public BaseRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("sierra");
        }
    }
}