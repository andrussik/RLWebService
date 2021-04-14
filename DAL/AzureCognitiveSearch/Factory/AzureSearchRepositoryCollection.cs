using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using DAL.AzureCognitiveSearch.Repositories.App;
using DAL.AzureCognitiveSearch.Repositories.Contracts;

namespace DAL.AzureCognitiveSearch.Factory
{
    public class AzureSearchRepositoryCollection : AzureSearchRepositoryFactory, IAzureSearchRepositoryCollection
    {
        public AzureSearchRepositoryCollection(SearchIndexClient searchIndexClient, SearchClient searchClient) : base(searchIndexClient, searchClient)
        {
        }
        
        public IPublicationRepository Publications =>
            GetRepository(() => new PublicationRepository(_searchIndexClient, _searchClient));
    }
}