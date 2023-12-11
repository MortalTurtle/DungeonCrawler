using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class TavernHPLabel : TavernLabel
    {
        public override Label GetLabel()
        {
            return new Label()
            {
                Size = new(30, 60),
                Location = new(340, 200),
                ForeColor = Color.DarkRed
            };
        }

        public override void Update()
        {
            this.Control.Text = player.HP + "/ \n" + player.HPMax;
        }
    }
}
