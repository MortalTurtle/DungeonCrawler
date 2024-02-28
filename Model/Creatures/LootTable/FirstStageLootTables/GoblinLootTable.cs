using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class GoblinLootTable : LootTable
    {
        public override int GoldFloor => 50;
        public override int GoldCeil => 80;
        public override List<IArtefact> Artefacts => new() { new OldFlail() };
    }
}
