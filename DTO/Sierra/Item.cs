
using System.Collections.Generic;

namespace DTO.Sierra
{
    public class Item
    {
        public string Id { get; set; } = default!;
        public string? Barcode { get; set; }
        public string? CallNumber { get; set; }
        
        public Library? Location { get; set; }

        public ItemStatus? Status { get; set; }
        
        public ICollection<string>? BibIds { get; set; }
    }
}