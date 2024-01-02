using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model.Weapons
{
    public class OldRustySword : IWeapon
    {
        public string Name => "Old and rusty sword";

        public int FloorDmgRange => 5;

        public int CeilingDmgRange => 7;

        public double Precision => 80;

        public int AttackCost => 7;

        public int StrongCost => (int)(7 * 1.6);

        public int PreciseCost => (int)(AttackCost * 1.3);

        public Stats StatBoost => new Stats();

        public int Defense => 0;

        public string PicturePath => throw new NotImplementedException();
    }
}
