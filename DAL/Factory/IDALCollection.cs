using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace DAL.Factory
{
    public interface IDALCollection
    {
        ISierraRepositoryCollection _sierraRepo { get; }
        IRiksRepositoryCollection _riksRepo { get; }
        IUrramRepositoryCollection _urramRepo { get; }
    }
}