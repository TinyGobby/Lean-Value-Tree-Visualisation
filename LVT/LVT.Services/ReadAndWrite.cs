using LVT.LVT.Services;
using System;
using System.IO;

namespace LVT
{
    internal class ReadAndWrite
    {
        internal static bool IsValidArgument(String[] args)
        {
            return args.Length == 1 && args[0].ToLower().EndsWith("json");
        }

        internal static void ShowErrorMessage(String[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the location of the JSON file you want to parse");
            }
            else if (!args[0].ToLower().EndsWith("json"))
            {
                Console.WriteLine("File must be in JSON format");
            }
        }

        internal static void BuildTree(StreamReader file)
        {
            LeanValueTree newTree = ParseLVTData(file);
            CreateLVTHtml(newTree);
        }

        internal static LeanValueTree ParseLVTData(StreamReader file)
        {
            JsonParser Parser = new JsonParser();
            return Parser.ParseJsonLVTFromStream(file);
        }

        internal static void CreateLVTHtml(LeanValueTree tree)
        {
            VisionPresenter VP = new VisionPresenter();

            Directory.CreateDirectory("C:\\temp");
            string OrgaChart = VP.VisualizeToString(tree.Vision);
            SaveToDisk(OrgaChart);
        }

        internal static void SaveToDisk(string chartdata)
        {
            string content = Properties.Resources.TemplateHTMLPageTop + chartdata + Properties.Resources.TemplateHTMLPageBottom;
            File.WriteAllText(@"C:\temp\LVT.html", content);
            Console.WriteLine(@"Your LeanValueTree has been saved to C:\temp\LVT.html");
        }
    }
}
