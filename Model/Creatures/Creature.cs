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
        private int fatigue;
        public int Fatigue
        {
            get { return fatigue; }
            private set 
            {
                if (value > MaxFatigue)
                    fatigue = MaxFatigue;
                if (value < 0)
                    fatigue = 0;
                else fatigue = value;
            }
        }

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
        public abstract int MaxFatigue { get; }
        public void Attack(Creature other)
        {
            Fatigue += Weapon.AttackCost;
            this.Weapon.Attack(other);
        }

        public Creature()
        {
            hp = HPMax;
        }

        public void Rest()
        {
            Fatigue -= 4;
        }

        public void UpdateOnEOT()
        {
        }

        public void ReceiveHit(int damage)
        {
            this.HP -= damage;
        }
    }
}
