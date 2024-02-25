using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class TavernFatigueLabel : TavernLabel
    {
        public override Label GetLabel()
        {
            return new Label()
            {
                Size = new(30, 60),
                Location = new(340, 250),
                ForeColor = Color.DarkBlue
            };
        }

        public override void Update()
        {
            Control.Text = player.Fatigue + "/ \n" + player.Stats.MaxFatigue;
        }
    }
}
