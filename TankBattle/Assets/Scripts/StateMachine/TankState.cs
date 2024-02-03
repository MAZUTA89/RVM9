using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public abstract class TankState
    {
        protected EnemyTank TankEnemy { get; set; }
        protected TankStateMachine StateMachine { get; set; }
        public TankState(EnemyTank tankEnemy, TankStateMachine stateMachine)
        {
            TankEnemy = tankEnemy;
            StateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            Debug.Log($"{this.GetType()} activated!");
        }
        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }
        public virtual void OnTriggerEnter(Collider other)
        {

        }
        public virtual void OnTriggerStay(Collider other)
        {

        }
        public virtual void OnTriggerExit(Collider other)
        {

        }
        public virtual void Exit()
        {
            Debug.Log($"{this.GetType()} exit!");
        }
    }
}
