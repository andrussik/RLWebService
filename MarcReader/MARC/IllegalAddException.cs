using System;

namespace MarcReader.MARC
{
    public class IllegalAddException : ArgumentException
    {

        public IllegalAddException(String className)
            : base(string.Format("The addition of the object of type {0} is not allowed.", className))
        {
        }

        public IllegalAddException(String className, String reason)
            : base(string.Format("The addition of the object of type {0} is not allowed: {1}", className, reason))
        {
        }
    }
}