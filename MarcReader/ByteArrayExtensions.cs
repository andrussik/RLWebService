using System.Linq;

namespace MarcReader
{
    public static class ByteArrayExtensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            return new string(bytes.Select(a => (char)a).ToArray());
        }
    }
}
