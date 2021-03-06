using BLL.Services.Contracts;
using DAL.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Services.App
{
    public class BaseService : IBaseService
    {
        protected readonly ISierraRepositoryCollection _sierraRepo;
        protected readonly IRiksRepositoryCollection _riksRepo;
        protected readonly IUrramRepositoryCollection _urramRepo;

        public BaseService(
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo
            )
        {
            _sierraRepo = sierraRepo;
            _riksRepo = riksRepo;
            _urramRepo = urramRepo;
        }
    }
}