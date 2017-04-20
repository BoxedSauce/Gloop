using System.Web.Optimization;
using Gloop.Web;

namespace Gloop.App
{
    public class MvcApplication : GloopApplication
    {
        protected override void OnApplicationStarted()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
