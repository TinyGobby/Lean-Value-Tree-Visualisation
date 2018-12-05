using LVT.LVT.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace LVT.LVT.Services
{
    public class JsonParser : IJsonToLVTParser
    {
        //public LeanValueTree ParseJsonLVT(string Path)
        //{
        //    using (StreamReader file = File.OpenText($"{Path}"))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        return (LeanValueTree)serializer.Deserialize(file, typeof(LeanValueTree));
        //    }
        //}
        public LeanValueTree ParseJsonLVTFromStream(StreamReader stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            return (LeanValueTree)serializer.Deserialize(stream, typeof(LeanValueTree));
        }

    }
}
