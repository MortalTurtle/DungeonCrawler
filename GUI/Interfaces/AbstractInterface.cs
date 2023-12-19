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
using DungeonCrawler.GUI.Screens;

namespace DungeonCrawler
{
    public abstract class AbstractInterface : IInterface
    {
        private readonly Form form;

        private ITheme theme;
        public IScreen CurrentScreen { get; private set; }
        private Button mainButton => theme.MainButton;
        private Button startButton => theme.GameStartButton;
        private Label mainLabel => theme.MainLabel;
        private TextBox mainTextBox => theme.MainTextBox;

        private readonly Dictionary<Control, Rectangle> controlToOriginalSize = new();
        public AbstractInterface()
        {
            this.form = Interface.Form;
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
                theme = Activator.CreateInstance(screen.ChosenTheme) as ITheme;
                InitializeInterface();
            };
            foreach (var c in screen.Controls)
                AddControl(c);
        }
        public void InitializeInterface()
        {
            form.Controls.Clear();
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

        public void GenerateFightAndTavernScreens(Player player)
        {
            theme.GenerateFightAndTavernScreens(player);
        }

        public void LoadNewScreen(Type screenType)
        {
            form.Controls.Clear();
            CurrentScreen = theme.GetScreen(screenType);
            foreach (var control in CurrentScreen.Controls)
                AddControl(control);
        }

        void IInterface.LoadNewScreen<TScreen>() => LoadNewScreen(typeof(TScreen));

        public TScreen GetScreen<TScreen>()
            where TScreen : IScreen => theme.GetScreen<TScreen>();

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

        private void RegisterOriginalSize(Control c)
        {
            if (controlToOriginalSize.ContainsKey(c))
                return;
            controlToOriginalSize.Add(c, new Rectangle(c.Location.X, c.Location.Y, c.Size.Width, c.Size.Height));
        }
    }
}
