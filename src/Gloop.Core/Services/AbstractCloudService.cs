using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace Gloop.Core.Services
{
    public abstract class AbstractCloudService
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly Lazy<CloudBlobClient> _cloudBlobClient;
        private readonly Lazy<CloudTableClient> _cloudTableClient;

        protected CloudBlobClient BlobClient
        {
            get { return _cloudBlobClient.Value; }
        }

        protected CloudTableClient TableClient
        {
            get { return _cloudTableClient.Value; }
        }

        protected AbstractCloudService(CloudStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
            
            _cloudBlobClient = new Lazy<CloudBlobClient>(() => _storageAccount.CreateCloudBlobClient());
            _cloudTableClient = new Lazy<CloudTableClient>(() => _storageAccount.CreateCloudTableClient());
        }
    }
}