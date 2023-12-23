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
        public override int HPMax => 90;
        private IWeapon weapon;
        public override IWeapon Weapon => weapon;
        public override int MaxFatigue => 60;
        public override Stats Stats => Stats.PlayerDefault;
        private IGearSet gearSet;
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
            this.weapon = new Longsword();
            Gold = 70;

            if (name.Length > 30 || name.Contains(' '))
                throw new IncorrectPlayerNameException();
            this.name = name;
        }
        public new void ReceiveHit(int damage)
        {
            var dmgReduction = (int)(GearSet.CollectiveDefenseBoost * 0.25);
            damage -= Game.Rng.Next(0,dmgReduction);
            damage = damage < 0 ? 0 : damage;
            HP -= damage;
        }

        public void TavernHeal()
        {
            HP = HPMax;
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
