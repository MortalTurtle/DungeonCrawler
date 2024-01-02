using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IArtefact
    {
        string Name { get; }
        Stats StatBoost { get; }
        int Defense { get; }
        string PicturePath { get; }
    }
}
