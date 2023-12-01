using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class ControlsFactory<TControl>
        where TControl : Control, new()
    {
        private TControl control = new TControl();
        public Control Create()
        {
            return control;
        }

        public ControlsFactory<TControl> At(Point p)
        {
            control.Location = p;
            return this;
        }
        public ControlsFactory<TControl> WithText(string text)
        {
            control.Text = text;
            return this;
        }
        public ControlsFactory<TControl> WithSize(Size size)
        {
            control.Size = size;
            return this;
        }
        public ControlsFactory<TControl> WithFond(Font font)
        {
            control.Font = font;
            return this;
        }
        public ControlsFactory<TControl> WithForeColor(Color color)
        {
            control.ForeColor = color;
            return this;
        }
        public ControlsFactory<TControl> WithBackColor(Color color)
        {
            control.BackColor = color;
            return this;
        }
    }
}
