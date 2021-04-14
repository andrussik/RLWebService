using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace DAL.Factory
{
    public class DALCollection : IDALCollection
    {
        public ISierraRepositoryCollection _sierraRepo { get; set; }
        public IRiksRepositoryCollection _riksRepo { get; set; }
        public IUrramRepositoryCollection _urramRepo { get; set; }
        
        public DALCollection(ISierraRepositoryCollection sierraRepo, IRiksRepositoryCollection riksRepo, IUrramRepositoryCollection urramRepo)
        {
            _sierraRepo = sierraRepo;
            _riksRepo = riksRepo;
            _urramRepo = urramRepo;
        }
    }
}