using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls
{
    public interface IHPBars
    {
        HpLabel playerHp { get; }
        HpLabel enemyHp { get; }
        public void NewBars();
        public void UpdateBars();
    }
}
