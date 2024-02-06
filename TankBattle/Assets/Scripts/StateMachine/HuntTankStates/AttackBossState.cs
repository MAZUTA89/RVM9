using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class AttackBossState : TankState
    {
        NavMeshAgent _agent;
        public AttackBossState(EnemyTank tankEnemy, TankStateMachine stateMachine) : base(tankEnemy, stateMachine)
        {
            _agent = tankEnemy.Agent;
        }

        public override void Enter()
        {
            base.Enter();
            _agent.speed = 0f;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            TankEnemy.ShootingWithDelay();
        }
    }
}
