using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public static class FirstStageRNGGenerator
    {
        public static List<ICreature> Generate()
        {
            return new List<ICreature>() {new Goblin(), new GiantRat(), new Skeleton() };
        }
    }
}
