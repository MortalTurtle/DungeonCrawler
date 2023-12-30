using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class InventoryButton : ITavernControl
    {
        private readonly Button button;
        public Control Control => button;
        public InventoryButton()
        {
            button = GetButton();
            button.Click += (sender, args) =>
            {
                Interface.LoadScreen<IGearScreen>();
                Interface.UpdateScreen();
            };
        }

        public virtual Button GetButton() => new Button() 
        {
            Size = new(150,30),
            Text = "Inventory",
            Location = new(100, 130),
            BackColor = Color.Black,
            ForeColor = Color.White
        };
    }
}
