using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DAL.Sierra.Repositories.Contracts;
using DTO.DAL.Sierra;
using DTO.PublicApi;
using DTO.PublicApi.Mappers;

namespace DAL.Sierra.Repositories.App
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
        
        public async Task<IEnumerable<Book>> FindAsync(string searchString)
        {
            var urlString = "bibs/search?text=" + searchString;
            var searchResponseDTO = await _httpClient.GetFromJsonAsync<SearchResponse>(urlString);

            var bibs = searchResponseDTO?.Entries
                ?.Where(entry => entry.Bib != null)
                .Select(entry => entry.Bib!).ToList() ?? new List<Bib>();

            var books = BookMapper.Map(bibs);

            return books;
        }
    }
}