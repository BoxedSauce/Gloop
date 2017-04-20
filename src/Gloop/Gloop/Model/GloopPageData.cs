using System.Collections.Generic;

namespace Gloop.Model
{
    public class GloopPageData : IGloopPageData
    {
        public Dictionary<string, string> Fields { get; set; }
    }

    public interface IGloopPageData
    {
        Dictionary<string, string> Fields { get; set; }
    }
}
