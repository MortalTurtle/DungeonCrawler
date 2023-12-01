using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.TargetButton
{
    [Default]
    public class DefaultEnemyTargetButton : TargetButton
    {
        public override ActionTarget Target => ActionTarget.Enemy;

        public DefaultEnemyTargetButton() 
        {
            this.Button.Location = new Point(350, 400);
            this.Button.Text = "Enemy";
        }
    }
}
