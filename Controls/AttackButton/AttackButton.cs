using Accessibility;
using DungeonCrawler.Controls;
using DungeonCrawler.Controls.FightActions;
using DungeonCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class AttackButton : IAttackButton
    {
        public Button Button {get; private set;}
        public abstract AttackFightAction FightAction { get;}
        public AttackButton(Form form)
        {
            this.Button = ControlsFactory.GetAttackButton(form);
            Button.Click += (sender, args) =>
            {
                Button.BackColor = Color.DimGray;
                var lastButton = Game.CurrentGame.CurrentFight.AttackButton;
                if (lastButton != null)
                    lastButton.Button.BackColor = Color.White;
                Game.CurrentGame.CurrentFight.AttackButton = this;
            };
        }
    }
}
