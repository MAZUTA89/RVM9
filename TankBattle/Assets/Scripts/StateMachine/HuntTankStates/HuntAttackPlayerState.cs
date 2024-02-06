using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class HuntAttackPlayerState : TankState
    {
        NavMeshAgent _agent;
        PlayerTankTerritory PlayerTankTerritory { get; set; }
        MoveTerritory _playerTerritory;
        EnemySO EnemySO { get; set; }

        bool _reachedPlayer;
        public HuntAttackPlayerState(EnemyTank tankEnemy, TankStateMachine stateMachine,
            PlayerTankTerritory playerTankTerritory,
            EnemySO enemySO) : base(tankEnemy, stateMachine)
        {
            _agent = tankEnemy.Agent;
            PlayerTankTerritory = playerTankTerritory;
            EnemySO = enemySO;
        }
        public override void Enter()
        {
            base.Enter();
            _playerTerritory = PlayerTankTerritory.Territory;
            _reachedPlayer = false;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(!TankEnemy.IsVeiw)
            {
                (TankEnemy as HuntTank).PatrolState.SetMoveTerritory(_playerTerritory);
                StateMachine.ChangeState((TankEnemy as HuntTank).PatrolState);
                return;
            }
            MoveToPlayer();
            TankEnemy.ShootingWithDelay();
        }

        void MoveToPlayer()
        {
            if (!_reachedPlayer)
            {
                _agent.destination = _playerTerritory.transform.position;
                if (Vector3.Distance(_playerTerritory.transform.position, TankEnemy.transform.position)
                    < EnemySO.DistanceToChangePoint)
                {
                    _reachedPlayer = true;
                }
            }
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
