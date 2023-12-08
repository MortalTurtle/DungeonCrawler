using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class TavernScreen : ITavernScreen
    {
        public List<Control> Controls { get; private set; }
        public TavernScreen() 
        {
            Controls = new List<Control>();
        }
        public void Update()
        { }
    }
}
