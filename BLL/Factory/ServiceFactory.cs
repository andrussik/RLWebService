using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Factory
{
    public class ServiceFactory : IServiceFactory
    {
        protected readonly ISierraRepositoryCollection _sierraRepo;
        protected readonly IRiksRepositoryCollection _riksRepo;
        protected readonly IUrramRepositoryCollection _urramRepo;

        private readonly Dictionary<Type, object> _serviceCache = new();

        protected ServiceFactory(
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo
            )
        {
            _sierraRepo = sierraRepo;
            _riksRepo = riksRepo;
            _urramRepo = urramRepo;
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