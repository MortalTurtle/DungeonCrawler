﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IInterface
    {
        public IScreen CurrentScreen { get; }
        void StartChooseInterfaceScreen(ChooseInterfaceScreen screen);
        public void InitializeInterface();
        public void GenerateFightAndTavernScreens(Player player);
        public void LoadNewScreen(Type screenType);
        public void LoadNewScreen<TScreen>()
            where TScreen : IScreen;
        TScreen GetScreen<TScreen>()
            where TScreen : IScreen;
        public void Alert(string msg);
    }
}
