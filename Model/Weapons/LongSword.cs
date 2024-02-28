using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Longsword : IWeapon
    {
        public int FloorDmgRange => 8;
        public int CeilingDmgRange => 10;
        public double Precision => 70;
        public int AttackCost => 7;
        public int StrongCost => (int)(AttackCost * 1.65);
        public int PreciseCost => (int)(AttackCost * 1.3);
        public string Name => "Longsword";
        public Stats StatBoost => new() {Strength = 1 };
        public string PicturePath => Program.ImagePath + "\\longSword.png";
    }
}
