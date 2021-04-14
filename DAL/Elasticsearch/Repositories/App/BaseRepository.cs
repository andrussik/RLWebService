using DAL.Elasticsearch.Repositories.Contracts;
using Nest;

namespace DAL.Elasticsearch.Repositories.App
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly IElasticClient _elasticClient;

        public BaseRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
    }
}