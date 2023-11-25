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

namespace DungeonCrawler
{
    public abstract class AbstractActionButton : IActionButton, IControlButton
    {
        public Button Button {get; private set;}
        public abstract Action<Creature, Creature> Action { get; }
        public abstract string ButtonText { get; }
        public abstract string FailMessage { get; }
        public AbstractActionButton(Form form)
        {
            this.Button = ControlsFactory.GetAttackButton(form);
            Button.Text = ButtonText;
            Button.Click += (sender, args) =>
            {
                Game.CurrentGame.CurrentFight.ChangeActionButton(this);
                //var lastButton = Game.CurrentGame.CurrentFight.ActionButton;
                //if (lastButton == this)
                //{
                //    Game.CurrentGame.CurrentFight.ActionButton = null;
                //    Button.BackColor = Color.White;
                //    return;
                //}
                //if (lastButton != null)
                //    lastButton.Button.BackColor = Color.White;
                //Button.BackColor = Color.DimGray;
                //Game.CurrentGame.CurrentFight.ActionButton = this;
            };
        }
        public abstract bool IsAbleToPerformAction();
    }
}
