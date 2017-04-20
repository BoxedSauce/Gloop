using System;
using Gloop.Core.Services;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;

namespace Gloop.Core
{
    public class ApplicationContext
    {
        private readonly CloudStorageAccount _storageAccount;

        private Lazy<IPageService> _pageService;
        private Lazy<IContentService> _contentService;

        public IPageService PageService
        {
            get { return _pageService.Value; }
        }

        public IContentService ContentService
        {
            get { return _contentService.Value; }
        }

        public ApplicationContext()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("GloopConnectionString"));
    
            BuildServiceCache();
        }



        private void BuildServiceCache()
        {
            if (_pageService == null)
                _pageService = new Lazy<IPageService>(() => new PageService(_storageAccount));

            if(_contentService == null)
                _contentService = new Lazy<IContentService>(()=> new ContentService(_storageAccount));
        }
    }
}
