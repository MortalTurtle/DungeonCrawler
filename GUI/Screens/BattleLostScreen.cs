using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GUI.Screens
{
    public abstract class BattleLostScreen : IBattleLostScreen, IScreen
    {
        public List<Control> Controls { get; private set; }
        public BattleLostScreen()
        {
            Controls = new();
            var button = GetNewGameButton();
            button.Click += (sender, args) =>
            {
                Interface.ReinitializeInterface();
            };
            Controls.Add(button);
        }

        public virtual Button GetNewGameButton()
        {
            var button = ReadyControls.GetMainButton();
            button.Text = "Start new game";
            return button;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
