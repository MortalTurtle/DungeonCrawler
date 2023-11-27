﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model.Weapons
{
    public interface IWeapon
    {
        int FloorDmgRange { get; }
        int CeilingDmgRange { get; }
        double Precision { get; }
        int AttackCost { get; }
        void Attack(Creature other, Stats stats, double perceptionK, double strengthK)
        {
            var randomChance = Game.Rng.NextDouble() * 100;
            randomChance *= ((double)1 + stats.Perception * perceptionK / 10);
            if (randomChance >= 100 - Precision)
            {
                var dmg = Game.Rng.Next(FloorDmgRange, CeilingDmgRange) + (int)(stats.Strength * strengthK);
                other.ReceiveHit(dmg);
            }
        }
    }
}
