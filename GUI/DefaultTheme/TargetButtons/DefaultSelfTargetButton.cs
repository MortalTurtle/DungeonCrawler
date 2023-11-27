using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.TargetButton
{
    [Default]
    internal class DefaultSelfTargetButton : TargetButton
    {
        public override ActionTarget Target => ActionTarget.Self;
        public DefaultSelfTargetButton(Form form) : base(form)
        {
            this.Button.Location = new Point(form.Width / 2 - 100, 400);
            this.Button.Text = "Self";
        }
    }
}
