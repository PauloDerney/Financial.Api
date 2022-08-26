using CrossCutting.Core;
using System.Net;

namespace CrossCutting.Exceptions
{
    public class AlreadyExistException : CustomExceptionType
    {
        public AlreadyExistException(string errorMessage)
            : base(HttpStatusCode.Conflict, errorMessage) { }
    }
}