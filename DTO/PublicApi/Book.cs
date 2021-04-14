using System.Collections.Generic;

namespace DTO.PublicApi
{
    public class Book
    {
        public string Id { get; set; } = default!;
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? PublishYear { get; set; }
        
        public Language? Lang { get; set; }
        public MaterialType? MaterialType { get; set; }
        
        public ICollection<Item>? Items { get; set; }
    }
}