using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinFerreiraOutsuranceTest
{
    public class Parser
    {
        private List<LineItem> contents;

        public static Parser ParseFromFile(string fileName)
        {
            return new Parser(File.ReadAllLines(fileName).Skip(1).ToArray());
        }

        public Parser(string[] fileContents)
        {
            contents = fileContents
                .Select( m => new LineItem(m))
                .ToList();
        }

        internal void GenerateOutput(string fileName1, string fileName2)
        {
            File.WriteAllLines(fileName1, GetFrequency().Select(m => m.ToString()));
            File.WriteAllLines(fileName2, GetStreetNames().Select(m => m.ToString()));
        }

        public List<StatsItem> GetFrequency()
        {
            var listOfNames = contents.Select(m => m.FirstName)
                .Concat(contents.Select(m => m.LastName));
            return listOfNames.Distinct()
                .Select( m=> new StatsItem(m, listOfNames.Count(p => p == m) ))
                .OrderByDescending(m => m.Count)
                .ThenBy(m => m.Item)
                .ToList();
        }

        public List<string> GetStreetNames()
        {
            return contents.OrderBy(m => m.SortedAddress).Select(m => m.Address).ToList();
        }

    }
}
