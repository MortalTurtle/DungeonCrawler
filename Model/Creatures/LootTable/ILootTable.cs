﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ILootTable
    {
        int Gold { get; }
        List<IArtefact> Artefacts { get; }
    }
}
