using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class AbstractHPBars<TPlayerHp,TEnemyHP> : IHPBars
        where TPlayerHp : HPLabel, new()
        where TEnemyHP : HPLabel, new()
    {
        public HPLabel PlayerHP { get; private set; }
        private readonly Player player;
        public HPLabel EnemyHP { get; private set; }
        private readonly Creature enemy;
        public AbstractHPBars(Player player, Creature enemy)
        {
            this.player = player;
            this.enemy = enemy;
            PlayerHP = new TPlayerHp();
            EnemyHP = new TEnemyHP();
        }

        public void NewBars()
        {
            PlayerHP = new TPlayerHp();
            EnemyHP = new TEnemyHP();
        }

        public void UpdateBars()
        {
            PlayerHP.Update(player);
            EnemyHP.Update(enemy);
        }
    }
}
