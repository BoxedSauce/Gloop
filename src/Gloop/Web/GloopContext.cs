using System;
using System.Web;
using Gloop.Web.Routing;

namespace Gloop.Web
{
    public class GloopContext : IDisposable
    {
        internal const string HttpContextItemName = "Gloop.GloopContext";
        private static readonly object Locker = new object();
        private static GloopContext _gloopContext;

        public HttpContextBase HttpContext { get; private set; }

        public string CleanedGloopUrlPath { get; private set; }

        public Uri OriginalRequestUrl { get; private set; }

        public PageContentRequest PageContentRequest { get; set; }


        internal GloopContext(HttpContextBase httpContext)
        {
            //This ensures the dispose method is called when the request terminates, though
            // we also ensure this happens in the Umbraco module because the UmbracoContext is added to the
            // http context items.
            httpContext.DisposeOnPipelineCompleted(this);

            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            HttpContext = httpContext;


            var requestUrl = new Uri("http://localhost");
            var request = GetRequestFromContext();
            if (request != null)
            {
                requestUrl = request.Url;
            }
            OriginalRequestUrl = requestUrl;
            CleanedGloopUrlPath = UriToGloop(OriginalRequestUrl);
        }




        public static GloopContext EnsureContext(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var umbracoContext = CreateContext(httpContext);

            //assign the singleton
            Current = umbracoContext;
            return Current;
        }

        public static GloopContext CreateContext(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            return new GloopContext(httpContext);
        }

        public static GloopContext Current
        {
            get
            {
                //if we have a real context then return the request based object
                if (System.Web.HttpContext.Current != null)
                {
                    return (GloopContext)System.Web.HttpContext.Current.Items[HttpContextItemName];
                }

                //return the object if not running in a real HttpContext
                return _gloopContext;
            }

            internal set
            {
                lock (Locker)
                {
                    //if running in a real HttpContext, this can only be set once
                    if (System.Web.HttpContext.Current != null && Current != null)
                    {
                        throw new ApplicationException("The current GloopContext can only be set once during a request.");
                    }

                    //if there is an HttpContext, return the item
                    if (System.Web.HttpContext.Current != null)
                    {
                        System.Web.HttpContext.Current.Items[HttpContextItemName] = value;
                    }
                    else
                    {
                        _gloopContext = value;
                    }
                }
            }
        }

        
        public void Dispose()
        {

        }


        private HttpRequestBase GetRequestFromContext()
        {
            try
            {
                return HttpContext.Request;
            }
            catch (System.Web.HttpException)
            {
                return null;
            }
        }

        private static string UriToGloop(Uri uri)
        {
            string path = uri.AbsolutePath;
            path = path.ToLower();
            return path;
        }
    }
}
