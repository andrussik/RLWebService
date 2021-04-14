using Azure.Search.Documents.Indexes;
using Nest;

namespace DTO.AzureCognitiveSearch
{
    [ElasticsearchType(IdProperty = nameof(Code))]
    public class Library
    {
        [SearchableField]
        public string Code { get; set; } = default!;
        
        [SearchableField]
        public string Name { get; set; } = default!;
    }
}