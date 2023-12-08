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
        public override Label GetLabel()
        {
            return new Label()
            {
                Location = new Point(500, 100),
                Size = new Size(100, 30),
                ForeColor = Color.Green
            };
        }

        public override void Update()
        {
            this.Label.Text = creature.Name;
        }
    }
}
