using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class SkeletonLootTable : LootTable
    {
        public override int GoldFloor => 40;
        public override int GoldCeil => 60;
        public override List<IArtefact> Artefacts => new();
    }
}
