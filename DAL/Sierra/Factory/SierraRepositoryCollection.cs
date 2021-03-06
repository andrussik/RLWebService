using System.Net.Http;
using DAL.Factory;
using DAL.Sierra.Repositories.App;
using DAL.Sierra.Repositories.Contracts;

namespace DAL.Sierra.Factory
{
    public class SierraRepositoryCollection : RepositoryFactory, ISierraRepositoryCollection
    {
        public SierraRepositoryCollection(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public IBookRepository SierraBooks =>
            GetRepository(() => new BookRepository(_clientFactory));
    }
}