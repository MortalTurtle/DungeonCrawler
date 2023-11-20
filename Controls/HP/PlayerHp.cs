using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PlayerHp : HpLabel
    {
        public PlayerHp() : base(DefaultParameters.PlayerHpLocation)
        { }
    }
}
