using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Enemy.StateMachine;
using Assets.Scripts.Enemy.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy
{
    public class SimpleTank : EnemyTank
    {
        public PatrolState PatrolState { get; private set; }
        [Inject]
        public void Construct(MoveTerritoryProvider moveTerritoryProvider, EnemySO enemySO,
            [Inject(Id = "BulletPrefab")] GameObject bulletPrefab)
        {
            MoveTerritoryProvider = moveTerritoryProvider;
            EnemySO = enemySO;
            BulletPrefab = bulletPrefab;
        }
        public override void InitializeStateMachine()
        {
            TankStateMachine = new TankStateMachine();

            PatrolState = new SimplePatrolState(this, TankStateMachine, Animator,
                MoveTerritoryProvider, EnemySO);

            //PatrolState.SetMoveTerritory(SpawnTerritory);

            TankStateMachine.Initialize(PatrolState);
        }

        public override void OnStart()
        {
        }
    }
}
