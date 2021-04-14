using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Nest;

namespace DAL.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        protected readonly IHttpClientFactory _clientFactory;
        private readonly Dictionary<Type, object> _repoCache = new();

        public RepositoryFactory(IHttpClientFactory clientFactory)
        {
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