using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IStatLabel
    {
        Label Label { get; }
        void Update(Creature creature);
        void Update();
    }
}
