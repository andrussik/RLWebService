using Nest;

namespace DTO.SearchEngine
{
    public class Item
    {
        public string? Id { get; set; } = default!;
        // public string ExternalId { get; set; } = default!;
        // public string ExternalSystemCode { get; set; } = default!;
        // public string ExternalPublicationId { get; set; } = default!;
        // public string Isbn { get; set; } = default!;
        public string PublicationId { get; set; } = default!;
        public string? Barcode { get; set; }
        public string? CallNumber { get; set; }
        
        public Library? Location { get; set; }

        public ItemStatus? Status { get; set; }

        // public JoinField? PublicationJoinField { get; set; }
        // public JoinField? LocationJoinField { get; set; }
    }
}