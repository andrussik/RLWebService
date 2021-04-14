using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.SearchEngine;
using Nest;

namespace DAL.Elasticsearch.Repositories.Contracts
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString);
        Task IndexManyAsync(IEnumerable<Publication> publications);
        Task<ISearchResponse<Publication>> ScrollAsync(string? scrollId = null);
    }
}