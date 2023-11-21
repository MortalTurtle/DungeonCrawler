using DungeonCrawler.Controls.TargetButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.AttackButtons
{
    public class AllButtons
    {
        public List<IControlButton> Buttons { get; private set; }

        public AllButtons(Form form)
        {
            Buttons = new();
            Buttons.Add(new DefaultAttackButton(form));
            Buttons.Add(new DefaultEndTurnButton(form));
            Buttons.Add(new SelfTargetButton(form));
            Buttons.Add(new EnemyTargetButton(form));
        }
    }
}
