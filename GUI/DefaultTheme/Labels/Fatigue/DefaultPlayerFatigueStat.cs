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
        public override void Update()
        {
            this.Label.Text = base.creature.Fatigue + " \\\n" + base.creature.MaxFatigue; 
        }

        public override Label? GetLabel() => new ControlsFactory<Label>().WithForeColor(Color.DarkBlue)
            .At(new Point(DefaultParameters.PlayerHpLocation.X, DefaultParameters.PlayerHpLocation.Y + 40))
            .WithSize(DefaultParameters.DefaultHpSize).Create() as Label;
    }
}
