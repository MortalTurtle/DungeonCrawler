using DungeonCrawler.Controls.BattleLoggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IWeapon : IArtefact
    {
        string Name { get; }
        int FloorDmgRange { get; }
        int CeilingDmgRange { get; }
        double Precision { get; }
        int AttackCost { get; }
        int StrongCost { get; }
        int PreciseCost { get; }
        void Attack(ICreature other, Stats stats, double perceptionK, double strengthK, AttackLogger log)
        {
            var roll = Game.Rng.NextDouble() * 100;
            log.ChanceRoll = (int)roll;
            roll *= ((double)1 + stats.Perception * perceptionK / 10);
            log.ChanceRollMinToSuccess = (int)(100 - Precision);
            var dmgRoll = Game.Rng.Next(FloorDmgRange, CeilingDmgRange) + (int)(stats.Strength * strengthK);
            if (roll >= 100 - Precision)
            {
                log.IsSuccessful = true;
                log.DmgRoll = dmgRoll;
                other.ReceiveHit(dmgRoll);
            }
        }
    }
}
