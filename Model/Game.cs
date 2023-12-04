using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{ 
    public static class Game
    {
        public static Random Rng = new();
        public static Dungeon CurrentGame { get; private set; }
        public static void StartGame(string characterName)
        {
            CurrentGame = new Dungeon(characterName);
            StartBattle();
        }

        public static void StartBattle()
        {
            CurrentGame.StartBattle();
        }

        public static void EndFight(bool hasPlayerWon)
        {
            if (hasPlayerWon)
                Interface.CallEndOfFightScreenPlayerWon();
            else Interface.CallEndOfFightScreenPlayerLost();
        }
    }
}
