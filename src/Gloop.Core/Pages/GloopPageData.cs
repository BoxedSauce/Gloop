using System.Collections.Generic;

namespace Gloop.Core.Pages
{
    public class GloopPageData : IGloopPageData
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ViewName { get; set; }
        public Dictionary<string, string> Fields { get; set; }
    }
}
