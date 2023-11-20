using DungeonCrawler.Controls;
using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.Controls.HP;
using DungeonCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public static class Interface
    {
        private static Form form;

        private static Button mainButton;
        private static Label mainLabel;
        private static TextBox mainTextBox;

        private static IHPBars hpBars;
        private static IEndTurnButton endTurnButton;
        private static IAttackButtons attackButtons;

        private static void UpdateStartButton()
        {
            mainButton = new Button
            {
                Location = new Point(60, form.ClientSize.Height / 2 + 100),
                Size = new Size(form.ClientSize.Width - 120, 60),
                Text = "Confirm",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
            mainButton.Click += (sender, args) =>
            {
                form.Controls.Clear();
                Game.StartGame(mainTextBox.Text);
                mainLabel.Text = mainTextBox.Text;
                form.Controls.Add(mainLabel);
            };
        }

        public static void InitializeInterface(Form form)
        {
            Interface.form = form;
            mainButton = ControlsFactory.GetMainButton(form);
            mainTextBox = ControlsFactory.GetMainTextBox(form);
            mainLabel = ControlsFactory.GetMainLabel(form);
            form.Controls.Add(mainButton);
            form.Controls.Add(mainTextBox);
            form.Controls.Add(mainLabel);

            mainButton.Click += (sender, args) =>
            {
                form.Controls.Remove(mainButton);
                UpdateStartButton();
                form.Controls.Add(mainButton);
                mainLabel.Text = "ENTER YOUR NAME";
                mainTextBox.Size = new Size(form.ClientSize.Width - 120, 130);
                mainTextBox.Text = "your_name_here";
            };
        }

        public static void UpdateInterfaceOnFightStart(Player player, Creature enemy)
        {
            form.Controls.Clear();
            form.Controls.Add(mainLabel);
            AddHPBars(player, enemy);
            AddEOTButton();
            AddAttackButtons();
        }

        private static void AddAttackButtons()
        {
            attackButtons = new AllAttackButtons(form);
            foreach (var button in attackButtons.attackButtons)
                form.Controls.Add(button.Button);
        }

        private static void AddEOTButton()
        {
            endTurnButton = new DefaultEndTurnButton(form);
            form.Controls.Add(endTurnButton.Button);
        }

        private static void AddHPBars(Player player, Creature enemy)
        {
            hpBars = new HPBars<PlayerHp, EnemyHP>(player, enemy);
            hpBars.UpdateBars();
            form.Controls.Add(hpBars.playerHp.Label);
            form.Controls.Add(hpBars.enemyHp.Label);
        }

        public static void UpdateInterfaceOnEOT()
        {
            hpBars.UpdateBars();
        }
    }
}
