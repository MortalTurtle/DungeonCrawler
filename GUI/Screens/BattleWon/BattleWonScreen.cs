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

        public BattleWonScreen()
        {
            Controls = new();
            var button = GetNextBattleButton();
            button.Click += (sender, args) =>
            {
                Game.StartBattle();
            };
            Controls.Add(button);
        }

        public void Update() { }

        public virtual Button GetNextBattleButton()
        {
            var button = ReadyControls.GetMainButton();
            button.Text = "Continue expedition";
            return button;
        }
    }
}
