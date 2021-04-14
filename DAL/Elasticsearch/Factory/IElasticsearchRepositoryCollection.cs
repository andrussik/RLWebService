using DAL.Elasticsearch.Repositories.Contracts;

namespace DAL.Elasticsearch.Factory
{
    public interface IElasticsearchRepositoryCollection
    {
        IPublicationRepository Publications { get; }
    }
}