using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IHPBars
    {
        HPLabel PlayerHP { get; }
        HPLabel EnemyHP { get; }
        public void NewBars();
        public void UpdateBars(Creature player, Creature enemy);
        public void UpdateBars();
    }
}
