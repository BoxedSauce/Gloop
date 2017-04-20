using System.Collections.Generic;

namespace Gloop.Core.Pages
{
    public interface IGloopPageData
    {
        string Name { get; set; }
        string Url { get; set; }
        string ViewName { get; set; }
        Dictionary<string, string> Fields { get; set; }
    }
}