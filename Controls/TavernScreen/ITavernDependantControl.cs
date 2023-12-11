using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ITavernDependentControl
    {
        Control Control { get; }
        void Update();
        void Update(Player player);
    }
}
