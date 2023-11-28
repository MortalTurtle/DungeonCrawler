using DungeonCrawler.Controls;
using System;
using System.CodeDom;
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

        private readonly Type[] sameThemeAttribute;
        private readonly Type[] defaultThemeTypes;
        public AbstractTheme()
        {
            var thisAttribute = this.GetType().GetCustomAttribute(typeof(ThemeAttribute));
            var defaultThemeAttribute = new List<Type>();
            var sameThemeAttribute = new List<Type>();
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsAbstract)
                    continue;
                if (type.GetCustomAttributes().Contains(thisAttribute)
                    && !type.BaseType.IsAbstract
                    && thisAttribute is not DefaultAttribute)
                    sameThemeAttribute.Add(type);
                else if (type.GetCustomAttributes().Contains(Activator.CreateInstance(typeof(DefaultAttribute))) && type.BaseType.IsAbstract)
                    defaultThemeAttribute.Add(type);
            }
            for (int i = 0; i < defaultThemeAttribute.Count;i++)
            {
                var defaultControlElement = defaultThemeAttribute[i];
                if (sameThemeAttribute.Any(x => x.IsAssignableTo(defaultControlElement)))
                {
                    defaultThemeAttribute.RemoveAt(i);
                    i--;
                }
            }
            this.defaultThemeTypes = defaultThemeAttribute.ToArray();
            this.sameThemeAttribute = sameThemeAttribute.ToArray();
        }
        public void GenerateMainButtons(Form form)
        {
            MainButton = ReadyControls.GetMainButton(form);
            MainTextBox = ReadyControls.GetMainTextBox(form);
            MainLabel = ReadyControls.GetMainLabel(form);
            GameStartButton = new Button
            {
                Location = new Point(60, form.ClientSize.Height / 2 + 100),
                Size = new Size(form.ClientSize.Width - 120, 60),
                Text = "Confirm",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
            GenerateControlButtonsLayout(form);
            EditForm(form);
        }
        private void GenerateControlButtonsLayout(Form form)
        {
            ControlButtons = new();
            var instances = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IControlButton)))
                .Select(x => Activator.CreateInstance(x, form) as IControlButton)
                .Concat(defaultThemeTypes.Where( x => x.GetInterfaces().Contains(typeof(IControlButton)))
                .Select(x => Activator.CreateInstance(x,form) as IControlButton))
                .ToArray();
            ControlButtons.AddRange(instances);
        }
        public void GenerateStatLabels(Creature player, Creature enemy)
        {
            if (EnemyStats != null && PlayerStats != null)
                return;
            EnemyStats = new();
            PlayerStats = new();
            var types = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IStatLabel)))
                .Concat(defaultThemeTypes.Where(x => x.GetInterfaces().Contains(typeof(IStatLabel))));
            var playerStatInstances = types.Where(x => x.GetInterfaces().Contains(typeof(IPLayerStatLabel)))
            .Select(x => Activator.CreateInstance(x) as IPLayerStatLabel).ToArray();
            var enemyStatInstances = types.Where(x => x.GetInterfaces().Contains(typeof(IEnemyStatLabel)))
            .Select(x => Activator.CreateInstance(x) as IEnemyStatLabel).ToArray();
            foreach(var instance in enemyStatInstances)
            PlayerStats.AddRange(playerStatInstances);
            EnemyStats.AddRange(enemyStatInstances);
        }
    }
}
