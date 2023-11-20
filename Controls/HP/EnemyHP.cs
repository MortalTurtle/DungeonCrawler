using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.HP
{
    internal class EnemyHP : HpLabel
    {
        public EnemyHP() : base(new Point(600,100))
        {
            base.Label.ForeColor = Color.SandyBrown;
        }
    }
}
