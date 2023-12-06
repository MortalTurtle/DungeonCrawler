using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.Controls.TargetButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class AbstractButtonLayout : IButtonLayout
    {
        public List<IBattleControlButton> Buttons { get; private set; }

        public AbstractButtonLayout(Form form)
        {
            var thisAttribute = this.GetType().GetCustomAttribute(typeof(ThemeAttribute));
            Buttons = new();
            var instances = Assembly.GetExecutingAssembly().GetTypes()
                .Where(
                x => x.GetInterfaces().Contains(typeof(IBattleControlButton)) &&
                x.GetCustomAttributes().Contains(thisAttribute) &&
                !x.GetTypeInfo().IsAbstract
                )
                .Select(x => Activator.CreateInstance(x, form) as IBattleControlButton).ToArray();
            Buttons.AddRange(instances);
        }
    }
}
