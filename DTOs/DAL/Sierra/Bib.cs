using System;

namespace DTOs.DAL.Sierra
{
    public class Bib
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int PublishYear { get; set; }
        public DateTime CatalogDate { get; set; }
        public bool Deleted { get; set; }
        public bool Suppressed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}