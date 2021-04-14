using System.Collections.Generic;

namespace DTO.Sierra
{
    public class BibResponse
    {
        public int Total { get; set; }
        public int Start { get; set; }
        public ICollection<Bib>? Entries { get; set; }
    }
}