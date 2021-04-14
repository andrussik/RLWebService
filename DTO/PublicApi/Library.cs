using Nest;

namespace DTO.PublicApi
{
    [ElasticsearchType(IdProperty = nameof(Code))]
    public class Library
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}