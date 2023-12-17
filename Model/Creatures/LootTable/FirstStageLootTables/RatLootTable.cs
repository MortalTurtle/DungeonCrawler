using DungeonCrawler.Model.Creatures.LootTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class RatLootTable : LootTable
    {
        public override int GoldFloor => 30;
        public override int GoldCeil => 40;
    }
}
