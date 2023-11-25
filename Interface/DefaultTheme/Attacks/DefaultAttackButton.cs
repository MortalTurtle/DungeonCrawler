using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.AttackButtons
{
    [Default]
    public class DefaultAttackButton : AbstractActionButton
    {
        public override Action<Creature, Creature> Action => (player, target) => player.Attack(target);
        public override string ButtonText => "Regular Attack";
        public override string FailMessage => "Too tired, need rest";
        public DefaultAttackButton(Form form) : base(form) { }
        public override bool IsAbleToPerformAction()
        {
            var player = Game.CurrentGame.CurrentFight.Player;
            return player.Weapon.AttackCost <= player.MaxFatigue - player.Fatigue;
        }
    }
}
