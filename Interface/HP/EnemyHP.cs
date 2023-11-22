using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class EnemyHP : HPLabel
    {
        public override Point Location => new Point(600, 100);
        public EnemyHP() 
        {
            Label.ForeColor = Color.Chocolate;
        }
    }
}
