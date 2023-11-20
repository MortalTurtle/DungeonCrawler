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
        private static AttackFightAction defaultAction = new AttackFightAction(ActionTarget.Enemy,ActionType.DefaultAttack);
        public override AttackFightAction FightAction => defaultAction;
        public DefaultAttackButton(Form form) : base(form) { }
    }
}
