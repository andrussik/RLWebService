using System;
using System.Collections.Generic;
using System.Net.Http;
using DAL.Factory;
using DTO.SearchEngine;
using SolrNet;

namespace DAL.Solr.Factory
{
    public class SolrRepositoryFactory : IRepositoryFactory
    {
        protected readonly ISolrOperations<Publication> _solr;
        protected readonly IHttpClientFactory _clientFactory;
        private readonly Dictionary<Type, object> _repoCache = new();

        public SolrRepositoryFactory(ISolrOperations<Publication> solr, IHttpClientFactory clientFactory)
        {
            _solr = solr;
            _clientFactory = clientFactory;
        }

        public TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class
        {
            if (_repoCache.TryGetValue(typeof(TRepository), out var repo))
            {
                return (TRepository) repo;
            }
        
            var newRepoInstance = repoCreationMethod();
            _repoCache.Add(typeof(TRepository), newRepoInstance);
            return newRepoInstance;
        }
    }
}