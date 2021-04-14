using System.Collections.Generic;
using System.Linq;

namespace DTO.AzureCognitiveSearch.Mappers
{
    public class ItemMapper
    {
        public static Item Map(Sierra.Item item)
        {
            return new()
            {
                Id = item.Id,
                PublicationId = item.BibIds!.First(),
                Barcode = item.Barcode,
                CallNumber = item.CallNumber,
                Location = LibraryMapper.Map(item.Location!),
                Status = StatusMapper.Map(item.Status!)
            };
        }
        
        public static IEnumerable<Item> Map(IEnumerable<Sierra.Item> items)
        {
            var result = new List<Item>();

            foreach (var item in items)
            {
                var mappedItem = Map(item);
                result.Add(mappedItem);
            }

            return result;
        }
        
        public static Item Map(SearchEngine.Item item)
        {
            return new()
            {
                Id = item.Id!,
                PublicationId = item.PublicationId,
                Barcode = item.Barcode,
                CallNumber = item.CallNumber,
                Location = item.Location != null ? new Library{Code = item.Location.Code, Name = item.Location.Name} : null,
                Status = item.Status != null ? new ItemStatus{Code = item.Status.Code, Display = item.Status.Display} : null
            };
        }
        
        public static IEnumerable<Item> Map(IEnumerable<SearchEngine.Item> items)
        {
            var result = new List<Item>();

            foreach (var item in items)
            {
                result.Add(Map(item));
            }

            return result;
        }
    }
}