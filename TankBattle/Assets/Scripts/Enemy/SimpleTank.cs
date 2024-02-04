using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Enemy.StateMachine;
using Assets.Scripts.Enemy.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Enemy
{
    public class SimpleTank : EnemyTank
    {
        public MoveTerritoryProvider MoveTerritoryProvider { get; private set; }
        public EnemySO EnemySO { get; private set; }
        public PatrolState PatrolState { get; private set; }
        [Inject]
        public void Construct(MoveTerritoryProvider moveTerritoryProvider, EnemySO enemySO)
        {
            MoveTerritoryProvider = moveTerritoryProvider;
            EnemySO = enemySO;
        }
        public override void InitializeStateMachine()
        {
            TankStateMachine = new TankStateMachine();

            MoveTerritoryProvider.Initialize();
            //StartCoroutine(MoveTerritoryProvider.DeleteObjectsWithDelay());

            PatrolState = new SimplePatrolState(this, TankStateMachine, Animator, MoveTerritoryProvider, EnemySO);

            TankStateMachine.Initialize(PatrolState);
        }

        public override void OnStart()
        {
        }
    }
}
