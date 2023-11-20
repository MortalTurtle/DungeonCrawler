using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Goblin : Creature
    {
        public override string Name => "Goblin";

        public override int HPMax => 50;

        public override int Damage => 6;
    }
}
