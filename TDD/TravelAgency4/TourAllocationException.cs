using System;
using System.Runtime.Serialization;

namespace TravelAgency4
{
    [Serializable]
    public class TourAllocationException : Exception
    {
        public DateTime? SuggestedTime { get; private set; }
        public TourAllocationException(DateTime? suggestedTime)
        {
            SuggestedTime = suggestedTime;
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