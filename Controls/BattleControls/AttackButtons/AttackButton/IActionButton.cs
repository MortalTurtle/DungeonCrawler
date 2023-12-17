using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls
{
    public interface IActionButton
    {
        Color DefaultBackColor { get; }
        Button Button { get; }
        Action<Player, ICreature> Action { get; }
        string ButtonText { get; }
        string FailMessage { get; }
        int ActionCost { get; }
    }
}
