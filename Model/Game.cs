using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{ 
    public static class Game
    {
        public static Random Rng = new Random();
        public static Dungeon CurrentGame { get; private set; }
        public static void StartGame(string characterName)
        {
            CurrentGame = new Dungeon(characterName);
            CurrentGame.StartFight(new Goblin());
        }
    }
}
