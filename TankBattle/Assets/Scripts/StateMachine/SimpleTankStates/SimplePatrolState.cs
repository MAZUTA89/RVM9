using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemy.StateMachine;
using Assets.Scripts.Enemy.StateMachine.States;
using Assets.Scripts.Enemy.MoveTerritores;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class SimplePatrolState : PatrolState
    {
        public SimplePatrolState(EnemyTank tankEnemy, TankStateMachine stateMachine, Animator animator,
            MoveTerritoryProvider moveTerritoryProvider, EnemySO enemySO)
            : base(tankEnemy, stateMachine, animator, moveTerritoryProvider, enemySO)
        {
            XParameterName = "XS";
            YParameterName = "YS";
            XParameter = Animator.StringToHash(XParameterName);
            YParameter = Animator.StringToHash(YParameterName);
        }

        protected override void Patroling()
        {
            base.Patroling();
            TankEnemy.ShootingWithDelay();
        }
        
    }
}