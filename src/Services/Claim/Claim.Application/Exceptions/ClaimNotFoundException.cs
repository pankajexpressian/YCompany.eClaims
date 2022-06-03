using System;

namespace Claim.Application.Exceptions
{
    public class ClaimNotFoundException : Exception
    {
        public ClaimNotFoundException() : base()
        {

        }
        public ClaimNotFoundException(string message) : base(message)
        {

        }

        public ClaimNotFoundException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
