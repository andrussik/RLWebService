using Azure.Search.Documents.Indexes;

namespace DTO.AzureCognitiveSearch
{
    public class ItemStatus
    {
        [SearchableField]
        public string? Code { get; set; }
        
        [SearchableField]
        public string? Display { get; set; }
    }
}