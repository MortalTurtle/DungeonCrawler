using DungeonCrawler.Controls.FightActions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Controls.TargetButton
{
    public class DefaultTargetButton : ITargetButton
    {
        public static DefaultTargetButton Instance = new DefaultTargetButton();
        public Button Button => throw new NotImplementedException();
        public ActionTarget Target => ActionTarget.None;
    }
}
