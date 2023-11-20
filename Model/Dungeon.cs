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
        public Fight CurrentFight { get;private set; }
        public Dungeon(string playerName) 
        {
            this.player = new Player(playerName);
        }

        public void StartFight(Creature enemy)
        {
            CurrentFight = new Fight(player, enemy);
        }

        public void EndTurn() => CurrentFight.EndTurn();
    }
}
