using System;
using System.Runtime.Serialization;

namespace MarcReader.MARC
{
    public interface IVariableField : ISerializable, IComparable<IVariableField>
    {
        long Id { get; set; }
        String Tag { get; set; }

        /// <summary>
        /// Returns true if the given regular expression matches a subsequence of a
        /// data element within the variable field.
        /// </summary>
        /// <param name="pattern">Regex pattern</param>
        /// <returns></returns>
        bool Find(String pattern);
    }
}