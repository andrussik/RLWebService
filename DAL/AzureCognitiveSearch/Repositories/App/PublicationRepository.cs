using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using DAL.AzureCognitiveSearch.Repositories.Contracts;
using DTO.AzureCognitiveSearch;

namespace DAL.AzureCognitiveSearch.Repositories.App
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(SearchIndexClient searchIndexClient, SearchClient searchClient) : base(searchIndexClient, searchClient)
        {
        }

        public async Task CreateOrUpdateIndexAsync()
        {
            var fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(Publication));

            var index = new SearchIndex("publications", searchFields);

            await _searchIndexClient.CreateOrUpdateIndexAsync(index);
        }

        public async Task IndexDocumentsAsync(IEnumerable<Publication> publications)
        {
            var batch = IndexDocumentsBatch.Upload(publications);
            
            var options = new IndexDocumentsOptions { ThrowOnAnyError = true };
            
            await _searchClient.IndexDocumentsAsync(batch, options);
        }

        public async Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString)
        {
            var searchStrings = searchString
                .Split(" ")
                .Select(s => s + "~").ToList();

            var query = string.Join(" | ", searchStrings);
            
            var options = new SearchOptions
            {
                Size = 5,
                QueryType = SearchQueryType.Full,
                SearchFields = { "Title", "Author"}
            };

            SearchResults<Publication> searchResult = await _searchClient.SearchAsync<Publication>(query, options);

            var publications = searchResult.GetResults().Select(x => x.Document);

            return publications;
        }
    }
}