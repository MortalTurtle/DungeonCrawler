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

        private IHPBars hpBars => theme.HPBars;
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
            AddHPBars(player, enemy);
            AddControlButtons();
        }

        private void AddControlButtons()
        {
            foreach (var button in controlButtons)
                form.Controls.Add(button.Button);
        }

        private void AddHPBars(Player player, Creature enemy)
        {
            theme.GenerateHPBars(player, enemy);
            hpBars.UpdateBars();
            form.Controls.Add(hpBars.PlayerHP.Label);
            form.Controls.Add(hpBars.EnemyHP.Label);
        }

        public void UpdateInterfaceOnEOT()
        {
            hpBars.UpdateBars();
        }
    }
}
