using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultPreciseAttack : AbstractActionButton
    {
        public DefaultPreciseAttack()
        {
            Button.Location = new Point(135, 410);
        }
        public override Action<Creature, Creature> Action => (player, enemy) => player.PreciseAttack(enemy);
        public override Color ColorWhenPressed => Color.LightBlue;
        public override string ButtonText => "Precise Attack";
        public override string FailMessage => "Need Rest";
        public override bool IsAbleToPerformAction() => Game.CurrentGame.CurrentFight.Player.CanDoPreciseAttack();
    }
}
