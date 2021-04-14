using System.Collections.Generic;

namespace DTO.Sierra
{
    public class SearchResponse
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public int Start { get; set; }
        public ICollection<Entry>? Entries { get; set; }
    }
}