﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Goblin : Creature<GoblinLootTable>, IFirstStageEnemy
    {
        public override string Name => "Goblin";
        public override int HPMax => 50;
        private readonly IWeapon weapon = new OldFlail();
        public override IWeapon Weapon 
        { 
            get => weapon;
            set => throw new NotImplementedException(); 
        }
        public override int MaxFatigue => 40;
        public override Stats Stats => new() 
        {
            Strength = 1,
            Perception = 1,
            Endurance = 1,
            Initiative = 2
        };
    }
}
