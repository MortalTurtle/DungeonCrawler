using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace DungeonCrawler
{
    [Default]
    public class DefaultEnemyNameLabel : AbstractStatLabel, IEnemyStatLabel
    {
        public override Point Location => new Point(500, 100);
        public override Size Size => new Size(100,30);
        public override void Update()
        {
            this.Label.ForeColor = Color.Green;
            this.Label.Text = creature.Name;
        }
    }
}
