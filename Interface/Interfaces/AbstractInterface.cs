using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class AbstractInterface<TTheme> : IInterface
        where TTheme : ITheme, new()
    {
        private Form form;
        private readonly ITheme theme;
        private Button mainButton => theme.MainButton;
        private Button startButton => theme.GameStartButton;
        private Label mainLabel => theme.MainLabel;
        private TextBox mainTextBox => theme.MainTextBox;
        private List<IEnemyStatLabel> enemyStats => theme.EnemyStats;
        private List<IPLayerStatLabel> playerStats => theme.PlayerStats; 
        private List<IControlButton> controlButtons => theme.ControlButtons;

        public AbstractInterface()
        { theme = new TTheme(); }

        private void UpdateStartButton()
        {
            startButton.Click += (sender, args) =>
            {
                form.Controls.Clear();
                Game.StartGame(mainTextBox.Text);
                mainLabel.Text = mainTextBox.Text;
                form.Controls.Add(mainLabel);
            };
        }

        public void InitializeInterface(Form form)
        {
            theme.GenerateMainButtons(form);
            this.form = form;
            form.Controls.Add(mainButton);
            form.Controls.Add(mainTextBox);
            form.Controls.Add(mainLabel);
            mainButton.Click += (sender, args) =>
            {
                form.Controls.Remove(mainButton);
                UpdateStartButton();
                form.Controls.Add(startButton);
                mainLabel.Text = "ENTER YOUR NAME";
                mainTextBox.Size = new Size(form.ClientSize.Width - 120, 130);
                mainTextBox.Text = "your_name_here";
            };
        }

        public void UpdateInterfaceOnFightStart(Player player, Creature enemy)
        {
            form.Controls.Clear();
            form.Controls.Add(mainLabel);
            theme.GenerateStatLabels(player, enemy);
            AddStatLabels(player, enemy);
            AddControlButtons();
        }

        private void AddControlButtons()
        {
            foreach (var button in controlButtons)
                form.Controls.Add(button.Button);
        }

        private void AddStatLabels(Player player, Creature enemy)
        {
            foreach(var label in enemyStats)
            {
                form.Controls.Add(label.Label);
                label.Update(enemy);
            }
            foreach(var label in playerStats)
            {
                form.Controls.Add(label.Label);
                label.Update(player);
            }
        }

        public void UpdateInterfaceOnEOT()
        {
            foreach (var label in playerStats)
                label.Update();
            foreach (var label in enemyStats)
                label.Update();
        }

        public void Alert(string msg)
        {
            var buttons = MessageBoxButtons.OK;
            MessageBox.Show(msg);
        }
    }
}
