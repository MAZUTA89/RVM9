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
using Assets.Scripts.Bullet;
using Assets.Scripts.Gun;
using Assets.Scripts.Player;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
        protected Side Direction;
        protected int XParameter;
        protected int YParameter;
        protected string XParameterName;
        protected string YParameterName;



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
            Agent.speed = EnemySO.Speed;
        }

        public override void Enter()
        {
            base.Enter();
            //InitializeMovepoint();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Patroling();
        }

        #region PatrolingRegion
        protected virtual void Patroling()
        {
            Agent.destination = CurrentMovePoint;
            float distance = Vector3.Distance(TankEnemy.transform.position, CurrentMovePoint);
            //Debug.Log(distance);
            if (distance < EnemySO.DistanceToChangePoint)
            {
                InitializeMovepoint(MoveTerritoryInProgress);
                //Debug.Log($"{Direction}");
            }
            AnimatePatrloingAndInitializeDirection();
        }
        void AnimatePatrloingAndInitializeDirection()
        {
            switch (Direction)
            {
                case Side.Left:
                    {
                        Animator.SetFloat(XParameter, -1);
                        Animator.SetFloat(YParameter, 0);
                        TankEnemy.NormalizedDirection = new Vector2(-1, 0);
                        break;
                    }
                case Side.Right:
                    {
                        Animator.SetFloat(XParameter, 1);
                        Animator.SetFloat(YParameter, 0);
                        TankEnemy.NormalizedDirection = new Vector2(1, 0);
                        break;
                    }
                case Side.Up:
                    {
                        Animator.SetFloat(XParameter, 0);
                        Animator.SetFloat(YParameter, 1);
                        TankEnemy.NormalizedDirection = new Vector2(0, 1);
                        break;
                    }
                case Side.Down:
                    {
                        Animator.SetFloat(XParameter, 0);
                        Animator.SetFloat(YParameter, -1);
                        TankEnemy.NormalizedDirection = new Vector2(0, -1);
                        break;
                    }
            }

        }
        protected void InitializeMovepoint(MoveTerritory reachedTerritory)
        {
            MoveTerritoryInProgress = MoveTerritoryProvider.
                GetRandomMoveTerritory(reachedTerritory.MoveTerritoryIndex
                ,out Direction);
            CurrentMovePoint = MoveTerritoryInProgress.transform.position;
        }
       
        #endregion
        public void SetMoveTerritory(MoveTerritory moveTerritory)
        {
            InitializeMovepoint(moveTerritory);
        }
        public void SetMoveTerritoryAndStartSide(MoveTerritory moveTerritory, Side side)
        {
            Direction = side;
            MoveTerritoryInProgress = MoveTerritoryProvider.
                GetMoveTerritory(moveTerritory.MoveTerritoryIndex
                , Direction);
            CurrentMovePoint = MoveTerritoryInProgress.transform.position;
        }

    }
}
