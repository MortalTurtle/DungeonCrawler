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
        private readonly TableLayoutPanel statsTable; // 0 - MaxHp 1 - fatigue 2 - defense
        public GearScreen()
        {
            Controls = new();
            talismanBox = GetGenericBox<ITalisman>("Talisman Slot");
            talismanBox.Location = new(70, 100);
            weaponBox = GetGenericBox<IWeapon>("WeaponSlot");
            weaponBox.Location = new(30, 170);
            statsTable = GetStatsPanel();
            statsTable.Location = new(200, 100);
            inventoryLayoutPanel = new TableLayoutPanel() { Size = new(280, 280), Location = new(400, 50) };
            inventoryLayoutPanel.RowStyles.Clear();
            inventoryLayoutPanel.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
            {
                inventoryLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65));
                inventoryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65));
            }
            var exit = GetExitButton();
            exit.Click += (s, e) => Interface.LoadScreen<ITavernScreen>();
            Controls.Add(inventoryLayoutPanel);
            Controls.Add(talismanBox);
            Controls.Add(weaponBox);
            Controls.Add(exit);
            Controls.Add(statsTable);
        }

        public void Update()
        {
            var playerGearSet = Game.CurrentGame.Player.GearSet;
            inventoryLayoutPanel.Controls.Clear();
            talismanBox.Artefact = playerGearSet.Talisman;
            weaponBox.Artefact = playerGearSet.Weapon;
            foreach (var item in playerGearSet.Inventory)
            {
                var picBox = CreatePictureBox(item);
                var toolTip = new ToolTip();
                toolTip.SetToolTip(picBox, item.Name);
                AddPictureBoxToInventoryTable(picBox);
            }
        }

        public virtual Button GetExitButton() => new Button()
        {
            Size = new(100, 40),
            Location = new(275, 390),
            BackColor = Color.DimGray,
            Text = "Back",
            ForeColor = Color.White,
        };

        public virtual TableLayoutPanel GetStatsPanel() 
        {
            var table = new TableLayoutPanel() {Size = new(200,0)};
            var statsType = typeof(Stats);
            var properties = statsType.GetProperties().ToArray();
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            for (int i = 0; i < 3 + properties.Length; i++)
            {
                var originalSize = table.Size;
                table.Size = new(originalSize.Width, originalSize.Width + 40);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            }
            table.Controls.Add(new Label() { Text = "Max HP - ", Size = new Size(200, 18) }, 0, 1);
            table.Controls.Add(new Label() { Text = "Max fatigue - ", Size = new Size(200, 18) }, 0, 2);
            table.Controls.Add(new Label() { Text = "Defense - ", Size = new Size(200, 18) }, 0, 3);
            for (int i = 3; i < 3 + properties.Length;i++)
                table.Controls.Add(new Label() { Text = properties[i - 3].Name + " - ", Size = new Size(200, 18) }, 0, i);
            return table;
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
                Game.CurrentGame.Player.GearSet.Inventory.Remove(artefactData);
                Game.CurrentGame.Player.GearSet.Inventory.Add(box.Artefact);
                var artefactProperty = type.GetProperties().Where(x => x.PropertyType == typeof(TArtefact)).First();
                data.Artefact = artefactProperty.GetValue(Game.CurrentGame.Player.GearSet) as TArtefact;
                artefactProperty.SetValue(Game.CurrentGame.Player.GearSet, artefactData as TArtefact);
                box.Artefact = artefactData;
            };
            return box;
        }
    }
}
