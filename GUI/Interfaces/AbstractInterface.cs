using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

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
        private Dictionary<Control, Rectangle> controlToOriginalSize = new();
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

        private void ResizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(form.Width) / (Interface.OriginalFormSize.Width);
            float yRatio = (float)(form.Height) / (Interface.OriginalFormSize.Height);
            var newX = (int)(r.X * xRatio);
            var newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            var newHeight = (int)(r.Height * yRatio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        public void InitializeInterface(Form form)
        {
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            theme.GenerateMainButtons(form);
            RegisterControlButtons();
            this.form = form;
            form.Resize += (sender, args) =>
            {
                foreach (Control control in form.Controls)
                {
                    ResizeControl(
                        controlToOriginalSize[control],
                        control);
                }
            };
            RegisterOriginalSize(mainButton);
            RegisterOriginalSize(mainLabel);
            RegisterOriginalSize(startButton);
            RegisterOriginalSize(mainTextBox);
            form.Controls.Add(mainButton);
            form.Controls.Add(mainTextBox);
            form.Controls.Add(mainLabel);
            mainButton.Click += (sender, args) =>
            {
                form.Controls.Remove(mainButton);
                UpdateStartButton();
                form.Controls.Add(startButton);
                form.Controls.Add(mainTextBox);
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

        private void RegisterControlButtons()
        {
            foreach (var c in controlButtons)
                RegisterOriginalSize(c.Button);
        }

        private void AddControlButtons()
        {
            foreach (var button in controlButtons)
            {
                form.Controls.Add(button.Button);
            }
        }

        private void RegisterOriginalSize(Control c)
        {
            if (controlToOriginalSize.ContainsKey(c))
                return;
            controlToOriginalSize.Add(c, new Rectangle(c.Location.X, c.Location.Y, c.Size.Width, c.Size.Height));
        }

        private void AddStatLabels(Player player, Creature enemy)
        {
            foreach(var label in enemyStats)
            {
                RegisterOriginalSize(label.Label);
                form.Controls.Add(label.Label);
                label.Update(enemy);
            }
            foreach(var label in playerStats)
            {
                RegisterOriginalSize(label.Label);
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
