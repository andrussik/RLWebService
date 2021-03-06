using System;

namespace DAL.Factory
{
    public interface IRepositoryFactory
    {
        TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class;
    }
}