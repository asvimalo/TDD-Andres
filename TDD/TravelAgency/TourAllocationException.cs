using System;
using System.Runtime.Serialization;

namespace TravelAgency
{
    [Serializable]
    public class TourAllocationException : Exception
    {
        public TourAllocationException()
        {
        }

        public TourAllocationException(string message) : base(message)
        {
        }

        public TourAllocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TourAllocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}