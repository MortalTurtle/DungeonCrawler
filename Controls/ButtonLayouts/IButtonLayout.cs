﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IButtonLayout
    {
        List<IBattleControlButton> Buttons { get; }
    }
}
