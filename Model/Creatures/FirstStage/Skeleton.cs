﻿using DungeonCrawler.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Skeleton : Creature<SkeletonLootTable>, IFirstStageEnemy
    {
        public override string Name => "Skeleton";

        private readonly IWeapon weapon = new OldRustySword();
        public override IWeapon Weapon {
            get => weapon;
            set => throw new NotImplementedException();
        }
        public override Stats Stats => new()
        {
            MaxHealth = 40,
            MaxFatigue = 50,
            Endurance = 3,
            Strength = 1,
            Perception = 2,
            Initiative = 4,
        };
    }
}
