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
using static Assets.Scripts.Enemy.MoveTerritores.MoveTerritoryProvider;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class PatrolState : TankState
    {
        protected MoveTerritoryProvider MoveTerritoryProvider;
        protected Vector3 CurrentMovePoint;
        protected MoveTerritory MoveTerritoryInProgress;
        protected NavMeshAgent Agent;
        protected EnemySO EnemySO;
        protected Animator Animator;
        protected int XParameter;
        protected int YParameter;
        protected Side Direction;
        public PatrolState(EnemyTank tankEnemy,
            TankStateMachine stateMachine,
            Animator animator,
            MoveTerritoryProvider moveTerritoryProvider,
            EnemySO enemySO)
            : base(tankEnemy, stateMachine)
        {
            MoveTerritoryProvider = moveTerritoryProvider;
            Agent = TankEnemy.Agent;
            EnemySO = enemySO;
            Animator = animator;
            XParameter = Animator.StringToHash("XS");
            YParameter = Animator.StringToHash("YS");
        }

        public override void Enter()
        {
            base.Enter();

            MoveTerritoryInProgress = MoveTerritoryProvider.GetRandomMoveTerritory(new MoveTerritoryIndex() { Jndex = 10, Index = 2 }, out Direction);
            CurrentMovePoint = MoveTerritoryInProgress.transform.position;
            //InitializeMovepoint();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Patroling();
        }

        protected virtual void Patroling()
        {
            Agent.destination = CurrentMovePoint;
            float distance = Vector3.Distance(TankEnemy.transform.position, CurrentMovePoint);
            Debug.Log(distance);
            if (distance < EnemySO.DistanceToChangePoint)
            {
                InitializeMovepoint();
            }
            AnimatePatrloing();
        }
        void AnimatePatrloing()
        {
            switch (Direction)
            {
                case Side.Left:
                    {
                        Animator.SetFloat(XParameter, -1);
                        Animator.SetFloat(YParameter, 0);
                        break;
                    }
                case Side.Right:
                    {
                        Animator.SetFloat(XParameter, 1);
                        Animator.SetFloat(YParameter, 0);
                        break;
                    }
                case Side.Up:
                    {
                        Animator.SetFloat(XParameter, 0);
                        Animator.SetFloat(YParameter, 1);
                        break;
                    }
                case Side.Down:
                    {
                        Animator.SetFloat(XParameter, 0);
                        Animator.SetFloat(YParameter, -1);
                        break;
                    }
            }

        }
        void InitializeMovepoint()
        {
            MoveTerritoryInProgress = MoveTerritoryProvider.GetRandomMoveTerritory(MoveTerritoryInProgress.MoveTerritoryIndex
                , out Direction);
            CurrentMovePoint = MoveTerritoryInProgress.transform.position;
        }
    }
}
