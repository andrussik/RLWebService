using DAL.Solr.Repositories.Contracts;

namespace DAL.Solr.Factory
{
    public interface ISolrRepositoryCollection
    {
        IPublicationRepository Publications { get; }
    }
}