

using DAL.AzureCognitiveSearch.Repositories.Contracts;

namespace DAL.AzureCognitiveSearch.Factory
{
    public interface IAzureSearchRepositoryCollection
    {
        IPublicationRepository Publications { get; }
    }
}