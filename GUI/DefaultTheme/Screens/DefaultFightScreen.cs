using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private ListBox log = new ListBox() 
        {
            Location = new Point(240,100),
            Size = new Size(160,200),
            Font = new Font(FontFamily.GenericSansSerif,7)
        };
        internal override Label ChosenActionCost => actionCostLabel;

        public DefaultFightScreen()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "images\\player.png");
            var picture = new PictureBox()
            {
                ImageLocation = path,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Location = new(100, 250)
            };
            Controls.Add(picture);
        }

        internal override ListBox battleLog => log;
    }
}
