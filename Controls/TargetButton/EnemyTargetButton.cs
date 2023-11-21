using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.TargetButton
{
    public class EnemyTargetButton : TargetButton
    {
        public override ActionTarget Target => ActionTarget.Enemy;

        public EnemyTargetButton(Form form) : base(form) 
        {
            this.Button.Location = new Point(form.Width / 2, 400);
            this.Button.Text = "Enemy";
        }
    }
}
