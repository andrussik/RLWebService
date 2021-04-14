using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.AzureCognitiveSearch;

namespace DAL.AzureCognitiveSearch.Repositories.Contracts
{
    public interface IPublicationRepository
    {
        Task CreateOrUpdateIndexAsync();
        Task IndexDocumentsAsync(IEnumerable<Publication> publications);
        Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString);
    }
}