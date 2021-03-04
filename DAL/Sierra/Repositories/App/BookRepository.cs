using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DAL.Sierra.Repositories.Contracts;
using DTOs.DAL.Sierra;
using DTOs.PublicApi;
using DTOs.PublicApi.Mappers;

namespace DAL.Sierra.Repositories.App
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
        
        public async Task<IEnumerable<BookDTO>> FindAsync(string searchString)
        {
            var urlString = "bibs/search?text=" + searchString;
            var searchResponseDTO = await _httpClient.GetFromJsonAsync<SearchResponseDTO>(urlString);

            var bibs = searchResponseDTO?.Entries
                ?.Where(entry => entry.Bib != null)
                .Select(entry => entry.Bib!).ToList() ?? new List<Bib>();

            var books = BookMapper.Map(bibs);

            return books;
        }
    }
}