using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class EndTurnButton : IEndTurnButton, IBattleControlButton
    {
        public Button Button { get; private set; }
        public EndTurnButton()
        {
            this.Button = GetEndTurnButton();
            this.Button.Click += (sender, args) =>
            {
                Game.CurrentGame.EndTurn();
            };
        }

        public virtual Button GetEndTurnButton()
        {
            return ReadyControls.GetEndTurnButton();
        }
    }
}
