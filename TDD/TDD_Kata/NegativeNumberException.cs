using System;
using System.Runtime.Serialization;

namespace TDD_Kata
{
    [Serializable]
    internal class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {
        }

        public NegativeNumberException(string message) : base(message)
        {
        }

        public NegativeNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}