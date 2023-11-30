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
        private List<IEnemyStatLabel> enemyStats => theme.EnemyStats;
        private List<IPLayerStatLabel> playerStats => theme.PlayerStats; 
        private List<IControlButton> controlButtons => theme.ControlButtons;
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

        public void StartChooseInterfaceScreen()
        {
            var comboBox = new ComboBox()
            {
                Location = new Point(Interface.OriginalFormSize.Width / 2 - 150, Interface.OriginalFormSize.Height / 2 - 100),
                Size = new Size(300, 100),
                ItemHeight = 100,
                Font = new Font(FontFamily.GenericSansSerif, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            var nameToInstance = new Dictionary<string, ITheme>();
            foreach (var instance in Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        t => t.GetInterfaces()
                        .Contains(typeof(ITheme)) && !t.IsAbstract)
                        .Select(x => Activator.CreateInstance(x) as ITheme)
                    .ToArray())
                nameToInstance.Add(instance.ToString(), instance);
            comboBox.Items.AddRange(nameToInstance.Keys.ToArray());
            comboBox.SelectedIndex = 0;
            var label = ReadyControls.GetMainLabel(form);
            label.Text = "Choose interface type";
            var confirmButton = ReadyControls.GetMainButton(form);
            confirmButton.Text = "ConfirmInterface";
            confirmButton.Location = new Point(confirmButton.Location.X, confirmButton.Location.Y + 50);
            confirmButton.Click += (sender, args) =>
            {
                form.Controls.Clear();
                theme = nameToInstance[comboBox.Items[comboBox.SelectedIndex] as string];
                InitializeInterface();
            };
            AddControl(label);
            AddControl(confirmButton);
            AddControl(comboBox);
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

        public void InitializeInterface()
        {
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            theme.GenerateMainButtons(form);
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
            theme.GenerateStatLabels(player, enemy);
            AddStatLabels(player, enemy);
            AddControlButtons();
        }

        private void AddControl(Control c)
        {
            RegisterOriginalSize(c);
            ResizeControl(controlToOriginalSize[c], c);
            form.Controls.Add(c);
        }

        private void AddControlButtons()
        {
            foreach (var button in controlButtons)
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
            foreach(var label in enemyStats)
            {
                AddControl(label.Label);
                label.Update(enemy);
            }
            foreach(var label in playerStats)
            {
                AddControl(label.Label);
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
