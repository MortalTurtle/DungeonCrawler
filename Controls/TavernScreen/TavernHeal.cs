using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.TavernScreen
{
    public abstract class TavernHeal : ITavernControl
    {
        public Control Control => button;
        private Button button { get; set; }
        
        public TavernHeal()
        {
            button = GetHealButton();
            button.Click += (sender, args) =>
            {
                var player = Game.CurrentGame.Player;
                if (player.HP == player.Stats.MaxHealth) return;
                player.TavernHeal();
            };
            var tooltip = new ToolTip();
            tooltip.SetToolTip(button, "The cost is 45 gold");
        }
        public virtual Button GetHealButton()
        {
            return new Button()
            {
                Size = new Size(130, 40),
                Text = "Tend to your wounds",
                BackColor = Color.PaleVioletRed,
                ForeColor = Color.DarkRed,
                Location = new(200, 200)
            };
        }
    }
}
