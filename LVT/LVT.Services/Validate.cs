using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace LVT.LVT.Services
{
    public class Validate
    {
        public static void ValidateArgument(string file)
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
