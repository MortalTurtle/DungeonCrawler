using DungeonCrawler.Controls;
using DungeonCrawler.Controls.BattleLoggers;
using DungeonCrawler.Controls.FightActions;
using DungeonCrawler.Controls.TargetButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler.Model
{
    public class Battle
    {
        public Player Player { get; set; }
        public Creature Enemy { get; set; }
        public bool HasEnded { get; private set; }
        public Battle(Player player, Creature enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            TargetButton = DefaultTargetButton.Instance;
            Interface.UpdateInterfaceOnFightStart(player, enemy);
            Interface.ChangeActionButton(null, Color.White, Color.White);
            HasEnded = false;
            ActionCost = 0;
        }
        public ITargetButton TargetButton { get; set; }
        public int ActionCost { get; set; }
        public string ActionFailMessage { get; set; }
        public IBattleActionLogger PlayerActionLog { get; set; }
        public IBattleActionLogger EnemyActionLog { get; set; }
        public Action<Creature, Creature> ChosenAction { get; set; }
        private int turn = 1;
        public void EndTurn()
        {
            if (Player.MaxFatigue - Player.Fatigue < ActionCost)
            {
                Interface.Alert(ActionFailMessage);
                Interface.ChangeActionButton(null, Color.White, Color.White);
                return;
            }
            Interface.LogBattleAction(new TurnLogger(turn));
            if (Enemy.Stats.Initiative > Player.Stats.Initiative)
            {
                EnemyAction();
                PlayerAction();
            }
            else
            {
                PlayerAction();
                EnemyAction();
            }
            Player.UpdateOnEOT();
            Enemy.UpdateOnEOT();
            Interface.UpdateScreen();
            if (Player.HP == 0 || Enemy.HP == 0)
            {
               HasEnded = true;
               TargetButton.Button.BackColor = Color.White;
               Game.EndFight(Enemy.HP == 0 && Player.HP != 0);
            }
            else turn++;
        }

        private void EnemyAction()
        {
            if (Enemy.MaxFatigue - Enemy.Fatigue >= Enemy.Weapon.AttackCost)
                Enemy.Attack(Player);
            else
            {
                EnemyActionLog = new RestActionLogger() { Executant = Enemy };
                Enemy.Rest();
            }
            Interface.LogBattleAction(EnemyActionLog);
        }

        private void PlayerAction()
        {
            PerformAction(TargetButton.Target);
            Interface.LogBattleAction(PlayerActionLog);
        }

        private void PerformAction(ActionTarget target)
        {
            if (target == ActionTarget.None || ChosenAction == null)
            {
                PlayerActionLog = new RestActionLogger() { Executant = Player };
                Player.Rest();
            }
            Creature targetCreature = target == ActionTarget.Self ? Player : Enemy;
            ChosenAction(Player, targetCreature);
        }
    }
}
