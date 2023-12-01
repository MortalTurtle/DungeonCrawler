using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Reflection;

namespace DungeonCrawler
{
    public abstract class AbstractInterface : IInterface
    {
        private Form form;
        private ITheme theme;
        private Button mainButton => theme.MainButton;
        private Button startButton => theme.GameStartButton;
        private Label mainLabel => theme.MainLabel;
        private TextBox mainTextBox => theme.MainTextBox;
        private Dictionary<Control, Rectangle> controlToOriginalSize = new();
        public AbstractInterface()
        {
            this.form = Interface.form;
            form.Resize += (sender, args) =>
            {
                foreach (Control control in form.Controls)
                {
                    ResizeControl(
                        controlToOriginalSize[control],
                        control);
                }
            };
        }

        public void StartChooseInterfaceScreen(ChooseInterfaceScreen screen)
        {
            screen.ConfirmButton.Click += (sender, args) =>
            {
                form.Controls.Clear();
                theme = screen.ChosenTheme;
                InitializeInterface();
            };
            foreach (var c in screen.Controls)
                AddControl(c);
        }
        public void InitializeInterface()
        {
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            theme.GenerateMainButtons();
            theme.EditForm(form);
            AddControl(mainLabel);
            AddControl(mainButton);
            AddControl(mainTextBox);
            form.Controls.Add(mainButton);
            form.Controls.Add(mainTextBox);
            form.Controls.Add(mainLabel);
            mainButton.Click += (sender, args) =>
            {
                form.Controls.Remove(mainButton);
                UpdateStartButton();
                form.Controls.Add(startButton);
                AddControl(startButton);
                mainLabel.Text = "ENTER YOUR NAME";
                mainTextBox.Size = new Size(form.ClientSize.Width - 120, 130);
                mainTextBox.Text = "your_name_here";
            };
        }

        public void UpdateInterfaceOnFightStart(Player player, Creature enemy)
        {
            form.Controls.Clear();
            form.Controls.Add(mainLabel);
            theme.GenerateFightScreen(player, enemy);
            AddStatLabels(player, enemy);
            AddControlButtons();
        }

        public void UpdateInterfaceOnEOT()
        {
            foreach (var label in theme.PlayerStats)
                label.Update();
            foreach (var label in theme.EnemyStats)
                label.Update();
        }

        public void Alert(string msg)
        {
            var buttons = MessageBoxButtons.OK;
            MessageBox.Show(msg);
        }

        private void AddControl(Control c)
        {
            RegisterOriginalSize(c);
            ResizeControl(controlToOriginalSize[c], c);
            form.Controls.Add(c);
        }

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

        private void AddControlButtons()
        {
            foreach (var button in theme.ControlButtons)
                AddControl(button.Button);
        }

        private void RegisterOriginalSize(Control c)
        {
            if (controlToOriginalSize.ContainsKey(c))
                return;
            controlToOriginalSize.Add(c, new Rectangle(c.Location.X, c.Location.Y, c.Size.Width, c.Size.Height));
        }

        private void AddStatLabels(Player player, Creature enemy)
        {
            foreach(var label in theme.EnemyStats)
            {
                AddControl(label.Label);
                label.Update(enemy);
            }
            foreach(var label in theme.PlayerStats)
            {
                AddControl(label.Label);
                label.Update(player);
            }
        }
    }
}
