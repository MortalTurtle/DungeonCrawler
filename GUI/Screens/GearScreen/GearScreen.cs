using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class GearScreen : IGearScreen
    {
        public List<Control> Controls { get; private set; }
        public GearScreen() 
        {
            Controls = new();
        }
        public void Update()
        {

        }
    }
}
