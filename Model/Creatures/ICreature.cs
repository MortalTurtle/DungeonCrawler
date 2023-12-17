using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ICreature
    {
        string Name { get; }
        IWeapon Weapon { get; }
        Stats Stats { get; }
        int HPMax { get; }
        int HP { get; }
        int MaxFatigue { get; }
        int Fatigue { get; }
        ILootTable LootTable { get; }
        void Attack(ICreature other);
        void StrongAttack(ICreature other);
        void PreciseAttack(ICreature other);
        void Rest();
        void ReceiveHit(int damage);
        void UpdateOnEOT();
    }
}
