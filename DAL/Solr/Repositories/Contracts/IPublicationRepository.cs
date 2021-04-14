using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.SearchEngine;

namespace DAL.Solr.Repositories.Contracts
{
    public interface IPublicationRepository
    {
        Task AddRangeAsync<T>(string index, IEnumerable<T> publications);
        Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString);
    }
}