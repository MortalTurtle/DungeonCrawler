using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IFightScreen : IScreen
    {
        List<IPLayerStatLabel> PlayerStatLabels { get; }
        List<IEnemyStatLabel> EnemyStatLabels { get; }
        void GenerateFightScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player, Creature enemy);
    }
}
