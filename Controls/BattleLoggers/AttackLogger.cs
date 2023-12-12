using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.BattleLoggers
{
    public class AttackLogger : IBattleActionLogger
    {
        public Creature Executant { get; set; }
        public Creature Target { get; set; }
        public int ChanceRoll { get; set; }
        public int ChanceRollMinToSuccess { get; set; }
        public int DmgRoll { get; set; }
        public string AttackType { get; set; }
        public bool IsSuccessful { get; set; }
        public string GetLogMessage()
        {
            if (IsSuccessful)
                return String.Format("{0} have used a {1} on {2} for {3}, rolled {4} / {5}",
                    Executant.Name, AttackType, Target.Name, DmgRoll,ChanceRoll, ChanceRollMinToSuccess);
            else return String.Format("{0} tried to use a {1} on {2}, rolled {3} / {4}",
                Executant.Name, AttackType, Target.Name, ChanceRoll, ChanceRollMinToSuccess);
        }
    }
}
