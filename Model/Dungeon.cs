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
        private Player player { get; set; }
        public Battle CurrentFight { get;private set; }
        private readonly List<Creature> enemies = new List<Creature>();
        private int currentEnemyPointer = 0;
        public Dungeon(string playerName) 
        {
            this.player = new Player(playerName);
            enemies.Add(new Goblin());
        }
        public void StartBattle()
        {
            CurrentFight = new Battle(player,enemies[currentEnemyPointer++]);
        }
        public void EndTurn() => CurrentFight.EndTurn();
    }
}
