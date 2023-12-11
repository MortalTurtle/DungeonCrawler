using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class TavernScreen : ITavernScreen
    {
        public List<Control> Controls { get; private set; }
        private List<ITavernDependentControl> dependentControls { get; set; }
        public TavernScreen() 
        {
            Controls = new List<Control>();
        }
        public void Update()
        {
            foreach (var control in dependentControls)
                control.Update();
        }

        public void GenerateTavernScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Player player)
        {
            var instances = sameThemeAttribute.Concat(defaultThemeTypes)
                .Where(x => x.GetInterfaces()
                .Contains(typeof(ITavernControl)))
                .Select(x => Activator.CreateInstance(x) as ITavernControl).ToArray();
            dependentControls = new();
            var dependentInstances = sameThemeAttribute.Concat(defaultThemeTypes)
                .Where(x => x.GetInterfaces()
                .Contains(typeof(ITavernDependentControl))).Select(x => Activator.CreateInstance(x) as ITavernDependentControl).ToArray();
            dependentControls.AddRange(dependentInstances);
            Controls.AddRange(dependentInstances.Select(x =>
            {
                x.Update(player);
                return x.Control;
            }));
            Controls.AddRange(instances.Select(x => x.Control));
        }
    }
}
