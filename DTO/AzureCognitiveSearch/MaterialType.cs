using Azure.Search.Documents.Indexes;

namespace DTO.AzureCognitiveSearch
{
    public class MaterialType
    {
        [SearchableField]
        public string Code { get; set; } = default!;
        
        [SearchableField]
        public string Name { get; set; } = default!;
    }
}