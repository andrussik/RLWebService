using System.Collections.Generic;
using MarcReader.MARC;

namespace MarcReader
{
    /// <summary>
    /// Implement this interface to provide an iterator over a collection of
    /// <code>Record</code> objects.
    /// </summary>
    public interface IMarcReader : IEnumerator<IRecord>, IEnumerable<IRecord>
    {
        ///// <summary>
        ///// Returns true if the iteration has more records, false otherwise.
        ///// </summary>
        ///// <returns></returns>
        //public bool HasNext();

        ///// <summary>
        ///// Returns the next record in the iteration.
        ///// </summary>
        ///// <returns></returns>
        //public IRecord Next();
    }
}
