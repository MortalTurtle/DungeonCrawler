using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.BattleLoggers
{
    internal class RestActionLogger : IBattleActionLogger
    {
        public Creature Executant { get; set; }
        public string GetLogMessage() => String.Format("{0} are resting, rested for {1}", Executant.Name, Executant.Stats.Endurance + 4);
    }
}
