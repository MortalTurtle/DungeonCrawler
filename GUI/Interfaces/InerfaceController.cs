using DungeonCrawler.Controls;
using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public static class Interface
    {
        private static IInterface currentInterface;
        public static Size OriginalFormSize = new(700, 500);
        public static void InitializeInterface (Form form, IInterface ready)
        {
            currentInterface = ready;
            currentInterface.InitializeInterface(form);
        }

        public static void UpdateInterfaceOnFightStart(Player player, Creature enemy)
        {
            currentInterface.UpdateInterfaceOnFightStart(player,enemy);
        }

        public static void UpdateInterfaceOnEOT()
        {
            currentInterface.UpdateInterfaceOnEOT();
        }

        public static void Alert(string msg)
        {
            currentInterface.Alert(msg);
        }
    }
}
