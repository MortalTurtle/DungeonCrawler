using DungeonCrawler.Controls;
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
            Interface.UpdateInterfaceOnFightStart(player, enemy);
            HasEnded = false;
        }

        public IAttackButton AttackButton { get; set; }
        public void EndTurn()
        {
            enemy.Attack(player);
            Interface.UpdateInterfaceOnEOT();
        }
    }
}
