using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class LootTable : ILootTable
    {
        public abstract int GoldFloor { get; }

        public abstract int GoldCeil { get; }

        public int Gold { get; private set; }

        public LootTable() 
        {
            Gold = Game.Rng.Next(GoldFloor,GoldCeil);
        }
    }
}
