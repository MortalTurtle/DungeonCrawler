using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class TavernGoldLabel : TavernLabel
    {
        public override Label GetLabel()
        {
            return new Label() {Size = new(150,30),
                Location = new(100,100),
            ForeColor = Color.Gold,
            BackColor = Color.DimGray,
            BorderStyle = BorderStyle.FixedSingle};
        }

        public override void Update()
        {
            this.Control.Text = "Gold left: " + player.Gold;
        }
    }
}
