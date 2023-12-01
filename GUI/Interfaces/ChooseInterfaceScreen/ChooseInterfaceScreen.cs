using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public class ChooseInterfaceScreen
    {
        public readonly List<Control> Controls = new List<Control>();
        public readonly Button ConfirmButton;
        public ITheme ChosenTheme;
        public ChooseInterfaceScreen(IInterface ready, Form form) 
        {
            var comboBox = new ComboBox()
            {
                Location = new Point(
                    Interface.OriginalFormSize.Width / 2 - 150,
                    Interface.OriginalFormSize.Height / 2 - 100
                    ),
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
            var label = ReadyControls.GetMainLabel();
            label.Text = "Choose interface type";
            var confirmButton = ReadyControls.GetMainButton();
            confirmButton.Text = "ConfirmInterface";
            Controls.Add(label);
            Controls.Add(confirmButton);
            Controls.Add(comboBox);
            ConfirmButton = confirmButton;
            confirmButton.Location = new Point(confirmButton.Location.X, confirmButton.Location.Y + 50); confirmButton.Click += (sender, args) =>
            {
                ChosenTheme = nameToInstance[comboBox.Items[comboBox.SelectedIndex] as string];
            };
        }
    }
}
