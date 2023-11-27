using DungeonCrawler.Controls.AttackButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [DarkTheme]
    internal class DarkAttackButton : DefaultAttackButton
    {
        public override Color DefaultBackColor => Color.Black;
        public override Color ColorWhenPressed => Color.DimGray;
        public DarkAttackButton(Form form) : base(form)
        {
            this.Button.ForeColor = Color.White;
        }
    }
}
