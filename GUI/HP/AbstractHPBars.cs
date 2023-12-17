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
        private Player player { get; set; }
        public HPLabel EnemyHP { get; private set; }
        private ICreature enemy { get; set; }
        public AbstractHPBars()
        {
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
            if (player == null || enemy == null)
                throw new Exception("HP bars are not connected to any entity");
            PlayerHP.Update(player);
            EnemyHP.Update(enemy);
        }

        public void UpdateBars(Player player, ICreature enemy)
        {
            this.player = player;
            this.enemy = enemy;
            UpdateBars();
        }
    }
}
