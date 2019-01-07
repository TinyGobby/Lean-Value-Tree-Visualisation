using System;
using System.IO;

namespace LVT.LVT.Services
{
    public class Validate
    {
        internal static void ValidateArgument(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }
            else if (!file.ToLower().EndsWith(".json"))
            {
               throw new Exception("File must be in JSON format");
            }

            return;
        }
    }
}
