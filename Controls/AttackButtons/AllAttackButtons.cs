using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.AttackButtons
{
    public class AllAttackButtons : IAttackButtons
    {
        public List<IAttackButton> attackButtons { get; private set; }

        public AllAttackButtons(Form form)
        {
            attackButtons = new();
            attackButtons.Add(new DefaultAttackButton(form));
        }
    }
}
