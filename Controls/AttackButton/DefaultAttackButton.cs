using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.AttackButtons
{
    public class DefaultAttackButton : AttackButton
    {
        public override ActionType FightAction => ActionType.DefaultAttack;
        public DefaultAttackButton(Form form) : base(form) { }
    }
}
