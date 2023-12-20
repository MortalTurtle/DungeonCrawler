using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class EmptyArtefact : IArtefact
    {
        public readonly static IArtefact Instance = new EmptyArtefact();
        public Stats StatBoost => new Stats();
        public int Defense => 0;
    }
}
