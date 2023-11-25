using System;
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
        void Attack(Creature other)
        {
            var randomChance = Game.Rng.NextDouble() * 100;
            if (randomChance >= 100 - Precision)
            {
                var dmg = Game.Rng.Next(FloorDmgRange, CeilingDmgRange);
                other.ReceiveHit(dmg);
            }
        }
    }
}
