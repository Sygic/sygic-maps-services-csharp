using System;
using System.Runtime.Serialization;

namespace Sygic.Maps.Clients.OptimizationApi.Model
{
    [Serializable]
    public class OptimizationApiException : Exception
    {
        public OptimizationApiException()
        {
        }

        public OptimizationApiException(string message) : base(message)
        {
        }

        public OptimizationApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OptimizationApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}