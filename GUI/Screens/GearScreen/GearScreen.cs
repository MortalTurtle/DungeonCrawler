using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class GearScreen : IGearScreen
    {
        public List<Control> Controls { get; private set; }
        private readonly TableLayoutPanel inventoryLayoutPanel;
        private readonly PictureBox talismanBox;
        private readonly Dictionary<PictureBox, IArtefact> boxToArtefactInstance = new();
        public GearScreen() 
        {
            Controls = new();
            talismanBox = GetTalismanBox();
            inventoryLayoutPanel = new TableLayoutPanel() {Size = new(280,280), Location = new(400, 50) };
            inventoryLayoutPanel.RowStyles.Clear();
            inventoryLayoutPanel.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
            {
                inventoryLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65));
                inventoryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65));
            }

            for (int i = 0; i < 10;i++)
            {
                var pic = new PictureBox() {Size = new Size(60,60), ImageLocation = Path.Combine(Directory.GetCurrentDirectory(), "images\\empty.png"), AllowDrop = true };
                pic.MouseDown += (sender, e) =>
                {
                    pic.DoDragDrop(pic.ImageLocation, DragDropEffects.Copy | DragDropEffects.Move);
                };
                inventoryLayoutPanel.Controls.Add(pic,i % 4 , i / 4);
            }

            Controls.Add(inventoryLayoutPanel);
            Controls.Add(talismanBox);
        }
        public void Update()
        {

        }

        private PictureBox GetTalismanBox()
        {
            var talismanBox = new PictureBox() { Size = new Size(60, 60), Location = new(100, 100), AllowDrop = true };
            var tooltip = new ToolTip();
            tooltip.SetToolTip(talismanBox, "Talisman slot");
            talismanBox.DragEnter += (sender, args) =>
            {
                args.Effect = DragDropEffects.Move;
            };
            talismanBox.DragDrop += (sender, args) =>
            {
                inventoryLayoutPanel.Controls.RemoveAt(0);
                talismanBox.ImageLocation = args.Data.GetData(DataFormats.Text) as string;
            };
            return talismanBox;
        }
    }
}
