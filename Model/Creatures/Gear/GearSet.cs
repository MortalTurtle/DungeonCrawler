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
        private ITalisman talisman = new EmptyArtefact();
        public ITalisman Talisman 
        {
            get => talisman;
            set => CalculateStatsOnArtefactChange(ref talisman, value);
        }
        private IWeapon weapon;
        public IWeapon Weapon 
        {
            get => weapon;
            set => CalculateStatsOnArtefactChange(ref weapon, value); 
        }
        private Stats creatureStats;
        public Stats CreatureStats => creatureStats;
        private readonly List<IArtefact> inventory = new();
        public List<IArtefact> Inventory => inventory;
        public PlayersStartGearSet(Stats playerStats) 
        {
            creatureStats = playerStats;
        }

        private void CalculateStatsOnArtefactChange<TArtefact>(ref TArtefact from, TArtefact to)
            where TArtefact : IArtefact
        {
            IArtefact fromAsArtefact = from;
            if (fromAsArtefact == null)
                fromAsArtefact = EmptyArtefact.Instance;
            creatureStats -= fromAsArtefact.StatBoost;
            creatureStats += to.StatBoost;
            from = to;
        }
    }
}
