using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Enemy.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Enemy.StateMachine;
using UnityEngine;
using Zenject;
using Assets.Scripts.Player;

namespace Assets.Scripts.Enemy
{
    public class HuntTank : EnemyTank
    {
        public PlayerTankTerritory PlayerTankTerritory { get; private set; }
        public HuntPatrolState PatrolState { get; private set; }
        public HuntAttackPlayerState AttackPlayerState { get; private set;}
        [Inject]
        public void Construct(MoveTerritoryProvider moveTerritoryProvider, EnemySO enemySO,
            [Inject(Id = "BulletPrefab")] GameObject bulletPrefab,
            PlayerTankTerritory playerTankTerritory)
        {
            MoveTerritoryProvider = moveTerritoryProvider;
            EnemySO = enemySO;
            PlayerTankTerritory = playerTankTerritory;
            BulletPrefab = bulletPrefab;
        }
        public override void InitializeStateMachine()
        {
            TankStateMachine = new TankStateMachine();

            PatrolState = new HuntPatrolState(this, TankStateMachine, Animator,
                MoveTerritoryProvider, EnemySO, PlayerTankTerritory);

            AttackPlayerState = new HuntAttackPlayerState(this, TankStateMachine,
                PlayerTankTerritory, EnemySO);

            TankStateMachine.Initialize(PatrolState);
        }

        public override void OnStart()
        {
        }
    }
}
