using System;

namespace Addressee
{
    //// TODO: serialization support
    public class InvalidPostcodeException : AddresseeException
    {
        public InvalidPostcodeException()
        {
        }

        public InvalidPostcodeException(string message)
            : base(message)
        {
        }

        public InvalidPostcodeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}