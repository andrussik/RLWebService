using System.Collections.Generic;

namespace DTO.SearchEngine.Mappers
{
    public class LibraryMapper
    {
        public static Library Map(Sierra.Library library)
        {
            return new ()
            {
                Code = library.Code,
                Name = library.Name
            };
        }

        public static IEnumerable<Library> Map(IEnumerable<Sierra.Library> libraries)
        {
            var result = new List<Library>();
            foreach (var library in libraries)
            {
                var lib = Map(library);
                result.Add(lib);
            }

            return result;
        }
    }
}