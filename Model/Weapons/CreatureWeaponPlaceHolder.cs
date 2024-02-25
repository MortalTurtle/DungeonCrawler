using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CreatureWeaponPlaceHolder : IWeapon
    {
        public string Name { get; private set; }
        public int FloorDmgRange { get; private set; }
        public int CeilingDmgRange { get; private set; }
        public double Precision { get; private set; }
        public int AttackCost { get; private set; }
        public int StrongCost { get; private set; }
        public int PreciseCost { get; private set; }
        public Stats StatBoost => new();
        public string PicturePath => throw new NotImplementedException();

        public CreatureWeaponPlaceHolder(string name,
            int floorDmg,
            int ceilDmg,
            double precisionPercent, 
            int atkCost,
            int strongAtkCost,
            int preciseAtkCost)
        {
            Name = name;
            FloorDmgRange = floorDmg;
            CeilingDmgRange = ceilDmg;
            Precision = precisionPercent;
            AttackCost = atkCost;
            StrongCost = strongAtkCost;
            PreciseCost = preciseAtkCost;
        }
    }
}
