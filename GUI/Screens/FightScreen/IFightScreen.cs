using DungeonCrawler.Controls;
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
        void GenerateFightScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Player player, ICreature enemy);
        void ChangeActionButton(IActionButton other, Color colorToChange, Color defaultBackColor);
        void LogAction(IBattleActionLogger log);
        void UpdateOnFightStart(Player player, ICreature enemy);
    }
}
