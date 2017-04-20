using System.IO;
using System.Linq;
using Gloop.Core.Extensions;
using Gloop.Core.Pages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Gloop.Core.Services
{
    public class PageService : AbstractCloudService, IPageService
    {
        public PageService(CloudStorageAccount storageAccount)
            : base(storageAccount)
        {

        }

        public GloopPageData GetPageData(string path)
        {
            if (path[0] == '/')
                path = path.ReplaceFirst("/", "");

            CloudBlobContainer container = BlobClient.GetContainerReference("gloopdata");
            CloudBlobDirectory directory = container.GetDirectoryReference(path);

            var blob = directory.ListBlobs()
                .OfType<CloudBlob>()
                .LastOrDefault();

            if (blob == null)
                return null;

            GloopPageData pageData;

            using (var memoryStream = new MemoryStream())
            {
                blob.DownloadToStream(memoryStream);
                pageData = memoryStream.Deserialize<GloopPageData>();
            }

            return pageData;
        }
    }
}
