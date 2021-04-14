using System.Collections.Generic;

namespace DAL.EF.Interfaces
{
    public interface IRepositoryCollection
    {
        List<int>? Ints { get; }
    }
}