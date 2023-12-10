using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class ContinueButton : ITavernControl
    {
        public Control Control => button;
        private Button button { get; set; }
        public ContinueButton()
        {
            button = GetContinueButton();
            button.Click += (sender, args) =>
            {
                Interface.LoadScreen<IBattleWonScreen>();
            };
        }

        public virtual Button GetContinueButton()
        {
            var button = ReadyControls.GetMainButton();
            button.Text = "Return to dungeon";
            button.Location = new Point(170, 400);
            button.Size = new Size(350, 60);
            button.ForeColor = Color.Black;
            button.BackColor = Color.BurlyWood;
            return button;
        }
    }
}
