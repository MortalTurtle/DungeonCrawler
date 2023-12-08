using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultEnemyFatigueStat : AbstractStatLabel, IEnemyStatLabel
    {
        public DefaultEnemyFatigueStat() 
        {
            base.Label.ForeColor = Color.BlueViolet;
        }

        public override void Update()
        {
            this.Label.Text = base.creature.Fatigue + " \\\n" + base.creature.MaxFatigue;
        }
        public override Label GetLabel() => new Label() 
        {
            Location = new Point(600, 130),
            Size = DefaultParameters.DefaultHpSize,
            ForeColor = Color.BlueViolet 
        };
    }
}
