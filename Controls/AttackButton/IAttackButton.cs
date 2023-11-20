using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls
{
    public interface IAttackButton
    {
        Button Button { get; }
        ActionType FightAction { get; }
    }
}
