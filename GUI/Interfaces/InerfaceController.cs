﻿using DungeonCrawler.Controls;
using DungeonCrawler.Controls.AttackButtons;
using DungeonCrawler.GUI.Screens;
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
        public static Form Form;
        private static IInterface currenThemedInterface;
        public static Size OriginalFormSize = new(700, 500);
        public static void InitializeInterface (Form form, IInterface ready)
        {
            var screen = new ChooseInterfaceScreen(ready, form);
            currenThemedInterface = ready;
            currenThemedInterface.StartChooseInterfaceScreen(screen);
        }

        public static void ReinitializeInterface() => currenThemedInterface.InitializeInterface();

        public static void UpdateInterfaceOnFightStart(Player player, Creature enemy) =>
            currenThemedInterface.UpdateInterfaceOnFightStart(player, enemy);

        public static void ChangeActionButton(IActionButton other, Color colorToChange, Color defaultBackColor) => 
            (currenThemedInterface.CurrentScreen as IFightScreen).ChangeActionButton(other, colorToChange, defaultBackColor);

        public static void UpdateInterfaceOnEOT() => currenThemedInterface.CurrentScreen.Update();

        public static void Alert(string msg) => currenThemedInterface.Alert(msg);

        public static void LoadScreen<TScreen>()
            where TScreen : IScreen => currenThemedInterface.LoadNewScreen<TScreen>();
        public static void CallEndOfFightScreenPlayerLost() => currenThemedInterface.LoadNewScreen(typeof(IBattleLostScreen));

        public static void CallEndOfFightScreenPlayerWon() => currenThemedInterface.LoadNewScreen<IBattleWonScreen>();

    }
}
