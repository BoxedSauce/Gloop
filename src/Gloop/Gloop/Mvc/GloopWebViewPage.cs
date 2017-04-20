using System.Web.Mvc;
using Gloop.Model;
using Gloop.Web;

namespace Gloop.Mvc
{
    public abstract class GloopWebViewPage : GloopWebViewPage<GloopPageData>
    {
    }

    public abstract class GloopWebViewPage<TModel> : WebViewPage<TModel> 
        where TModel : IGloopPageData
    {
        private GloopHelper _helper;

        public GloopContext GloopContext
        {
            get
            {
                return GloopContext.Current;
            }
        }

        /// <summary>
        /// Gets the GloopHelper
        /// </summary>
        /// <remarks>
        /// This constructs the GloopHelper with the content model of the page routed to
        /// </remarks>
        public virtual GloopHelper Gloop
        {
            get
            {
                if (_helper == null)
                {
                    var model = ViewData.Model ;
                    _helper = model == null
                        ? new GloopHelper(GloopContext)
                        : new GloopHelper(GloopContext, model);
                }
                return _helper;
            }
        }
    }
}
