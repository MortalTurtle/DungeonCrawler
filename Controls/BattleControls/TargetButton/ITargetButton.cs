using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ITargetButton
    {
        Button Button { get; }
        ActionTarget Target { get; }
    }
}
