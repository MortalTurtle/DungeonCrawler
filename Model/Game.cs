using DungeonCrawler.GUI.Screens;
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
            Interface.LoadScreen<IBattleWonScreen>();
        }

        public static void StartBattle()
        {
            CurrentGame.StartBattle();
        }

        public static void EndFight(bool hasPlayerWon)
        {
            if (hasPlayerWon)
            {
                var player = CurrentGame.Player;
                var enemy = CurrentGame.CurrentFight.Enemy;
                player.Gold += enemy.LootTable.Gold;
                player.GearSet.Inventory.AddRange(enemy.LootTable.Artefacts);
                var screen = Interface.GetScreen<IBattleWonScreen>();
                screen.UpdateLootGained(enemy.LootTable);
                Interface.LoadScreen<IBattleWonScreen>();
            }
            else Interface.LoadScreen<IBattleLostScreen>();
        }
    }
}
