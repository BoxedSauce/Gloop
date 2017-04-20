using System.IO;
using System.Web.Mvc;
using Gloop.Model;
using Gloop.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace Gloop.Mvc
{
    public class GloopController : Controller
    {
        private readonly CloudTable _table;
        private readonly CloudBlobContainer _container;

        public virtual GloopContext GloopContext { get; private set; }

        public GloopController()
            : this(GloopContext.Current)
        {

        }

        public GloopController(GloopContext gloopContext)
        {
            GloopContext = gloopContext;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("GloopConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            _table = tableClient.GetTableReference("GloopPage");
            _table.CreateIfNotExists();

            _container = blobClient.GetContainerReference("gloopdata");
            _container.CreateIfNotExists();
        }


        public ActionResult Index()
        {
            //GloopPage page = new GloopPage();
            //page.PartitionKey = "Pages";
            //page.RowKey = "root";
            //page.Name = "Home";
            //page.Data = "Home";
            //page.View = "Home";
            //page.UrlPath = "/";
            //page.Published = true;


            //TableOperation insertOperation = TableOperation.Insert(page);
            //_table.Execute(insertOperation);

            //return null;

            // get the table row
            TableOperation retrieveOperation = TableOperation.Retrieve<GloopPage>("Pages", GloopContext.CleanedGloopUrlPath);
            TableResult retrievedResult = _table.Execute(retrieveOperation);

            GloopPage page = retrievedResult.Result as GloopPage;
            if (page == null)
                return new HttpNotFoundResult("Page not found");

            // get the blob
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(page.Data);
            GloopPageData pageData;
            
            using (var memoryStream = new MemoryStream())
            {
                blockBlob.DownloadToStream(memoryStream);
                // de-serialize the blob to model
                pageData = memoryStream.Deserialize<GloopPageData>();
            }
            
            // get the view
            var viewResult = ViewEngines.Engines.FindView(ControllerContext, page.View, null);
            if (viewResult.View == null)
                return new HttpNotFoundResult("View not found");

            return View(viewResult.View, pageData);
        }
    }
}
