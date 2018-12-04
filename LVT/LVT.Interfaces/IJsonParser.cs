using System;
using System.Collections.Generic;
using System.Text;

namespace LVT.LVT.Interfaces
{
    public interface IJsonToLVTParser
    {
        LeanValueTree ParseJsonLVT(string path);
    }
}
