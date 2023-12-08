using DungeonCrawler.Controls;
using DungeonCrawler.GUI.Screens;
using Ninject;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public abstract class AbstractTheme : ITheme
    {
        private StandardKernel screensContainer;
        public Color MainColor { get; private set; }
        public IBattleLostScreen BattleLostScreen { get; private set; }
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
                if (type.GetInterfaces().Contains(typeof(IBattleLostScreen)))
                    this.BattleLostScreen = Activator.CreateInstance(type) as IBattleLostScreen;
                if (type.GetCustomAttributes().Contains(thisAttribute)
                    && thisAttribute is not DefaultAttribute)
                    sameThemeAttribute.Add(type);
                else if (type.GetCustomAttributes().Contains(Activator.CreateInstance(typeof(DefaultAttribute))) && type.BaseType.IsAbstract)
                    defaultThemeAttribute.Add(type);
            }
            for (int i = 0; i < defaultThemeAttribute.Count; i++)
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
            FindScreenTypes();
            GenerateMainButtons();
        }

        public void GenerateMainButtons()
        {
            MainButton = ReadyControls.GetMainButton();
            MainTextBox = ReadyControls.GetMainTextBox();
            MainLabel = ReadyControls.GetMainLabel();
            GameStartButton = new Button
            {
                Location = new Point(60, Interface.OriginalFormSize.Height / 2 + 100),
                Size = new Size(Interface.OriginalFormSize.Width - 120, 60),
                Text = "Confirm",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
        }
        public override string ToString()
        {
            return (this.GetType().GetCustomAttribute(typeof(ThemeNameAttribute)) as ThemeNameAttribute).Name;
        }

        public void GenerateFightScreen(Creature player, Creature enemy)
        {
            var screen = screensContainer.Get(typeof(IFightScreen)) as IFightScreen;
            screen.GenerateFightScreen(sameThemeAttribute, defaultThemeTypes, player, enemy);
            screen.Controls.Add(MainLabel);
        }

        public IScreen GetScreen(Type screenType)
        {
            return screensContainer.Get(screenType) as IScreen;
        }

        private void FindScreenTypes()
        {
            screensContainer = new();
            foreach (var type in sameThemeAttribute.Concat(defaultThemeTypes))
                if (type.GetInterfaces().Contains(typeof(IScreen)))
                    screensContainer.Bind(
                        type.GetInterfaces().First(x => x.IsAssignableTo(typeof(IScreen)) && (x is not IScreen))
                        ).To(type).InSingletonScope();
        }
    }
}
