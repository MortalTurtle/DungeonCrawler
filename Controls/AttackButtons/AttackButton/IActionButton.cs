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
        string ButtonText { get; }
        Button Button { get; }
        Action<Creature, Creature> Action { get; }
    }
}
