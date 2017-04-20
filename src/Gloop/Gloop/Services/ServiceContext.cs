using System;

namespace Gloop.Services
{
    public class ServiceContext
    {

        private Lazy<IPageContentService> _pageContentService;



        public IPageContentService PageContentService
        {
            get { return _pageContentService.Value; }
        }


        public ServiceContext()
        {
            
            BuildServiceCache();
        }


        private void BuildServiceCache()
        {
            if (_pageContentService == null)
                _pageContentService = new Lazy<IPageContentService>(() => new PageContentService());
        }

    }
}
