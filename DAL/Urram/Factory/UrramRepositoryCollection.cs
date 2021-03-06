using System.Net.Http;
using DAL.Factory;

namespace DAL.Urram.Factory
{
    public class UrramRepositoryCollection : RepositoryFactory, IUrramRepositoryCollection
    {
        public UrramRepositoryCollection(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}