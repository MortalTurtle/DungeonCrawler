using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Stats
    {
        public int Strength { get; set; }
        public int Endurance { get; set; }
        public int Perception { get; set; }
        public int Initiative { get; set; }
        public static Stats PlayerDefault => new()
        {
            Strength = 1,
            Endurance = 1,
            Perception = 1,
            Initiative = 3
        };
    }
}
