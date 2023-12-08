using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class OldFlail : IWeapon
    {
        public int FloorDmgRange => 6;
        public int CeilingDmgRange => 9;
        public double Precision => 60;
        public int AttackCost => 6;
        public int StrongCost => (int)(AttackCost * 1.60);
        public int PreciseCost => (int)(AttackCost * 1.35);
        public string Name => "Old Flail";
    }
}
