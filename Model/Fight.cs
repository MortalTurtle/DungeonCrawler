using DungeonCrawler.Controls;
using DungeonCrawler.Controls.FightActions;
using DungeonCrawler.Controls.TargetButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Model
{
    public class Fight
    {
        public Player Player { get; set; }
        public Creature Enemy { get; set; }
        public bool HasEnded { get; private set; }
        public Fight(Player player, Creature enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            TargetButton = DefaultTargetButton.Instance;
            Interface.UpdateInterfaceOnFightStart(player, enemy);
            HasEnded = false;
        }
        public ITargetButton TargetButton { get; set; }
        public IActionButton ActionButton { get; set; }
        public void EndTurn()
        {
            if (Enemy.MaxFatigue - Enemy.Fatigue >= Enemy.Weapon.AttackCost)
            {
                Enemy.Attack(Player);
            }
            else Enemy.Rest();
            if (ActionButton != null && !ActionButton.IsAbleToPerformAction())
            {
                Interface.Alert(ActionButton.FailMessage);
                ChangeActionButton(null, Color.White, Color.White);
                return;
            }
            PerformAction(TargetButton.Target);
            Player.UpdateOnEOT();
            Enemy.UpdateOnEOT();
            Interface.UpdateInterfaceOnEOT();
        }
        public void PerformAction( ActionTarget target)
        {
            if (target == ActionTarget.None || ActionButton == null)
                return;
            Creature targetCreature = target == ActionTarget.Self ? Player : Enemy;
            ActionButton.Action.Invoke(Player, targetCreature);
        }
        public void ChangeActionButton(IActionButton other, Color colorToChange, Color defaultBackColor)
        {
            var lastButton = ActionButton;
            if (lastButton == other)
            {
                Game.CurrentGame.CurrentFight.ActionButton = null;
                lastButton.Button.BackColor = defaultBackColor;
                return;
            }
            if (lastButton != null)
                lastButton.Button.BackColor = defaultBackColor;
            Game.CurrentGame.CurrentFight.ActionButton = other;
            if (other == null)
                return;
            other.Button.BackColor = colorToChange;
        }
    }
}
