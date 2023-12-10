using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler 
{ 
    public abstract class TavernRest : ITavernControl
    {
        private Button button { get; set; }
        public Control Control => button;

        public TavernRest()
        {
            button = GetButton();
            button.Click += (sender, args) =>
            {
                Game.CurrentGame.Player.TavernRest();
            };
        }
        public virtual Button GetButton() 
        {
            return new Button()
            {
                Size = new Size(130, 40),
                Text = "Rest",
                BackColor = Color.PaleTurquoise,
                ForeColor = Color.DarkCyan,
                Location = new(200, 250)
            };
        }
    }
}
