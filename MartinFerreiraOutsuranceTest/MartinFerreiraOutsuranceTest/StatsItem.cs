using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinFerreiraOutsuranceTest
{
    public class StatsItem
    {

        public StatsItem(string name, int count)
        {
            this.Item = name;
            this.Count = count;
        }

        public string Item { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Item}, {Count}";
        }
    }
}
