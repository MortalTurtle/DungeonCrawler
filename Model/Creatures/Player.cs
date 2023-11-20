using DungeonCrawler.Model.Exceptions;
using System;
using System.Collections.Generic;
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

        public Player(string name)
        {
            if (name.Length > 30 || name.Contains(' '))
                throw new IncorrectPlayerNameException();
            this.name = name;
        }
    }
}
