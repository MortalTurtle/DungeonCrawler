using DungeonCrawler.Controls.AttackButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultTheme : AbstractTheme
    {
        public override void EditMainButtons()
        { }

        public override IButtonLayout GenerateControlButtonsLayout(Form form)
        {
            return new DefaultButtonLayout(form);
        }
    }
}
