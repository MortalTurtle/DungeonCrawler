using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultFightScreen : FightScreen
    {
        private Label actionCostLabel = new Label() 
        {
            Location = new Point(100, 380),
            Size = new Size(100,19),
            ForeColor = Color.GreenYellow,
            BackColor = Color.DimGray,
            BorderStyle = BorderStyle.Fixed3D,
        };
        internal override Label ChosenActionCost => actionCostLabel;
    }
}
