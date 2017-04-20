using System.Web;
using Gloop.Core.Pages;

namespace Gloop.Web
{
    public class GloopHelper
    {
        private readonly IGloopPageData _currentPageData;
        private readonly GloopContext _gloopContext;

        public GloopHelper(GloopContext gloopContext)
        {
            _gloopContext = gloopContext;
        }

        public GloopHelper(GloopContext gloopContext, IGloopPageData currentPageData)
        {
            _gloopContext = gloopContext;
            _currentPageData = currentPageData;
        }

        /// <summary>
        /// Renders an PageField to the template
        /// </summary>
        /// <param name="fieldAlias"></param>
        /// <returns></returns>
        public IHtmlString PageField(string fieldAlias)
        {
            if(_currentPageData == null || !_currentPageData.Fields.ContainsKey(fieldAlias))
                return null;

            return new HtmlString(_currentPageData.Fields[fieldAlias]);
        }
    }
}
