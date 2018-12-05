using System;
using System.Collections.Generic;
using System.Text;

namespace LVT.LVT.Interfaces
{
    public interface IVisualizer<T>
        where T: class
    {
        string VisualizeToString(T toVisualise);
    }
}
