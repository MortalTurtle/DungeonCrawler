using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.FightActions
{
    public class AttackFightAction : IFightAction
    {
        public ActionTarget Target { get; private set; }
        public ActionType Action { get; private set; }
        public AttackFightAction(ActionTarget target, ActionType action)
        {
            this.Target = target;
            this.Action = action;
        }
    }
}
