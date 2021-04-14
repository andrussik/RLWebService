using System.Net.Http;
using DAL.Elasticsearch.Repositories;
using DAL.Elasticsearch.Repositories.App;
using DAL.Elasticsearch.Repositories.Contracts;
using DAL.Factory;
using DAL.Riks.Factory;
using Nest;

namespace DAL.Elasticsearch.Factory
{
    public class ElasticsearchRepositoryCollection : ElasticsearchRepositoryFactory, IElasticsearchRepositoryCollection
    {
        public ElasticsearchRepositoryCollection(IElasticClient elasticClient) : base(elasticClient)
        {
        }
        
        public IPublicationRepository Publications =>
            GetRepository(() => new PublicationRepository(_elasticClient));
    }
}