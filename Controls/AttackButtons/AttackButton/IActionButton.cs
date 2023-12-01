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
        string ButtonText { get; }
        Button Button { get; }
        Action<Creature, Creature> Action { get; }
        string FailMessage { get; }
        bool IsAbleToPerformAction();
    }
}
