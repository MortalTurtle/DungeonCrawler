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
        public Color MainColor { get; private set; }
        public List<IControlButton> ControlButtons { get;private set; }
        public List<IEnemyStatLabel> EnemyStats {get;private set; }
        public List<IPLayerStatLabel> PlayerStats { get;private set; }
        public Button MainButton { get; private set; }
        public Button GameStartButton { get; private set; }
        public Label MainLabel { get; private set; }
        public TextBox MainTextBox { get; private set; }
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
            var instances = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IControlButton)))
                .Select(x => Activator.CreateInstance(x, form) as IControlButton).ToArray();
            ControlButtons.AddRange(instances);
        }
        public abstract void EditMainButtons();
        public void GenerateStatLabels(Creature player, Creature enemy)
        {
            EnemyStats = new();
            PlayerStats = new();
            var playerStatInstances = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IPLayerStatLabel)))
            .Select(x => Activator.CreateInstance(x) as IPLayerStatLabel).ToArray();
            var enemyStatInstances = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IEnemyStatLabel)))
            .Select(x => Activator.CreateInstance(x) as IEnemyStatLabel).ToArray();
            PlayerStats.AddRange(playerStatInstances);
            EnemyStats.AddRange(enemyStatInstances);
        }
    }
}
