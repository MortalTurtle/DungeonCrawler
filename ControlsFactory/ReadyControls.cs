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
        public static Button GetMainButton(Form form)
        {
            return new Button
            {
                Location = new Point((int)(form.ClientSize.Width * 0.085), (int)(form.ClientSize.Height * 0.4)), // 60 200
                Size = new Size((int)(form.ClientSize.Width * 0.82), (int)(form.ClientSize.Height * 0.12)),
                Text = "YES",
                Font = new Font(FontFamily.GenericSansSerif, 25)
            };
        }
        public static TextBox GetMainTextBox(Form form)
        {
            return new TextBox
            {
                Location = new Point((int)(form.ClientSize.Width * 0.085), (int)(form.ClientSize.Height * 0.4)), // 60 200
                Size = new Size((int)(form.ClientSize.Width * 0.82), (int)(form.ClientSize.Height * 0.26)), // form.ClientSize.Width - 120, 130
                Font = new Font(FontFamily.GenericSansSerif, 25),
            };
        }
        public static Label GetMainLabel(Form form)
        {
            return new Label
            {
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size(form.ClientSize.Width, (int)(form.ClientSize.Height * 0.16)),
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
                Location = new Point((int)(form.ClientSize.Width * 0.42), (int)(form.ClientSize.Height * 0.93)),
                Size = new Size((int)(form.ClientSize.Width * 0.143), (int)(form.ClientSize.Height * 0.06)), // 100 25
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
                Location = new Point((int)(form.ClientSize.Width * 0.043), (int)(form.ClientSize.Height * 0.95)), // 30, form.ClientSize.Height - 25
                Size = new Size((int)(form.ClientSize.Width * 0.143), (int)(form.ClientSize.Height * 0.05)), // 100 25
            };
        }
        public static Button GetTargetButton(Form form)
        {
            return new Button()
            {
                Font = new Font(FontFamily.GenericSansSerif, 9),
                Size = new Size((int)(form.ClientSize.Width * 0.143), (int)(form.ClientSize.Height * 0.05)),
            };
        }
    }
}
