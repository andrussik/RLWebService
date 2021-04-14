using Nest;

namespace DTO.SearchEngine
{
    [ElasticsearchType(IdProperty = nameof(Code))]
    public class Library
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        // public string Address { get; set; } = default!;
        // public decimal? Lat { get; set; }
        // public decimal? Lon { get; set; }
    }
}