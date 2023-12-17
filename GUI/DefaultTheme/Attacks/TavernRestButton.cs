using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class TavernRestButton : AbstractActionButton
    {
        public TavernRestButton()
        {
            this.Button.Location = new Point(135, 435);
        }
        public override Action<Player, ICreature> Action => (player, enemy) => player.Rest();
        public override string ButtonText => "Rest";
        public override string FailMessage => "Unable To Rest";
        public override int ActionCost => -(Game.CurrentGame.Player.Stats.Endurance + 4);
    }
}
