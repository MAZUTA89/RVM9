using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Enemy.StateMachine;
using Assets.Scripts.Enemy.StateMachine.States;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class PatrolState : TankState
    {
        protected MoveTerritoryProvider MoveTerritoryProvider;
        protected Vector3 CurrentMovePoint;
        protected NavMeshAgent Agent;
        protected EnemySO EnemySO;
        public PatrolState(EnemyTank tankEnemy,
            TankStateMachine stateMachine,
            MoveTerritoryProvider moveTerritoryProvider,
            EnemySO enemySO)
            : base(tankEnemy, stateMachine)
        {
            MoveTerritoryProvider = moveTerritoryProvider;
            Agent = TankEnemy.Agent;
            EnemySO = enemySO;
        }

        public override void Enter()
        {
            base.Enter();
           InitializeMovepoint();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Patroling();
        }
        protected virtual void Patroling() 
        {
            Agent.destination = CurrentMovePoint;

            if(Agent.remainingDistance < EnemySO.DistanceToChangePoint)
            {
                InitializeMovepoint();
            }
        }
        void InitializeMovepoint()
        {
            CurrentMovePoint = MoveTerritoryProvider.GetRandomMoveTerritorypPosition();
        }
    }
}
