using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ServiceFactory : IServiceFactory
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

        private readonly Dictionary<Type, object> _serviceCache = new();

        protected ServiceFactory(
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

        public TService GetService<TService>(Func<TService> serviceCreationMethod) 
            where TService : class
        {
            if (_serviceCache.TryGetValue(typeof(TService), out var service))
            {
                return (TService) service;
            }

            var newServiceInstance = serviceCreationMethod();
            _serviceCache.Add(typeof(TService), newServiceInstance);
            return newServiceInstance;
        }
    }
}