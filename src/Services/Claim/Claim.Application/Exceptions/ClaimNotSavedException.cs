using System;

namespace Claim.Application.Exceptions
{
    public class ClaimNotSavedException : Exception
    {
        public ClaimNotSavedException() : base()
        {

        }
        public ClaimNotSavedException(string message) : base(message)
        {

        }

        public ClaimNotSavedException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
