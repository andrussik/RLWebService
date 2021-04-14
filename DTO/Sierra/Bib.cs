using System;

namespace DTO.Sierra
{
    public class Bib
    {
        public string Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int PublishYear { get; set; }
        public DateTime CatalogDate { get; set; }
        public bool Deleted { get; set; }
        public bool Suppressed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Language? Lang { get; set; }
        public MaterialType? MaterialType { get; set; }
    }
}