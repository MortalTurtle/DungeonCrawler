using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IInterface
    {
        void StartChooseInterfaceScreen();
        public void InitializeInterface();
        public void UpdateInterfaceOnFightStart(Player player, Creature enemy);
        public void UpdateInterfaceOnEOT();
        public void Alert(string msg);
    }
}
