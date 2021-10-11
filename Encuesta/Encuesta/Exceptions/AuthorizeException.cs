using System;

namespace Encuesta.Exceptions
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException()
        {

        }

        public AuthorizeException(string message) : base(message)
        {

        }
    }
}
