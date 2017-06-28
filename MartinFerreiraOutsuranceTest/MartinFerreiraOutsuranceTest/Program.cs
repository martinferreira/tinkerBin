using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinFerreiraOutsuranceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = string.Empty;
            
            if (args.Length == 0)
            {
                fileName = "data.csv";
            }
            var parser = Parser.ParseFromFile(fileName);

            parser.GenerateOutput("output1.txt", "output2.txt");

        }
    }
}
