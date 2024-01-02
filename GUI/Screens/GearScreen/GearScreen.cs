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
        private readonly PictureBoxWithArtefact weaponBox;
        public GearScreen()
        {
            Controls = new();
            talismanBox = GetGenericBox<ITalisman>("Talisman Slot");
            talismanBox.Location = new(100, 100);
            weaponBox = GetGenericBox<IWeapon>("WeaponSlot");
            weaponBox.Location = new(40, 180);
            inventoryLayoutPanel = new TableLayoutPanel() { Size = new(280, 280), Location = new(400, 50) };
            inventoryLayoutPanel.RowStyles.Clear();
            inventoryLayoutPanel.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
            {
                inventoryLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65));
                inventoryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65));
            }

            Controls.Add(inventoryLayoutPanel);
            Controls.Add(talismanBox);
            Controls.Add(weaponBox);
        }

        private PictureBoxWithArtefact CreatePictureBox(IArtefact artefact)
        {
            var pic = new PictureBoxWithArtefact(artefact) { Size = new Size(60, 60), AllowDrop = true };
            pic.MouseDown += (sender, e) =>
            {
                pic.DoDragDrop(pic, DragDropEffects.Move);
            };
            return pic;
        }

        private void AddPictureBoxToInventoryTable(PictureBoxWithArtefact box)
        {
            var count = inventoryLayoutPanel.Controls.Count;
            inventoryLayoutPanel.Controls.Add(box,count % 4, count / 4);
        }

        public void Update()
        {
            var playerGearSet = Game.CurrentGame.Player.GearSet;
            inventoryLayoutPanel.Controls.Clear();
            talismanBox.Artefact = playerGearSet.Talisman;
            weaponBox.Artefact = playerGearSet.Weapon;
            foreach (var item in playerGearSet.Inventory)
                AddPictureBoxToInventoryTable(CreatePictureBox(item));
        }

        private PictureBoxWithArtefact GetGenericBox<TArtefact>(string toolTipMsg)
            where TArtefact : class, IArtefact
        {
            var box = new PictureBoxWithArtefact(new EmptyArtefact()) { Size = new Size(60, 60), AllowDrop = true };
            var tooltip = new ToolTip();
            tooltip.SetToolTip(box, toolTipMsg);
            box.DragEnter += (sender, args) =>
            {
                var data = args.Data.GetData(typeof(PictureBoxWithArtefact)) as PictureBoxWithArtefact;
                if (data.Artefact is TArtefact)
                    args.Effect = DragDropEffects.Move;
                else args.Effect = DragDropEffects.None;
            };
            box.DragDrop += (sender, args) =>
            {
                var data = args.Data.GetData(typeof(PictureBoxWithArtefact)) as PictureBoxWithArtefact;
                var artefactData = data.Artefact;
                var type = typeof(IGearSet);
                var artefactProperty = type.GetProperties().Where(x => x.PropertyType == typeof(TArtefact)).First();
                data.Artefact = artefactProperty.GetValue(Game.CurrentGame.Player.GearSet) as TArtefact;
                artefactProperty.SetValue(Game.CurrentGame.Player.GearSet, artefactData as TArtefact);
                box.Artefact = artefactData;
            };
            return box;
        }
    }
}
