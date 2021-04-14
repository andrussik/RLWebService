using System.Collections.Generic;
using System.Linq;

namespace DTO.SearchEngine.Mappers
{
    public class ItemMapper
    {
        public static Item Map(Sierra.Item item, string externalSystemCode)
        {
            return new()
            {
                Id = item.Id,
                // ExternalId = item.Id,
                // ExternalSystemCode = externalSystemCode,
                // ExternalPublicationId = item.BibIds!.First(),
                PublicationId = item.BibIds!.First(),
                Barcode = item.Barcode,
                CallNumber = item.CallNumber,
                Location = LibraryMapper.Map(item.Location!),
                Status = StatusMapper.Map(item.Status!)
            };
        }
        
        public static IEnumerable<Item> Map(IEnumerable<Sierra.Item> items, string externalSystemCode)
        {
            var result = new List<Item>();

            foreach (var item in items)
            {
                var mappedItem = Map(item, externalSystemCode);
                result.Add(mappedItem);
            }

            return result;
        }
    }
}