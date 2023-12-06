using DungeonCrawler.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class FightScreen : IFightScreen
    {
        public List<Control> Controls { get; private set; }
        
        public List<IPLayerStatLabel> PlayerStatLabels { get; private set; }
        public List<IEnemyStatLabel> EnemyStatLabels { get; private set; }
        private IActionButton currentActionButton { get; set; }
        internal abstract Label ChosenActionCost { get; }
        public FightScreen()
        { }

        public void GenerateFightScreen(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player, Creature enemy)
        {
            Controls = new();
            PlayerStatLabels = new();
            EnemyStatLabels = new();
            GenerateControlButtonsLayout(sameThemeAttribute, defaultThemeTypes);
            GenerateStatLabels(sameThemeAttribute, defaultThemeTypes, player, enemy);
        }

        private void GenerateControlButtonsLayout(Type[] sameThemeAttribute, Type[] defaultThemeTypes)
        {
            var instances = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IBattleControlButton)))
                .Select(x => Activator.CreateInstance(x) as IBattleControlButton)
                .Concat(defaultThemeTypes.Where(x => x.GetInterfaces().Contains(typeof(IBattleControlButton)))
                .Select(x => Activator.CreateInstance(x) as IBattleControlButton))
                .ToArray();
            Controls.Add(ChosenActionCost);
            Controls.AddRange(instances.Select(x => x.Button));
        }

        public void ChangeActionButton(IActionButton other, Color colorToChange, Color defaultBackColor)
        {
            var lastButton = currentActionButton;
            if (lastButton == other)
            {
                currentActionButton = null;
                ChosenActionCost.Text = "";
                lastButton.Button.BackColor = defaultBackColor;
                return;
            }
            if (lastButton != null)
                lastButton.Button.BackColor = lastButton.DefaultBackColor;
            if (other == null)
                return; 
            ChosenActionCost.Text = other.ActionCost < 0 ?
                other.ActionCost.ToString() : "+" + other.ActionCost.ToString();
            ChosenActionCost.Text += " Fatigue";
            currentActionButton = other;
            other.Button.BackColor = colorToChange;
        }

        public void GenerateStatLabels(Type[] sameThemeAttribute, Type[] defaultThemeTypes, Creature player, Creature enemy)
        {
            var types = sameThemeAttribute.Where(x => x.GetInterfaces().Contains(typeof(IStatLabel)))
                .Concat(defaultThemeTypes.Where(x => x.GetInterfaces().Contains(typeof(IStatLabel))));
            var playerStatInstances = types.Where(x => x.GetInterfaces().Contains(typeof(IPLayerStatLabel)))
            .Select(x => Activator.CreateInstance(x) as IPLayerStatLabel).ToArray();
            var enemyStatInstances = types.Where(x => x.GetInterfaces().Contains(typeof(IEnemyStatLabel)))
            .Select(x => Activator.CreateInstance(x) as IEnemyStatLabel).ToArray();
            foreach (var instance in enemyStatInstances)
            {
                instance.Update(enemy);
                Controls.Add(instance.Label);
            }
            foreach (var instance in playerStatInstances)
            {
                instance.Update(player);
                Controls.Add(instance.Label);
            }
            PlayerStatLabels.AddRange(playerStatInstances);
            EnemyStatLabels.AddRange(enemyStatInstances);
        }

        public void Update()
        {
            foreach (var label in PlayerStatLabels)
                label.Update();
            foreach (var enemy in EnemyStatLabels)
                enemy.Update();
        }
    }
}
