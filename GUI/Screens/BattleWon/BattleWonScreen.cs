using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class BattleWonScreen : IBattleWonScreen
    {
        public List<Control> Controls { get; private set; }
        private int lootControlsCount { get; set; }
        public BattleWonScreen()
        {
            Controls = new();
            var button = GetNextBattleButton();
            button.Click += (sender, args) =>
            {
                Game.StartBattle();
                Interface.GetScreen<IBattleWonScreen>().ClearLootTable();
            };
            Controls.Add(button);
            button = GetTavernButton();
            button.Click += (sender, args) =>
            {
                Interface.LoadScreen<ITavernScreen>();
                Interface.UpdateScreen();
                Interface.GetScreen<IBattleWonScreen>().ClearLootTable();
            };
            Controls.Add(button);
        }

        public virtual void UpdateLootGained(ILootTable loot)
        {
            var goldLabel = new Label()
            {
                Size = new(200, 30),
                Location = new(60, 290),
                Text = "Gold gained: " + loot.Gold,
                Font = new Font(FontFamily.GenericMonospace,15)
            };
            Controls.Add(goldLabel);
            lootControlsCount = 1;
        }

        public void Update()
        { }

        public virtual Button GetTavernButton()
        { 
            var button = ReadyControls.GetMainButton();
            button.Location = new Point(60, 150);
            button.Text = "Go to tavern";
            return button;
        }
        public virtual Button GetNextBattleButton()
        {
            var button = ReadyControls.GetMainButton();
            button.Location = new Point(60, 220);
            button.Text = "Continue expedition";
            return button;
        }

        public void ClearLootTable()
        {
            Controls = Controls.Take(Controls.Count - lootControlsCount).ToList();
            lootControlsCount = 0;
        }
    }
}
