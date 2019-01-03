using LVT.LVT.Services;
using System;
using System.IO;

namespace LVT
{
    public class ReadAndWrite
    {
        public static void CheckCommandLineArgument(String[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the location of the JSON file");
            }
            else
            {
                Console.WriteLine(args[0]);
                StreamReader file = File.OpenText(args[0]);
            }
        }

        public static LeanValueTree ParseLVTData(StreamReader file)
        {
            JsonParser Parser = new JsonParser();
            return Parser.ParseJsonLVTFromStream(file);
        }

        public static void CreateLVTHtml(LeanValueTree tree)
        {
            VisionPresenter VP = new VisionPresenter();

            Directory.CreateDirectory("C:\\temp");
            string OrgaChart = VP.VisualizeToString(tree.Vision);
            SaveToDisk(OrgaChart);
        }

        public static void SaveToDisk(string chartdata)
        {
            string content = Properties.Resources.TemplateHTMLHeader + chartdata + Properties.Resources.TemplateHTMLFooter;
            File.WriteAllText(@"C:\temp\LVT.html", content);
            Console.WriteLine(@"Your LeanValueTree has been saved to C:\temp\LVT.html");
        }
    }
}
