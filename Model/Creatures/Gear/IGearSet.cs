﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IGearSet
    {
        Stats CreatureStats { get; }
        ITalisman Talisman { get; set; }
        IWeapon Weapon { get; set; }
        List<IArtefact> Inventory { get; }
    }
}
