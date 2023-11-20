using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public static class ControlsFactory
    {
        private static Button endTurnButton; 
        public static Button GetMainButton(Form form)
        {
            return new Button
            {
                AutoSize = true,
                Location = new Point(60, 200),
                Size = new Size(form.ClientSize.Width - 120, 60),
                Text = "YES",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
        }
        public static TextBox GetMainTextBox(Form form)
        {
            return new TextBox
            {
                Location = new Point(60, 200),
                Font = new Font(FontFamily.GenericSansSerif, 25),
            };
        }
        public static Label GetMainLabel(Form form)
        {
            return new Label
            {
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size(form.ClientSize.Width, 80),
                Text = "Start?",
                Font = new Font(FontFamily.GenericSansSerif, 30)
            };
        }

        public static Button GetEndTurnButton(Form form)
        {
            if (endTurnButton != null)
                return endTurnButton;
            else endTurnButton = new Button()
            {
                Location = new Point(form.ClientSize.Width / 2 - 50, form.ClientSize.Height - 25),
                Size = new Size(100, 25),
                Text = "End Turn",
                Font = new Font(FontFamily.GenericSansSerif, 11)
            };
            return endTurnButton;
        }

        public static Button GetAttackButton(Form form)
        {
            return new Button()
            {
                Font = new Font(FontFamily.GenericSansSerif, 9),
                Text = "Regular Attack",
                Location = new Point(30, form.ClientSize.Height - 25),
                Size = new Size(100, 25),
            };
        }
    }
}
