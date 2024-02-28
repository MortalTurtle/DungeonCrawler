using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DungeonCrawler
{
    public abstract class GearScreen : IGearScreen
    {
        public List<Control> Controls { get; private set; }
        private readonly TableLayoutPanel inventoryLayoutPanel;
        private readonly PictureBoxWithArtefact talismanBox;
        private readonly PictureBoxWithArtefact weaponBox;
        private readonly TableLayoutPanel statsTable;
        private readonly Dictionary<PropertyInfo, Label> statPropertyToLabel = new();
        private readonly PropertyInfo[] statProperties = typeof(Stats).GetProperties().ToArray();
        private readonly ToolTip inventoryTT = new();
        public GearScreen()
        {
            Controls = new();
            talismanBox = GetGenericPlayerGearBox<ITalisman>();
            weaponBox = GetGenericPlayerGearBox<IWeapon>();
            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(talismanBox, "Talisman");
            ttip.SetToolTip(weaponBox, "Weapon");
            talismanBox.Location = new(70, 100);
            weaponBox.Location = new(30, 170);
            statsTable = GetStatsPanel();
            statsTable.Location = new(200, 100);
            inventoryLayoutPanel = new TableLayoutPanel() { Size = new(280, 280), Location = new(400, 50) };
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
                AddPictureBoxToInventoryTable(picBox);
            }
            UpdateStats();
        }

        private void UpdateStats()
        {
            foreach (var property in statProperties)
            {
                statPropertyToLabel[property].Text = property.Name + " - " + ((int)property.GetValue(Game.CurrentGame.Player.Stats));
            }
        }

        public virtual Button GetExitButton() => new()
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
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            for (int i = 0; i < statProperties.Length; i++)
            {
                var originalSize = table.Size;
                table.Size = new(originalSize.Width, originalSize.Width + 40);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            }
            for (int i = 0; i < statProperties.Length; i++)
            {
                var label = new Label() { Size = new Size(200, 18) };
                statPropertyToLabel.Add(statProperties[i], label);
                table.Controls.Add(label, 0, i);
            }
            return table;
        }

        private PictureBoxWithArtefact CreatePictureBox(IArtefact artefact)
        {
            var pic = new PictureBoxWithArtefact(artefact) { Size = new Size(60, 60), AllowDrop = true };
            inventoryTT.SetToolTip(pic, artefact.Name);
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

        private PictureBoxWithArtefact GetGenericPlayerGearBox<TArtefact>()
            where TArtefact : class, IArtefact
        {
            var box = new PictureBoxWithArtefact(new EmptyArtefact()) { Size = new Size(60, 60), AllowDrop = true };
            box.DragEnter += (sender, args) =>
            {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                var data = args.Data.GetData(typeof(PictureBoxWithArtefact)) as PictureBoxWithArtefact;
                if (data.Artefact is TArtefact)
                    args.Effect = DragDropEffects.Move;
                else args.Effect = DragDropEffects.None;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            };
            box.DragDrop += (sender, args) =>
            {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                var data = args.Data.GetData(typeof(PictureBoxWithArtefact)) as PictureBoxWithArtefact;
                var artefactData = data.Artefact;
                var type = typeof(IGearSet);
                Game.CurrentGame.Player.GearSet.Inventory.Remove(artefactData);
                Game.CurrentGame.Player.GearSet.Inventory.Add(box.Artefact);
                var artefactProperty = type.GetProperties().Where(x => x.PropertyType == typeof(TArtefact)).First();
                data.Artefact = artefactProperty.GetValue(Game.CurrentGame.Player.GearSet) as TArtefact;
                inventoryTT.SetToolTip(data, data.Artefact.Name);
                artefactProperty.SetValue(Game.CurrentGame.Player.GearSet, artefactData as TArtefact);
                box.Artefact = artefactData;
                UpdateStats();
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            };
            return box;
        }
    }
}
