using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model.Creatures.LootTable
{
    public class EmptyLootTable : ILootTable
    {
        public int Gold => throw new NotImplementedException();
    }
}
