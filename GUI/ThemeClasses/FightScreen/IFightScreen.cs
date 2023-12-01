using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IFightScreen
    {
        List<IControlButton> ControlButtons { get; }
        List<IEnemyStatLabel> EnemyStats { get; }
        List<IPLayerStatLabel> PlayerStats { get; }
        void GenerateFightScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player, Creature enemy);
    }
}
