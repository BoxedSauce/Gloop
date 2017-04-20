using Gloop.Core.Pages;

namespace Gloop.Core.Services
{
    public interface IPageService
    {
        GloopPageData GetPageData(string path);
    }
}