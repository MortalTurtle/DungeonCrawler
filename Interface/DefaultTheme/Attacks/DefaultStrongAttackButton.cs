using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultStrongAttackButton : AbstractActionButton
    {
        public DefaultStrongAttackButton(Form form) : base(form)
        {
            Button.Location = new Point(30, 410);
        }
        public override Action<Creature, Creature> Action => (player, target) => player.StrongAttack(target);
        public override string ButtonText => "Strong Attack";
        public override string FailMessage => "Cant do strong attack, need rest"; 
        public override bool IsAbleToPerformAction() => Game.CurrentGame.CurrentFight.Player.CanDoStrongAttack();
    }
}
