using System;
using Gloop.Core.Extensions;
using Gloop.Core.Pages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Gloop.Core.Services
{
    public class ContentService : AbstractCloudService, IContentService
    {

        public ContentService(CloudStorageAccount storageAccount)
            : base(storageAccount)
        {
        }



        public void SavePage(GloopPageData page)
        {
            string fileName = DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".json";
            string folder = null;

            if (page.Url != "/")
                folder = page.Url + "/";

            string filePath = folder + fileName;
            filePath = filePath.ReplaceFirst("/", "");

            CloudBlobContainer container = BlobClient.GetContainerReference("gloopdata");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filePath);
            blockBlob.UploadText(JsonConvert.SerializeObject(page));
        }
    }
}