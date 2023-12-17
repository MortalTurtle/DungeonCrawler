using DungeonCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Dungeon
    {
        public Player Player { get; private set; }
        public Battle CurrentFight { get;private set; }
        private readonly List<ICreature> enemies = new List<ICreature>();
        private int currentEnemyPointer = 0;
        public Dungeon(string playerName) 
        {
            this.Player = new Player(playerName);
            Interface.GenerateTavernAndFightScreen(Player);
            enemies.AddRange(FirstStageRNGGenerator.Generate());
        }
        public void StartBattle()
        {
            CurrentFight = new Battle(Player,enemies[currentEnemyPointer++]);
        }
        public void EndTurn() => CurrentFight.EndTurn();
    }
}
