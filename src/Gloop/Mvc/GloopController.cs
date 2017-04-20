using System.Web.Mvc;
using Gloop.Core;
using Gloop.Core.Pages;
using Gloop.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace Gloop.Mvc
{
    public class GloopController : Controller
    {
        private GloopContext GloopContext { get; }
        private ApplicationContext Application { get; }

        public GloopController()
            : this(GloopContext.Current)
        {

        }

        public GloopController(GloopContext gloopContext)
        {
            GloopContext = gloopContext;
            Application = new ApplicationContext();
        }


        public ActionResult Index()
        {
            GloopPageData pageData = Application.PageService.GetPageData(GloopContext.CleanedGloopUrlPath);
            if(pageData == null)
                return new HttpNotFoundResult("Page not found");

            var viewResult = ViewEngines.Engines.FindView(ControllerContext, pageData.ViewName, null);
            if (viewResult.View == null)
                return new HttpNotFoundResult("View not found");

            return View(viewResult.View, pageData);
        }
    }
}
