using System.Collections.Generic;
using Azure.Search.Documents.Indexes;

namespace DTO.AzureCognitiveSearch
{
    public class Publication
    {
        [SimpleField(IsKey = true)]
        public string Id { get; set; } = default!;
        
        [SearchableField]
        public string? Title { get; set; }
        
        [SearchableField]
        public string? Author { get; set; }
        
        public int? PublishYear { get; set; }
        
        [SearchableField]
        public Language? Lang { get; set; }
        
        [SearchableField]
        public MaterialType? MaterialType { get; set; }
        
        [SearchableField]
        public ICollection<Item>? Items { get; set; }
    }
}