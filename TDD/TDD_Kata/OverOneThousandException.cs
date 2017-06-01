using System;
using System.Runtime.Serialization;

namespace TDD_Kata
{
    [Serializable]
    internal class OverOneThousandException : Exception
    {
        public OverOneThousandException()
        {
        }

        public OverOneThousandException(string message) : base(message)
        {
        }

        public OverOneThousandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OverOneThousandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}