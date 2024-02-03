using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Enemy.StateMachine.States;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class TankStateMachine
    {
        public TankState LastState { get; private set; }
        public TankState CurrentState { get; private set; }
        
        public void Initialize(TankState startState)
        {
            CurrentState = startState;
            LastState = CurrentState;
            CurrentState.Enter();
        }

        public void ChangeState(TankState newState)
        {
            CurrentState.Exit();
            LastState = CurrentState;
            CurrentState = newState;
            newState.Enter();
        }

        public void UpdateLoop()
        {
            CurrentState.LogicUpdate();
        }

        public void FixedUpdate()
        {
            CurrentState.PhysicsUpdate();
        }

        public void OnTriggerEnter(Collider other)
        {
            CurrentState.OnTriggerEnter(other);
        }

        public void OnTriggerStay(Collider other)
        {
            CurrentState.OnTriggerStay(other);
        }
        public void OnTriggerExit(Collider other)
        {
            CurrentState.OnTriggerExit(other);
        }
    }
}
