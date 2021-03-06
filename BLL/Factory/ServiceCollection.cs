using BLL.Services.App;
using BLL.Services.Contracts;
using DAL.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Factory
{
    public class ServiceCollection : ServiceFactory, IServiceCollection
    {
        public ServiceCollection(
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo
            ) : base(sierraRepo, riksRepo, urramRepo)
        {
        }

        public IBookService Books =>
            GetService<IBookService>(() => new BookService(_sierraRepo, _riksRepo, _urramRepo));

    }
}