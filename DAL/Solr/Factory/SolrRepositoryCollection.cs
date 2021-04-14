using System.Net.Http;
using DAL.Solr.Repositories.App;
using DAL.Solr.Repositories.Contracts;
using DTO.SearchEngine;
using SolrNet;

namespace DAL.Solr.Factory
{
    public class SolrRepositoryCollection : SolrRepositoryFactory, ISolrRepositoryCollection
    {
        public SolrRepositoryCollection(ISolrOperations<Publication> solr, IHttpClientFactory clientFactory) : base(solr, clientFactory)
        {
        }
        
        public IPublicationRepository Publications =>
            GetRepository(() => new PublicationRepository(_solr, _clientFactory));
    }
}