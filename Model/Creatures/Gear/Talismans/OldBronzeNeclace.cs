﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class OldBronzeNecklace : ITalisman
    {
        public string Name => "Old bronze necklace";
        public Stats StatBoost => new Stats()
        {
            Strength = 1,
            Perception = 2
        };
        public int Defense => 2;

        public string PicturePath => Program.ImagePath + "\\oldBronzeNecklace.png";
    }
}
