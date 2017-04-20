using Microsoft.WindowsAzure.Storage.Table;

namespace Gloop.Model
{
    public class GloopPage : TableEntity
    {
        public string Name { get; set; }
        public string UrlPath { get; set; }
        public string Data { get; set; }
        public string Template { get; set; }
        public string View { get; set; }
        public bool Published { get; set; }
    }
}