using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class GiantRat : Creature<RatLootTable>, IFirstStageEnemy
    {
        public override string Name => "Giant rat";
        public override IWeapon Weapon => new CreatureWeaponPlaceHolder("Claws", 4, 7, 90, 4, 7, 6);

        private readonly Stats stats = new Stats
        {
            Endurance = 2,
            Initiative = 4,
            Perception = 5,
            Strength = 0
        };

        public override Stats Stats => stats;
        public override int HPMax => 35;
        public override int MaxFatigue => 40;
    }
}
