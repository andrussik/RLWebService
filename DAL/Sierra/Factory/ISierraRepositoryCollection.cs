using DAL.Sierra.Repositories.Contracts;

namespace DAL.Sierra.Factory
{
    public interface ISierraRepositoryCollection
    {
        IBookRepository Books { get; }
    }
}