using DungeonCrawler.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Goblin : Creature
    {
        public override string Name => "Goblin";
        public override int HPMax => 50;
        private readonly IWeapon weapon = new OldFlail();
        public override IWeapon Weapon => weapon;
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
