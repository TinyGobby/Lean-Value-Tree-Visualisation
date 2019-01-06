using System;
using System.IO;

namespace LVT.LVT.Services
{
    public class Validate
    {
        internal static bool IsValidArgument(string[] args)
        {
            return args.Length == 1 && args[0].ToLower().EndsWith(".json") && File.Exists(args[0]);
        }

        internal static void ShowErrorMessage(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the location of the JSON file you want to parse");
            }
            else if (!File.Exists(args[0]))
            {
                Console.WriteLine("This file does not exist. Please provide valid path and filename.");
            }
            else if (!args[0].ToLower().EndsWith(".json"))
            {
                Console.WriteLine("File must be in JSON format");
            }
        }

        //public static bool IsValidFilename(string filename)
        //{
        //    return filename != null && filename.ToLower().EndsWith(".json");
        //}

        //public static string ShowErrorMessageWeb(string filename)
        //{
        //    string message;

        //    if (filename == null)
        //    {
        //        message = "Please select a JSON file";
        //    }
        //    else if (!filename.ToLower().EndsWith(".json"))
        //    {
        //        message = "File must be in JSON format";
        //    }
        //    return message;
    //    }
    }
}
