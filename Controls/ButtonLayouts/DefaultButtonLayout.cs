using DungeonCrawler.Controls.TargetButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.AttackButtons
{
    [Default]
    public class DefaultButtonLayout : AbstractButtonLayout
    {
        public List<IControlButton> Buttons { get; private set; }

        public DefaultButtonLayout(Form form) : base(form)
        { }
    }
}
