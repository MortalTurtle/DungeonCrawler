using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class AbstractStatLabel : IStatLabel
    {
        public Label Label { get; private set; }
        internal Creature creature { get; set; }
        public AbstractStatLabel()
        {
            Label = GetLabel();
        }

        public abstract Label GetLabel();
        public void Update(Creature creature)
        {
            this.creature = creature;
            Update();
        }
        public abstract void Update();
    }
}
