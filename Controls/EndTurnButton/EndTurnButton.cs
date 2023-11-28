using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class EndTurnButton : IEndTurnButton, IControlButton
    {
        public Button Button { get; private set; }
        public EndTurnButton(Form form)
        {
            this.Button = ReadyControls.GetEndTurnButton(form);
            this.Button.Click += (sender, args) =>
            {
                Game.CurrentGame.EndTurn();
            };
        }
    }
}
