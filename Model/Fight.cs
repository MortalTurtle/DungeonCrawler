using DungeonCrawler.Controls;
using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model
{
    public class Fight
    {
        private Player player { get; set; }
        private Creature enemy { get; set; }
        public bool HasEnded { get; private set; }
        public Fight(Player player , Creature enemy)
        {
            this.player = player;
            this.enemy = enemy;
            FightActionsDict.GenerateActions(player);
            Interface.UpdateInterfaceOnFightStart(player, enemy);
            HasEnded = false;
        }

        public IAttackButton AttackButton { get; set; }
        public void EndTurn()
        {
            PerformAction(AttackButton.FightAction, ActionTarget.Enemy);
            enemy.Attack(player);
            Interface.UpdateInterfaceOnEOT();
        }

        public void PerformAction(ActionType action, ActionTarget target)
        {
            if (action == ActionType.None || target == ActionTarget.None)
                return;
            Creature targetCreature = target == ActionTarget.Self ? player : enemy;
            FightActionsDict.Perform(action, targetCreature);
        }
    }
}
