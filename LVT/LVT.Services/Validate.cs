using System;
using System.IO;

namespace LVT.LVT.Services
{
    public class Validate
    {
        public static void ValidateFilename(string filename)
        {
            if (filename == null)
            {
                throw new NullReferenceException("Upload cannot be empty. Please return to the previous page to select a valid JSON file.");
            }
            else if (!filename.ToLower().EndsWith(".json"))
            {
                throw new Exception("File must be in JSON format. Please return to the previous page to select a valid JSON file.");
            }

            return;
        }

        public static void ValidateArgument(string filename)
        {
            if (filename == null)
            {
                throw new NullReferenceException("Selection cannot be empty\nPlease provide the name and path of the file you want to open (for example: C:\\test\\LVT.json)");
            }
            else if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            else if (!filename.ToLower().EndsWith(".json"))
            {
                throw new Exception("File must be in JSON format");
            }

            return;
        }
    }

}
