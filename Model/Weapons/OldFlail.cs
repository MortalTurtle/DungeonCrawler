using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model.Weapons
{
    public class OldFlail : IWeapon
    {
        public int FloorDmgRange => 7;

        public int CeilingDmgRange => 9;

        public double Precision => 40;
    }
}
