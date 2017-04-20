using System;

namespace Gloop.Web.Routing
{
    public class PageContentRequest
    {
        public string UriPath { get; set; }

        public PageContentRequest(string uriPath)
        {
            if (uriPath == null) throw new ArgumentNullException(nameof(uriPath));

            UriPath = uriPath;
        }
    }
}
