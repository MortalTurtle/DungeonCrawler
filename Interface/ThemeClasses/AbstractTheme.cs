using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public abstract class AbstractTheme : ITheme
    {
        public Color MainColor { get; set; }
        public IHPBars HPBars { get; set; }
        public List<IControlButton> ControlButtons { get; set; }
        public Button MainButton { get; set; }
        public Button GameStartButton { get; set; }
        public Label MainLabel { get; set; }
        public TextBox MainTextBox { get; set; }
        public abstract void EditForm(Form form);

        private readonly Type[]? sameThemeAttribute;
        public AbstractTheme()
        {
            var thisAttribute = this.GetType().GetCustomAttribute(typeof(ThemeAttribute));
            sameThemeAttribute = Assembly.GetExecutingAssembly().GetTypes()
                .Where( x => x.GetCustomAttributes().Contains(thisAttribute) &&
                !x.GetTypeInfo().IsAbstract).ToArray();
        }

        public void GenerateMainButtons(Form form)
        {
            MainButton = ControlsFactory.GetMainButton(form);
            MainTextBox = ControlsFactory.GetMainTextBox(form);
            MainLabel = ControlsFactory.GetMainLabel(form);
            GameStartButton = new Button
            {
                Location = new Point(60, form.ClientSize.Height / 2 + 100),
                Size = new Size(form.ClientSize.Width - 120, 60),
                Text = "Confirm",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
            GenerateControlButtonsLayout(form);
            EditForm(form);
            EditMainButtons();
        }
        private void GenerateControlButtonsLayout(Form form)
        {
            ControlButtons = new();
            var instances = sameThemeAttribute.Where(
                x => x.GetInterfaces().Contains(typeof(IControlButton)))
                .Select(x => Activator.CreateInstance(x, form) as IControlButton).ToArray();
            ControlButtons.AddRange(instances);
        }
        public abstract void EditMainButtons();
        public void GenerateHPBars(Creature player, Creature enemy)
        {
            var hpBarInstances = sameThemeAttribute.Where(x =>
            x.GetInterfaces().Contains(typeof(IHPBars))).Select(x => Activator.CreateInstance(x) as IHPBars).ToArray();
            if (hpBarInstances.Any())
                HPBars = hpBarInstances[0];
            else HPBars = new DefaultHPBars();
        }
    }
}
