using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model.Weapons
{
    internal class LongSword : IWeapon
    {
        public int FloorDmgRange => 6;

        public int CeilingDmgRange => 10;

        public double Precision => 75;
    }
}
