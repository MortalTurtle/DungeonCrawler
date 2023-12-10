using DungeonCrawler.Controls;
using DungeonCrawler.GUI.Screens;
using Ninject;
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
        Button MainButton { get; }
        Button GameStartButton { get; }
        Label MainLabel { get; }
        TextBox MainTextBox { get; }
        void EditForm(Form form);
        void GenerateMainButtons();
        IScreen GetScreen(Type screenType);
        void GenerateFightAndTavernScreens(Player player);
    }
}
