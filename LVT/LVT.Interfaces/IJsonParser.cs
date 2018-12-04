using System;
using System.IO;

namespace LVT.LVT.Interfaces
{
    public interface IJsonToLVTParser
    {
        LeanValueTree ParseJsonLVT(String filePath);
        LeanValueTree ParseJsonLVTFromStream(StreamReader stream);
    }
}
