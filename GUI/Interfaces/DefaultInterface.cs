using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class DefaultInterface<TTheme> : AbstractInterface<TTheme>
        where TTheme : ITheme, new()
    {
        public DefaultInterface() : base()
        { }
    }
}
