using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using DAL.AzureCognitiveSearch.Repositories.Contracts;

namespace DAL.AzureCognitiveSearch.Repositories.App
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly SearchIndexClient _searchIndexClient;
        protected readonly SearchClient _searchClient;

        public BaseRepository(SearchIndexClient searchIndexClient, SearchClient searchClient)
        {
            _searchIndexClient = searchIndexClient;
            _searchClient = searchClient;
        }
    }
}