using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PlayersStartGearSet : IGearSet
    {
        private ITalisman talisman;
        public ITalisman Talisman 
        {
            get => talisman;
            set => CalculateStatsOnArtefactChange(ref talisman, value);
        }
        private Stats statsToAlter;
        public Stats CollectiveStatBoost => statsToAlter;
        public int CollectiveDefenseBoost { get; private set; }
        public PlayersStartGearSet(Stats playerStats) 
        {
            statsToAlter = playerStats;
            Talisman = new OldBronzeNecklace();
        }

        private void CalculateStatsOnArtefactChange<TArtefact>(ref TArtefact from, TArtefact to)
            where TArtefact : IArtefact
        {
            IArtefact fromAsArtefact = from as IArtefact;
            if (fromAsArtefact == null)
                fromAsArtefact = EmptyArtefact.Instance;
            statsToAlter -= fromAsArtefact.StatBoost;
            statsToAlter += to.StatBoost;
            CollectiveDefenseBoost -= fromAsArtefact.Defense;
            CollectiveDefenseBoost += to.Defense;
            from = to;
        }
    }
}
