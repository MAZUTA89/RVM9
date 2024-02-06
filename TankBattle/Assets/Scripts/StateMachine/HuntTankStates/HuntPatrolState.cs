using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class HuntPatrolState : PatrolState
    {
        PlayerTankTerritory PlayerTankTerritory { get; set; }
        public HuntPatrolState(EnemyTank tankEnemy,
            TankStateMachine stateMachine,
            Animator animator,
            MoveTerritoryProvider moveTerritoryProvider,
            EnemySO enemySO,
            PlayerTankTerritory playerTankTerritory)
            : base(tankEnemy, stateMachine, animator,
                  moveTerritoryProvider, enemySO)
        {
            XParameterName = "XH";
            YParameterName = "YH";
            XParameter = Animator.StringToHash(XParameterName);
            YParameter = Animator.StringToHash(YParameterName);
            PlayerTankTerritory = playerTankTerritory;
        }

        protected override void Patroling()
        {
            base.Patroling();
            if(TankEnemy.IsVeiw)
            {
                StateMachine.ChangeState((TankEnemy as HuntTank).AttackPlayerState);
                return;
            }
        }

        public void SetMoveTerritory(MoveTerritory moveTerritory)
        {
            InitializeMovepoint(moveTerritory);
        }
    }
}