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
        public TavernScreen() 
        {
            Controls = new List<Control>();
        }
        public void Update()
        { }

        public void GenerateTavernScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player)
        {
            var instances = sameThemeAttribute.Concat(defaultThemeTypes)
                .Where(x => x.GetInterfaces()
                .Contains(typeof(ITavernControl)))
                .Select(x => Activator.CreateInstance(x) as ITavernControl);
            Controls.AddRange(instances.Select(x => x.Control));
        }
    }
}
