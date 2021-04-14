using Azure.Search.Documents.Indexes;

namespace DTO.AzureCognitiveSearch
{
    public class Item
    {
        [SimpleField]
        public string Id { get; set; } = default!;
        
        [SearchableField]
        public string PublicationId { get; set; } = default!;
        
        [SearchableField]
        public string? Barcode { get; set; }
        
        [SearchableField]
        public string? CallNumber { get; set; }
        
        [SearchableField]
        public Library? Location { get; set; }

        [SearchableField]
        public ItemStatus? Status { get; set; }
    }
}