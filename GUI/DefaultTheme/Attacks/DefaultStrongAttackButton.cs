﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class DefaultStrongAttackButton : AbstractActionButton
    {
        public DefaultStrongAttackButton()
        {
            Button.Location = new Point(30, 410);
        }
        public override Action<Player, ICreature> Action => (player, target) => player.StrongAttack(target);
        public override Color ColorWhenPressed => Color.LightCoral;
        public override string ButtonText => "Strong Attack";
        public override string FailMessage => "Cant do strong attack, need rest";

        public override int ActionCost => Game.CurrentGame.Player.Weapon.StrongCost;
    }
}
