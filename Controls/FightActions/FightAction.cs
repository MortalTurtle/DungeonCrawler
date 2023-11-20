using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.FightActions
{
    public class FightAction : IFightAction
    {
        public ActionTarget Target { get; set; }
        public ActionType Action { get; private set; }
        public FightAction(ActionTarget target, ActionType action)
        {
            this.Target = target;
            this.Action = action;
        }
    }
}
