using System;
using System.IO;

namespace LVT.LVT.Interfaces
{
    public interface IJsonToLVTParser
    {
        LeanValueTree ParseJsonLVTFromStream(StreamReader stream);
    }
}
