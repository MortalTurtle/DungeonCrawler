using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Default]
    public class PlayerHP : HPLabel, IPLayerStatLabel
    {
        public override Point Location => DefaultParameters.PlayerHpLocation;
    }
}
