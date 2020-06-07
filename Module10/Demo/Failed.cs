using System;

namespace Demo
{
    internal class Failed
    {
    }

    internal class NetworkError : Failed
    {
    }

    internal class Moved : Failed
    {
        public Uri RedirectUri { get; }

        public Moved(Uri redirectUri)
        {
            RedirectUri = redirectUri;
        }
    }

    internal class NotFound : Failed
    {
    }

    internal class Timeout : Failed
    {
    }
}