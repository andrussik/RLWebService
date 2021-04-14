using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.PublicApi;
using DTO.Sierra;
using Item = DTO.Sierra.Item;

namespace DAL.Sierra.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<SearchResponse> FindAsync(string searchString);
        Task<string> GetMarcFileAsync(string link);
        Task<MarcFileLinkResponse> GetMarcFileLinkFromIdsAsync(IEnumerable<string> bookIds);
        Task<MarcFileLinkResponse> GetMarcFileLinkFromIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Bib>> GetBibsFromIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Item>> GetItemsFromIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Item>> GetItemsFromBibIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Item>> GetItemsFromBibIdsAsync(IEnumerable<string> bibIds);
    }
}