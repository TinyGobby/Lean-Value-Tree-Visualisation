using LVT.LVT.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace LVT.LVT.Services
{
    class JsonParser : IJsonToLVTParser
    {
        public LeanValueTree ParseJsonLVTFromStream(StreamReader stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            return (LeanValueTree)serializer.Deserialize(stream, typeof(LeanValueTree));
        }
    }
}
