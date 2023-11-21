using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.AttackButtons
{
    public class DefaultAttackButton : ActionButton
    {
        public override Action<Creature, Creature> Action => (player, target) => player.Attack(target);
        public DefaultAttackButton(Form form) : base(form) { }
    }
}
