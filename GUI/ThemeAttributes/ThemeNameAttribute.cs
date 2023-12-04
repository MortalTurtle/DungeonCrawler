using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class ThemeNameAttribute : Attribute
    {
        public string Name { get; set; }
        public ThemeNameAttribute(string name)
        {
            Name = name;
        }

        public override string ToString() 
        {
            return Name;
        }
    }
}
