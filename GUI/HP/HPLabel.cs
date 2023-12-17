using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class HPLabel : IStatLabel
    {
        public abstract Point Location { get; }
        private ICreature creature { get; set; }
        public HPLabel()
        {
            Label = new Label()
            {
                Size = DefaultParameters.DefaultHpSize,
                Location = this.Location,
                ForeColor = Color.DarkRed,
                Text = "",
            };
            Label.Font = new Font(Label.Font, FontStyle.Bold);
        }
        public Label Label { get; private set; }
        public void Update(ICreature creature)
        {
            this.creature = creature;
            Update();
        }
        public void Update()
        {
            Label.Text = creature.HP + " \\" + '\n' + creature.HPMax;
        }
    }
}
