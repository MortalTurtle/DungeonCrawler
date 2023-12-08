using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public static class FirstStageRNGGenerator
    {
        public static List<Creature> Generate()
        {
            return new List<Creature>() {new Goblin(), new GiantRat(), new Skeleton() };
        }
    }
}
