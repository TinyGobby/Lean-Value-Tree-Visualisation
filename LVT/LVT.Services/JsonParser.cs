using LVT.LVT.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LVT.LVT.Services
{
    class JsonParser : IJsonToLVTParser
    {
        public LeanValueTree ParseJsonLVT(string Path)
        {
            using (StreamReader file = File.OpenText($"{Path}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (LeanValueTree)serializer.Deserialize(file, typeof(LeanValueTree));
            }
        }
    }
}
