using DungeonCrawler.Model.Creatures.LootTable;
using DungeonCrawler.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Player : Creature<EmptyLootTable>
    {
        private readonly string name;
        public override string Name => name;
        public override IWeapon Weapon 
        {
            get => GearSet.Weapon;
            set 
            {
                GearSet.Weapon = value;
            }
        }
        public override Stats Stats => Stats.PlayerDefault;
        private readonly IGearSet gearSet;
        public IGearSet GearSet => gearSet;
        private int gold;
        public int Gold 
        {
            get => gold;
            set 
            {
                if (value < 0) 
                    throw new Exception("Gold went below zero");
                gold = value;
            }
        }
        public Player(string name)
        {
            gearSet = new PlayersStartGearSet(Stats);
            this.Weapon = new Longsword();
            Gold = 50;
            if (name.Length > 30 || name.Contains(' '))
                throw new IncorrectPlayerNameException();
            this.name = name;
        }
        public new void ReceiveHit(int damage)
        {
            var dmgReduction = (int)((double)Stats.Defense * 0.25);
            damage -= Game.Rng.Next(0,dmgReduction);
            damage = damage < 0 ? 0 : damage;
            HP -= damage;
        }

        public void TavernHeal()
        {
            HP = Stats.MaxHealth;
            this.gold -= 45;
            Interface.UpdateScreen();
        }
        public void TavernRest()
        {
            Fatigue = 0;
            this.gold -= 25;
            Interface.UpdateScreen();
        }
    }
}
