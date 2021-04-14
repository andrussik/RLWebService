using System.Collections.Generic;

namespace DTO.PublicApi.Mappers
{
    public class ItemMapper
    {
        public static Item Map(SearchEngine.Item item)
        {
            return new()
            {
                Id = item.Id!,
                PublicationId = item.PublicationId,
                Barcode = item.Barcode,
                CallNumber = item.CallNumber,
                Location = new Library {Code = item.Location!.Code, Name = item.Location.Name},
                Status = new ItemStatus {Code = item.Status!.Code, Display = item.Status.Display}
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
        
        public static Item Map(AzureCognitiveSearch.Item item)
        {
            return new()
            {
                Id = item.Id,
                PublicationId = item.PublicationId,
                Barcode = item.Barcode,
                CallNumber = item.CallNumber,
                Location = new Library {Code = item.Location!.Code, Name = item.Location.Name},
                Status = new ItemStatus {Code = item.Status!.Code, Display = item.Status.Display}
            };
        }

        public static IEnumerable<Item> Map(IEnumerable<AzureCognitiveSearch.Item> items)
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