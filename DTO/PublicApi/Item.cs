

namespace DTO.PublicApi
{
    public class Item
    {
        public string Id { get; set; } = default!;
        public string PublicationId { get; set; } = default!;
        public string? Barcode { get; set; }
        public string? CallNumber { get; set; }
        
        public Library? Location { get; set; }

        public ItemStatus? Status { get; set; }
    }
}