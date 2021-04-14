using System.Collections.Generic;
using LuceneExtensions.DataAnnotations;
using Nest;

namespace DTO.SearchEngine
{
    // [ElasticsearchType(IdProperty = nameof(Isbn))]
    public class Publication
    {
        [IdProperty]
        public string Id { get; set; } = default!;
        // public string Isbn { get; set; } = default!;
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? PublishYear { get; set; }
        public Language? Lang { get; set; }
        public MaterialType? MaterialType { get; set; }

        public ICollection<Item>? Items { get; set; }
        // public JoinField? ItemJoinField { get; set; }
        // public string? LanguageCode { get; set; }
    }
}