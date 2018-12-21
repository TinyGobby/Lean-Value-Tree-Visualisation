using LVT.LVT.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LVT
{
    class CommandLineArg
    {
        public void CheckCommandLineArgument(String[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("need a file input");
            }
            else
            {
                Console.WriteLine(args[0]);
                StreamReader file = File.OpenText(args[0]);
               
            }
        }
    }
}
