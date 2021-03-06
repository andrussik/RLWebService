using System;
using DAL.Factory;

namespace BLL.Factory
{
    public interface IServiceFactory
    {
        TService GetService<TService>(Func<TService> serviceCreationMethod)
            where TService : class;
    }
}