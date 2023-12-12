using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.BattleLoggers
{
    public class TurnLogger : IBattleActionLogger
    {
        public TurnLogger(int turn)
        {
            this.turn = turn;
        }
        private int turn;
        public string GetLogMessage() => "Turn " + turn;
    }
}
