using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IGearSet
    {
        Stats CollectiveStatBoost { get; }
        int CollectiveDefenseBoost { get; }
        ITalisman Talisman { get; set; }
    }
}
