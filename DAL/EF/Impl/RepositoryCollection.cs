
using System.Collections.Generic;
using DAL.EF.Interfaces;

namespace DAL.EF.Impl
{
    public class RepositoryCollection : IRepositoryCollection
    {
        public List<int>? Ints { get; set; }
    }
}