using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.FightActions
{
    public static class FightActionsDict
    {
        private static Dictionary<ActionType, Action<Creature>> actions;

        public static void GenerateActions(Player player)
        {
            actions = new Dictionary<ActionType, Action<Creature>>();
            actions.Add(ActionType.DefaultAttack, player.Attack);
        }

        public static void Perform(ActionType actionType,Creature target)
        {
            actions[actionType].Invoke(target);
        }
    }
}
