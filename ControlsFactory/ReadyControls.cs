using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public static class ReadyControls
    {
        private static Button endTurnButton; 
        public static Button GetMainButton()
        {
            return new Button
            {
                Location = new Point((int)(60), (int)(200)), // 60 200
                Size = new Size((int)(Interface.OriginalFormSize.Width * 0.82), (int)(Interface.OriginalFormSize.Height * 0.12)),
                Text = "YES",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
        }
        public static TextBox GetMainTextBox()
        {
            return new TextBox
            {
                Location = new Point(60, 200), // 60 200
                Size = new Size((int)(Interface.OriginalFormSize.Width * 0.82),130), // form.ClientSize.Width - 120, 130
                Font = new Font(FontFamily.GenericSansSerif, 25),
            };
        }
        public static Label GetMainLabel()
        {
            return new Label
            {
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size(Interface.OriginalFormSize.Width, (int)(Interface.OriginalFormSize.Height * 0.16)),
                Text = "Start?",
                Font = new Font(FontFamily.GenericSansSerif, 30)
            };
        }
        public static Button GetEndTurnButton()
        {
            if (endTurnButton != null)
                return endTurnButton;
            else endTurnButton = new Button()
            {
                Location = new Point((int)(Interface.OriginalFormSize.Width * 0.42), (int)(Interface.OriginalFormSize.Height * 0.85)),
                Size = new Size(100,25), // 100 25
                Text = "End Turn",
                Font = new Font(FontFamily.GenericSansSerif, 11)
            };
            return endTurnButton;
        }
        public static Button GetAttackButton()
        {
            return new Button()
            {
                Font = new Font(FontFamily.GenericSansSerif, 9),
                Text = "Regular Attack",
                Location = new Point(30, 435),
                Size = new Size(100, 25),
            };
        }
        public static Button GetTargetButton()
        {
            return new Button()
            {
                Font = new Font(FontFamily.GenericSansSerif, 9),
                Size = new Size(100, (int)(25)),
            };
        }
    }
}
