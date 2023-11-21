using DungeonCrawler.Controls;
using DungeonCrawler.Controls.FightActions;
using DungeonCrawler.Controls.TargetButton;
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
        public Fight(Player player, Creature enemy)
        {
            this.player = player;
            this.enemy = enemy;
            TargetButton = DefaultTargetButton.Instance;
            Interface.UpdateInterfaceOnFightStart(player, enemy);
            HasEnded = false;
        }
        public ITargetButton TargetButton { get; set; }
        public IActionButton ActionButton { get; set; }
        public void EndTurn()
        {
            enemy.Attack(player);
            PerformAction(TargetButton.Target);
            Interface.UpdateInterfaceOnEOT();
        }

        public void PerformAction( ActionTarget target)
        {
            if (target == ActionTarget.None || ActionButton == null)
                return;
            Creature targetCreature = target == ActionTarget.Self ? player : enemy;
            ActionButton.Action.Invoke(player, targetCreature);
        }
    }
}
