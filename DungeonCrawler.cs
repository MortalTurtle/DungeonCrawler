using DungeonCrawler.Controls;
using DungeonCrawler.GUI.DarkTheme;
using DungeonCrawler.Model;

namespace DungeonCrawler
{
    public partial class DungeonCrawler : Form
    {
        public DungeonCrawler()
        {
            InitializeComponent();
            this.Size = new Size(700, 500);
            Interface.InitializeInterface(this, new DefaultInterface<DefaultTheme>());
        }
    }
}