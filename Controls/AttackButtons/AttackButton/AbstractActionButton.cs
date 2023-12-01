using Accessibility;
using DungeonCrawler.Controls;
using DungeonCrawler.Controls.FightActions;
using DungeonCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public abstract class AbstractActionButton : IActionButton, IControlButton
    {
        public Button Button {get; private set;}
        public abstract Action<Creature, Creature> Action { get; }
        public virtual Color ColorWhenPressed => Color.DimGray;
        public virtual Color DefaultBackColor => Color.White;
        public abstract string ButtonText { get; }
        public abstract string FailMessage { get; }
        public AbstractActionButton()
        {
            this.Button = GetAttackButton();
            Button.Text = ButtonText;
            Button.BackColor = DefaultBackColor;
            Button.Click += (sender, args) =>
            {
                Game.CurrentGame.CurrentFight.ChangeActionButton(
                    this,ColorWhenPressed,
                    DefaultBackColor
                    );
            };
        }

        public virtual Button GetAttackButton()
        {
            return ReadyControls.GetAttackButton();
        }

        public abstract bool IsAbleToPerformAction();
    }
}
