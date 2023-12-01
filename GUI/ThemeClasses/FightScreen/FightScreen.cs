using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class FightScreen : IFightScreen
    {
        public List<IControlButton> ControlButtons { get; private set; }

        public List<IEnemyStatLabel> EnemyStats { get; private set; }

        public List<IPLayerStatLabel> PlayerStats { get; private set; }

        public FightScreen()
        { }

        public void GenerateFightScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player, Creature enemy)
        {
            if (ControlButtons == null)
                GenerateControlButtonsLayout(sameThemeAttribute, defaultThemeTypes);
            if (EnemyStats == null && PlayerStats == null)
                GenerateStatLabels(sameThemeAttribute, defaultThemeTypes, player, enemy);
        }

        private void GenerateControlButtonsLayout(Type[] sameThemeAttribute, Type[] defaultThemeTypes)
        {
            ControlButtons = new();
            var instances = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IControlButton)))
                .Select(x => Activator.CreateInstance(x) as IControlButton)
                .Concat(defaultThemeTypes.Where(x => x.GetInterfaces().Contains(typeof(IControlButton)))
                .Select(x => Activator.CreateInstance(x) as IControlButton))
                .ToArray();
            ControlButtons.AddRange(instances);
        }

        public void GenerateStatLabels(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player, Creature enemy)
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
            foreach (var instance in enemyStatInstances)
                PlayerStats.AddRange(playerStatInstances);
            EnemyStats.AddRange(enemyStatInstances);
        }
    }
}
