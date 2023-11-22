using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class AbstractTheme : ITheme
    {
        public Color MainColor { get; set; }
        public IHPBars HPBars { get; set; }
        public List<IControlButton> ControlButtons { get; set; }
        public Button MainButton { get; set; }
        public Button GameStartButton { get; set; }
        public Label MainLabel { get; set; }
        public TextBox MainTextBox { get; set; }
        public void EditForm(Form form)
        {
            throw new NotImplementedException();
        }
        public void GenerateMainButtons(Form form)
        {
            MainButton = ControlsFactory.GetMainButton(form);
            MainTextBox = ControlsFactory.GetMainTextBox(form);
            MainLabel = ControlsFactory.GetMainLabel(form);
            GameStartButton = new Button
            {
                Location = new Point(60, form.ClientSize.Height / 2 + 100),
                Size = new Size(form.ClientSize.Width - 120, 60),
                Text = "Confirm",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
            ControlButtons = GenerateControlButtonsLayout(form).Buttons;
            EditMainButtons();
        }
        public abstract IButtonLayout GenerateControlButtonsLayout(Form form);

        public abstract void EditMainButtons();
        public void GenerateHPBars(Player player, Creature enemy)
        {
            HPBars = new HPBars(player, enemy);
        }
    }
}
