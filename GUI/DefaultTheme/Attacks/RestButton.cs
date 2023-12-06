using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class RestButton : AbstractActionButton
    {
        public RestButton()
        {
            this.Button.Location = new Point(135, 435);
        }
        public override Action<Creature, Creature> Action => (player, enemy) => player.Rest();
        public override string ButtonText => "Rest";
        public override string FailMessage => "Unable To Rest";
        public override int ActionCost => -5;
    }
}
