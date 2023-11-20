using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.HP
{
    public class HPBars<TPlayerHp, TEnemyHP> : IHPBars
        where TPlayerHp : HpLabel, new()
        where TEnemyHP : HpLabel, new()
    {
        public HpLabel playerHp { get; private set; }
        private Player player { get; set; }
        public HpLabel enemyHp { get; private set; }
        private Creature enemy { get; set; }
        public HPBars(Player player, Creature enemy)
        {
            this.player = player;
            this.enemy = enemy;
            playerHp = new TPlayerHp();
            enemyHp = new TEnemyHP();
        }

        public void NewBars()
        {
            playerHp = new TPlayerHp();
            enemyHp = new TEnemyHP();
        }

        public void UpdateBars()
        {
            playerHp.Update(player);
            enemyHp.Update(enemy);
        }
    }
}
