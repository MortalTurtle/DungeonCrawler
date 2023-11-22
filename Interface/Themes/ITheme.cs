using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface ITheme
    {
        Color MainColor { get; }
        IHPBars HPBars { get; }
        List<IControlButton> ControlButtons { get; }
        Button MainButton { get; }
        Button GameStartButton { get; }
        Label MainLabel { get; }
        TextBox MainTextBox { get; }
        void EditForm(Form form);
        void GenerateMainButtons(Form form);
        void GenerateHPBars(Player player, Creature creature);
        IButtonLayout GenerateControlButtonsLayout(Form form);
    }
}
