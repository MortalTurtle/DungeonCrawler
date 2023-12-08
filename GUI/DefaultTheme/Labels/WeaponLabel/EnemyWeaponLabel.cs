using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class EnemyWeaponLabel : AbstractStatLabel, IEnemyStatLabel
    {
        public override Label GetLabel() => new Label() 
        { 
            Location = new(500, 130), Size = new Size(150, 50),
            ForeColor = Color.Brown
        };

        public override void Update()
        {
            Label.Text = string.Format("{0} \nAvg dmg: {1}",
                creature.Weapon.Name,
                Math.Round((double)creature.Weapon.CeilingDmgRange + creature.Weapon.FloorDmgRange) / 2, 2
                );
        }
    }
}
