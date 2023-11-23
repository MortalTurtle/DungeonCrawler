using DungeonCrawler.Model.Exceptions;
using DungeonCrawler.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Player : Creature
    {
        private readonly string name;
        public override string Name => name;
        public override int HPMax => 100;
        public override int Damage => 10;
        private IWeapon weapon;
        public override IWeapon Weapon => weapon;
        public Player(string name)
        {
            this.weapon = new LongSword();
            if (name.Length > 30 || name.Contains(' '))
                throw new IncorrectPlayerNameException();
            this.name = name;
        }
    }
}
