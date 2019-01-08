using System;
using System.IO;

namespace LVT.LVT.Services
{
    public class Validate
    {
        public static void ValidateFile(string file)
        {
            if (file == null)
            {
                throw new NullReferenceException("Upload cannot be empty. Please return to the previous page to select a valid JSON file.");
            }
            else if (!file.ToLower().EndsWith(".json"))
            {
                throw new Exception("File must be in JSON format. Please return to the previous page to select a valid JSON file.");
            }

            return;
        }

        public static void ValidateArgument(string file)
        {
            if (file == null)
            {
                throw new NullReferenceException("Selection cannot be empty.\nPlease provide the name and path of the file you want to open (for example: C:\\test\\LVT.json)");
            }
            else if (!File.Exists(file))
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
