using System.Net;
using System.Runtime.Serialization;

namespace CrossCutting.Core
{
    public abstract class CustomExceptionType : Exception, ISerializable
    {
        public CustomExceptionType(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}