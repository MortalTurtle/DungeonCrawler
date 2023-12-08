using DungeonCrawler.Model.Exceptions;
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
        public override int HPMax => 90;
        private IWeapon weapon;
        public override IWeapon Weapon => weapon;
        public override int MaxFatigue => 60;
        public override Stats Stats => Stats.PlayerDefault;
        public Player(string name)
        {
            this.weapon = new Longsword();
            if (name.Length > 30 || name.Contains(' '))
                throw new IncorrectPlayerNameException();
            this.name = name;
        }
    }
}
