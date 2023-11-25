using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class EnemyFatigueStat : AbstractStatLabel, IEnemyStatLabel
    {
        public override Point Location => new Point(600, 130);

        public override Size Size => DefaultParameters.DefaultHpSize;

        public EnemyFatigueStat() 
        {
            base.Label.ForeColor = Color.BlueViolet;
        }

        public override void Update()
        {
            this.Label.Text = base.creature.Fatigue + " \\\n" + base.creature.MaxFatigue;
        }
    }
}
