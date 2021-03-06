using System.Net.Http;
using DAL.Factory;

namespace DAL.Riks.Factory
{
    public class RiksRepositoryCollection : RepositoryFactory, IRiksRepositoryCollection
    {
        public RiksRepositoryCollection(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}