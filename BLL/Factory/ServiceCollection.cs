using Azure.Search.Documents;
using BLL.Services.App;
using BLL.Services.Contracts;
using DAL.AzureCognitiveSearch.Factory;
using DAL.EF;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Solr.Factory;
using DAL.Urram.Factory;
using Elasticsearch.Net;
using LuceneSearchEngine;
using Nest;

namespace BLL.Factory
{
    public class ServiceCollection : ServiceFactory, IServiceCollection
    {
        public ServiceCollection(
            IUnitOfWork uow,
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo,
            IServiceCollection services,
            IElasticsearchRepositoryCollection elasticRepo,
            ISolrRepositoryCollection solrRepo,
            IAzureSearchRepositoryCollection azureSearchRepo,
            LuceneSearchEngineCore lucene
        ) : base(uow, sierraRepo, riksRepo, urramRepo, services, elasticRepo, solrRepo, azureSearchRepo, lucene)
        {
        }

        public IBookService Books =>
            GetService<IBookService>(() => new BookService(UOW, SierraRepo, RiksRepo, UrramRepo, Services, ElasticRepo, SolrRepo, AzureSearchRepo, Lucene));
    }
}