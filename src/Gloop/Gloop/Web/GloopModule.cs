using System;
using System.Web;
using Gloop.Services;
using Gloop.Web.Routing;

namespace Gloop.Web
{
    public class GloopModule : IHttpModule
    {
        /// <summary>
		/// Begins to process a request.
		/// </summary>
		/// <param name="httpContext"></param>
        private static void BeginRequest(HttpContextBase httpContext)
        {
            // write the trace output for diagnostics at the end of the request
            httpContext.Trace.Write("GloopModule", "Gloop request begins");

            // create the UmbracoContext singleton, one per request, and assign
            GloopContext.EnsureContext(httpContext);
        }

        private static void ProcessRequest(HttpContextWrapper httpContext)
        {
            if (GloopContext.Current == null)
                throw new InvalidOperationException("The UmbracoContext.Current is null, ProcessRequest cannot proceed unless there is a current UmbracoContext");
           
            var gloopContext = GloopContext.Current;
            var serviceContext = new ServiceContext();
            
            httpContext.Trace.Write("GloopModule", "Gloop request confirmed");

           
            // instanciate, prepare and process the published content request
            // important to use CleanedUmbracoUrl - lowercase path-only version of the current url

            //var pageContentEngine = new PageContentRequestEngine(serviceContext);
            //var pageContentRequest = new PageContentRequest(gloopContext.CleanedGloopUrlPath);
            //gloopContext.PageContentRequest = pageContentRequest;
            //pageContentRequest.Prepare();

            //RewriteToGloopHandler(httpContext, pageContentRequest);
        }



        public void Init(HttpApplication application)
        {
            application.BeginRequest += (sender, e) =>
            {
                var httpContext = ((HttpApplication)sender).Context;
                BeginRequest(new HttpContextWrapper(httpContext));
            };
            
            application.PostReleaseRequestState += (sender, args) =>
            {
                var httpContext = ((HttpApplication)sender).Context;
                try
                {
                    httpContext.Response.Headers.Remove("Server");
                    httpContext.Response.Headers.Remove("X-Powered-By");
                    httpContext.Response.Headers.Remove("X-AspNet-Version");
                    httpContext.Response.Headers.Remove("X-AspNetMvc-Version");
                }
                catch (PlatformNotSupportedException)
                {
                    // can't remove headers this way on IIS6 or cassini.
                }
            };

            application.PostResolveRequestCache += (sender, e) =>
            {
                var httpContext = ((HttpApplication)sender).Context;
                ProcessRequest(new HttpContextWrapper(httpContext));
            };
        }

        public void Dispose() { }
    }
}
