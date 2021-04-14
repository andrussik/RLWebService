using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DAL.Sierra.Repositories.Contracts;
using DTO.Sierra;

namespace DAL.Sierra.Repositories.App
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
        
        public async Task<SearchResponse> FindAsync(string searchString)
        {
            var urlString = "bibs/search?text=" + searchString + "&start=0&limit=2000";
            var searchResponseDTO = await _httpClient.GetFromJsonAsync<SearchResponse>(urlString);

            return searchResponseDTO ?? new SearchResponse();
        }
        
        public async Task<string> GetMarcFileAsync(string link)
        {
            var result = await _httpClient.GetStringAsync(link);
            return result;
        }

        public async Task<MarcFileLinkResponse> GetMarcFileLinkFromIdsAsync(IEnumerable<string> bookIds)
        {
            var bookIdsString = string.Join(",", bookIds);

            var urlString = $"bibs/marc?id={bookIdsString}&offset=0&limit=2000";
            var result = await _httpClient.GetFromJsonAsync<MarcFileLinkResponse>(urlString);

            return result ?? new MarcFileLinkResponse();
        }

        public async Task<MarcFileLinkResponse> GetMarcFileLinkFromIdRangeAsync(int minId, int maxId)
        {
            var minAndMaxIds = new [] {minId, maxId};
            var bookIdsString = string.Join(",", minAndMaxIds);
            var urlString = $"bibs/marc?id=[{bookIdsString}]&offset=0&limit=2000";
            var result = await _httpClient.GetFromJsonAsync<MarcFileLinkResponse>(urlString);

            return result ?? new MarcFileLinkResponse();
        }

        public async Task<IEnumerable<Bib>> GetBibsFromIdRangeAsync(int minId, int maxId)
        {
            var urlString = $"bibs/?id=[{minId},{maxId}]&offset=0&limit=2000";
            var result = await _httpClient.GetFromJsonAsync<BibResponse>(urlString);

            return result?.Entries ?? Array.Empty<Bib>();
        }

        public async Task<IEnumerable<Item>> GetItemsFromIdRangeAsync(int minId, int maxId)
        {
            var urlString = $"items/?id=[{minId},{maxId}]&offset=0&limit=2000";
            var itemResponse = await _httpClient.GetFromJsonAsync<ItemResponse>(urlString);

            return itemResponse?.Entries ?? Array.Empty<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsFromBibIdRangeAsync(int minId, int maxId)
        {
            var urlString = $"items/?bibIds=[{minId},{maxId}]&offset=0&limit=2000";
            var itemResponse = await _httpClient.GetFromJsonAsync<ItemResponse>(urlString);

            return itemResponse?.Entries ?? Array.Empty<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsFromBibIdsAsync(IEnumerable<string> bibIds)
        {
            var joinIds = string.Join(",", bibIds);
            var urlString = $"items/?bibIds={joinIds}&offset=0&limit=2000";
            var itemResponse = await _httpClient.GetFromJsonAsync<ItemResponse>(urlString);

            return itemResponse?.Entries ?? Array.Empty<Item>();
        }
    }
}