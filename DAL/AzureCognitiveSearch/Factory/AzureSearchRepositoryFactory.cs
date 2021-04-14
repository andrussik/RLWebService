using System;
using System.Collections.Generic;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using DAL.Factory;
using Nest;

namespace DAL.AzureCognitiveSearch.Factory
{
    public class AzureSearchRepositoryFactory : IRepositoryFactory
    {
        protected readonly SearchIndexClient _searchIndexClient;
        protected readonly SearchClient _searchClient;
        private readonly Dictionary<Type, object> _repoCache = new();

        public AzureSearchRepositoryFactory(SearchIndexClient searchIndexClient, SearchClient searchClient)
        {
            _searchIndexClient = searchIndexClient;
            _searchClient = searchClient;
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