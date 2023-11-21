﻿using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.TargetButton
{
    public abstract class TargetButton : IControlButton, ITargetButton
    {
        private readonly Button button;
        public Button Button => button;
        public abstract ActionTarget Target { get; }

        public TargetButton(Form form)
        {
            this.button = ControlsFactory.GetTargetButton(form);
            Button.Click += (sender, args) =>
            {
                var lastButton = Game.CurrentGame.CurrentFight.TargetButton;
                if (lastButton == this)
                {
                    Game.CurrentGame.CurrentFight.TargetButton = DefaultTargetButton.Instance;
                    Button.BackColor = Color.White;
                    return;
                }
                if (lastButton is not DefaultTargetButton)
                    lastButton.Button.BackColor = Color.White;
                Button.BackColor = Color.DimGray;
                Game.CurrentGame.CurrentFight.TargetButton = this;
            };
        }
    }
}