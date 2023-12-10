﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ITavernScreen : IScreen
    {
        void GenerateTavernScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player);
    }
}
