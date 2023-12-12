using DungeonCrawler.Controls;
using DungeonCrawler.Controls.BattleLoggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Creature
    {
        public abstract string Name { get; }
        public abstract IWeapon Weapon { get; }
        public abstract Stats Stats { get; }
        private int hp;
        private int fatigue;
        public int Fatigue
        {
            get { return fatigue; }
            internal set 
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
            internal set
            {
                if (value < 0) hp = 0;
                else hp = value;
            }
        }

        public abstract int HPMax { get; }
        public abstract int MaxFatigue { get; }
        public void Attack(Creature other)
        {
            var log = new AttackLogger() { Executant = this, Target = other, AttackType = "default attack" };
            Fatigue += Weapon.AttackCost;
            this.Weapon.Attack(other,Stats,1,1, log as AttackLogger);
            LogActionToFight(log);
        }
        public void StrongAttack(Creature other)
        {
            var log = new AttackLogger() { Executant = this, Target = other, AttackType = "strong attack" };
            Fatigue += Weapon.StrongCost;
            this.Weapon.Attack(other, Stats, 0.7, 2,log);
            LogActionToFight(log);
        }
        public void PreciseAttack(Creature other)
        {
            var log = new AttackLogger() { Executant = this, Target = other, AttackType = "precise attack" };
            Fatigue += Weapon.PreciseCost;
            this.Weapon.Attack(other, Stats, 2, 1.2, log);
            LogActionToFight(log);
        }

        private void LogActionToFight(IBattleActionLogger log)
        {
            if (this is Player)
                Game.CurrentGame.CurrentFight.PlayerActionLog = log;
            else Game.CurrentGame.CurrentFight.EnemyActionLog = log;
        }

        public Creature()
        {
            hp = HPMax;
        }

        public void Rest()
        {
            var log = new RestActionLogger() { Executant = this };
            LogActionToFight(log);
            Fatigue -= (4 + Stats.Endurance);
        }

        public void UpdateOnEOT()
        { }

        public void ReceiveHit(int damage)
        {
            this.HP -= damage;
        }
    }
}
