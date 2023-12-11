using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class TavernLabel : ITavernDependentControl
    {
        private Label label;
        internal Player player;
        public Control Control => label;
        public TavernLabel()
        {
            label = GetLabel();
        }
        public abstract void Update();
        public abstract Label GetLabel();
        public void Update(Player player)
        {
            this.player = player;
            Update();
        }
    }
}
