using System;
using System.Collections.Generic;
using DAL.Factory;
using Nest;

namespace DAL.Elasticsearch.Factory
{
    public class ElasticsearchRepositoryFactory : IRepositoryFactory
    {
        protected readonly IElasticClient _elasticClient;
        private readonly Dictionary<Type, object> _repoCache = new();

        public ElasticsearchRepositoryFactory(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
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