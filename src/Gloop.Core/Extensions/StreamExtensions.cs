using System.IO;
using Newtonsoft.Json;

namespace Gloop.Core.Extensions
{
    public static class StreamExtensions
    {
        public static T Deserialize<T>(this Stream stream)
        {
            stream.Position = 0;

            using (StreamReader reader = new StreamReader(stream))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
