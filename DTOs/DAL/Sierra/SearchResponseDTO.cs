using System.Collections.Generic;

namespace DTOs.DAL.Sierra
{
    public class SearchResponseDTO
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public int Start { get; set; }
        public ICollection<Entry>? Entries { get; set; }
    }
}