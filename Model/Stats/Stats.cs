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
        private static readonly Stats playerDefault = new() { Strength = 1, Endurance = 1, Perception = 1 };
        public static Stats PlayerDefault => playerDefault;
    }
}
