using DungeonCrawler.Controls;
using DungeonCrawler.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Creature
    {
        public abstract string Name { get; }
        public abstract IWeapon Weapon { get; }
        private int hp;
        public int HP
        {
            get { return hp; }
            private set
            {
                if (value < 0) hp = 0;
                else hp = value;
            }
        }
        public abstract int HPMax { get; }
        public abstract int Damage { get; }
        public void Attack(Creature other)
        {
            this.Weapon.Attack(other);
        }

        public Creature()
        {
            hp = HPMax;
        }

        public void ReceiveHit(int damage)
        {
            this.HP -= damage;
        }
    }
}
