using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls
{
    public abstract class HpLabel
    {
        public HpLabel(Point location)
        {
            Label = new Label()
            {
                Size = DefaultParameters.DefaultHpSize,
                Location = location,
                ForeColor = Color.DarkRed,
                Text = "",
            };
            Label.Font = new Font(Label.Font, FontStyle.Bold);
        }
        public Label Label { get; private set; }
        public void Update(Creature creature)
        {
            Label.Text = creature.HP.ToString() + " \\" + '\n' + creature.HPMax;
        }
    }
}
