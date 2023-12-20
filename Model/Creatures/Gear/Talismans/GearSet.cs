using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model.Creatures.Gear.Talismans
{
    public class PlayersStartGearSet : IGearSet
    {
        public ITalisman Talisman 
        {
            get => Talisman;
            set
            {
                if (Talisman == null)
                    CalculateStatsOnArtefactChange(EmptyArtefact.Instance, value);
                else CalculateStatsOnArtefactChange(Talisman, value);
                Talisman = value;
            }
        }
        private Stats collectiveStatBoost = new Stats();
        public Stats CollectiveStatBoost => collectiveStatBoost;
        public int CollectiveDefenseBoost { get; private set; }
        public PlayersStartGearSet() 
        {
            Talisman = new OldBronzeNecklace();
        }

        private void CalculateStatsOnArtefactChange(IArtefact from, IArtefact to)
        {
            collectiveStatBoost -= from.StatBoost;
            collectiveStatBoost += to.StatBoost;
            CollectiveDefenseBoost -= from.Defense;
            CollectiveDefenseBoost += to.Defense;
        }
    }
}
