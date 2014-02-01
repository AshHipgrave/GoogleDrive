using System;

namespace SxGoogle
{
    public class GetCredentialsException : Exception
    {
        public string AuthorisationUrl { get; set; }

        internal GetCredentialsException(string AuthUrl)
        {
            AuthorisationUrl = AuthUrl;
        }
    }

    public class NoRefreshTokenException : GetCredentialsException
    {
        public NoRefreshTokenException(string AuthUrl)
            : base(AuthUrl)
        {
        }
    }

    public class CodeExchangeException : GetCredentialsException
    {
        public CodeExchangeException(string AuthUrl)
            : base(AuthUrl)
        {
        }
    }

    public class NoUserIdException : Exception
    {
    }
}