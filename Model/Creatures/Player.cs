using DungeonCrawler.Model.Creatures.Gear.Talismans;
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
        private IGearSet gearSet = new PlayersStartGearSet();
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
            this.weapon = new Longsword();
            Gold = 70;
            if (name.Length > 30 || name.Contains(' '))
                throw new IncorrectPlayerNameException();
            this.name = name;
        }

        public void TavernHeal()
        {
            HP = HPMax;
            this.gold -= 35;
            Interface.UpdateScreen();
        }
        public void TavernRest()
        {
            Fatigue = 0;
            this.gold -= 15;
            Interface.UpdateScreen();
        }
    }
}
