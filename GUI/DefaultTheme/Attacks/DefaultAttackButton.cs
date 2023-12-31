﻿using DungeonCrawler.Controls.FightActions;
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
        public DefaultAttackButton()
        { }
        public override Action<Player, ICreature> Action => (player, target) => player.Attack(target);
        public override string ButtonText => "Regular Attack";
        public override string FailMessage => "Too tired, need rest";
        public override int ActionCost => Game.CurrentGame.Player.Weapon.AttackCost;
    }
}
