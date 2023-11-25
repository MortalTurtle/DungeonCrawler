using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultPlayerFatigueStat : AbstractStatLabel, IPLayerStatLabel
    {
        public override Point Location =>
            new Point(DefaultParameters.PlayerHpLocation.X,DefaultParameters.PlayerHpLocation.Y + 40);
        public override Size Size => DefaultParameters.DefaultHpSize;

        public DefaultPlayerFatigueStat() 
        {
            this.Label.ForeColor = Color.DarkBlue;
        }
        public override void Update()
        {
            this.Label.Text = base.creature.Fatigue + " \\\n" + base.creature.MaxFatigue; 
        }
    }
}
