using System;
using System.CodeDom;
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
        private readonly PictureBoxWithArtefact talismanBox;
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
                var pic = new PictureBoxWithArtefact(new OldBronzeNecklace()) {Size = new Size(60,60), AllowDrop = true };
                pic.MouseDown += (sender, e) =>
                {
                    pic.DoDragDrop(pic, DragDropEffects.Move);
                };
                inventoryLayoutPanel.Controls.Add(pic,i % 4 , i / 4);
            }
            Controls.Add(inventoryLayoutPanel);
            Controls.Add(talismanBox);
        }

        public void Update()
        {
            var playerGearSet = Game.CurrentGame.Player.GearSet;
            talismanBox.Artefact = playerGearSet.Talisman;
        }

        private PictureBoxWithArtefact GetTalismanBox()
        {
            var talismanBox = new PictureBoxWithArtefact(new EmptyArtefact()) { Size = new Size(60, 60), Location = new(100, 100), AllowDrop = true };
            var tooltip = new ToolTip();
            tooltip.SetToolTip(talismanBox, "Talisman slot");
            talismanBox.DragEnter += (sender, args) =>
            {
                if ((sender as PictureBoxWithArtefact).Artefact is ITalisman)
                    args.Effect = DragDropEffects.Move;
                else
                    args.Effect = DragDropEffects.None;
            };
            talismanBox.DragDrop += (sender, args) =>
            {
                var data = args.Data.GetData(typeof(PictureBoxWithArtefact)) as PictureBoxWithArtefact;
                inventoryLayoutPanel.Controls.Remove(data);
                Game.CurrentGame.Player.GearSet.Talisman = data.Artefact as ITalisman;
                talismanBox.Artefact = data.Artefact;
            };
            return talismanBox;
        }
    }
}
