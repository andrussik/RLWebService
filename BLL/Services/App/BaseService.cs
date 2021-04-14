using BLL.Factory;
using BLL.Services.Contracts;
using DAL.AzureCognitiveSearch.Factory;
using DAL.EF;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Solr.Factory;
using DAL.Urram.Factory;
using LuceneSearchEngine;
using Nest;

namespace BLL.Services.App
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UOW;
        protected readonly ISierraRepositoryCollection SierraRepo;
        protected readonly IRiksRepositoryCollection RiksRepo;
        protected readonly IUrramRepositoryCollection UrramRepo;
        protected readonly IServiceCollection Services;
        protected readonly IElasticsearchRepositoryCollection ElasticRepo;
        protected readonly ISolrRepositoryCollection SolrRepo;
        protected readonly IAzureSearchRepositoryCollection AzureSearchRepo;
        protected readonly LuceneSearchEngineCore Lucene;

        public BaseService(
            IUnitOfWork uow,
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo,
            IServiceCollection services,
            IElasticsearchRepositoryCollection elasticRepo,
            ISolrRepositoryCollection solrRepo,
            IAzureSearchRepositoryCollection azureSearchRepo,
            LuceneSearchEngineCore lucene
            )
        {
            UOW = uow;
            SierraRepo = sierraRepo;
            RiksRepo = riksRepo;
            UrramRepo = urramRepo;
            Services = services;
            ElasticRepo = elasticRepo;
            SolrRepo = solrRepo;
            AzureSearchRepo = azureSearchRepo;
            Lucene = lucene;
        }
    }
}