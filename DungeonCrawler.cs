using DungeonCrawler.Controls;
using DungeonCrawler.Controls.HP;
using DungeonCrawler.Model;

namespace DungeonCrawler
{
    public partial class DungeonCrawler : Form
    {
        public DungeonCrawler()
        {
            InitializeComponent();
            this.Size = new Size(700, 500);
            Interface.InitializeInterface(this);
        }
    }
}