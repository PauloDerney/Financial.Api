using CrossCutting.Core;
using System.Net;

namespace CrossCutting.Exceptions
{
    public class BalanceException : CustomExceptionType
    {
        public BalanceException(string errorMessage)
            : base(HttpStatusCode.BadRequest, errorMessage) { }
    }
}