using CrossCutting.Core;
using System.Net;

namespace CrossCutting.Exceptions
{
    public class NotFoundException : CustomExceptionType
    {
        public NotFoundException(string errorMessage)
            : base(HttpStatusCode.NotFound, errorMessage) { }
    }
}