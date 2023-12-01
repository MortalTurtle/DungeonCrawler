﻿using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ITheme
    {
        Color MainColor { get; }
        List<IEnemyStatLabel> EnemyStats { get; }
        List<IPLayerStatLabel> PlayerStats { get; }
        List<IControlButton> ControlButtons { get; }
        Button MainButton { get; }
        Button GameStartButton { get; }
        Label MainLabel { get; }
        TextBox MainTextBox { get; }
        void EditForm(Form form);
        void GenerateMainButtons();
        void GenerateFightScreen(Creature player, Creature enemy);
    }
}
